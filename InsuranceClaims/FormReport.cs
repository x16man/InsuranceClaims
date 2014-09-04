using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Insurance.Data.Model;
using Microsoft.Reporting.WinForms;
using InsuranceClaims.AppData.InsuranceClaimsDataSetTableAdapters;
namespace InsuranceClaims
{
    public partial class FormReport : Form
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ClaimInsuranceTypeTableAdapter citAdapter = new ClaimInsuranceTypeTableAdapter();
        private ClaimDetailTableAdapter detailsAdapter = new ClaimDetailTableAdapter();
        private ClaimInfo _claimInfo;
        #endregion
        public FormReport()
        {
            InitializeComponent();
        }
        public FormReport(ClaimInfo obj):this()
        {
            this.reportViewer1.LocalReport.SetParameters(new[]{new ReportParameter("ClaimId",obj.Id.ToString()), });
            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            this._claimInfo = obj;
            
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            Logger.Debug(string.Format("{0}----{1}-{2}",e.ReportPath,e.Parameters[0].Values.Count,e.Parameters[1].Values.Count));
            var claimId = int.Parse(e.Parameters["ClaimId"].Values[0]);
            var claimNo = e.Parameters["ClaimNo"].Values[0];
            switch (e.ReportPath)
            {
                case "ClaimInsuranceType":
                    var dt = citAdapter.GetData(claimId, claimNo);
                    e.DataSources.Add(new ReportDataSource("InsuranceClaimsDataSet_ClaimInsuranceType", dt));
                    break;
                case "ClaimDetails":
                    var dt1 = detailsAdapter.GetData(claimId, claimNo);
                    e.DataSources.Add(new ReportDataSource("InsuranceClaimsDataSet_ClaimDetail", dt1));
                    break;
            }
            //var adapter = new ClaimInsuranceTypeTableAdapter();
            
        }
        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“insuranceClaimsDataSet.ClaimDetails”中。您可以根据需要移动或移除它。
            this.claimPersonTableAdapter.Fill(this.insuranceClaimsDataSet.ClaimPerson, (int)this._claimInfo.Id);

            this.reportViewer1.RefreshReport();
        }
    }
}
