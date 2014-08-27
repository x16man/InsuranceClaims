﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Insurance.Data;
using Insurance.Data.Model;
using Timer = System.Windows.Forms.Timer;
using Shmzh.Components.Util;

namespace InsuranceClaims
{
    public partial class FormMain : Form
    {
        #region Field
        private System.Timers.Timer DragOverTimer = new System.Timers.Timer();
        private TreeNode DragOverNode;
        private ToolStripTextBox toolStripStatusTextBox_Location;
        #endregion
        #region private method
        private void CreateTree()
        {
            this.treeView_CustomerInsurance.Nodes.Clear();

            foreach(var customer in GlobleVariables.Customers)
            {
                var node = new TreeNode();
                node.Tag = customer;
                node.Text = customer.Name;
                node.ToolTipText = customer.Remark;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                this.treeView_CustomerInsurance.Nodes.Add(node);
                var objs = GlobleVariables.Insurances.FindAll(item => item.CustomerId == customer.Id);
                foreach(var obj in objs)
                {
                    var insuranceNode = new TreeNode();
                    insuranceNode.Tag = obj;
                    insuranceNode.Text = obj.Code;
                    insuranceNode.ToolTipText = obj.Remark;
                    insuranceNode.ImageIndex = 1;
                    insuranceNode.SelectedImageIndex = 4;
                    node.Nodes.Add(insuranceNode);
                }
            }
        }
        private void InitClaimListView()
        {
            this.listView_Claim.View = View.Details;
            this.listView_Claim.FullRowSelect = true;
            this.listView_Claim.Columns.Clear();
            this.listView_Claim.Columns.AddRange(new[]
                                                          {
                                                              //new ColumnHeader(){Text ="",TextAlign = HorizontalAlignment.Left,DisplayIndex = 0,Name ="Id",Width = 24,},
                                                              new ColumnHeader(){Text ="理赔单号",TextAlign = HorizontalAlignment.Left,DisplayIndex = 2,Name ="ClaimNo",Width = 200,},
                                                              new ColumnHeader(){Text ="客户",TextAlign = HorizontalAlignment.Left,DisplayIndex = 1,Name ="Customer",Width = 200,},
                                                              new ColumnHeader(){Text = "所属保单号",TextAlign = HorizontalAlignment.Left,DisplayIndex = 3,Name ="Code",Width = 120}, 
                                                              new ColumnHeader(){Text ="理赔日期",TextAlign = HorizontalAlignment.Center,DisplayIndex = 3,Name = "ClaimDate",Width = 120,}, 
                                                              new ColumnHeader(){Text = "理赔总金额",TextAlign = HorizontalAlignment.Right,DisplayIndex = 4,Name = "SubTotal",Width = 120,}, 
                                                              new ColumnHeader(){Text="备注",TextAlign = HorizontalAlignment.Left,DisplayIndex = 5,Name = "Remark",Width = 200,}, 
                                                          });
        }
        private void BindClaimList(InsuranceInfo insuranceInfo)
        {
            this.label_Title.Text = string.Empty;

            this.toolStripTextBox_SearchContent.ToolTipText = "输入理赔单号进行模糊查找";
            this.toolStripButton_Print.Enabled = false;
            this.listView_Claim.Items.Clear();
            if(insuranceInfo == null)
            {
                
            }
            else
            {
                this.listView_Claim.Tag = insuranceInfo;
                var customerInfo = GlobleVariables.Customers.Find(item => item.Id == insuranceInfo.CustomerId);
                
                //this.label_Title.Text = string.Format("{0} 保险单：{1}", customerInfo.Name,insuranceInfo.Code);
                
                var objs = GlobleVariables.Claims.FindAll(item => item.InsuranceId == insuranceInfo.Id);
                foreach (var claimInfo in objs)
                {
                    var item = new ListViewItem(claimInfo.ClaimNo, 2);
                    item.Tag = claimInfo;

                    //item.SubItems.Add(claimInfo.ClaimNo);
                    item.SubItems.Add(customerInfo.Name);
                    item.SubItems.Add(insuranceInfo.Code);
                    item.SubItems.Add(claimInfo.ClaimDate.ToShortDateString());
                    item.SubItems.Add(claimInfo.SubTotal.ToString());
                    item.SubItems.Add(claimInfo.Remark);
                    this.listView_Claim.Items.Add(item);
                }
            }
        }
        private void BindClaimList(InsuranceInfo insuranceInfo,string searchContent)
        {
            this.toolStripTextBox_SearchContent.ToolTipText = "输入理赔单号进行模糊查找";
            this.toolStripButton_Print.Enabled = false;

            this.listView_Claim.Items.Clear();
            if (insuranceInfo == null)
            {

            }
            else
            {
                this.listView_Claim.Tag = insuranceInfo;
                var customerInfo = GlobleVariables.Customers.Find(item => item.Id == insuranceInfo.CustomerId);

                var objs = GlobleVariables.Claims.FindAll(item => item.InsuranceId == insuranceInfo.Id);
                var filterObjs = objs.FindAll(item => item.ClaimNo.ToUpper().Contains(searchContent.ToUpper()));

                foreach (var claimInfo in filterObjs)
                {
                    var item = new ListViewItem(claimInfo.ClaimNo, 2);
                    item.Tag = claimInfo;

                    //item.SubItems.Add(claimInfo.ClaimNo);
                    item.SubItems.Add(customerInfo.Name);
                    item.SubItems.Add(insuranceInfo.Code);
                    item.SubItems.Add(claimInfo.ClaimDate.ToShortDateString());
                    item.SubItems.Add(claimInfo.SubTotal.ToString());
                    item.SubItems.Add(claimInfo.Remark);
                    this.listView_Claim.Items.Add(item);
                }
            }
        }
        private void InitClaimDetailListView()
        {
            this.listView_Claim.View = View.Details;
            this.listView_Claim.FullRowSelect = true;
            this.listView_Claim.Columns.Clear();
            this.listView_Claim.Columns.AddRange(new[]
                                                          {
                                                              //new ColumnHeader(){Text ="",TextAlign = HorizontalAlignment.Left,DisplayIndex = 0,Name ="Id",Width = 24,},
                                                              new ColumnHeader(){Text ="序号",TextAlign = HorizontalAlignment.Left,DisplayIndex = 1,Name ="Customer",Width = 60,},
                                                              new ColumnHeader(){Text = "工号",TextAlign = HorizontalAlignment.Left,DisplayIndex = 2,Name = "HRID",Width = 60,}, 
                                                              new ColumnHeader(){Text ="被保险人姓名",TextAlign = HorizontalAlignment.Left,DisplayIndex = 2,Name ="Name",Width = 120,},
                                                              new ColumnHeader(){Text ="连带信息",TextAlign = HorizontalAlignment.Left,DisplayIndex = 3,Name ="RelatedPerson",Width = 120,},
                                                              new ColumnHeader(){Text = "身份证号码",TextAlign = HorizontalAlignment.Left,DisplayIndex = 4,Name="PersonId",Width=120,}, 
                                                              new ColumnHeader(){Text="发票张数",TextAlign = HorizontalAlignment.Center,DisplayIndex = 5,Name = "InvoiceCount",Width = 120,}, 
                                                              new ColumnHeader(){Text ="责任内金额",TextAlign = HorizontalAlignment.Right,DisplayIndex = 6,Name = "ResponsibilityAmount",Width = 120,}, 
                                                              new ColumnHeader(){Text="给付金额",TextAlign = HorizontalAlignment.Right,DisplayIndex = 7,Name = "ClaimAmount",Width = 120}, 
                                                              new ColumnHeader(){Text = "投保险种",TextAlign = HorizontalAlignment.Center,DisplayIndex = 8,Name = "InsuranceTypeName",Width = 120,}, 
                                                              new ColumnHeader(){Text="备注",TextAlign = HorizontalAlignment.Left,DisplayIndex = 9,Name = "Remark",Width = 200}, 
                                                          });
        }
        private void BindClaimDetailList(ClaimInfo claimInfo)
        {
            this.toolStripTextBox_SearchContent.ToolTipText = "输入工号、姓名、身份证号码进行模糊查找";
            this.toolStripButton_Print.Enabled = true;
            this.listView_Claim.Items.Clear();
            this.listView_Claim.Tag = claimInfo;
            var objs = GlobleVariables.ClaimDetails.FindAll(item => item.ClaimId == claimInfo.Id);
            var insuranceInfo = GlobleVariables.Insurances.Find(item => item.Id == claimInfo.InsuranceId);
            var customerInfo = GlobleVariables.Customers.Find(item => item.Id == insuranceInfo.CustomerId);

            this.label_Title.Text = string.Format("{0} 保险单：{1} -> 理赔单：{2}", customerInfo.Name, insuranceInfo.Code, claimInfo.ClaimNo);
            foreach (var claimDetailInfo in objs)
            {
                var item = new ListViewItem(claimDetailInfo.SequenceNo.ToString(), 3);
                item.Tag = claimDetailInfo;
                //item.SubItems.Add(claimDetailInfo.SequenceNo.ToString());
                item.SubItems.Add(claimDetailInfo.HRID);
                item.SubItems.Add(claimDetailInfo.Name);
                item.SubItems.Add(claimDetailInfo.RelatedPerson);
                item.SubItems.Add(claimDetailInfo.PersonId);
                item.SubItems.Add(claimDetailInfo.InvoiceCount.ToString());
                item.SubItems.Add(claimDetailInfo.ResponsibilityAmount.ToString());
                item.SubItems.Add(claimDetailInfo.ClaimAmount.ToString());
                item.SubItems.Add(claimDetailInfo.InsuranceTypeName);
                item.SubItems.Add(claimDetailInfo.Remark);
                this.listView_Claim.Items.Add(item);
            }
        }
        private void BindClaimDetailList(ClaimInfo claimInfo,string searchContent)
        {
            this.toolStripTextBox_SearchContent.ToolTipText = "输入工号、姓名、身份证号码进行模糊查找";
            this.toolStripButton_Print.Enabled = true;
            this.toolStripTextBox_SearchContent.Enabled = true;
            this.listView_Claim.Items.Clear();
            this.listView_Claim.Tag = claimInfo;
            var objs = GlobleVariables.ClaimDetails.FindAll(item => item.ClaimId == claimInfo.Id);

            var filterObjs = objs.FindAll(item => item.PersonId.ToUpper() == searchContent.ToUpper() || item.HRID.Contains(searchContent.ToUpper()) || item.Name.ToUpper().Contains(searchContent.ToUpper()));
            if(filterObjs.Count == 0)
            {
                filterObjs = objs.FindAll(item => item.PersonId.ToUpper().Contains(searchContent.ToUpper()) || item.HRID.Contains(searchContent.ToUpper()) || item.Name.ToUpper().Contains(searchContent.ToUpper()));
            }
            
            var insuranceInfo = GlobleVariables.Insurances.Find(item => item.Id == claimInfo.InsuranceId);
            var customerInfo = GlobleVariables.Customers.Find(item => item.Id == insuranceInfo.CustomerId);

            this.label_Title.Text = string.Format("{0} 保险单：{1} -> 理赔单：{2}", customerInfo.Name, insuranceInfo.Code, claimInfo.ClaimNo);
            foreach (var claimDetailInfo in filterObjs)
            {
                var item = new ListViewItem(claimDetailInfo.SequenceNo.ToString(), 3);
                item.Tag = claimDetailInfo;
                //item.SubItems.Add(claimDetailInfo.SequenceNo.ToString());
                item.SubItems.Add(claimDetailInfo.HRID);
                item.SubItems.Add(claimDetailInfo.Name);
                item.SubItems.Add(claimDetailInfo.RelatedPerson);
                item.SubItems.Add(claimDetailInfo.PersonId);
                item.SubItems.Add(claimDetailInfo.InvoiceCount.ToString());
                item.SubItems.Add(claimDetailInfo.ResponsibilityAmount.ToString());
                item.SubItems.Add(claimDetailInfo.ClaimAmount.ToString());
                item.SubItems.Add(claimDetailInfo.InsuranceTypeName);
                item.SubItems.Add(claimDetailInfo.Remark);
                this.listView_Claim.Items.Add(item);
            }
        }
        
