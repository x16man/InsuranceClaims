using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
                this.listBox_InsuranceType.Items.Add(obj.Name);
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
            this.textBox_Name.Text = string.Empty;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if(this.listBox_InsuranceType.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {

                var obj =GlobleVariables.InsuranceTypes.Find(item=>item.Name== this.listBox_InsuranceType.SelectedItem.ToString());
                this.CurrentInsuranceType = obj;
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
                var obj = GlobleVariables.InsuranceTypes.Find(item=>item.Name == this.listBox_InsuranceType.SelectedItem.ToString());

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

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (this.CurrentInsuranceType == null)
            {
                var obj = new InsuranceTypeInfo();
                obj.Name = this.textBox_Name.Text.Trim();
                if(GlobleVariables.InsuranceTypes.Exists(item=>item.Name == this.textBox_Name.Text.Trim()))
                {
                    MessageBox.Show("已经存在该名称的险种！");
                    return;
                }
                if (DataRepository.InsuranceTypeProvider.Insert(obj) > 0)
                {
                    GlobleVariables.InsuranceTypes.Add(obj);
                    this.CurrentInsuranceType = null;
                    this.textBox_Name.Text = string.Empty;
                    

                    this.BindInsuranceTypeList();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
            else
            {
                if (GlobleVariables.InsuranceTypes.Exists(item => item.Name == this.textBox_Name.Text.Trim()))
                {
                    MessageBox.Show("已经存在该名称的险种！");
                    return;
                }
                this.CurrentInsuranceType.Name = this.textBox_Name.Text.Trim();
                if (DataRepository.InsuranceTypeProvider.Update(this.CurrentInsuranceType))
                {
                    this.CurrentInsuranceType = null;
                    this.textBox_Name.Text = string.Empty;
                    this.BindInsuranceTypeList();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
        }
    }
}
