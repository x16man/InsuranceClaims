namespace InsuranceClaims
{
    partial class FormInsuranceType
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
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.listBox_InsuranceType = new System.Windows.Forms.ListBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(16, 48);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(41, 12);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "名称：";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(63, 45);
            this.textBox_Name.MaxLength = 50;
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(221, 21);
            this.textBox_Name.TabIndex = 2;
            // 
            // listBox_InsuranceType
            // 
            this.listBox_InsuranceType.FormattingEnabled = true;
            this.listBox_InsuranceType.ItemHeight = 12;
            this.listBox_InsuranceType.Location = new System.Drawing.Point(63, 75);
            this.listBox_InsuranceType.Name = "listBox_InsuranceType";
            this.listBox_InsuranceType.Size = new System.Drawing.Size(220, 184);
            this.listBox_InsuranceType.TabIndex = 4;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(290, 10);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 5;
            this.button_Add.Text = "新建(&N)";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(291, 46);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(75, 23);
            this.button_Edit.TabIndex = 6;
            this.button_Edit.Text = "修改(&E)";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(290, 85);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 7;
            this.button_Delete.Text = "删除(&D)";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(296, 234);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 8;
            this.button_Close.Text = "关闭(&C)";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(292, 125);
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
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "代码：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(62, 15);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(221, 21);
            this.txtCode.TabIndex = 11;
            // 
            // FormInsuranceType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 269);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.listBox_InsuranceType);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInsuranceType";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "责任险种";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.ListBox listBox_InsuranceType;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
    }
}