namespace InsuranceClaims
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip_Main = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator_Exit = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip_Main = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_CustomerInsurance = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_TreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView_Claim = new System.Windows.Forms.ListView();
            this.contextMenuStrip_ListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label_Title = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_SearchContent = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMenuItem_AddCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DeleteCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddInsurance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditInsurance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DeleteInsurance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditClaim = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_AddClaim = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Print = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_Search = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_InsuranceType = new System.Windows.Forms.ToolStripButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_Main.SuspendLayout();
            this.statusStrip_Main.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip_TreeView.SuspendLayout();
            this.contextMenuStrip_ListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_Main
            // 
            this.toolStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_AddClaim,
            this.toolStripSeparator5,
            this.toolStripButton_Print,
            this.toolStripSeparator2,
            this.toolStripLabel_Search,
            this.toolStripTextBox_SearchContent,
            this.toolStripSeparator4,
            this.label_Title,
            this.toolStripButton_Exit,
            this.toolStripSeparator_Exit,
            this.toolStripButton_InsuranceType});
            this.toolStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Main.Name = "toolStrip_Main";
            this.toolStrip_Main.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip_Main.Size = new System.Drawing.Size(536, 25);
            this.toolStrip_Main.TabIndex = 0;
            this.toolStrip_Main.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator_Exit
            // 
            this.toolStripSeparator_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator_Exit.Name = "toolStripSeparator_Exit";
            this.toolStripSeparator_Exit.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip_Main
            // 
            this.statusStrip_Main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip_Main.Location = new System.Drawing.Point(0, 482);
            this.statusStrip_Main.Name = "statusStrip_Main";
            this.statusStrip_Main.Size = new System.Drawing.Size(740, 22);
            this.statusStrip_Main.TabIndex = 1;
            this.statusStrip_Main.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_CustomerInsurance);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView_Claim);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip_Main);
            this.splitContainer1.Size = new System.Drawing.Size(740, 482);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView_CustomerInsurance
            // 
            this.treeView_CustomerInsurance.AllowDrop = true;
            this.treeView_CustomerInsurance.ContextMenuStrip = this.contextMenuStrip_TreeView;
            this.treeView_CustomerInsurance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_CustomerInsurance.HideSelection = false;
            this.treeView_CustomerInsurance.ImageIndex = 0;
            this.treeView_CustomerInsurance.ImageList = this.imageList1;
            this.treeView_CustomerInsurance.Location = new System.Drawing.Point(0, 0);
            this.treeView_CustomerInsurance.Name = "treeView_CustomerInsurance";
            this.treeView_CustomerInsurance.SelectedImageIndex = 0;
            this.treeView_CustomerInsurance.Size = new System.Drawing.Size(200, 482);
            this.treeView_CustomerInsurance.TabIndex = 0;
            this.treeView_CustomerInsurance.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_CustomerInsurance_DragDrop);
            this.treeView_CustomerInsurance.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_CustomerInsurance_AfterSelect);
            this.treeView_CustomerInsurance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_CustomerInsurance_MouseClick);
            this.treeView_CustomerInsurance.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_CustomerInsurance_ItemDrag);
            this.treeView_CustomerInsurance.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView_CustomerInsurance_DragOver);
            // 
            // contextMenuStrip_TreeView
            // 
            this.contextMenuStrip_TreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_AddCustomer,
            this.toolStripMenuItem_EditCustomer,
            this.toolStripMenuItem_DeleteCustomer,
            this.toolStripSeparator1,
            this.toolStripMenuItem_AddInsurance,
            this.toolStripMenuItem_EditInsurance,
            this.toolStripMenuItem_DeleteInsurance});
            this.contextMenuStrip_TreeView.Name = "contextMenuStrip_TreeView";
            this.contextMenuStrip_TreeView.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip_TreeView.Size = new System.Drawing.Size(131, 142);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OrgChartHS.png");
            this.imageList1.Images.SetKeyName(1, "Book_angleHS.png");
            this.imageList1.Images.SetKeyName(2, "TextboxHS.png");
            this.imageList1.Images.SetKeyName(3, "shape_square.png");
            this.imageList1.Images.SetKeyName(4, "Book_openHS.png");
            this.imageList1.Images.SetKeyName(5, "table.png");
            this.imageList1.Images.SetKeyName(6, "DataContainer_MoveNextHS.png");
            this.imageList1.Images.SetKeyName(7, "book_32.png");
            this.imageList1.Images.SetKeyName(8, "0203_Textbox_32.png");
            this.imageList1.Images.SetKeyName(9, "base_business_contacts.png");
            this.imageList1.Images.SetKeyName(10, "report.png");
            this.imageList1.Images.SetKeyName(11, "HomeHS.png");
            this.imageList1.Images.SetKeyName(12, "Overlay_Share_16.png");
            this.imageList1.Images.SetKeyName(13, "Overlay_Share_32.png");
            this.imageList1.Images.SetKeyName(14, "company.png");
            this.imageList1.Images.SetKeyName(15, "Users.png");
            this.imageList1.Images.SetKeyName(16, "RadialChartHS.png");
            // 
            // listView_Claim
            // 
            this.listView_Claim.ContextMenuStrip = this.contextMenuStrip_ListView;
            this.listView_Claim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Claim.FullRowSelect = true;
            this.listView_Claim.GridLines = true;
            this.listView_Claim.HideSelection = false;
            this.listView_Claim.Location = new System.Drawing.Point(0, 25);
            this.listView_Claim.Name = "listView_Claim";
            this.listView_Claim.Size = new System.Drawing.Size(536, 457);
            this.listView_Claim.SmallImageList = this.imageList1;
            this.listView_Claim.TabIndex = 0;
            this.listView_Claim.UseCompatibleStateImageBehavior = false;
            this.listView_Claim.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_Claim_MouseDoubleClick);
            this.listView_Claim.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView_Claim_MouseDown);
            this.listView_Claim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_Claim_KeyDown);
            // 
            // contextMenuStrip_ListView
            // 
            this.contextMenuStrip_ListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Paste,
            this.toolStripMenuItem_EditClaim,
            this.ToolStripMenuItem_Delete});
            this.contextMenuStrip_ListView.Name = "contextMenuStrip_ListView";
            this.contextMenuStrip_ListView.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip_ListView.Size = new System.Drawing.Size(136, 70);
            // 
            // label_Title
            // 
            this.label_Title.BackColor = System.Drawing.SystemColors.Control;
            this.label_Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label_Title.ForeColor = System.Drawing.Color.Black;
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox_SearchContent
            // 
            this.toolStripTextBox_SearchContent.MaxLength = 50;
            this.toolStripTextBox_SearchContent.Name = "toolStripTextBox_SearchContent";
            this.toolStripTextBox_SearchContent.Size = new System.Drawing.Size(180, 25);
            this.toolStripTextBox_SearchContent.ToolTipText = "可输入工号、姓名、身份证号码进行查找";
            this.toolStripTextBox_SearchContent.TextChanged += new System.EventHandler(this.toolStripTextBox_SearchContent_TextChanged);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(173, 17);
            this.toolStripStatusLabel2.Text = "输入保单号进行保单的模糊定位";
            // 
            // toolStripMenuItem_AddCustomer
            // 
            this.toolStripMenuItem_AddCustomer.Image = global::InsuranceClaims.Properties.Resources._042b_AddCategory_16x16_72;
            this.toolStripMenuItem_AddCustomer.Name = "toolStripMenuItem_AddCustomer";
            this.toolStripMenuItem_AddCustomer.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem_AddCustomer.Text = "新建客户";
            this.toolStripMenuItem_AddCustomer.Click += new System.EventHandler(this.toolStripMenuItem_AddCustomer_Click);
            // 
            // toolStripMenuItem_EditCustomer
            // 
            this.toolStripMenuItem_EditCustomer.Image = global::InsuranceClaims.Properties.Resources._126_Edit_16x16_72;
            this.toolStripMenuItem_EditCustomer.Name = "toolStripMenuItem_EditCustomer";
            this.toolStripMenuItem_EditCustomer.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem_EditCustomer.Text = "修改客户";
            this.toolStripMenuItem_EditCustomer.Click += new System.EventHandler(this.toolStripMenuItem_EditCustomer_Click);
            // 
            // toolStripMenuItem_DeleteCustomer
            // 
            this.toolStripMenuItem_DeleteCustomer.Image = global::InsuranceClaims.Properties.Resources.DeleteHS;
            this.toolStripMenuItem_DeleteCustomer.Name = "toolStripMenuItem_DeleteCustomer";
            this.toolStripMenuItem_DeleteCustomer.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem_DeleteCustomer.Text = "删除客户";
            this.toolStripMenuItem_DeleteCustomer.Click += new System.EventHandler(this.toolStripMenuItem_DeleteCustomer_Click);
            // 
            // toolStripMenuItem_AddInsurance
            // 
            this.toolStripMenuItem_AddInsurance.Image = global::InsuranceClaims.Properties.Resources._077_AddFile_16x16_72;
            this.toolStripMenuItem_AddInsurance.Name = "toolStripMenuItem_AddInsurance";
            this.toolStripMenuItem_AddInsurance.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem_AddInsurance.Text = "新建保险单";
            this.toolStripMenuItem_AddInsurance.Click += new System.EventHandler(this.toolStripMenuItem_AddInsurance_Click);
            // 
            // toolStripMenuItem_EditInsurance
            // 
            this.toolStripMenuItem_EditInsurance.Image = global::InsuranceClaims.Properties.Resources._126_Edit_16x16_72;
            this.toolStripMenuItem_EditInsurance.Name = "toolStripMenuItem_EditInsurance";
            this.toolStripMenuItem_EditInsurance.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem_EditInsurance.Text = "修改保险单";
            this.toolStripMenuItem_EditInsurance.Click += new System.EventHandler(this.toolStripMenuItem_EditInsurance_Click);
            // 
            // toolStripMenuItem_DeleteInsurance
            // 
            this.toolStripMenuItem_DeleteInsurance.Image = global::InsuranceClaims.Properties.Resources.DeleteHS;
            this.toolStripMenuItem_DeleteInsurance.Name = "toolStripMenuItem_DeleteInsurance";
            this.toolStripMenuItem_DeleteInsurance.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem_DeleteInsurance.Text = "删除保险单";
            this.toolStripMenuItem_DeleteInsurance.Click += new System.EventHandler(this.toolStripMenuItem_DeleteInsurance_Click);
            // 
            // toolStripMenuItem_Paste
            // 
            this.toolStripMenuItem_Paste.Image = global::InsuranceClaims.Properties.Resources.PasteHS;
            this.toolStripMenuItem_Paste.Name = "toolStripMenuItem_Paste";
            this.toolStripMenuItem_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.toolStripMenuItem_Paste.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem_Paste.Text = "粘贴";
            this.toolStripMenuItem_Paste.Click += new System.EventHandler(this.toolStripMenuItem_Paste_Click);
            // 
            // toolStripMenuItem_EditClaim
            // 
            this.toolStripMenuItem_EditClaim.Image = global::InsuranceClaims.Properties.Resources.Properties;
            this.toolStripMenuItem_EditClaim.Name = "toolStripMenuItem_EditClaim";
            this.toolStripMenuItem_EditClaim.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem_EditClaim.Text = "修改";
            this.toolStripMenuItem_EditClaim.Click += new System.EventHandler(this.toolStripMenuItem_EditClaim_Click);
            // 
            // ToolStripMenuItem_Delete
            // 
            this.ToolStripMenuItem_Delete.Image = global::InsuranceClaims.Properties.Resources.DeleteHS;
            this.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete";
            this.ToolStripMenuItem_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ToolStripMenuItem_Delete.Size = new System.Drawing.Size(135, 22);
            this.ToolStripMenuItem_Delete.Text = "删除";
            this.ToolStripMenuItem_Delete.Click += new System.EventHandler(this.ToolStripMenuItem_Delete_Click);
            // 
            // toolStripButton_AddClaim
            // 
            this.toolStripButton_AddClaim.Image = global::InsuranceClaims.Properties.Resources._077_AddFile_16x16_72;
            this.toolStripButton_AddClaim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddClaim.Name = "toolStripButton_AddClaim";
            this.toolStripButton_AddClaim.Size = new System.Drawing.Size(103, 22);
            this.toolStripButton_AddClaim.Text = "新建理赔单(&N)";
            this.toolStripButton_AddClaim.Click += new System.EventHandler(this.toolStripButton_AddClaim_Click);
            // 
            // toolStripButton_Print
            // 
            this.toolStripButton_Print.Enabled = false;
            this.toolStripButton_Print.Image = global::InsuranceClaims.Properties.Resources.printer;
            this.toolStripButton_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Print.Name = "toolStripButton_Print";
            this.toolStripButton_Print.Size = new System.Drawing.Size(67, 22);
            this.toolStripButton_Print.Text = "打印(&P)";
            this.toolStripButton_Print.Click += new System.EventHandler(this.toolStripButton_Print_Click);
            // 
            // toolStripLabel_Search
            // 
            this.toolStripLabel_Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel_Search.Image = global::InsuranceClaims.Properties.Resources.Find_VS;
            this.toolStripLabel_Search.Name = "toolStripLabel_Search";
            this.toolStripLabel_Search.Size = new System.Drawing.Size(16, 22);
            this.toolStripLabel_Search.Text = "toolStripLabel1";
            // 
            // toolStripButton_Exit
            // 
            this.toolStripButton_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Exit.Image = global::InsuranceClaims.Properties.Resources.exit;
            this.toolStripButton_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Exit.Name = "toolStripButton_Exit";
            this.toolStripButton_Exit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton_Exit.Size = new System.Drawing.Size(67, 22);
            this.toolStripButton_Exit.Text = "退出(&X)";
            this.toolStripButton_Exit.Click += new System.EventHandler(this.toolStripButton_Exit_Click);
            // 
            // toolStripButton_InsuranceType
            // 
            this.toolStripButton_InsuranceType.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_InsuranceType.Image = global::InsuranceClaims.Properties.Resources.ViewThumbnailsHS;
            this.toolStripButton_InsuranceType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_InsuranceType.Name = "toolStripButton_InsuranceType";
            this.toolStripButton_InsuranceType.Size = new System.Drawing.Size(67, 22);
            this.toolStripButton_InsuranceType.Text = "险种(&T)";
            this.toolStripButton_InsuranceType.Click += new System.EventHandler(this.toolStripButton_InsuranceType_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel1.Image = global::InsuranceClaims.Properties.Resources.LayoutSelectRow;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 16);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel_Location";
            this.toolStripStatusLabel1.ToolTipText = "报单定位";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 504);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip_Main);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保险单理赔管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.toolStrip_Main.ResumeLayout(false);
            this.toolStrip_Main.PerformLayout();
            this.statusStrip_Main.ResumeLayout(false);
            this.statusStrip_Main.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip_TreeView.ResumeLayout(false);
            this.contextMenuStrip_ListView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.ToolStrip toolStrip_Main;
        private System.Windows.Forms.StatusStrip statusStrip_Main;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView_CustomerInsurance;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView_Claim;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_TreeView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddCustomer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditCustomer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DeleteCustomer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddInsurance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditInsurance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DeleteInsurance;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddClaim;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ListView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Paste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditClaim;
        private System.Windows.Forms.ToolStripButton toolStripButton_InsuranceType;
        private System.Windows.Forms.ToolStripButton toolStripButton_Print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_Exit;
        private System.Windows.Forms.ToolStripButton toolStripButton_Exit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delete;
        private System.Windows.Forms.ToolStripLabel label_Title;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Search;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_SearchContent;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        
        
    }
}

