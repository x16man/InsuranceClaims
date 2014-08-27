using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Insurance.Data.Model;
using Insurance.Data;
namespace InsuranceClaims
{
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }
        public FormCustomer(CustomerInfo obj):this()
        {
            this.Tag = obj;
            this.textBox_Name.Text = obj.Name;
            this.textBox_Address.Text = obj.Address;
            this.textBox_Remark.Text = obj.Remark;
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if(this.Tag == null)
            {
                var obj = new CustomerInfo();
                obj.Name = this.textBox_Name.Text.Trim();
                obj.Address = this.textBox_Address.Text.Trim();
                obj.Remark = this.textBox_Remark.Text.Trim();
                obj.CategoryId = 0;
                var objs = GlobleVariables.Customers.FindAll(item => item.Name == obj.Name);
                if(objs.Count == 0)
                {
                    if (DataRepository.CustomerProvider.Insert(obj) > 0)
                    {
                        GlobleVariables.Customers.Add(obj);
                        this.DialogResult = DialogResult.OK;
                        this.Tag = obj;
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }    
                }
                else
                {
                    MessageBox.Show("已经存在该客户！");
                }
            }
            else
            {
                var obj = this.Tag as CustomerInfo;
                obj.Name = this.textBox_Name.Text.Trim();
                obj.Address = this.textBox_Address.Text.Trim();
                obj.Remark = this.textBox_Remark.Text.Trim();
                obj.CategoryId = 0;
                var exitsObj = GlobleVariables.Customers.Find(item => item.Name == obj.Name);
                if(exitsObj == null)
                {
                    if(DataRepository.CustomerProvider.Update(obj))
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
                }
                else
                {
                    if(exitsObj.Id == obj.Id)
                    {
                        if (DataRepository.CustomerProvider.Update(obj))
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("保存失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("已经存在该客户！");
                    }
                }
            }
        }
    }
}
