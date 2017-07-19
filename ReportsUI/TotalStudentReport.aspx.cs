using System;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

namespace ReportsUI
{
    public partial class ReportsUiTotalStudentReport : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRepeatStudent();
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            GetRepeatStudent();
        }

        private void GetRepeatStudent()
        {
            //Class getClassType = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            //{tbl_TransferHistory.TraSession}{Student.VarAdmissionSession}{Student.Status}
            //"'and {tbl_TransferHistory.TraSession}='" +
            //sessionDropDownList.SelectedValue +
            //"'or {tbl_TransferHistory.TraSession}='" +sessionDropDownList.SelectedValue +


            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/TotalNumberOfStudents.rpt"));

            if (sessionDropDownList.SelectedValue != "")
            {
                var textObject = report.ReportDefinition.ReportObjects["SESSION"] as TextObject;
                if (textObject != null) textObject.Text = "SESSION: " + sessionDropDownList.SelectedItem.Text;
            }

            TotalStudent.ReportSource = report;
            TotalStudent.SelectionFormula = "{Student.VarSessionName}='" + sessionDropDownList.SelectedValue +
                                            "'and{Student.Status}='" + "P" + "'";
            TotalStudent.RefreshReport();
            //report.Dispose();
        }
    }
}