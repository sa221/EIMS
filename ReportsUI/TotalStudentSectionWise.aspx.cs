using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_TotalStudentSectionWise : System.Web.UI.Page
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
        report.Load(Server.MapPath("~/Reports/TotalStudentSectionWise.rpt"));

        if (sessionDropDownList.SelectedValue != "")
        {
            var textObject = report.ReportDefinition.ReportObjects["SESSION"] as TextObject;
            if (textObject != null) textObject.Text = "SESSION: " + sessionDropDownList.SelectedItem.Text;
        }

        TotalStudenSection.ReportSource = report;
        TotalStudenSection.SelectionFormula = "{Student.VarSessionName}='" + sessionDropDownList.SelectedValue +
                                        "'and{Student.Status}='" + "P" + "'";
        TotalStudenSection.RefreshReport();
        //report.Dispose();
    }
}