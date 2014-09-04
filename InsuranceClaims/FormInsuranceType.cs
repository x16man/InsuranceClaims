using System;
using System.Windows.Forms;
using Insurance.Data;
using Insurance.Data.Model;

namespace InsuranceClaims
{
    public partial class FormInsuranceType : Form
    {
        #region Property

        private InsuranceTypeInfo CurrentInsuranceType { get; set; }
        #endregion

        #region private method
        private void BindInsuranceTypeList()
        {
            this.listBox_InsuranceType.Items.Clear();
            foreach(var obj in GlobleVariables.InsuranceTypes)
            {
                this.listBox_InsuranceType.Items.Add(string.Format("{0}-{1}",obj.Code,obj.Name));
            }
        }
        #endregion

        #region CTOR
        public FormInsuranceType()
        {
            InitializeComponent();
            this.BindInsuranceTypeList();

            this.CurrentInsuranceType = null;
        }
        
        #endregion

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            this.CurrentInsuranceType = null;
            this.txtCode.Text =this.textBox_Name.Text = string.Empty;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if(this.listBox_InsuranceType.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {
                var s = this.listBox_InsuranceType.SelectedItem.ToString().Split("-".ToCharArray());
                var code = s[0];
                var name = s[1];
                var obj =GlobleVariables.InsuranceTypes.Find(item=>item.Name== name && item.Code ==code);
                this.CurrentInsuranceType = obj;
                this.txtCode.Text = obj.Code;
                this.textBox_Name.Text = obj.Name;

            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (this.listBox_InsuranceType.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {
                var s = this.listBox_InsuranceType.SelectedItem.ToString().Split("-".ToCharArray());
                var code = s[0];
                var name = s[1];
                var obj = GlobleVariables.InsuranceTypes.Find(item => item.Name == name && item.Code == code);

                if(DataRepository.InsuranceTypeProvider.Delete(obj))
                {
                    GlobleVariables.InsuranceTypes.Remove(obj);
                    this.BindInsuranceTypeList();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }
        private void Insert(InsuranceTypeInfo obj)
        {
            if (DataRepository.InsuranceTypeProvider.Insert(obj) > 0)
            {
                GlobleVariables.InsuranceTypes.Add(obj);
                this.CurrentInsuranceType = null;
                this.textBox_Name.Text = string.Empty;
                this.txtCode.Text = string.Empty;

                this.BindInsuranceTypeList();
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }
        private void Update(InsuranceTypeInfo obj)
        {
            if (DataRepository.InsuranceTypeProvider.Update(obj))
            {
                this.CurrentInsuranceType = null;
                this.textBox_Name.Text = string.Empty;
                this.txtCode.Text = string.Empty;

                this.BindInsuranceTypeList();
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            if (this.CurrentInsuranceType == null)
            {
                var obj = new InsuranceTypeInfo();
                obj.Name = this.textBox_Name.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();

                var a = GlobleVariables.InsuranceTypes.Find(item => item.Code == obj.Code);
                var b = GlobleVariables.InsuranceTypes.Find(item => item.Name == obj.Name);
                if (a == null && b== null)
                {
                    this.Insert(obj);
                }
                else
                {
                    MessageBox.Show("已经存在该代码或名称的责任险种！");
                }
            }
            else
            {
                this.CurrentInsuranceType.Code = this.txtCode.Text.Trim();
                this.CurrentInsuranceType.Name = this.textBox_Name.Text.Trim();

                var a = GlobleVariables.InsuranceTypes.Find(item => item.Code == this.CurrentInsuranceType.Code);
                var b = GlobleVariables.InsuranceTypes.Find(item => item.Name == this.CurrentInsuranceType.Name);

                if (a == null && b == null)
                {
                    this.Update(this.CurrentInsuranceType);
                }
                else if(a==null && b!= null)
                {
                    if (b.Id == this.CurrentInsuranceType.Id)
                    {
                        this.Update(this.CurrentInsuranceType);
                    }
                    else
                    {
                        MessageBox.Show("已经存在该名称的责任险种!");
                    }
                }
                else if (a != null && b == null)
                {
                    if (a.Id == this.CurrentInsuranceType.Id)
                    {
                        this.Update(this.CurrentInsuranceType);
                    }
                    else
                    {
                        MessageBox.Show("已经存在该代码的责任险种!");
                        
                    }
                }
                else if (a != null && b != null)
                {
                    if (a.Id == this.CurrentInsuranceType.Id && b.Id == this.CurrentInsuranceType.Id)
                    {
                        this.Update();
                    }
                    else
                    {
                        MessageBox.Show("已经存在该代码或名称的责任险种!");
                    }
                }
                
                
                
            }
        }
    }
}
