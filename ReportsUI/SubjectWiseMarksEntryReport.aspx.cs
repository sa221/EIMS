using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_SubjectWiseMarksEntryReport : System.Web.UI.Page
{
    private SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            LoadReport();
        }
    }
    protected void showButton_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

    private void LoadReport()
    {
        var report = new ReportDocument();
        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        if (classDropDownList.SelectedValue != "0")
        {
            //Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            //if (cls != null && cls.ClassType == 2)
            //{
            if (subjectDropDownList.SelectedValue != "" && sectionDropDownList.SelectedValue == "0" &&
                unitcodeDropDownList.SelectedValue == "")
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksSheet.rpt"));
                string examName = string.Empty;
                examName = examNameDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
                StudentMarksSheet.ReportSource = report;
                //StudentMarksSheet.DataBind();
                StudentMarksSheet.SelectionFormula = "{tbl_StudentSubjectAssign.ClassId} ='" +
                                                     classDropDownList.SelectedValue +
                                                    "'and {tbl_StudentSubjectAssign.VarSessionId}='" +
                                                     sessionDropDownList.SelectedValue +
                                                     "'and {tbl_StudentSubjectAssign.VarSubjectCode}='" +
                                                     subjectDropDownList.SelectedValue +
                                                     "'and {Student.Status}='" + "P" +
                                                     "'and{Student.VarBranchID}=" + brachId;
                StudentMarksSheet.RefreshReport();
            }
            else if (subjectDropDownList.SelectedValue != "" && sectionDropDownList.SelectedValue == "0" &&
                     unitcodeDropDownList.SelectedValue != "")
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksSheet.rpt"));
                string examName = string.Empty;
                examName = examNameDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
                StudentMarksSheet.ReportSource = report;
                //StudentMarksSheet.DataBind();
                StudentMarksSheet.SelectionFormula = "{tbl_StudentSubjectAssign.ClassId} ='" +
                                                     classDropDownList.SelectedValue +
                                                    "'and {tbl_StudentSubjectAssign.VarSessionId}='" +
                                                     sessionDropDownList.SelectedValue +
                                                     "'and {tbl_StudentSubjectAssign.VarSubjectCode}='" +
                                                     subjectDropDownList.SelectedValue +
                                                     "'and {Student.Status}='" + "P" +
                                                     "'and{Student.VarBranchID}=" + brachId;
                StudentMarksSheet.RefreshReport();
            }
            else if (subjectDropDownList.SelectedValue != "" && sectionDropDownList.SelectedValue != "0" &&
                     unitcodeDropDownList.SelectedValue == "")
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksSheet.rpt"));
                string examName = string.Empty;
                examName = examNameDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
                StudentMarksSheet.ReportSource = report;
                //{tbl_StudentSubjectAssign.VarSessionId}{tbl_StudentSubjectAssign.ClassId}{tbl_StudentSubjectAssign.VarSection}{tbl_StudentSubjectAssign.VarSubjectCode}
                StudentMarksSheet.SelectionFormula = "{tbl_StudentSubjectAssign.ClassId} ='" +
                                                     classDropDownList.SelectedValue +
                                                    "'and {tbl_StudentSubjectAssign.VarSessionId}='" +
                                                     sessionDropDownList.SelectedValue +
                                                     "'and {tbl_StudentSubjectAssign.VarSubjectCode}='" +
                                                     subjectDropDownList.SelectedValue +
                                                     "'and {tbl_StudentSubjectAssign.VarSection}='" +
                                                     sectionDropDownList.SelectedValue +
                                                     "'and {Student.Status}='" + "P" +
                                                     "'and{Student.VarBranchID}=" + brachId;
                StudentMarksSheet.RefreshReport();
            }
            else if (subjectDropDownList.SelectedValue != "" && sectionDropDownList.SelectedValue != "0" &&
                     unitcodeDropDownList.SelectedValue != "")
            {
                report.Load(Server.MapPath("~/Reports/SubjectWiseMarksSheet.rpt"));
                string examName = string.Empty;
                examName = examNameDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
                StudentMarksSheet.ReportSource = report;
                //StudentMarksSheet.DataBind();{tblSection.SectionId}{Student.VarBranchID}{tbl_StudentSubjectAssign.VarSubjectCode}
                StudentMarksSheet.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                     classDropDownList.SelectedValue +
                    //"'and {tbl_ExamMarks.ExamCode}='" +
                    //examNameDropDownList.SelectedValue +
                                                    "'and {tbl_StudentSubjectAssign.VarSubjectCode}='" +
                                                     subjectDropDownList.SelectedValue +
                                                     "'and {tbl_Present_class.VarSection}='" +
                                                     sectionDropDownList.SelectedValue +
                    //"'and {tbl_ExamMarks.UnitCode}='" +
                    //unitcodeDropDownList.SelectedValue +
                                                     "'and {Student.Status}='" + "P" +
                                                     "'and{Student.VarBranchID}=" + brachId;
                StudentMarksSheet.RefreshReport();
            }
        }
    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}