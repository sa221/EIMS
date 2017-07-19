using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_ApplicantListReport : System.Web.UI.Page
{
    private SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetStudent();
        }
    }
    protected void showButton_Click(object sender, EventArgs e)
    {
        GetStudent();
    }
    private void GetStudent()
    {
        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        Branch getBranchName = db.Branches.FirstOrDefault(x => x.VarBranchID == Convert.ToInt32(brachId));
        var report = new ReportDocument();
        
        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //if (textObject != null)
        //    if (getBranchName != null) textObject.Text = "(" + getBranchName.VarBranchName + ")";
        if (classDropDownList.SelectedValue != "0" && applicantStatusDropDownList.SelectedValue!="0")
        {
            report.Load(Server.MapPath("~/Reports/ApplicantList.rpt"));
            AdmissionResult.ReportSource = report;
            AdmissionResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.admissionForClass}='" +
                                               classDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.Status}='" + applicantStatusDropDownList.SelectedValue +
                                               "and{ParticipantStudent.VarBranchId}='" + brachId;
            AdmissionResult.RefreshReport();
        }
        else if (classDropDownList.SelectedValue == "0" && applicantStatusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/ApplicantList.rpt"));
            AdmissionResult.ReportSource = report;
            AdmissionResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.Status}='" + applicantStatusDropDownList.SelectedValue +
                                               "and{ParticipantStudent.VarBranchId}='" + brachId;
            AdmissionResult.RefreshReport();
        }
        else if (classDropDownList.SelectedValue != "0" && applicantStatusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/ApplicantList.rpt"));
            AdmissionResult.ReportSource = report;
            AdmissionResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.admissionForClass}='" +
                                               classDropDownList.SelectedValue +
                                               "and{ParticipantStudent.VarBranchId}='" + brachId;
            AdmissionResult.RefreshReport();
        }
        else
        {
            report.Load(Server.MapPath("~/Reports/ApplicantList.rpt"));
            AdmissionResult.ReportSource = report;
            AdmissionResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.VarBranchId}=" + brachId;
            AdmissionResult.RefreshReport();
        }
    }
}