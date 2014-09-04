namespace InsuranceClaims
{
    partial class FormCustomer
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
            this.label_Remark = new System.Windows.Forms.Label();
            this.textBox_Remark = new System.Windows.Forms.TextBox();
            this.button_Ok = new System.Windows.Forms.Button();
            this.label_Address = new System.Windows.Forms.Label();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(12, 23);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(41, 12);
            this.label_Name.TabIndex = 0;
            this.label_Name.Text = "名称：";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(59, 20);
            this.textBox_Name.MaxLength = 50;
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(221, 21);
            this.textBox_Name.TabIndex = 1;
            // 
            // label_Remark
            // 
            this.label_Remark.AutoSize = true;
            this.label_Remark.Location = new System.Drawing.Point(12, 95);
            this.label_Remark.Name = "label_Remark";
            this.label_Remark.Size = new System.Drawing.Size(41, 12);
            this.label_Remark.TabIndex = 2;
            this.label_Remark.Text = "备注：";
            // 
            // textBox_Remark
            // 
            this.textBox_Remark.Location = new System.Drawing.Point(59, 92);
            this.textBox_Remark.MaxLength = 255;
            this.textBox_Remark.Multiline = true;
            this.textBox_Remark.Name = "textBox_Remark";
            this.textBox_Remark.Size = new System.Drawing.Size(221, 89);
            this.textBox_Remark.TabIndex = 3;
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Ok.Location = new System.Drawing.Point(205, 196);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 4;
            this.button_Ok.Text = "&Y.确定";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.Location = new System.Drawing.Point(12, 59);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(41, 12);
            this.label_Address.TabIndex = 5;
            this.label_Address.Text = "地址：";
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(59, 56);
            this.textBox_Address.MaxLength = 50;
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(221, 21);
            this.textBox_Address.TabIndex = 6;
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 235);
            this.Controls.Add(this.label_Address);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.label_Remark);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.textBox_Remark);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCustomer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "客户信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Remark;
        private System.Windows.Forms.TextBox textBox_Remark;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.TextBox textBox_Address;
    }
}