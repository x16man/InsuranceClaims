using System;
using System.Windows.Forms;
using Insurance.Data;
using Insurance.Data.Model;
using InsuranceClaims.AppCode;


namespace InsuranceClaims
{
    public partial class FormInsurance : Form
    {
        #region private method
        private void BindCustomer()
        {
            this.comboBox_Customer.Items.Clear();
            foreach (var obj in GlobleVariables.Customers)
            {
                var item = new KeyValuePair(obj, obj.Name);
                this.comboBox_Customer.Items.Add(item);
            }
        }

        #endregion

        public FormInsurance()
        {
            InitializeComponent();

            this.BindCustomer();
        }
        public FormInsurance(CustomerInfo obj):this()
        {
            foreach (KeyValuePair item in this.comboBox_Customer.Items)
            {
                if ((item.Key as CustomerInfo).Id == obj.Id)
                {
                    this.comboBox_Customer.SelectedItem = item;
                    break;
                }
            }
        }
        public FormInsurance(InsuranceInfo obj):this()
        {
            this.Tag = obj;
            this.DialogResult = DialogResult.None;

            this.textBox_Code.Text = obj.Code;
            this.textBox_Remark.Text = obj.Remark;
            foreach(KeyValuePair item in this.comboBox_Customer.Items)
            {
                if((item.Key as CustomerInfo).Id == obj.CustomerId)
                {
                    this.comboBox_Customer.SelectedItem = item;
                    break;
                }
            }
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if(this.Tag == null)
            {
                var obj = new InsuranceInfo();
                obj.Code = this.textBox_Code.Text;
                obj.Remark = this.textBox_Remark.Text;
                obj.CustomerId = ((this.comboBox_Customer.SelectedItem as KeyValuePair).Key as CustomerInfo).Id;
                
                var objs = GlobleVariables.Insurances.FindAll(item => item.Code == obj.Code);
                if(objs.Count == 0)
                {
                    if (DataRepository.InsuranceProvider.Insert(obj) > 0)
                    {
                        GlobleVariables.Insurances.Add(obj);
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
                    MessageBox.Show("已经存在该保单！");
                }
            }
            else
            {
                var obj = this.Tag as InsuranceInfo;
                obj.Code = this.textBox_Code.Text;
                obj.Remark = this.textBox_Remark.Text;
                obj.CustomerId = ((this.comboBox_Customer.SelectedItem as KeyValuePair).Key as CustomerInfo).Id;
                
                var exitsObj = GlobleVariables.Insurances.Find(item => item.Code == obj.Code);
                if(exitsObj == null)
                {
                    if(DataRepository.InsuranceProvider.Update(obj))
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
                        if (DataRepository.InsuranceProvider.Update(obj))
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
                        MessageBox.Show("已经存在该保单！");
                    }
                }
            }
        }
    }
}
