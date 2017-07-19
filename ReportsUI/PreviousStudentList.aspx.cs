using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_PreviousStudentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudentReport();
        }
    }
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        failStatusLabel.InnerText = "";
        successStatusLabel.InnerText = "";
        LoadStudentReport();
    }

    private void LoadStudentReport()
    {
        var report = new ReportDocument();

        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        //{tbl_TransferHistory.PreClass}{tbl_TransferHistory.PreSession}{tbl_TransferHistory.PreSection}{tbl_TransferHistory.PreShift}
        if (sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue == "0")
        {

            report.Load(Server.MapPath("~/Reports/PreviousStudentListWithNameShorting.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{tbl_TransferHistory.PreClass}='" +
                                                    classDropDownList.SelectedValue +
                                                    "' and {tbl_TransferHistory.PreSession}='" +
                                                    sessionDropDownList.SelectedValue +
                                                    "'and {Student.Status}='" + "P" +
                                                    "'and{Student.VarBranchID}=" + brachId;
            CrystalReportViewer1.RefreshReport();

        }
        else if (sectionDropDownList.SelectedValue != "0" && shiftDropDownList.SelectedValue == "0")
        {

            report.Load(Server.MapPath("~/Reports/PreviousStudentListWithNameShorting.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{tbl_TransferHistory.PreClass} ='" +
                                                    classDropDownList.SelectedValue +
                                                    "' and {tbl_TransferHistory.PreSession}='" +
                                                    sessionDropDownList.SelectedValue +
                                                    "' and {tbl_TransferHistory.PreSection}='" +
                                                    sectionDropDownList.SelectedValue +
                                                    "'and {Student.Status}='" + "P" +
                                                    "'and{Student.VarBranchID}=" + brachId;
            CrystalReportViewer1.RefreshReport();

        }
        else if (sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue != "0")
        {

            report.Load(Server.MapPath("~/Reports/PreviousStudentListWithNameShorting.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{tbl_TransferHistory.PreClass} ='" +
                                                    classDropDownList.SelectedValue +
                                                    "' and {tbl_TransferHistory.PreSession}='" +
                                                    sessionDropDownList.SelectedValue +
                                                    "' and {tbl_TransferHistory.PreShift}='" +
                                                    shiftDropDownList.SelectedValue +
                                                    "'and {Student.Status}='" + "P" +
                                                    "'and{Student.VarBranchID}=" + brachId;
            CrystalReportViewer1.RefreshReport();

        }

        else
        {

            report.Load(Server.MapPath("~/Reports/PreviousStudentListWithNameShorting.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{tbl_TransferHistory.PreClass} ='" +
                                                    classDropDownList.SelectedValue +
                                                    "' and {tbl_TransferHistory.PreSection}='" +
                                                    sectionDropDownList.SelectedValue +
                                                    "' and {tbl_TransferHistory.PreSession}='" +
                                                    sessionDropDownList.SelectedValue +
                                                    "' and {tbl_TransferHistory.PreShift}='" +
                                                    shiftDropDownList.SelectedValue +
                                                    "'and {Student.Status}='" + "P" +
                                                    "'and{Student.VarBranchID}=" + brachId;
            CrystalReportViewer1.RefreshReport();

        }
    }
}