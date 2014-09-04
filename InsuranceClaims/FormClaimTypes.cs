using System;
using System.Windows.Forms;
using Insurance.Data;
using Insurance.Data.Model;

namespace InsuranceClaims
{
    public partial class FormClaimTypes : Form
    {
        #region Property

        private ClaimTypeInfo ClaimType { get; set; }
        #endregion

        #region private method
        private void Reset()
        {
            this.ClaimType = null;
            this.txtId.Text = string.Empty;
            this.txtName.Text = string.Empty;
        }
        private ClaimTypeInfo ConvertToClaimType(object o)
        {
            var ss = o.ToString().Split("-".ToCharArray());
            var obj = new ClaimTypeInfo {Id = ss[0], Name = ss[1],OldId = ss[0]};
            return obj;
        }
        private void BindClaimTypeList()
        {
            this.listBox_ClaimType.Items.Clear();
            foreach(var obj in GlobleVariables.ClaimTypes)
            {
                this.listBox_ClaimType.Items.Add(string.Format("{0}-{1}",obj.Id,obj.Name));
            }
        }
        #endregion

        #region CTOR
        public FormClaimTypes()
        {
            InitializeComponent();
            this.BindClaimTypeList();

            this.ClaimType = null;
        }
        
        #endregion

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            this.ClaimType = null;
            this.txtId.Text = string.Empty;
            this.txtName.Text = string.Empty;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if(this.listBox_ClaimType.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {
                var obj = this.ConvertToClaimType(this.listBox_ClaimType.SelectedItem);
                this.ClaimType = obj;
                this.txtId.Text = obj.Id;
                this.txtName.Text = obj.Name;

            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (this.listBox_ClaimType.SelectedItem == null)
            {
                MessageBox.Show("请先选择一条记录！");
            }
            else
            {

                var obj = this.ConvertToClaimType(this.listBox_ClaimType.SelectedItem);

                if(DataRepository.ClaimTypeProvider.Delete(obj.Id))
                {
                    GlobleVariables.ClaimTypes.Remove(obj);
                    this.BindClaimTypeList();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (this.ClaimType == null)
            {
                var obj = new ClaimTypeInfo();
                obj.OldId = obj.Id = this.txtId.Text.Trim();
                obj.Name = this.txtName.Text.Trim();

                if(GlobleVariables.ClaimTypes.Exists(item=>item.Name == obj.Name))
                {
                    MessageBox.Show("已经存在该名称的理赔类型！");
                    return;
                }
                if (GlobleVariables.ClaimTypes.Exists(item => item.Id == obj.Id))
                {
                    MessageBox.Show("已经存在该代码的理赔类型！");
                    return;
                }

                if (DataRepository.ClaimTypeProvider.Insert(obj))
                {
                    GlobleVariables.ClaimTypes.Add(obj);
                    this.Reset();

                    this.BindClaimTypeList();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
            else
            {
                var existsObj = GlobleVariables.ClaimTypes.Find(item => item.Id == this.txtId.Text.Trim());
                if (existsObj == null)
                {
                    existsObj = GlobleVariables.ClaimTypes.Find(item => item.Name == this.txtName.Text.Trim());
                    if (existsObj == null)
                    {
                        this.ClaimType.Id = this.txtId.Text.Trim();
                        this.ClaimType.Name = this.txtName.Text.Trim();
                        if (DataRepository.ClaimTypeProvider.Update(this.ClaimType))
                        {
                            var obj = GlobleVariables.ClaimTypes.Find(item => item.OldId == this.ClaimType.OldId);
                            obj.OldId = obj.Id = this.ClaimType.Id;
                            obj.Name = this.ClaimType.Name;

                            Reset();
                            this.BindClaimTypeList();
                        }
                        else
                        {
                            MessageBox.Show("保存失败！");
                        }
                    }
                    else
                    {
                        if (existsObj.Id == this.ClaimType.OldId)
                        {
                            this.ClaimType.Id = this.txtId.Text.Trim();
                            this.ClaimType.Name = this.txtName.Text.Trim();
                            if (DataRepository.ClaimTypeProvider.Update(this.ClaimType))
                            {
                                var obj = GlobleVariables.ClaimTypes.Find(item => item.OldId == this.ClaimType.OldId);
                                obj.OldId = obj.Id = this.ClaimType.Id;
                                obj.Name = this.ClaimType.Name;

                                Reset();
                                this.BindClaimTypeList();
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("已经存在该理赔类型名称！");
                        }
                        
                    }
                }
                else
                {
                    if (existsObj.Id == this.ClaimType.OldId)
                    {
                        existsObj = GlobleVariables.ClaimTypes.Find(item => item.Name == this.txtName.Text.Trim());
                        if (existsObj == null)
                        {
                            this.ClaimType.Id = this.txtId.Text.Trim();
                            this.ClaimType.Name = this.txtName.Text.Trim();
                            if (DataRepository.ClaimTypeProvider.Update(this.ClaimType))
                            {
                                var obj = GlobleVariables.ClaimTypes.Find(item => item.OldId == this.ClaimType.OldId);
                                obj.OldId = obj.Id = this.ClaimType.Id;
                                obj.Name = this.ClaimType.Name;

                                Reset();
                                this.BindClaimTypeList();
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                            }
                        }
                        else
                        {
                            if (existsObj.Id == this.ClaimType.OldId)
                            {
                                //do nothing.
                                //MessageBox.Show("Do Nothing.");
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
                    }
                }
                
            }
        }
    }
}