        #endregion

        #region private method
        private void AddCustomer(CustomerInfo obj)
        {
            var node = new TreeNode();
            node.Tag = obj;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            node.Text = obj.Name;
            node.ToolTipText = obj.Remark;
            this.treeView_CustomerInsurance.Nodes.Add(node);
        }
        private void EditCustomer(CustomerInfo obj)
        {
            foreach(TreeNode node in this.treeView_CustomerInsurance.Nodes)
            {
                var customerInfo = node.Tag as CustomerInfo;
                if(customerInfo.Id == obj.Id)
                {
                    node.Text = obj.Name;
                    node.ToolTipText = obj.Remark;
                    break;
                }
            }
        }
        private void AddInsurance(InsuranceInfo obj)
        {
            foreach (TreeNode node in this.treeView_CustomerInsurance.Nodes)
            {
                var customerInfo = node.Tag as CustomerInfo;
                if(customerInfo.Id == obj.CustomerId)
                {
                    var insuranceNode = new TreeNode();
                    insuranceNode.Tag = obj;
                    insuranceNode.ImageIndex = 1;
                    insuranceNode.SelectedImageIndex = 1;
                    insuranceNode.Text = obj.Code;
                    insuranceNode.ToolTipText = obj.Remark;
                    node.Nodes.Add(insuranceNode);
                    node.Expand();
                    break;
                }
            }
        }
        private void EditInsurance(InsuranceInfo obj)
        {
            if(this.treeView_CustomerInsurance.SelectedNode.Tag is InsuranceInfo)
            {
                var customerInfo = this.treeView_CustomerInsurance.SelectedNode.Parent.Tag as CustomerInfo;
                if(customerInfo.Id == obj.CustomerId)
                {
                    this.treeView_CustomerInsurance.SelectedNode.Tag = obj;
                    this.treeView_CustomerInsurance.SelectedNode.Text = obj.Code;
                    this.treeView_CustomerInsurance.SelectedNode.ToolTipText = obj.Remark;
                }
                else
                {
                    this.treeView_CustomerInsurance.SelectedNode.Remove();
                    foreach(TreeNode node in this.treeView_CustomerInsurance.Nodes)
                    {
                        customerInfo = node.Tag as CustomerInfo;
                        if(customerInfo.Id == obj.CustomerId)
                        {
                            var newNode = new TreeNode();
                            newNode.Tag = obj;
                            newNode.ImageIndex = 0;
                            newNode.SelectedImageIndex = 0;
                            newNode.Text = obj.Code;
                            newNode.ToolTipText = obj.Remark;
                            node.Nodes.Add(newNode);
                        }
                    }
                }
            }
        }

