using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Insurance.Data;
using Insurance.Data.Model;

namespace InsuranceClaims
{
    public partial class FormBanks : Form
    {
        #region Property

        private BankInfo Bank { get; set; }
        #endregion

        #region private method
        private string GetConnectionString(string fileName)
        {
            var fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
            var connectionString = fileExtension.Equals(".xls", StringComparison.OrdinalIgnoreCase)
                                       ? string.Format(
                                           "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=1'",
                                           fileName)
                                       : string.Format(
                                           "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=1'",
                                           fileName);
            return connectionString;
        }
        private string[] GetExcelSheetNames(string fileName)
        {
            OleDbConnection objConn = null;
            DataTable dt = null;
            try
            {
                var conString = this.GetConnectionString(fileName);
                objConn = new OleDbConnection(conString);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                var excelSheets = new string[dt.Rows.Count];
                var i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }
                return excelSheets;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
        private void Reset()
        {
            this.Bank = null;
            this.txtId.Text = string.Empty;
            this.txtName.Text = string.Empty;
        }
        private BankInfo ConvertToBank(object o)
        {
            var ss = o.ToString().Split("-".ToCharArray());
            var obj = new BankInfo {Id = ss[0], Name = ss[1],OldId = ss[0]};
            return obj;
        }
        private void BindBankList()
        {
            this.listBox_Bank.Items.Clear();
            foreach(var obj in GlobleVariables.Banks)
            {
                this.listBox_Bank.Items.Add(string.Format("{0}-{1}",obj.Id,obj.Name));
            }
        }
        #endregion

        #region CTOR
        public FormBanks()
        {
            InitializeComponent();
            this.BindBankList();

            this.Bank = null;
        }
        
        #endregion

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            this.Bank = null;
            this.txtId.Text = string.Empty;
            this.txtName.Text = string.Empty;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if(this.listBox_Bank.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {
                var obj = this.ConvertToBank(this.listBox_Bank.SelectedItem);
                this.Bank = obj;
                this.txtId.Text = obj.Id;
                this.txtName.Text = obj.Name;

            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (this.listBox_Bank.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {

                var obj = this.ConvertToBank(this.listBox_Bank.SelectedItem);

                if(DataRepository.BankProvider.Delete(obj.Id))
                {
                    GlobleVariables.Banks.Remove(obj);
                    this.BindBankList();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (this.Bank == null)
            {
                var obj = new BankInfo();
                obj.OldId = obj.Id = this.txtId.Text.Trim();
                obj.Name = this.txtName.Text.Trim();

                if(GlobleVariables.Banks.Exists(item=>item.Name == obj.Name))
                {
                    MessageBox.Show("已经存在该名称的银行！");
                    return;
                }
                if (GlobleVariables.Banks.Exists(item => item.Id == obj.Id))
                {
                    MessageBox.Show("已经存在该代码的银行！");
                    return;
                }

                if (DataRepository.BankProvider.Insert(obj))
                {
                    GlobleVariables.Banks.Add(obj);
                    this.Reset();

                    this.BindBankList();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
            else
            {
                var existsObj = GlobleVariables.Banks.Find(item => item.Id == this.txtId.Text.Trim());
                if (existsObj == null)
                {
                    existsObj = GlobleVariables.Banks.Find(item => item.Name == this.txtName.Text.Trim());
                    if (existsObj == null)
                    {
                        this.Bank.Id = this.txtId.Text.Trim();
                        this.Bank.Name = this.txtName.Text.Trim();
                        if (DataRepository.BankProvider.Update(this.Bank))
                        {
                            var obj = GlobleVariables.Banks.Find(item => item.OldId == this.Bank.OldId);
                            obj.OldId = obj.Id = this.Bank.Id;
                            obj.Name = this.Bank.Name;

                            Reset();
                            this.BindBankList();
                        }
                        else
                        {
                            MessageBox.Show("保存失败！");
                        }
                    }
                    else
                    {
                        if (existsObj.Id == this.Bank.OldId)
                        {
                            this.Bank.Id = this.txtId.Text.Trim();
                            this.Bank.Name = this.txtName.Text.Trim();
                            if (DataRepository.BankProvider.Update(this.Bank))
                            {
                                var obj = GlobleVariables.Banks.Find(item => item.OldId == this.Bank.OldId);
                                obj.OldId = obj.Id = this.Bank.Id;
                                obj.Name = this.Bank.Name;

                                Reset();
                                this.BindBankList();
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("已经存在该银行名称！");
                        }
                        
                    }
                }
                else
                {
                    if (existsObj.Id == this.Bank.OldId)
                    {
                        existsObj = GlobleVariables.Banks.Find(item => item.Name == this.txtName.Text.Trim());
                        if (existsObj == null)
                        {
                            this.Bank.Id = this.txtId.Text.Trim();
                            this.Bank.Name = this.txtName.Text.Trim();
                            if (DataRepository.BankProvider.Update(this.Bank))
                            {
                                var obj = GlobleVariables.Banks.Find(item => item.OldId == this.Bank.OldId);
                                obj.OldId = obj.Id = this.Bank.Id;
                                obj.Name = this.Bank.Name;

                                Reset();
                                this.BindBankList();
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                            }
                        }
                        else
                        {
                            if (existsObj.Id == this.Bank.OldId)
                            {
                                //do nothing.
                                MessageBox.Show("Do Nothing.");
                            }
                            else
                            {
                                MessageBox.Show("已经存在该名称的银行记录！");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("已经存在该银行代码的记录！");
                    }
                }
                
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileName = this.openFileDialog1.FileName;
                    var connectionString = this.GetConnectionString(fileName);
                    var sheetName = this.GetExcelSheetNames(fileName)[0];
                    var objs = new List<BankInfo>();
                    using (var connection = new OleDbConnection(connectionString))
                    {
                        var command = new OleDbCommand(string.Format("Select * From [{0}]", sheetName), connection);
                        connection.Open();
                        var dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            var obj = new BankInfo();
                            obj.OldId = obj.Id = dr[0].ToString();
                            obj.Name = dr[1].ToString();

                            objs.Add(obj);
                        }
                    }

                    foreach (var obj in objs)
                    {
                        var hospital = GlobleVariables.Banks.Find(item => item.Id == obj.Id);
                        if (hospital == null)
                        {
                            DataRepository.BankProvider.Insert(obj);
                            GlobleVariables.Banks.Add(obj);
                        }
                        else
                        {
                            hospital.Name = obj.Name;
                            DataRepository.BankProvider.Update(obj);
                        }
                    }
                    this.BindBankList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
        }
    }
}
