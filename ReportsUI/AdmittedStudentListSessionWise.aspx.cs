using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_AdmittedStudentListSessionWise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRepeatStudent();
        }
        
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
        var report = new ReportDocument();
        report.Load(Server.MapPath("~/Reports/NewAdmittedStudent.rpt"));

        if (sessionDropDownList.SelectedValue != "")
        {
            TotalStudent.ReportSource = report;
            TotalStudent.SelectionFormula = "{Student.VarAdmissionSession}='" + sessionDropDownList.SelectedValue +
                                            "'and{Student.VarBranchID}=" + brachId;
            TotalStudent.RefreshReport();
        }
    }
}