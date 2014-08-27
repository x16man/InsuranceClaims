namespace InsuranceClaims
{
    partial class FormInsurance
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
            this.label_Code = new System.Windows.Forms.Label();
            this.label_Customer = new System.Windows.Forms.Label();
            this.label_Remark = new System.Windows.Forms.Label();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.textBox_Remark = new System.Windows.Forms.TextBox();
            this.comboBox_Customer = new System.Windows.Forms.ComboBox();
            this.button_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Code
            // 
            this.label_Code.AutoSize = true;
            this.label_Code.Location = new System.Drawing.Point(13, 29);
            this.label_Code.Name = "label_Code";
            this.label_Code.Size = new System.Drawing.Size(53, 12);
            this.label_Code.TabIndex = 0;
            this.label_Code.Text = "保单号：";
            // 
            // label_Customer
            // 
            this.label_Customer.AutoSize = true;
            this.label_Customer.Location = new System.Drawing.Point(13, 60);
            this.label_Customer.Name = "label_Customer";
            this.label_Customer.Size = new System.Drawing.Size(41, 12);
            this.label_Customer.TabIndex = 1;
            this.label_Customer.Text = "客户：";
            // 
            // label_Remark
            // 
            this.label_Remark.AutoSize = true;
            this.label_Remark.Location = new System.Drawing.Point(13, 91);
            this.label_Remark.Name = "label_Remark";
            this.label_Remark.Size = new System.Drawing.Size(41, 12);
            this.label_Remark.TabIndex = 2;
            this.label_Remark.Text = "备注：";
            // 
            // textBox_Code
            // 
            this.textBox_Code.Location = new System.Drawing.Point(65, 26);
            this.textBox_Code.MaxLength = 50;
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(215, 21);
            this.textBox_Code.TabIndex = 3;
            // 
            // textBox_Remark
            // 
            this.textBox_Remark.Location = new System.Drawing.Point(65, 88);
            this.textBox_Remark.MaxLength = 255;
            this.textBox_Remark.Multiline = true;
            this.textBox_Remark.Name = "textBox_Remark";
            this.textBox_Remark.Size = new System.Drawing.Size(215, 95);
            this.textBox_Remark.TabIndex = 4;
            // 
            // comboBox_Customer
            // 
            this.comboBox_Customer.FormattingEnabled = true;
            this.comboBox_Customer.Location = new System.Drawing.Point(65, 57);
            this.comboBox_Customer.Name = "comboBox_Customer";
            this.comboBox_Customer.Size = new System.Drawing.Size(215, 20);
            this.comboBox_Customer.TabIndex = 5;
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(205, 198);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 6;
            this.button_Ok.Text = "确定(&Y)";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // FormInsurance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 234);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.comboBox_Customer);
            this.Controls.Add(this.textBox_Remark);
            this.Controls.Add(this.textBox_Code);
            this.Controls.Add(this.label_Remark);
            this.Controls.Add(this.label_Customer);
            this.Controls.Add(this.label_Code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInsurance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "保单信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Code;
        private System.Windows.Forms.Label label_Customer;
        private System.Windows.Forms.Label label_Remark;
        private System.Windows.Forms.TextBox textBox_Code;
        private System.Windows.Forms.TextBox textBox_Remark;
        private System.Windows.Forms.ComboBox comboBox_Customer;
        private System.Windows.Forms.Button button_Ok;
    }
}