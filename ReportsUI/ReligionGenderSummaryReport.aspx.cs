using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_ReligionGenderSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetStudentSummary();
        }
    }
    protected void showButton_Click(object sender, EventArgs e)
    {
        GetStudentSummary();
    }
    private void GetStudentSummary()
    {
        var report = new ReportDocument();
        report.Load(Server.MapPath("~/Reports/Rig.rpt"));
        ReligionGenderSummaryReport.ReportSource = report;
        ReligionGenderSummaryReport.SelectionFormula = "{tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                        "'and{tbl_Present_class.Status}='" + "P" + "'";
        ReligionGenderSummaryReport.RefreshReport();
    }
}