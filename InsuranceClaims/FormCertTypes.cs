using System;
using System.Windows.Forms;
using Insurance.Data;
using Insurance.Data.Model;

namespace InsuranceClaims
{
    public partial class FormCertTypes : Form
    {
        #region Property

        private CertTypeInfo CertType { get; set; }
        #endregion

        #region private method
        private void Reset()
        {
            this.CertType = null;
            this.txtId.Text = string.Empty;
            this.txtName.Text = string.Empty;
        }
        private CertTypeInfo ConvertToCertType(object o)
        {
            var ss = o.ToString().Split("-".ToCharArray());
            var obj = new CertTypeInfo {Id = ss[0], Name = ss[1],OldId = ss[0]};
            return obj;
        }
        private void BindCertTypeList()
        {
            this.listBox_CertType.Items.Clear();
            foreach(var obj in GlobleVariables.CertTypes)
            {
                this.listBox_CertType.Items.Add(string.Format("{0}-{1}",obj.Id,obj.Name));
            }
        }
        #endregion

        #region CTOR
        public FormCertTypes()
        {
            InitializeComponent();
            this.BindCertTypeList();

            this.CertType = null;
        }
        
        #endregion

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            this.CertType = null;
            this.txtId.Text = string.Empty;
            this.txtName.Text = string.Empty;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if(this.listBox_CertType.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {
                var obj = this.ConvertToCertType(this.listBox_CertType.SelectedItem);
                this.CertType = obj;
                this.txtId.Text = obj.Id;
                this.txtName.Text = obj.Name;

            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (this.listBox_CertType.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {

                var obj = this.ConvertToCertType(this.listBox_CertType.SelectedItem);

                if(DataRepository.CertTypeProvider.Delete(obj.Id))
                {
                    GlobleVariables.CertTypes.Remove(obj);
                    this.BindCertTypeList();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (this.CertType == null)
            {
                var obj = new CertTypeInfo();
                obj.OldId = obj.Id = this.txtId.Text.Trim();
                obj.Name = this.txtName.Text.Trim();

                if(GlobleVariables.CertTypes.Exists(item=>item.Name == obj.Name))
                {
                    MessageBox.Show("已经存在该名称的证件类型！");
                    return;
                }
                if (GlobleVariables.CertTypes.Exists(item => item.Id == obj.Id))
                {
                    MessageBox.Show("已经存在该代码的证件类型！");
                    return;
                }

                if (DataRepository.CertTypeProvider.Insert(obj))
                {
                    GlobleVariables.CertTypes.Add(obj);
                    this.Reset();

                    this.BindCertTypeList();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                    return;
                }
            }
            else
            {
                var existsObj = GlobleVariables.CertTypes.Find(item => item.Id == this.txtId.Text.Trim());
                if (existsObj == null)
                {
                    existsObj = GlobleVariables.CertTypes.Find(item => item.Name == this.txtName.Text.Trim());
                    if (existsObj == null)
                    {
                        this.CertType.Id = this.txtId.Text.Trim();
                        this.CertType.Name = this.txtName.Text.Trim();
                        if (DataRepository.CertTypeProvider.Update(this.CertType))
                        {
                            var obj = GlobleVariables.CertTypes.Find(item => item.OldId == this.CertType.OldId);
                            obj.OldId = obj.Id = this.CertType.Id;
                            obj.Name = this.CertType.Name;

                            Reset();
                            this.BindCertTypeList();
                        }
                        else
                        {
                            MessageBox.Show("保存失败！");
                            return;
                        }
                    }
                    else
                    {
                        if (existsObj.Id == this.CertType.OldId)
                        {
                            this.CertType.Id = this.txtId.Text.Trim();
                            this.CertType.Name = this.txtName.Text.Trim();
                            if (DataRepository.CertTypeProvider.Update(this.CertType))
                            {
                                var obj = GlobleVariables.CertTypes.Find(item => item.OldId == this.CertType.OldId);
                                obj.OldId = obj.Id = this.CertType.Id;
                                obj.Name = this.CertType.Name;

                                Reset();
                                this.BindCertTypeList();
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("已经存在该证件类型名称！");
                            return;
                        }
                        
                    }
                }
                else
                {
                    if (existsObj.Id == this.CertType.OldId)
                    {
                        existsObj = GlobleVariables.CertTypes.Find(item => item.Name == this.txtName.Text.Trim());
                        if (existsObj == null)
                        {
                            this.CertType.Id = this.txtId.Text.Trim();
                            this.CertType.Name = this.txtName.Text.Trim();
                            if (DataRepository.CertTypeProvider.Update(this.CertType))
                            {
                                var obj = GlobleVariables.CertTypes.Find(item => item.OldId == this.CertType.OldId);
                                obj.OldId = obj.Id = this.CertType.Id;
                                obj.Name = this.CertType.Name;

                                Reset();
                                this.BindCertTypeList();
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                                return;
                            }
                        }
                        else
                        {
                            if (existsObj.Id == this.CertType.OldId)
                            {
                                //do nothing.
                                MessageBox.Show("Do Nothing.");
                            }
                            else
                            {
                                MessageBox.Show("已经存在该名称的证件类型记录！");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("已经存在该证件类型代码的记录！");
                        return;
                    }
                }
                
            }
        }
    }
}
