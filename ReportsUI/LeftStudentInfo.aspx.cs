using System;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

namespace ReportsUI
{
    public partial class ReportsUiLeftStudentInfo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLeftStudent();
            }
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            GetLeftStudent();
        }

        private void GetLeftStudent()
        {
            if (fromDateTextBox.Text != "" && toDateTextBox.Text != "" && classDropDownList.SelectedValue != "0")
            {
                DateTime fromDate = Convert.ToDateTime(fromDateTextBox.Text);
                DateTime toDate = Convert.ToDateTime(toDateTextBox.Text);
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/LeftStudentInfo.rpt"));
                var textObject = report.ReportDefinition.ReportObjects["fromToText"] as TextObject;
                if (textObject != null)
                    textObject.Text = fromDate.ToString("dd/MM/yyyy") + " -TO- " + toDate.ToString("dd/MM/yyyy");
                LeftStudentReportViewer.ReportSource = report;
                LeftStudentReportViewer.SelectionFormula = "{Student.SDate}>='" + fromDate.ToString("yyyy-MM-dd") +
                                                           "'and {Student.SDate}<='" + toDate.ToString("yyyy-MM-dd") +
                                                          "'and  {Student.PClassID}='" + classDropDownList.SelectedValue +
                                                           "'and {Student.Status}='" + "L" + "'";
                LeftStudentReportViewer.RefreshReport();
            }
            else if (fromDateTextBox.Text != "" && toDateTextBox.Text != "" && classDropDownList.SelectedValue == "0")
            {
                DateTime fromDate = Convert.ToDateTime(fromDateTextBox.Text);
                DateTime toDate = Convert.ToDateTime(toDateTextBox.Text);
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/LeftStudentInfo.rpt"));
                var textObject = report.ReportDefinition.ReportObjects["fromToText"] as TextObject;
                if (textObject != null)
                    textObject.Text = fromDate.ToString("dd/MM/yyyy") + " -TO- " + toDate.ToString("dd/MM/yyyy");
                LeftStudentReportViewer.ReportSource = report;
                LeftStudentReportViewer.SelectionFormula = "{Student.SDate}>='" + fromDate.ToString("yyyy-MM-dd") +
                                                           "'and {Student.SDate}<='" + toDate.ToString("yyyy-MM-dd") +
                                                           "'and {Student.Status}='" + "L" + "'";
                LeftStudentReportViewer.RefreshReport();
            }
        }
    }
}