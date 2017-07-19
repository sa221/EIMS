using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_TotalStudentSummary : System.Web.UI.Page
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
        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        if (classModeCheckBox.Checked)
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/TOtalNumberOfStudentSummaryClassWise.rpt"));

            //if (sessionDropDownList.SelectedValue != "")
            //{
            //    var textObject = report.ReportDefinition.ReportObjects["SESSION"] as TextObject;
            //    if (textObject != null) textObject.Text = "SESSION: " + sessionDropDownList.SelectedItem.Text;
            //}

            TotalStudentSummary.ReportSource = report;
            TotalStudentSummary.SelectionFormula = "{Student.VarSessionName}='" + sessionDropDownList.SelectedValue +
                                            "'and{Student.Status}='" + "P" +
                                            "'and{Student.VarBranchID}=" + brachId;
            TotalStudentSummary.RefreshReport();
        }
        else
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/TOtalNumberOfStudentSummary.rpt"));

            //if (sessionDropDownList.SelectedValue != "")
            //{
            //    var textObject = report.ReportDefinition.ReportObjects["SESSION"] as TextObject;
            //    if (textObject != null) textObject.Text = "SESSION: " + sessionDropDownList.SelectedItem.Text;
            //}

            TotalStudentSummary.ReportSource = report;
            TotalStudentSummary.SelectionFormula = "{Student.VarSessionName}='" + sessionDropDownList.SelectedValue +
                                            "'and{Student.Status}='" + "P"+
                                            "'and{Student.VarBranchID}=" + brachId;
            TotalStudentSummary.RefreshReport();
        }
       
        //report.Dispose();
    }
}