using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Insurance.Data.Model;
using Microsoft.Reporting.WinForms;

namespace InsuranceClaims
{
    public partial class FormReport : Form
    {
        #region Field

        private ClaimInfo _claimInfo;
        #endregion
        public FormReport()
        {
            InitializeComponent();
        }
        public FormReport(ClaimInfo obj):this()
        {
            this.reportViewer1.LocalReport.SetParameters(new[]{new ReportParameter("ClaimId",obj.Id.ToString()), });

            this._claimInfo = obj;
            
        }
        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“insuranceClaimsDataSet.ClaimDetails”中。您可以根据需要移动或移除它。
            this.dataTable1TableAdapter.Fill(this.insuranceClaimsDataSet.DataTable1, (int)this._claimInfo.Id);

            this.reportViewer1.RefreshReport();
        }
    }
}
