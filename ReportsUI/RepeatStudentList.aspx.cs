using System;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_RepeatStudentList : Page
{
    private SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void showButton_Click(object sender, EventArgs e)
    {
        GetRepeatStudent();
    }

    private void GetRepeatStudent()
    {
        //Class getClassType = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
        if (classDropDownList.SelectedValue != "0")
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/RepeatStudentList.rpt"));
            RepeatStudentList.ReportSource = report;
            RepeatStudentList.SelectionFormula = "{tbl_Present_class.VarClassID}='" + classDropDownList.SelectedValue +
                                                 "'and {tbl_TransferHistory.TraClass}='" +
                                                 classDropDownList.SelectedValue +
                                                 "'and {tbl_Present_class.VarSessionId}='" +
                                                 sessionDropDownList.SelectedValue +
                                                 "'and{tbl_Present_class.Status}='" + "P" +
                                                 "'and{tbl_TransferHistory.Status}=3";

            RepeatStudentList.RefreshReport();
        }
        else if (classDropDownList.SelectedValue == "0")
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/RepeatStudentList.rpt"));
            RepeatStudentList.ReportSource = report;
            RepeatStudentList.SelectionFormula = "{tbl_Present_class.VarSessionId}='" +
                                                 sessionDropDownList.SelectedValue +
                                                 "'and{tbl_Present_class.Status}='" + "P" +
                                                 "'and{tbl_TransferHistory.Status}=3";
            RepeatStudentList.RefreshReport();
        }
    }
}