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
    public partial class FormClaim : Form
    {
        #region Field

        private InsuranceInfo _insuranceInfo;
        #endregion

        public FormClaim()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
        public FormClaim(ClaimInfo obj):this()
        {
            this.Tag = obj;
            this.textBox_ClaimNo.Text = obj.ClaimNo;
            this.dateTimePicker_ClaimDate.Value = obj.ClaimDate;
            this.textBox_Remark.Text = obj.Remark;
        }
        public FormClaim(InsuranceInfo obj):this()
        {
            this._insuranceInfo = obj;

        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if(this.Tag == null)//Insert
            {
                var existsObj = GlobleVariables.Claims.Find(item => item.ClaimNo == this.textBox_ClaimNo.Text);
                if (existsObj == null)
                {
                    var claimInfo = new ClaimInfo();
                    claimInfo.ClaimNo = this.textBox_ClaimNo.Text;
                    claimInfo.Remark = this.textBox_Remark.Text;
                    claimInfo.ClaimDate = this.dateTimePicker_ClaimDate.Value;
                    claimInfo.InsuranceId = this._insuranceInfo.Id;

                    if (DataRepository.ClaimProvider.Insert(claimInfo)>0)
                    {
                        GlobleVariables.Claims.Add(claimInfo);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
                }
                else
                {
                    MessageBox.Show("该理赔单已存在！");
                }
            }
            else//Update
            {
                var claimInfo = this.Tag as ClaimInfo;
                
                var existsObj = GlobleVariables.Claims.Find(item => item.ClaimNo == this.textBox_ClaimNo.Text);
                if(existsObj == null || existsObj.Id == claimInfo.Id)
                {
                    claimInfo.ClaimNo = this.textBox_ClaimNo.Text;
                    claimInfo.Remark = this.textBox_Remark.Text;
                    claimInfo.ClaimDate = this.dateTimePicker_ClaimDate.Value;
                    if (DataRepository.ClaimProvider.Update(claimInfo))
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
                    MessageBox.Show("该理赔单已存在！");
                }
            }
        }
    }
}