        private void AddLocationBoxToStatusStrip()
        {
            
        }
        #endregion

        public FormMain()
        {
            InitializeComponent();

            this.InitClaimListView();
            this.CreateTree();

            this.BindClaimList(null);

            this.DragOverTimer.Elapsed += new System.Timers.ElapsedEventHandler(DragOverTimer_Elapsed);
            this.DragOverTimer.Interval = 2000;

            //Add a textbox into the statusstrip.
            this.toolStripStatusTextBox_Location = new ToolStripTextBox();
            this.toolStripStatusTextBox_Location.Size = new Size(180, this.toolStripStatusTextBox_Location.Height - 2);
            this.toolStripStatusTextBox_Location.Margin = new Padding(2,3,2,2);
            this.toolStripStatusTextBox_Location.Enabled = true;
            this.toolStripStatusTextBox_Location.BorderStyle = BorderStyle.Fixed3D;
            this.toolStripStatusTextBox_Location.ToolTipText = "输入保单号进行模糊定位";
            this.toolStripStatusTextBox_Location.TextChanged += new EventHandler(toolStripStatusTextBox_Location_TextChanged);
            this.statusStrip_Main.Items.Insert(1, this.toolStripStatusTextBox_Location);
            this.toolStripStatusTextBox_Location.Width = 180;
            
        }

