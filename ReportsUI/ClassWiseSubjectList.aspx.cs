using System;
using System.Linq;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_ClassWiseSubjectList : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetStudent();
    }

    private void GetStudent()
    {
        if (classDropDownList.SelectedValue != "0")
        {
            Class getClassType = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            if (getClassType != null && getClassType.ClassType == 2)
            {
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/ClassWiseSubjectList.rpt"));
                SubjectList.ReportSource = report;
                SubjectList.SelectionFormula = "{tbl_Subject.ClassId}='" + classDropDownList.SelectedValue +
                                               "'and {tbl_EdexelunitCode.Class}='" + classDropDownList.SelectedValue +
                                               "'";
                SubjectList.RefreshReport();
            }
            else
            {
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/OLavelSubjectList.rpt"));
                SubjectList.ReportSource = report;
                SubjectList.SelectionFormula = "{tbl_Subject.ClassId}='" + classDropDownList.SelectedValue + "'";
                SubjectList.RefreshReport();
            }
        }
    }
}