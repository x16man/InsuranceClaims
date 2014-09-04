namespace InsuranceClaims
{
    partial class FormHospitals
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Name = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.listBox_Hospital = new System.Windows.Forms.ListBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(12, 46);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(41, 12);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "名称：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(59, 43);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 21);
            this.txtName.TabIndex = 2;
            // 
            // listBox_Hospital
            // 
            this.listBox_Hospital.FormattingEnabled = true;
            this.listBox_Hospital.ItemHeight = 12;
            this.listBox_Hospital.Location = new System.Drawing.Point(16, 99);
            this.listBox_Hospital.Name = "listBox_Hospital";
            this.listBox_Hospital.Size = new System.Drawing.Size(361, 484);
            this.listBox_Hospital.TabIndex = 4;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(140, 70);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 5;
            this.button_Add.Text = "新建(&N)";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(221, 70);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(75, 23);
            this.button_Edit.TabIndex = 6;
            this.button_Edit.Text = "修改(&E)";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(302, 70);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 7;
            this.button_Delete.Text = "删除(&D)";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(302, 8);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 9;
            this.button_Save.Text = "保存(&S)";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "代码：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(59, 10);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(237, 21);
            this.txtId.TabIndex = 11;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(16, 70);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "导入(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // FormHospitals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 598);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.listBox_Hospital);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormHospitals";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医院";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListBox listBox_Hospital;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}