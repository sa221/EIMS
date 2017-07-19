using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_SubjectWiseStudentList : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void showButton_Click(object sender, EventArgs e)
    {
        var report = new ReportDocument();

        Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
        if (cls != null && cls.ClassType == 2)
        {
            report.Load(Server.MapPath("~/Reports/SubjectWiseStudentListALevel.rpt"));
            SubjectWiseStudentList.ReportSource = report;
            if (sectionDropDownList.SelectedValue != "0")
            {
                SubjectWiseStudentList.SelectionFormula = "{tbl_EdexcelSubjectAssign.Session} ='" +
                                                          sessionDropDownList.SelectedValue +
                                                          "' and {tbl_EdexcelSubjectAssign.ClassId} ='" +
                                                          classDropDownList.SelectedValue +
                                                          "' and {tbl_EdexcelSubjectAssign.SubjectId} ='" +
                                                          subjectDropDownList.SelectedValue +
                                                          "' and{tbl_EdexcelSubjectAssign.UnitCode} ='" +
                                                          unitcodeDropDownList.SelectedValue +
                                                          "'and {tbl_EdexcelSubjectAssign.Section} ='" +
                                                          sectionDropDownList.SelectedValue +
                                                          "'and {tbl_Present_class.Status}='" + "P" + "'";
            }
            else
            {
                SubjectWiseStudentList.SelectionFormula = "{tbl_EdexcelSubjectAssign.Session} ='" +
                                                          sessionDropDownList.SelectedValue +
                                                          "' and {tbl_EdexcelSubjectAssign.ClassId} ='" +
                                                          classDropDownList.SelectedValue +
                                                          "' and {tbl_EdexcelSubjectAssign.SubjectId} ='" +
                                                          subjectDropDownList.SelectedValue +
                                                          "' and {tbl_EdexcelSubjectAssign.UnitCode} ='" +
                                                          unitcodeDropDownList.SelectedValue +
                                                          "'and {tbl_Present_class.Status}='" + "P" + "'";
                //"{Class.VarClassID} ='" + classDropDownList.SelectedValue + "' and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";
            }
            SubjectWiseStudentList.RefreshReport();
        }
        else if (cls != null && cls.ClassType == 1)
        {
            report.Load(Server.MapPath("~/Reports/SubjectWiseStudentList.rpt"));
            SubjectWiseStudentList.ReportSource = report;
            if (sectionDropDownList.SelectedValue != "0")
            {
                SubjectWiseStudentList.SelectionFormula = "{tbl_StudentSubjectAssign.VarSessionId} ='" +
                                                          sessionDropDownList.SelectedValue +
                                                          "' and {tbl_StudentSubjectAssign.ClassId} ='" +
                                                          classDropDownList.SelectedValue +
                                                          "' and {tbl_StudentSubjectAssign.VarSubjectCode} ='" +
                                                          subjectDropDownList.SelectedValue +
                                                          "'and {tbl_StudentSubjectAssign.VarSection} ='" +
                                                          sectionDropDownList.SelectedValue +
                                                          "'and {tbl_Present_class.Status}='" + "P" + "'";
            }
            else
            {
                SubjectWiseStudentList.SelectionFormula = "{tbl_StudentSubjectAssign.VarSessionId} ='" +
                                                          sessionDropDownList.SelectedValue +
                                                          "' and {tbl_StudentSubjectAssign.ClassId} ='" +
                                                          classDropDownList.SelectedValue +
                                                          "' and {tbl_StudentSubjectAssign.VarSubjectCode} ='" +
                                                          subjectDropDownList.SelectedValue +
                                                          "'and {tbl_Present_class.Status}='" + "P" + "'";
                //"{Class.VarClassID} ='" + classDropDownList.SelectedValue + "' and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";
            }
            SubjectWiseStudentList.RefreshReport();
        }
        else
        {
            report.Load(Server.MapPath("~/Reports/SubjectWiseStudentListJunior.rpt"));
            SubjectWiseStudentList.ReportSource = report;
            if (sectionDropDownList.SelectedValue != "0")
            {
                SubjectWiseStudentList.SelectionFormula = "{tbl_Present_class.VarSessionId} ='" +
                                                          sessionDropDownList.SelectedValue +
                                                          "' and {tbl_Subject.ClassId}='" +
                                                          classDropDownList.SelectedValue +
                                                          "' and {tbl_Subject.VarSubjectCode} ='" +
                                                          subjectDropDownList.SelectedValue +
                                                          "'and {tbl_Present_class.VarSection} ='" +
                                                          sectionDropDownList.SelectedValue +
                                                          "'and {tbl_Present_class.Status}='" + "P" + "'";
                //{tbl_Subject.VarSubjectCode}{tbl_Subject.ClassId}{tbl_Present_class.VarSessionId}{tbl_Present_class.VarSection}
            }
            else
            {
                SubjectWiseStudentList.SelectionFormula = "{tbl_Present_class.VarSessionId} ='" +
                                                          sessionDropDownList.SelectedValue +
                                                          "' and {tbl_Subject.ClassId}='" +
                                                          classDropDownList.SelectedValue +
                                                          "' and {tbl_Subject.VarSubjectCode} ='" +
                                                          subjectDropDownList.SelectedValue +
                                                          "'and {tbl_Present_class.Status}='" + "P" + "'";
                //"{Class.VarClassID} ='" + classDropDownList.SelectedValue + "' and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";"'and {tbl_Present_class.Status}='"+"P"+"'";
            }
            SubjectWiseStudentList.RefreshReport();
        }
    }
}