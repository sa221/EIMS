using System;
using System.Linq;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_AdmissionResultReport : Page
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
            report.Load(Server.MapPath("~/Reports/AdmissionTestResult.rpt"));
            var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
            if (textObject != null)
                if (getBranchName != null) textObject.Text = "("+getBranchName.VarBranchName+")";
            AdmissionResult.ReportSource = report;
            AdmissionResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.admissionForClass}='" +
                                               classDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.AdmissionDate}='" +
                                               admissionDate.ToString("yyyy-MM-dd") +
                                               "'and{ParticipantStudent.Status}='" + "3" +
                                               "'and{ParticipantStudent.VarBranchId}=" + brachId;
            AdmissionResult.RefreshReport();
        }
        else if (classDropDownList.SelectedValue == "0" && dateTextBox.Text != "")
        {
            DateTime admissionDate = Convert.ToDateTime(dateTextBox.Text);
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/AdmissionTestResult.rpt"));
            var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
            if (textObject != null)
                if (getBranchName != null) textObject.Text = "(" + getBranchName.VarBranchName + ")";
            AdmissionResult.ReportSource = report;
            AdmissionResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.AdmissionDate}='" +
                                               admissionDate.ToString("yyyy-MM-dd") +
                                               "'and{ParticipantStudent.Status}='" + "3" +
                                               "'and{ParticipantStudent.VarBranchId}=" + brachId;
            AdmissionResult.RefreshReport();
        }
        else if (classDropDownList.SelectedValue != "0" && dateTextBox.Text == "")
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/AdmissionTestResult.rpt"));
            var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
            if (textObject != null)
                if (getBranchName != null) textObject.Text = "(" + getBranchName.VarBranchName + ")";
            AdmissionResult.ReportSource = report;
            AdmissionResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.admissionForClass}='" +
                                               classDropDownList.SelectedValue + "'and{ParticipantStudent.Status}='" +
                                               "3" +
                                               "'and{ParticipantStudent.VarBranchId}=" + brachId;
            AdmissionResult.RefreshReport();
        }
        else
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/AdmissionTestResult.rpt"));
            AdmissionResult.ReportSource = report;
            AdmissionResult.SelectionFormula = "{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                               "'and{ParticipantStudent.Status}='" + "3" +
                                               "'and{ParticipantStudent.VarBranchId}=" + brachId;
            AdmissionResult.RefreshReport();
        }
    }
}