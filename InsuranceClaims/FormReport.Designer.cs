namespace InsuranceClaims
{
    partial class FormReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ClaimPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.insuranceClaimsDataSet = new InsuranceClaims.AppData.InsuranceClaimsDataSet();
            this.claimPersonTableAdapter = new InsuranceClaims.AppData.InsuranceClaimsDataSetTableAdapters.ClaimPersonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceClaimsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "InsuranceClaimsDataSet_ClaimPerson";
            reportDataSource2.Value = this.ClaimPersonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DisplayName = "理赔对照表";
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InsuranceClaims.Report.ClaimDetail.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(473, 351);
            this.reportViewer1.TabIndex = 0;
            // 
            // ClaimPersonBindingSource
            // 
            this.ClaimPersonBindingSource.DataMember = "ClaimPerson";
            this.ClaimPersonBindingSource.DataSource = this.insuranceClaimsDataSet;
            // 
            // insuranceClaimsDataSet
            // 
            this.insuranceClaimsDataSet.DataSetName = "InsuranceClaimsDataSet";
            this.insuranceClaimsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // claimPersonTableAdapter
            // 
            this.claimPersonTableAdapter.ClearBeforeFill = true;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 351);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印预览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClaimPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceClaimsDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ClaimPersonBindingSource;
        private InsuranceClaims.AppData.InsuranceClaimsDataSet insuranceClaimsDataSet;
        private InsuranceClaims.AppData.InsuranceClaimsDataSetTableAdapters.ClaimPersonTableAdapter claimPersonTableAdapter;
    }
}