namespace InsuranceClaims
{
    partial class FormClaim
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
            this.label_ClaimNo = new System.Windows.Forms.Label();
            this.label_ClaimDate = new System.Windows.Forms.Label();
            this.textBox_ClaimNo = new System.Windows.Forms.TextBox();
            this.button_Ok = new System.Windows.Forms.Button();
            this.dateTimePicker_ClaimDate = new System.Windows.Forms.DateTimePicker();
            this.label_Remark = new System.Windows.Forms.Label();
            this.textBox_Remark = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_ClaimNo
            // 
            this.label_ClaimNo.AutoSize = true;
            this.label_ClaimNo.Location = new System.Drawing.Point(17, 18);
            this.label_ClaimNo.Name = "label_ClaimNo";
            this.label_ClaimNo.Size = new System.Drawing.Size(65, 12);
            this.label_ClaimNo.TabIndex = 0;
            this.label_ClaimNo.Text = "理赔单号：";
            // 
            // label_ClaimDate
            // 
            this.label_ClaimDate.AutoSize = true;
            this.label_ClaimDate.Location = new System.Drawing.Point(17, 64);
            this.label_ClaimDate.Name = "label_ClaimDate";
            this.label_ClaimDate.Size = new System.Drawing.Size(65, 12);
            this.label_ClaimDate.TabIndex = 1;
            this.label_ClaimDate.Text = "理赔日期：";
            // 
            // textBox_ClaimNo
            // 
            this.textBox_ClaimNo.Location = new System.Drawing.Point(88, 15);
            this.textBox_ClaimNo.Name = "textBox_ClaimNo";
            this.textBox_ClaimNo.Size = new System.Drawing.Size(192, 21);
            this.textBox_ClaimNo.TabIndex = 2;
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(205, 210);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 4;
            this.button_Ok.Text = "确定(&Y)";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // dateTimePicker_ClaimDate
            // 
            this.dateTimePicker_ClaimDate.Location = new System.Drawing.Point(88, 60);
            this.dateTimePicker_ClaimDate.Name = "dateTimePicker_ClaimDate";
            this.dateTimePicker_ClaimDate.Size = new System.Drawing.Size(192, 21);
            this.dateTimePicker_ClaimDate.TabIndex = 5;
            // 
            // label_Remark
            // 
            this.label_Remark.AutoSize = true;
            this.label_Remark.Location = new System.Drawing.Point(17, 105);
            this.label_Remark.Name = "label_Remark";
            this.label_Remark.Size = new System.Drawing.Size(41, 12);
            this.label_Remark.TabIndex = 6;
            this.label_Remark.Text = "备注：";
            // 
            // textBox_Remark
            // 
            this.textBox_Remark.Location = new System.Drawing.Point(88, 102);
            this.textBox_Remark.Multiline = true;
            this.textBox_Remark.Name = "textBox_Remark";
            this.textBox_Remark.Size = new System.Drawing.Size(192, 89);
            this.textBox_Remark.TabIndex = 7;
            // 
            // FormClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 255);
            this.Controls.Add(this.textBox_Remark);
            this.Controls.Add(this.label_Remark);
            this.Controls.Add(this.dateTimePicker_ClaimDate);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.textBox_ClaimNo);
            this.Controls.Add(this.label_ClaimDate);
            this.Controls.Add(this.label_ClaimNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormClaim";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "理赔单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ClaimNo;
        private System.Windows.Forms.Label label_ClaimDate;
        private System.Windows.Forms.TextBox textBox_ClaimNo;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ClaimDate;
        private System.Windows.Forms.Label label_Remark;
        private System.Windows.Forms.TextBox textBox_Remark;
    }
}