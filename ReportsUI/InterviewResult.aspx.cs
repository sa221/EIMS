using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_InterviewResult : System.Web.UI.Page
{
    private SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
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
        string brachId = Session["VarBranchId"].ToString();
        Branch getBranchName = db.Branches.FirstOrDefault(x => x.VarBranchID == Convert.ToInt32(brachId));

        if (classDropDownList.SelectedValue != "0" && dateTextBox.Text != "")
        {
            DateTime admissionDate = Convert.ToDateTime(dateTextBox.Text);
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/InterviewResultReport.rpt"));
            var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
            if (textObject != null)
                if (getBranchName != null) textObject.Text = "(" + getBranchName.VarBranchName + ")";
            InterviewResult.ReportSource = report;
            InterviewResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.admissionForClass}='" +
                                               classDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.InterviewDate}='" +
                                               admissionDate.ToString("yyyy-MM-dd") +
                                               "'and{ParticipantStudent.Status}='" + "2" +
                                               "'and{ParticipantStudent.VarBranchId}=" + brachId;
            InterviewResult.RefreshReport();
        }
        else if (classDropDownList.SelectedValue == "0" && dateTextBox.Text != "")
        {
            DateTime admissionDate = Convert.ToDateTime(dateTextBox.Text);
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/InterviewResultReport.rpt"));
            var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
            if (textObject != null)
                if (getBranchName != null) textObject.Text = "(" + getBranchName.VarBranchName + ")";
            InterviewResult.ReportSource = report;
            InterviewResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.InterviewDate}='" +
                                               admissionDate.ToString("yyyy-MM-dd") +
                                               "'and{ParticipantStudent.Status}='" + "2" +
                                               "'and{ParticipantStudent.VarBranchId}=" + brachId;
            InterviewResult.RefreshReport();
        }
        else if (classDropDownList.SelectedValue != "0" && dateTextBox.Text == "")
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/InterviewResultReport.rpt"));
            var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
            if (textObject != null)
                if (getBranchName != null) textObject.Text = "(" + getBranchName.VarBranchName + ")";
            InterviewResult.ReportSource = report;
            InterviewResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.admissionForClass}='" +
                                               classDropDownList.SelectedValue + "'and{ParticipantStudent.Status}='" +
                                               "2" +
                                               "'and{ParticipantStudent.VarBranchId}=" + brachId;
            InterviewResult.RefreshReport();
        }
        else
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/InterviewResultReport.rpt"));
            InterviewResult.ReportSource = report;
            InterviewResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.Status}='" + "2" +
                                               "'and{ParticipantStudent.VarBranchId}=" + brachId;
            InterviewResult.RefreshReport();
        }
    }
}