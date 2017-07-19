using System;
using System.Linq;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

namespace ReportsUI
{
    public partial class ReportsUiAdmitRequest : Page
    {
        private readonly SWISDataContext db = new SWISDataContext();
        private string _fromid = "";
        private string _addmisionSession = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            _fromid = Request.QueryString["varRegistrationId"];
            _addmisionSession = Request.QueryString["VarSession"];
            if (!IsPostBack)
            {
                if (_fromid!=null && _addmisionSession!=null)
                {
                    failStatusLabel.InnerText = "";
                    sessionDropDownList.SelectedValue = _addmisionSession;
                    sessionDropDownList.DataBind();
                    fromIdTextBox.Text = _fromid;
                    string brhId = Session["VarBranchId"].ToString();
                    Branch getBrahName = db.Branches.FirstOrDefault(x => x.VarBranchID == Convert.ToInt32(brhId));
                    var reort = new ReportDocument();
                    reort.Load(Server.MapPath("~/Reports/AdmitRequest.rpt"));
                    //report.SetDataSource(db);
                    //string date = (dateTextBox.Text); 
                    //DateTime date = DateTime.ParseExact(dateTextBox.Text, "dd-MMM-yyyy", null);
                    GetStudent(reort, getBrahName, brhId);
                }
            }
            string brachId = Session["VarBranchId"].ToString();
            Branch getBranchName = db.Branches.FirstOrDefault(x => x.VarBranchID == Convert.ToInt32(brachId));
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/AdmitRequest.rpt"));
            GetStudent(report, getBranchName, brachId);
        }

        protected void createButton_Click(object sender, EventArgs e)
        {
            failStatusLabel.InnerText = "";
        
            string brachId = Session["VarBranchId"].ToString();
            Branch getBranchName = db.Branches.FirstOrDefault(x => x.VarBranchID == Convert.ToInt32(brachId));
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/AdmitRequest.rpt"));
            //report.SetDataSource(db);
            //string date = (dateTextBox.Text); 
            //DateTime date = DateTime.ParseExact(dateTextBox.Text, "dd-MMM-yyyy", null);
            GetStudent(report, getBranchName, brachId);
        }

        private void GetStudent(ReportDocument report, Branch getBranchName, string brachId)
        {
            var textObjectVenue = report.ReportDefinition.ReportObjects["venue"] as TextObject;
            if (textObjectVenue != null)
                if (getBranchName != null) textObjectVenue.Text = "Venue: " + getBranchName.Address;
                
        var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
            if (textObject != null)
                if (getBranchName != null) textObject.Text = "(" + getBranchName.VarBranchName + ")";
            if (fromIdTextBox.Text != "")
            {
                ParticipantStudent ps =
                    db.ParticipantStudents.FirstOrDefault(x => x.varRegistrationId == fromIdTextBox.Text && x.Status == "3" && x.VarSession==sessionDropDownList.SelectedValue);
                if (ps != null)
                {
                    AdmitRequestReport.ReportSource = report;
                    AdmitRequestReport.DataBind();
                    AdmitRequestReport.SelectionFormula = "{ParticipantStudent.varRegistrationId} ='" + fromIdTextBox.Text +
                                                          "'and{ParticipantStudent.Status}='" + "3" + "'and{ParticipantStudent.VarSession}='" + sessionDropDownList.SelectedValue +
                                                          "'and{ParticipantStudent.VarBranchId}=" + brachId;
                    AdmitRequestReport.RefreshReport();
                }
                else
                {
                    failStatusLabel.InnerText = "Invalid Request.";
                }
                //TextObject textObject = report.ReportDefinition.ReportObjects["admissionDate"] as TextObject;
                //if (textObject != null) textObject.Text = date;
            }
        }
    }
}