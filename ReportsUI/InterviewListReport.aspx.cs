using System;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;

namespace ReportsUI
{
    public partial class ReportsUiInterviewListReport : System.Web.UI.Page
    {
        private readonly SWISDataContext _db = new SWISDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            
            }
            GetStudent();
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            GetStudent();
        }

        private void GetStudent()
        {
            string brachId = Session["VarBranchId"].ToString();
            Branch getBranchName = _db.Branches.FirstOrDefault(x => x.VarBranchID == Convert.ToInt32(brachId));
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/InterviewReport.rpt"));
            var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
            if (textObject != null)
                if (getBranchName != null) textObject.Text = "(" + getBranchName.VarBranchName + ")";
            //if (!String.IsNullOrWhiteSpace(dateTextBox.Text))

            //    DateTime date = DateTime.ParseExact(dateTextBox.Text, "dd-MM-yyyy", null);


            if (classDropDownList.SelectedValue != "0" && dateTextBox.Text!="")
            {
                DateTime date = DateTime.ParseExact(dateTextBox.Text, "dd-MM-yyyy", null);
                int slot = Convert.ToInt32(interviewDropDown.SelectedValue);
                int slotTime= Convert.ToInt32(interviewTimeDropDown.SelectedValue);
                interviwResultViewer.ReportSource = report;
                interviwResultViewer.SelectionFormula = "{ParticipantStudent.VarSession}='" +
                                                        sessionDropDownList.SelectedValue +
                                                        "'and{ParticipantStudent.InterviewDate}='" + date.ToString("yyyy-MM-dd") +
                                                        "'and{ParticipantStudent.admissionForClass}='" +
                                                        classDropDownList.SelectedValue +
                                                        "'and{ParticipantStudent.VarBranchId}=" + brachId + "and{ParticipantStudent.InterviewSlot}=" +
                                                        slot+ "and{ParticipantStudent.IntrviewTime}="+slotTime ;
                interviwResultViewer.RefreshReport();
            }
          
        }
    }
}