        private void treeView_CustomerInsurance_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag is InsuranceInfo)
            {
                var insuranceInfo = e.Node.Tag as InsuranceInfo;
                this.InitClaimListView();
                this.BindClaimList(insuranceInfo);
            }
        }

        private void listView_Claim_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = this.listView_Claim.GetItemAt(e.X, e.Y);
            if(item.Tag is ClaimInfo)
            {
                var claimInfo = item.Tag as ClaimInfo;
                this.InitClaimDetailListView();
                this.BindClaimDetailList(claimInfo);
            }
        }

        private void treeView_CustomerInsurance_MouseClick(object sender, MouseEventArgs e)
        {
            var item = this.treeView_CustomerInsurance.GetNodeAt(e.X, e.Y);
            if(e.Button == MouseButtons.Right)
            {
                if(item == null)
                {
                    this.toolStripMenuItem_EditCustomer.Enabled = false;
                    this.toolStripMenuItem_DeleteCustomer.Enabled = false;
                    this.toolStripMenuItem_AddInsurance.Enabled = false;
                    this.toolStripMenuItem_EditInsurance.Enabled = false;
                    this.toolStripMenuItem_DeleteInsurance.Enabled = false;
                }
                else
                {
                    this.treeView_CustomerInsurance.SelectedNode = item;
                    if(item.Tag is CustomerInfo)
                    {
                        this.toolStripButton_AddClaim.Enabled = false;
                        this.toolStripMenuItem_EditCustomer.Enabled = true;
                        this.toolStripMenuItem_DeleteCustomer.Enabled = true;

                        this.toolStripMenuItem_AddInsurance.Enabled = true;
                        this.toolStripMenuItem_EditInsurance.Enabled = false;
                        this.toolStripMenuItem_DeleteInsurance.Enabled = false;
                    }
                    else if(item.Tag is InsuranceInfo)
                    {
                        this.toolStripButton_AddClaim.Enabled = true;
                        this.toolStripMenuItem_EditCustomer.Enabled = false;
                        this.toolStripMenuItem_DeleteCustomer.Enabled = false;

                        this.toolStripMenuItem_AddInsurance.Enabled = false;
                        this.toolStripMenuItem_EditInsurance.Enabled = true;
                        this.toolStripMenuItem_DeleteInsurance.Enabled = true;
                    }
                }
            }
            else if(e.Button == MouseButtons.Left)
            {
                if(item == null)
                {
                    this.toolStripButton_AddClaim.Enabled = false;
                }
                else
                {
                    if (item.Tag is InsuranceInfo)
                    {
                        this.toolStripButton_AddClaim.Enabled = true;
                    }
                    else
                    {
                        this.toolStripButton_AddClaim.Enabled = false;
                    }
                }
            }
        }

        private void toolStripMenuItem_AddCustomer_Click(object sender, EventArgs e)
        {
            var form = new FormCustomer();
            if(form.ShowDialog()==DialogResult.OK)
            {
                this.AddCustomer(form.Tag as CustomerInfo);
                form.Close();
            }
        }

        private void toolStripMenuItem_EditCustomer_Click(object sender, EventArgs e)
        {
            var customerInfo = this.treeView_CustomerInsurance.SelectedNode.Tag as CustomerInfo;
            var form = new FormCustomer(customerInfo);
            if(form.ShowDialog()==DialogResult.OK)
            {
                this.EditCustomer(form.Tag as CustomerInfo);
                form.Close();
            }
        }

        private void toolStripMenuItem_DeleteCustomer_Click(object sender, EventArgs e)
        {
            var node = this.treeView_CustomerInsurance.SelectedNode;
            if (node.Tag is CustomerInfo)
            {
                var customerInfo = node.Tag as CustomerInfo;
                if (node.Nodes.Count > 0)
                {
                    MessageBox.Show("该客户下尚存保单记录，不能删除！");
                }
                else
                {
                    if (DataRepository.CustomerProvider.Delete(customerInfo))
                    {
                        GlobleVariables.Customers.Remove(customerInfo);
                        node.Remove();
                    }
                }
            }
        }

        private void toolStripMenuItem_AddInsurance_Click(object sender, EventArgs e)
        {
            var customerInfo = this.treeView_CustomerInsurance.SelectedNode.Tag as CustomerInfo;
            var form = new FormInsurance(customerInfo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.AddInsurance(form.Tag as InsuranceInfo);
                form.Close();
            }
        }

        private void toolStripMenuItem_EditInsurance_Click(object sender, EventArgs e)
        {
            var insuranceInfo = this.treeView_CustomerInsurance.SelectedNode.Tag as InsuranceInfo;
            var form = new FormInsurance(insuranceInfo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.EditInsurance(form.Tag as InsuranceInfo);
                form.Close();
            }
        }

        private void toolStripMenuItem_DeleteInsurance_Click(object sender, EventArgs e)
        {
            var node = this.treeView_CustomerInsurance.SelectedNode;
            if (node.Tag is InsuranceInfo)
            {
                var insuranceInfo = node.Tag as InsuranceInfo;
                if (GlobleVariables.Claims.FindAll(item => item.InsuranceId == insuranceInfo.Id).Count > 0)
                {
                    MessageBox.Show("该保单下尚存理赔记录，不能删除！");
                }
                else
                {
                    if (DataRepository.InsuranceProvider.Delete(insuranceInfo))
                    {
                        GlobleVariables.Insurances.Remove(insuranceInfo);
                        node.Remove();
                    }
                }
            }
        }

        private void treeView_CustomerInsurance_DragOver(object sender, DragEventArgs e)
        {
            var tgtPoint = this.treeView_CustomerInsurance.PointToClient(new Point(e.X, e.Y));
            var tgtNode = this.treeView_CustomerInsurance.GetNodeAt(tgtPoint);
            var srcNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            if (tgtNode != null && tgtNode.Tag is CustomerInfo && srcNode.Parent!=tgtNode && e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = e.AllowedEffect;
                this.treeView_CustomerInsurance.SelectedNode = tgtNode;

                if (DragOverNode == null || DragOverNode != tgtNode)
                {
                    DragOverNode = tgtNode;
                    if (!tgtNode.IsExpanded && tgtNode.Nodes.Count > 0)
                    {
                        if (this.DragOverTimer.Enabled)
                        {
                            this.DragOverTimer.Enabled = false;
                        }
                        this.DragOverTimer.Enabled = true;
                    }
                }
            }
        }

        void DragOverTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ThreadStart ts = () => this.DragOverNode.Expand();
            this.Invoke(ts);
            this.DragOverTimer.Stop();
        }
        
        private void treeView_CustomerInsurance_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var srcNode = e.Item as TreeNode;
                if (srcNode != null && srcNode.Tag is InsuranceInfo)
                    DoDragDrop(srcNode, DragDropEffects.Move);
            }
        }

        private void treeView_CustomerInsurance_DragDrop(object sender, DragEventArgs e)
        {
            var srcNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            #region Check SrcNode
            InsuranceInfo srcInsuranceInfo;
            if (srcNode == null)
            {
                MessageBox.Show("源节点为空！");
                return;
            }
            if (srcNode.Tag is InsuranceInfo)
            {
                srcInsuranceInfo = srcNode.Tag as InsuranceInfo;
            }
            else
            {
                MessageBox.Show("源节点不是保险单！");
                return;
            }
            var tgtPoint = this.treeView_CustomerInsurance.PointToClient(new Point(e.X, e.Y));
            var tgtNode = this.treeView_CustomerInsurance.GetNodeAt(tgtPoint);

            if (tgtNode != null && e.Data.GetDataPresent(typeof(TreeNode)))
            {
                var insuranceInfo = srcNode.Tag as InsuranceInfo;
                var customerInfo = tgtNode.Tag as CustomerInfo;
                if (customerInfo != null)
                {
                    insuranceInfo.CustomerId = customerInfo.Id;
                    if (DataRepository.InsuranceProvider.Update(insuranceInfo))
                    {
                        srcNode.Remove();
                        tgtNode.Nodes.Add(srcNode);
                    }
                }
            }
            
            #endregion
        }

        private void toolStripButton_AddClaim_Click(object sender, EventArgs e)
        {
            if(this.treeView_CustomerInsurance.SelectedNode==null)
            {
                MessageBox.Show("请先选择保险单！");
                return;
            }
            var insuranceInfo = this.treeView_CustomerInsurance.SelectedNode.Tag as InsuranceInfo;
            if(insuranceInfo == null)
            {
                MessageBox.Show("请先选择保险单！");
                return;
            }
            var form = new FormClaim(insuranceInfo);

            if(form.ShowDialog() == DialogResult.OK)
            {
                this.BindClaimList(insuranceInfo);
            }
        }

        private void toolStripButton_Import_Click(object sender, EventArgs e)
        {
            

        }

        private void listView_Claim_MouseDown(object sender, MouseEventArgs e)
        {
            //理赔明细记录列表。
            if (e.Button == MouseButtons.Right && this.listView_Claim.Tag != null && this.listView_Claim.Tag is ClaimInfo)
            {
                var p = this.listView_Claim.PointToClient(MousePosition);
                var item = this.listView_Claim.GetItemAt(p.X,p.Y);

                this.toolStripMenuItem_EditClaim.Visible = false;
                if (Clipboard.GetText() != string.Empty)
                {
                    this.toolStripMenuItem_Paste.Enabled = true;
                    this.toolStripMenuItem_Paste.Visible = true;
                }
                else
                {
                    this.toolStripMenuItem_Paste.Enabled = false;
                    this.toolStripMenuItem_Paste.Visible = false;
                }
                this.ToolStripMenuItem_Delete.Enabled = item != null;
                
                
            }
            else//理赔单列表。
            {
                this.toolStripMenuItem_Paste.Visible = false;
                this.toolStripMenuItem_EditClaim.Visible = true ;

                var p = this.listView_Claim.PointToClient(MousePosition);
                var item = this.listView_Claim.GetItemAt(p.X, p.Y);
                this.toolStripMenuItem_EditClaim.Enabled = item != null;
                this.ToolStripMenuItem_Delete.Enabled = item != null;
            }
        }

        private void toolStripMenuItem_Paste_Click(object sender, EventArgs e)
        {
            // 获取剪切板的内容，并按行分割  
            string pasteText = "";
            pasteText = Clipboard.GetText();
            pasteText = pasteText.Replace("\r\n", "|");
            pasteText = pasteText.Replace("\t", ",");

            if (string.IsNullOrEmpty(pasteText))
                return;
            var rows = pasteText.Split("|".ToCharArray());
            #region 检查数据格式。
            foreach (var s in rows)
            {
                if (string.IsNullOrEmpty(s))
                    continue;
                
                var cols = s.Split(",".ToCharArray());
                if (cols.Length < 9)
                {
                    MessageBox.Show(@"粘贴对象的格式不正确！
正确的格式为：
序号   工号 被保险人姓名   连带信息 身份证号    发票张数    责任内金额  给付金额    投保险种    备注");
                    return;
                }
            }
            for (var i=0;i<rows.Length;i++)
            {
                if(string.IsNullOrEmpty(rows[i]))
                    continue;
                var cols = rows[i].Split(",".ToCharArray());
                if (!StringUtil.IsNumeric(cols[0].Trim()))
                {
                    MessageBox.Show(string.Format("第{0}行数据的序号格式不正确，请确保序号不为空且为数字型！",i));
                    return;
                }
                if (!StringUtil.IsNumeric(cols[5].Trim()))
                {
                    MessageBox.Show(string.Format("第{0}行数据的发票张数格式不正确，请确保发票张数不为空且为数字型！", i));
                    return;
                }
                try
                {
                    decimal.Parse(cols[6].Trim());
                }
                catch
                {
                    MessageBox.Show(string.Format("第{0}行数据的责任内金额格式不正确，请确保责任内金额不为空且为数字型！", i));
                    return;                
                }
                try
                {
                    decimal.Parse(cols[7].Trim());
                }
                catch
                {
                    MessageBox.Show(string.Format("第{0}行数据的给付金额格式不正确，请确保给付金额不为空且为数字型！", i));
                    return;
                }
                if(!GlobleVariables.InsuranceTypes.Exists(item=>item.Name == cols[8].Trim()))
                {
                    MessageBox.Show(string.Format("第{0}行数据的投保险种没有找到，请先添加投保险种！",i));
                    return;
                }
            }
            #endregion
            #region 数据转换

            var claimInfo = this.listView_Claim.Tag as ClaimInfo;
            for (var i = 0; i < rows.Length; i++)
            {
                if(string.IsNullOrEmpty(rows[i]))
                    continue;
                var cols = rows[i].Split(",".ToCharArray());
                var obj = new ClaimDetailInfo();
                obj.ClaimId = claimInfo.Id;
                obj.SequenceNo = long.Parse(cols[0]);
                obj.HRID = cols[1];
                obj.Name = cols[2];
                obj.RelatedPerson = cols[3];
                obj.PersonId = cols[4];
                obj.InvoiceCount = string.IsNullOrEmpty(cols[5]) ? 0 : long.Parse(cols[5]);
                obj.ResponsibilityAmount = decimal.Parse(cols[6]);
                obj.ClaimAmount = decimal.Parse(cols[7]);
                obj.InsuranceTypeId = GlobleVariables.InsuranceTypes.Find(item => item.Name == cols[8].Trim()).Id;
                obj.InsuranceTypeName = cols[8].Trim();
                if (cols.Length == 10)
                    obj.Remark = cols[9].Trim();
                else
                    obj.Remark = string.Empty;

                if(DataRepository.ClaimDetailProvider.Insert(obj)>0)
                {
                    GlobleVariables.ClaimDetails.Add(obj);
                }
            }
            this.BindClaimDetailList(claimInfo);

            #endregion
            #region 重新计算理赔单总金额

            var objs = GlobleVariables.ClaimDetails.FindAll(item => item.ClaimId == claimInfo.Id);
            decimal subTotal = 0;
            foreach(var obj in objs)
            {
                subTotal += obj.ClaimAmount;
            }
            claimInfo.SubTotal = subTotal;
            if(!DataRepository.ClaimProvider.Update(claimInfo))
            {
                MessageBox.Show("更新理赔单总金额失败！");
            }

            #endregion

        }

        private void toolStripMenuItem_EditClaim_Click(object sender, EventArgs e)
        {
            if (this.listView_Claim.SelectedItems.Count > 0)
            {
                var claimInfo = this.listView_Claim.SelectedItems[0].Tag as ClaimInfo;
                var form = new FormClaim(claimInfo);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindClaimList(this.listView_Claim.Tag as InsuranceInfo);

                }
            }
        }

        private void toolStripButton_InsuranceType_Click(object sender, EventArgs e)
        {
            var form = new FormInsuranceType();
            form.Show();
        }

        private void listView_Claim_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Back && this.listView_Claim.Tag is ClaimInfo)
            {
                var obj = this.listView_Claim.Tag as ClaimInfo;
                var insuranceInfo = GlobleVariables.Insurances.Find(item => item.Id == obj.InsuranceId);
                this.InitClaimListView();
                this.BindClaimList(insuranceInfo);
            }
            else if (e.KeyCode == Keys.Enter && this.listView_Claim.Tag is InsuranceInfo && this.listView_Claim.SelectedItems.Count > 0)
            {
                var claimInfo = this.listView_Claim.SelectedItems[0].Tag as ClaimInfo;
                this.InitClaimDetailListView();
                this.BindClaimDetailList(claimInfo);
            }
            else if(e.KeyCode == Keys.Delete && this.listView_Claim.Tag is ClaimInfo && this.listView_Claim.SelectedItems.Count > 0)
            {
                if(MessageBox.Show("你确定要删除这些选中的记录吗？","确认",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    for(var i=this.listView_Claim.SelectedItems.Count-1;i>=0;i--)
                    {
                        var claimDetailInfo = this.listView_Claim.SelectedItems[i].Tag as ClaimDetailInfo;
                        if(DataRepository.ClaimDetailProvider.Delete(claimDetailInfo))
                        {
                            this.listView_Claim.Items.Remove(this.listView_Claim.SelectedItems[i]);
                            GlobleVariables.ClaimDetails.Remove(claimDetailInfo);
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                            break;
                        }
                    }
                    this.BindClaimDetailList(this.listView_Claim.Tag as ClaimInfo);
                    decimal subTotal = 0;
                    
                    var claimInfo = this.listView_Claim.Tag as ClaimInfo;
                    var objs = GlobleVariables.ClaimDetails.FindAll(item => item.ClaimId == claimInfo.Id);
                    foreach(var obj in objs)
                    {
                        subTotal += obj.ClaimAmount;
                    }
                    claimInfo.SubTotal = subTotal;
                    if(!DataRepository.ClaimProvider.Update(claimInfo))
                    {
                        MessageBox.Show("重新计算理赔单总金额失败！");
                    }
                }
                
            }
        }

        private void toolStripButton_Print_Click(object sender, EventArgs e)
        {
            if(this.listView_Claim.Tag is ClaimInfo)
            {
                var obj = this.listView_Claim.Tag as ClaimInfo;
                var form = new FormReport(obj);
                form.Show();
            }
        }

        private void toolStripButton_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                new FormAbout().ShowDialog();
            }
        }

        private void ToolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            if(this.listView_Claim.Tag is ClaimInfo && this.listView_Claim.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("你确定要删除这些选中的记录吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (var i = this.listView_Claim.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        var claimDetailInfo = this.listView_Claim.SelectedItems[i].Tag as ClaimDetailInfo;
                        if (DataRepository.ClaimDetailProvider.Delete(claimDetailInfo))
                        {
                            this.listView_Claim.Items.Remove(this.listView_Claim.SelectedItems[i]);
                            GlobleVariables.ClaimDetails.Remove(claimDetailInfo);
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                            break;
                        }
                    }
                    this.BindClaimDetailList(this.listView_Claim.Tag as ClaimInfo);
                    decimal subTotal = 0;

                    var claimInfo = this.listView_Claim.Tag as ClaimInfo;
                    var objs = GlobleVariables.ClaimDetails.FindAll(item => item.ClaimId == claimInfo.Id);
                    foreach (var obj in objs)
                    {
                        subTotal += obj.ClaimAmount;
                    }
                    claimInfo.SubTotal = subTotal;
                    if (!DataRepository.ClaimProvider.Update(claimInfo))
                    {
                        MessageBox.Show("重新计算理赔单总金额失败！");
                    }
                }
            }
            else if(this.listView_Claim.Tag is InsuranceInfo && this.listView_Claim.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("你确定要删除这些选中的记录吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (var i = this.listView_Claim.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        var claimInfo = this.listView_Claim.SelectedItems[i].Tag as ClaimInfo;
                        if (DataRepository.ClaimProvider.Delete(claimInfo))
                        {
                            this.listView_Claim.Items.Remove(this.listView_Claim.SelectedItems[i]);
                            GlobleVariables.Claims.Remove(claimInfo);
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                            break;
                        }
                    }
                }
            }
        }

        private void toolStripTextBox_SearchContent_TextChanged(object sender, EventArgs e)
        {
            if(this.listView_Claim.Tag is ClaimInfo)
            {
                var claimInfo = this.listView_Claim.Tag as ClaimInfo;
                this.BindClaimDetailList(claimInfo, this.toolStripTextBox_SearchContent.Text.Trim());
            }
            else
            {
                var insuranceInfo = this.listView_Claim.Tag as InsuranceInfo;
                this.BindClaimList(insuranceInfo,this.toolStripTextBox_SearchContent.Text.Trim());
            }
        }

        void toolStripStatusTextBox_Location_TextChanged(object sender, EventArgs e)
        {
            foreach(TreeNode customerNode in this.treeView_CustomerInsurance.Nodes)
            {
                foreach(TreeNode insuranceNode in customerNode.Nodes)
                {
                    if (insuranceNode.Text.ToUpper().StartsWith(this.toolStripStatusTextBox_Location.Text.ToUpper()))
                    {
                        this.treeView_CustomerInsurance.SelectedNode = insuranceNode;
                        var insuranceInfo = insuranceNode.Tag as InsuranceInfo;
                        this.InitClaimListView();
                        this.BindClaimList(insuranceInfo);
                        insuranceNode.Parent.Expand();
                        insuranceNode.EnsureVisible();
                        return;
                    }
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.toolStripStatusTextBox_Location.Focus();
        }
        
    }
}
