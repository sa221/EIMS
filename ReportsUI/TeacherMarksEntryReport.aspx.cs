using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_TeacherMarksEntryReport : System.Web.UI.Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            LoadReport();
        }
    }
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void showButton_Click(object sender, EventArgs e)
    {

        LoadReport();
    }

    protected void LoadReport()
    {
        var report = new ReportDocument();
        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        if (testDropDownList.SelectedValue == "1")
        {
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            if (cls != null && cls.ClassType == 2)
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksALevelTest.rpt"));
                string examName = string.Empty;
                examName = examDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
                    //"{Class.VarClassID} ='" + classDropDownList.SelectedValue + "' and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";
                }
                SubjectWiseStudentList.RefreshReport();
            }
            else if (cls != null && cls.ClassType == 1)
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksTest.rpt"));
                string examName = string.Empty;
                examName = examDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
                }
                else
                {
                    SubjectWiseStudentList.SelectionFormula = "{tbl_StudentSubjectAssign.VarSessionId} ='" +
                                                              sessionDropDownList.SelectedValue +
                                                              "' and {tbl_StudentSubjectAssign.ClassId} ='" +
                                                              classDropDownList.SelectedValue +
                                                              "' and {tbl_StudentSubjectAssign.VarSubjectCode} ='" +
                                                              subjectDropDownList.SelectedValue +
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
                    //"{Class.VarClassID} ='" + classDropDownList.SelectedValue + "' and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";
                }
                SubjectWiseStudentList.RefreshReport();
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksJuniorTest.rpt"));
                string examName = string.Empty;
                examName = examDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
                    //"{Class.VarClassID} ='" + classDropDownList.SelectedValue + "' and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";"'and {tbl_Present_class.Status}='"+"P"+"'";
                }
                SubjectWiseStudentList.RefreshReport();
            }
        }
        else
        {
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            if (cls != null && cls.ClassType == 2)
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksALevelMock.rpt"));
                string examName = string.Empty;
                examName = examDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
                    //"{Class.VarClassID} ='" + classDropDownList.SelectedValue + "' and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";
                }
                SubjectWiseStudentList.RefreshReport();
            }
            else if (cls != null && cls.ClassType == 1)
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksMock.rpt"));
                string examName = string.Empty;
                examName = examDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
                }
                else
                {
                    SubjectWiseStudentList.SelectionFormula = "{tbl_StudentSubjectAssign.VarSessionId} ='" +
                                                              sessionDropDownList.SelectedValue +
                                                              "' and {tbl_StudentSubjectAssign.ClassId} ='" +
                                                              classDropDownList.SelectedValue +
                                                              "' and {tbl_StudentSubjectAssign.VarSubjectCode} ='" +
                                                              subjectDropDownList.SelectedValue +
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
                    //"{Class.VarClassID} ='" + classDropDownList.SelectedValue + "' and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";
                }
                SubjectWiseStudentList.RefreshReport();
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksJuniorMock.rpt"));
                string examName = string.Empty;
                examName = examDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
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
                                                              "'and {tbl_Present_class.Status}='" + "P" +
                                                              "'and{Student.VarBranchID}=" + brachId;
                    //"{Class.VarClassID} ='" + classDropDownList.SelectedValue + "' and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";"'and {tbl_Present_class.Status}='"+"P"+"'";
                }
                SubjectWiseStudentList.RefreshReport();
            }
        }
    }
}