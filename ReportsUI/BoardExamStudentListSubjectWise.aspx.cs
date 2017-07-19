using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_BoardExamStudentListSubjectWise : System.Web.UI.Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            LoadStudentReport();
        }
    }
    protected void sessionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getSection = from c in db.tbl_ExamSessions
                         where c.SessionId == sessionDropDownList.SelectedValue
                         select new { c.ExamSessionId, c.ExamSessionName };

        examSessionDropDownList.DataSource = getSection;
        examSessionDropDownList.DataValueField = "ExamSessionId";
        examSessionDropDownList.DataTextField = "ExamSessionName";
        examSessionDropDownList.DataBind();
        examSessionDropDownList.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void showButton_Click(object sender, EventArgs e)
    {
        LoadStudentReport();
    }

    private void LoadStudentReport()
    {
        var report = new ReportDocument();

        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        
        if (sessionDropDownList.SelectedValue != "0" && examSessionDropDownList.SelectedValue != "" && qLevelDropDownList.SelectedValue != "0" && subjectDropDownList.SelectedValue != "" && unitcodeDropDownList.SelectedValue != "")
        {
            report.Load(Server.MapPath("~/Reports/BoardExamSubjectWiseStudentList.rpt"));
            string examName = string.Empty;
            examName = "EXAMINEES " + examSessionDropDownList.SelectedItem.Text;
            var textObject = report.ReportDefinition.ReportObjects["examSession"] as TextObject;
            if (textObject != null) textObject.Text = examName;
            SubjectWiseStudentListBoardExam.ReportSource = report;
            SubjectWiseStudentListBoardExam.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" +
                                                    sessionDropDownList.SelectedValue +
                                                    "' and {tbl_BoardExamSubAssign.ExamSession}='" +
                                                    examSessionDropDownList.SelectedValue +
                                                    "' and {tbl_BoardExamSubAssign.QualificationLevel}='" +
                                                    qLevelDropDownList.SelectedValue +
                                                    "' and {tbl_BoardExamSubAssign.SubjectId}='" +
                                                    subjectDropDownList.SelectedValue +
                                                    "' and {tbl_BoardExamSubAssign.UnitCode}='" +
                                                    unitcodeDropDownList.SelectedValue +
                                                    "'and{Student.VarBranchID}=" + brachId;
            SubjectWiseStudentListBoardExam.RefreshReport();
            //{tbl_BoardExamSubAssign.Session}{tbl_BoardExamSubAssign.ExamSession}{tbl_BoardExamSubAssign.QualificationLevel}{tbl_BoardExamSubAssign.SubjectId}{tbl_BoardExamSubAssign.UnitCode}
        }
        else if (sessionDropDownList.SelectedValue != "0" && examSessionDropDownList.SelectedValue != "" && qLevelDropDownList.SelectedValue != "0" && subjectDropDownList.SelectedValue != "" && unitcodeDropDownList.SelectedValue == "")
        {
            report.Load(Server.MapPath("~/Reports/BoardExamSubjectWiseStudentList.rpt"));
            string examName = string.Empty;
            examName = "EXAMINEES " + examSessionDropDownList.SelectedItem.Text;
            var textObject = report.ReportDefinition.ReportObjects["examSession"] as TextObject;
            if (textObject != null) textObject.Text = examName;
            SubjectWiseStudentListBoardExam.ReportSource = report;
            SubjectWiseStudentListBoardExam.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" +
                                                    sessionDropDownList.SelectedValue +
                                                    "' and {tbl_BoardExamSubAssign.ExamSession}='" +
                                                    examSessionDropDownList.SelectedValue +
                                                    "' and {tbl_BoardExamSubAssign.QualificationLevel}='" +
                                                    qLevelDropDownList.SelectedValue +
                                                    "' and {tbl_BoardExamSubAssign.SubjectId}='" +
                                                    subjectDropDownList.SelectedValue +
                                                    "'and{Student.VarBranchID}=" + brachId;
            SubjectWiseStudentListBoardExam.RefreshReport();
        }
        //else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
        //{
        //    report.Load(Server.MapPath("~/Reports/StudentListWithNameShorting.rpt"));
        //    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //    //if (textObject != null)
        //    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //    CrystalReportViewer1.ReportSource = report;
        //    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                            classDropDownList.SelectedValue +
        //                                            "' and {tbl_Present_class.VarSessionId}='" +
        //                                            sessionDropDownList.SelectedValue +
        //                                            "'and {tbl_Present_class.Status}='" + "P" +
        //                                            "'and{Student.VarBranchID}=" + brachId;
        //    //CrystalReportViewer1.DataBind();
        //    CrystalReportViewer1.RefreshReport();
        //}
        //else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
        //{
        //    failStatusLabel.InnerText = "Select Roll Short or Name Short";
        //}
        //else
        //{

        //    //report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
        //    report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
        //    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + ""; 
        //    //report.SetParameterValue("@gdf", brachId);
        //    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //    //if (textObject != null)
        //    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //    CrystalReportViewer1.ReportSource = report;
        //    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                            classDropDownList.SelectedValue +
        //                                            "' and {tbl_Present_class.VarSessionId}='" +
        //                                            sessionDropDownList.SelectedValue +
        //                                            "'and {tbl_Present_class.Status}='" + "P" +
        //                                            "'and{Student.VarBranchID}=" + brachId;
        //    CrystalReportViewer1.RefreshReport();
        //}
    }


    protected void qLevelDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        unitcodeDropDownList.Items.Clear();
        var getSubject = (from s in db.tbl_BoardSubjects
                          where s.QualificationLevel == qLevelDropDownList.SelectedValue
                          select new { s.SubName, s.SubCode }).Distinct();

        subjectDropDownList.DataSource = getSubject;
        subjectDropDownList.DataValueField = "SubCode";
        subjectDropDownList.DataTextField = "SubName";
        subjectDropDownList.DataBind();
        subjectDropDownList.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void subjectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        unitcodeDropDownList.Items.Clear();
        var checkUnit =
            db.tbl_BoardSubjects.FirstOrDefault(
                x =>
                    x.QualificationLevel == qLevelDropDownList.SelectedValue &&
                    x.SubCode == subjectDropDownList.SelectedValue);
        if (checkUnit != null && checkUnit.UnitCode != "")
        {
            var getUnit = (from s in db.tbl_BoardSubjects
                           where s.QualificationLevel == qLevelDropDownList.SelectedValue && s.SubCode == subjectDropDownList.SelectedValue
                           select new { s.UnitCode, s.UnitName });

            unitcodeDropDownList.DataSource = getUnit;
            unitcodeDropDownList.DataValueField = "UnitCode";
            unitcodeDropDownList.DataTextField = "UnitName";
            unitcodeDropDownList.DataBind();

        }
        //unitcodeDropDownList.Items.Insert(0, new ListItem("--Select--", ""));
    }
}