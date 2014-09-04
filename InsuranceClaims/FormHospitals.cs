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
    public partial class FormHospitals : Form
    {
        #region Property

        private HospitalInfo Hospital { get; set; }
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
            this.Hospital = null;
            this.txtId.Text = string.Empty;
            this.txtName.Text = string.Empty;
        }
        private HospitalInfo ConvertToHospital(object o)
        {
            var ss = o.ToString().Split("-".ToCharArray());
            var obj = new HospitalInfo { Id = ss[0], Name = ss[1], OldId = ss[0] };
            return obj;
        }
        private void BindHospitalList()
        {
            this.listBox_Hospital.Items.Clear();
            foreach(var obj in GlobleVariables.Hospitals)
            {
                this.listBox_Hospital.Items.Add(string.Format("{0}-{1}",obj.Id,obj.Name));
            }
        }
        #endregion

        #region CTOR
        public FormHospitals()
        {
            InitializeComponent();
            this.BindHospitalList();

            this.Hospital = null;
        }
        
        #endregion

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            this.Hospital = null;
            this.txtId.Text = string.Empty;
            this.txtName.Text = string.Empty;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if(this.listBox_Hospital.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {
                var obj = this.ConvertToHospital(this.listBox_Hospital.SelectedItem);
                this.Hospital = obj;
                this.txtId.Text = obj.Id;
                this.txtName.Text = obj.Name;

            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (this.listBox_Hospital.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {

                var obj = this.ConvertToHospital(this.listBox_Hospital.SelectedItem);

                if(DataRepository.HospitalProvider.Delete(obj.Id))
                {
                    GlobleVariables.Hospitals.Remove(obj);
                    this.BindHospitalList();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (this.Hospital == null)
            {
                var obj = new HospitalInfo();
                obj.OldId = obj.Id = this.txtId.Text.Trim();
                obj.Name = this.txtName.Text.Trim();

                if(GlobleVariables.Hospitals.Exists(item=>item.Name == obj.Name))
                {
                    MessageBox.Show("已经存在该名称的医院！");
                    return;
                }
                if (GlobleVariables.Hospitals.Exists(item => item.Id == obj.Id))
                {
                    MessageBox.Show("已经存在该代码的医院！");
                    return;
                }

                if (DataRepository.HospitalProvider.Insert(obj))
                {
                    GlobleVariables.Hospitals.Add(obj);
                    this.Reset();

                    this.BindHospitalList();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                    return;
                }
            }
            else
            {
                var existsObj = GlobleVariables.Hospitals.Find(item => item.Id == this.txtId.Text.Trim());
                if (existsObj == null)
                {
                    existsObj = GlobleVariables.Hospitals.Find(item => item.Name == this.txtName.Text.Trim());
                    if (existsObj == null)
                    {
                        this.Hospital.Id = this.txtId.Text.Trim();
                        this.Hospital.Name = this.txtName.Text.Trim();
                        if (DataRepository.HospitalProvider.Update(this.Hospital))
                        {
                            var obj = GlobleVariables.Hospitals.Find(item => item.OldId == this.Hospital.OldId);
                            obj.OldId = obj.Id = this.Hospital.Id;
                            obj.Name = this.Hospital.Name;

                            Reset();
                            this.BindHospitalList();
                        }
                        else
                        {
                            MessageBox.Show("保存失败！");
                            return;
                        }
                    }
                    else
                    {
                        if (existsObj.Id == this.Hospital.OldId)
                        {
                            this.Hospital.Id = this.txtId.Text.Trim();
                            this.Hospital.Name = this.txtName.Text.Trim();
                            if (DataRepository.HospitalProvider.Update(this.Hospital))
                            {
                                var obj = GlobleVariables.Hospitals.Find(item => item.OldId == this.Hospital.OldId);
                                obj.OldId = obj.Id = this.Hospital.Id;
                                obj.Name = this.Hospital.Name;

                                Reset();
                                this.BindHospitalList();
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("已经存在该医院名称！");
                            return;
                        }
                        
                    }
                }
                else
                {
                    if (existsObj.Id == this.Hospital.OldId)
                    {
                        existsObj = GlobleVariables.Hospitals.Find(item => item.Name == this.txtName.Text.Trim());
                        if (existsObj == null)
                        {
                            this.Hospital.Id = this.txtId.Text.Trim();
                            this.Hospital.Name = this.txtName.Text.Trim();
                            if (DataRepository.HospitalProvider.Update(this.Hospital))
                            {
                                var obj = GlobleVariables.Hospitals.Find(item => item.OldId == this.Hospital.OldId);
                                obj.OldId = obj.Id = this.Hospital.Id;
                                obj.Name = this.Hospital.Name;

                                Reset();
                                this.BindHospitalList();
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                                return;
                            }
                        }
                        else
                        {
                            if (existsObj.Id == this.Hospital.OldId)
                            {
                                //do nothing.
                                MessageBox.Show("Do Nothing.");
                            }
                            else
                            {
                                MessageBox.Show("已经存在该名称的医院记录！");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("已经存在该医院代码的记录！");
                        return;
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
                    var objs = new List<HospitalInfo>();
                    using (var connection = new OleDbConnection(connectionString))
                    {
                        var command = new OleDbCommand(string.Format("Select * From [{0}]", sheetName), connection);
                        connection.Open();
                        var dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            var obj = new HospitalInfo();
                            obj.OldId = obj.Id = dr[0].ToString();
                            obj.Name = dr[1].ToString();

                            objs.Add(obj);
                        }
                    }

                    foreach (var obj in objs)
                    {
                        var hospital = GlobleVariables.Hospitals.Find(item => item.Id == obj.Id);
                        if (hospital == null)
                        {
                            DataRepository.HospitalProvider.Insert(obj);
                            GlobleVariables.Hospitals.Add(obj);
                        }
                        else
                        {
                            hospital.Name = obj.Name;
                            DataRepository.HospitalProvider.Update(obj);
                        }
                    }
                    this.BindHospitalList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
        }
    }
}
