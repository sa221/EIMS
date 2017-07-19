using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_BoardExamineeList : System.Web.UI.Page
{
    SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadExamineeStudentReport();
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
        //examSessionDropDownList.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        failStatusLabel.InnerText = "";
        successStatusLabel.InnerText = "";
        LoadExamineeStudentReport();
    }
    private void LoadExamineeStudentReport()
    {
        var report = new ReportDocument();

        string brachId = (string)Session["VarBranchId"];
        if (sessionDropDownList.SelectedValue != "0")
        {
            if (classDropDownList.SelectedValue == "0" && boardDropDownList.SelectedValue == "0" && qLevelDropDownList.SelectedValue == "0")
            {

                report.Load(Server.MapPath("~/Reports/BoardExaminee.rpt"));
                BoardExamineeReport.ReportSource = report;
                BoardExamineeReport.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" +
                                                       sessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.ExamSession}='" + examSessionDropDownList.SelectedValue +
                                                        "'and{tbl_BoardExamSubAssign.VarBranchId}='" + brachId + "'";
                BoardExamineeReport.RefreshReport();
            }
            else if (classDropDownList.SelectedValue == "0" && boardDropDownList.SelectedValue == "0" && qLevelDropDownList.SelectedValue != "0")
            {

                report.Load(Server.MapPath("~/Reports/BoardExaminee.rpt"));
                BoardExamineeReport.ReportSource = report;
                BoardExamineeReport.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" + sessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.ExamSession}='" + examSessionDropDownList.SelectedValue +
                                                        //"' and {tbl_BoardExamSubAssign.Class}='" + classDropDownList.SelectedValue +
                                                        //"' and {tbl_BoardExamSubAssign.Board}='" + boardDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.QualificationLevel}='" + qLevelDropDownList.SelectedValue +
                                                        "'and{tbl_BoardExamSubAssign.VarBranchId}='" + brachId + "'";
                BoardExamineeReport.RefreshReport();
            }
            else if (classDropDownList.SelectedValue == "0" && boardDropDownList.SelectedValue != "0" && qLevelDropDownList.SelectedValue == "0")
            {

                report.Load(Server.MapPath("~/Reports/BoardExaminee.rpt"));
                BoardExamineeReport.ReportSource = report;
                BoardExamineeReport.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" + sessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.ExamSession}='" + examSessionDropDownList.SelectedValue +
                                                        //"' and {tbl_BoardExamSubAssign.Class}='" + classDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.Board}='" + boardDropDownList.SelectedValue +
                                                        //"' and {tbl_BoardExamSubAssign.QualificationLevel}='" + qLevelDropDownList.SelectedValue +
                                                        "'and{tbl_BoardExamSubAssign.VarBranchId}='" + brachId + "'";
                BoardExamineeReport.RefreshReport();
            }
            else if (classDropDownList.SelectedValue != "0" && boardDropDownList.SelectedValue == "0" && qLevelDropDownList.SelectedValue == "0")
            {

                report.Load(Server.MapPath("~/Reports/BoardExaminee.rpt"));
                BoardExamineeReport.ReportSource = report;
                BoardExamineeReport.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" + sessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.ExamSession}='" + examSessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.Class}='" + classDropDownList.SelectedValue +
                                                        //"' and {tbl_BoardExamSubAssign.Board}='" + boardDropDownList.SelectedValue +
                                                        //"' and {tbl_BoardExamSubAssign.QualificationLevel}='" + qLevelDropDownList.SelectedValue +
                                                        "'and{tbl_BoardExamSubAssign.VarBranchId}='" + brachId + "'";
                BoardExamineeReport.RefreshReport();
            }
            else if (classDropDownList.SelectedValue == "0" && boardDropDownList.SelectedValue != "0" && qLevelDropDownList.SelectedValue != "0")
            {

                report.Load(Server.MapPath("~/Reports/BoardExaminee.rpt"));
                BoardExamineeReport.ReportSource = report;
                BoardExamineeReport.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" + sessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.ExamSession}='" + examSessionDropDownList.SelectedValue +
                                                        //"' and {tbl_BoardExamSubAssign.Class}='" + classDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.Board}='" + boardDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.QualificationLevel}='" + qLevelDropDownList.SelectedValue +
                                                        "'and{tbl_BoardExamSubAssign.VarBranchId}='" + brachId + "'";
                BoardExamineeReport.RefreshReport();
            }
            else if (classDropDownList.SelectedValue != "0" && boardDropDownList.SelectedValue == "0" && qLevelDropDownList.SelectedValue != "0")
            {

                report.Load(Server.MapPath("~/Reports/BoardExaminee.rpt"));
                BoardExamineeReport.ReportSource = report;
                BoardExamineeReport.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" + sessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.ExamSession}='" + examSessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.Class}='" + classDropDownList.SelectedValue +
                                                        //"' and {tbl_BoardExamSubAssign.Board}='" + boardDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.QualificationLevel}='" + qLevelDropDownList.SelectedValue +
                                                        "'and{tbl_BoardExamSubAssign.VarBranchId}='" + brachId + "'";
                BoardExamineeReport.RefreshReport();
            }
            else if (classDropDownList.SelectedValue != "0" && boardDropDownList.SelectedValue != "0" && qLevelDropDownList.SelectedValue == "0")
            {

                report.Load(Server.MapPath("~/Reports/BoardExaminee.rpt"));
                BoardExamineeReport.ReportSource = report;
                BoardExamineeReport.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" + sessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.ExamSession}='" + examSessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.Class}='" + classDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.Board}='" + boardDropDownList.SelectedValue +
                                                        //"' and {tbl_BoardExamSubAssign.QualificationLevel}='" + qLevelDropDownList.SelectedValue +
                                                        "'and{tbl_BoardExamSubAssign.VarBranchId}='" + brachId + "'";
                BoardExamineeReport.RefreshReport();
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/BoardExaminee.rpt"));
                BoardExamineeReport.ReportSource = report;
                BoardExamineeReport.SelectionFormula = "{tbl_BoardExamSubAssign.Session} ='" + sessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.ExamSession}='" + examSessionDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.Class}='" + classDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.Board}='" + boardDropDownList.SelectedValue +
                                                        "' and {tbl_BoardExamSubAssign.QualificationLevel}='" + qLevelDropDownList.SelectedValue +
                                                        "'and{tbl_BoardExamSubAssign.VarBranchId}='" + brachId + "'";
                BoardExamineeReport.RefreshReport();
            }
        }
        else
        {
            failStatusLabel.InnerText = "Please Select Session.";
        }

        //else if (sectionDropDownList.SelectedValue != "0" && shiftDropDownList.SelectedValue == "0")
        //{
        //    if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
        //    {
        //        report.Load(Server.MapPath("~/Reports/StudentListWithRollShorting.rpt"));
        //        //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //        //if (textObject != null)
        //        //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //        BoardExamineeReport.ReportSource = report;
        //        BoardExamineeReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                                classDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSessionId}='" +
        //                                                sessionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSection}='" +
        //                                                sectionDropDownList.SelectedValue +
        //                                                "'and {tbl_Present_class.Status}='" + "P" +
        //                                                "'and{Student.VarBranchID}=" + brachId;
        //        BoardExamineeReport.RefreshReport();
        //    }
        //    else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
        //    {
        //        report.Load(Server.MapPath("~/Reports/StudentListWithNameShorting.rpt"));
        //        //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //        //if (textObject != null)
        //        //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //        BoardExamineeReport.ReportSource = report;
        //        BoardExamineeReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                                classDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSessionId}='" +
        //                                                sessionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSection}='" +
        //                                                sectionDropDownList.SelectedValue +
        //                                                "'and {tbl_Present_class.Status}='" + "P" +
        //                                                "'and{Student.VarBranchID}=" + brachId;
        //        BoardExamineeReport.RefreshReport();
        //    }
        //    else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
        //    {
        //        failStatusLabel.InnerText = "Select Roll Short or Name Short";
        //    }
        //    else
        //    {
        //        report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
        //        //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //        //if (textObject != null)
        //        //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //        BoardExamineeReport.ReportSource = report;
        //        BoardExamineeReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                                classDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSessionId}='" +
        //                                                sessionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSection}='" +
        //                                                sectionDropDownList.SelectedValue +
        //                                                "'and {tbl_Present_class.Status}='" + "P" +
        //                                                "'and{Student.VarBranchID}=" + brachId;
        //        BoardExamineeReport.RefreshReport();
        //    }
        //}
        //else if (sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue != "0")
        //{
        //    if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
        //    {
        //        report.Load(Server.MapPath("~/Reports/StudentListWithRollShorting.rpt"));
        //        //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //        //if (textObject != null)
        //        //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //        BoardExamineeReport.ReportSource = report;
        //        BoardExamineeReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                                classDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSessionId}='" +
        //                                                sessionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarShiftCode}='" +
        //                                                shiftDropDownList.SelectedValue +
        //                                                "'and {tbl_Present_class.Status}='" + "P" +
        //                                                "'and{Student.VarBranchID}=" + brachId;
        //        BoardExamineeReport.RefreshReport();
        //    }
        //    else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
        //    {
        //        report.Load(Server.MapPath("~/Reports/StudentListWithNameShorting.rpt"));
        //        //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //        //if (textObject != null)
        //        //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //        BoardExamineeReport.ReportSource = report;
        //        BoardExamineeReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                                classDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSessionId}='" +
        //                                                sessionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarShiftCode}='" +
        //                                                shiftDropDownList.SelectedValue +
        //                                                "'and {tbl_Present_class.Status}='" + "P" +
        //                                                "'and{Student.VarBranchID}=" + brachId;
        //        BoardExamineeReport.RefreshReport();
        //    }

        //    else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
        //    {
        //        failStatusLabel.InnerText = "Select Roll Short or Name Short";
        //    }
        //    else
        //    {
        //        report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
        //        //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //        //if (textObject != null)
        //        //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //        BoardExamineeReport.ReportSource = report;
        //        BoardExamineeReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                                classDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSessionId}='" +
        //                                                sessionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarShiftCode}='" +
        //                                                shiftDropDownList.SelectedValue +
        //                                                "'and {tbl_Present_class.Status}='" + "P" +
        //                                                "'and{Student.VarBranchID}=" + brachId;
        //        BoardExamineeReport.RefreshReport();
        //    }
        //}

        //else
        //{
        //    if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
        //    {
        //        report.Load(Server.MapPath("~/Reports/StudentListWithRollShorting.rpt"));
        //        //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //        //if (textObject != null)
        //        //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //        BoardExamineeReport.ReportSource = report;
        //        BoardExamineeReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                                classDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSection}='" +
        //                                                sectionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSessionId}='" +
        //                                                sessionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarShiftCode}='" +
        //                                                shiftDropDownList.SelectedValue +
        //                                                "'and {tbl_Present_class.Status}='" + "P" +
        //                                                "'and{Student.VarBranchID}=" + brachId;
        //        BoardExamineeReport.RefreshReport();
        //    }
        //    else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
        //    {
        //        report.Load(Server.MapPath("~/Reports/StudentListWithNameShorting.rpt"));
        //        //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //        //if (textObject != null)
        //        //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //        BoardExamineeReport.ReportSource = report;
        //        BoardExamineeReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                                classDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSection}='" +
        //                                                sectionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSessionId}='" +
        //                                                sessionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarShiftCode}='" +
        //                                                shiftDropDownList.SelectedValue +
        //                                                "'and {tbl_Present_class.Status}='" + "P" +
        //                                                "'and{Student.VarBranchID}=" + brachId;
        //        BoardExamineeReport.RefreshReport();
        //    }
        //    else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
        //    {
        //        failStatusLabel.InnerText = "Select Roll Short or Name Short";
        //    }
        //    else
        //    {
        //        //
        //        report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
        //        //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
        //        //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
        //        //if (textObject != null)
        //        //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
        //        BoardExamineeReport.ReportSource = report;
        //        BoardExamineeReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
        //                                                classDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSection}='" +
        //                                                sectionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarSessionId}='" +
        //                                                sessionDropDownList.SelectedValue +
        //                                                "' and {tbl_Present_class.VarShiftCode}='" +
        //                                                shiftDropDownList.SelectedValue +
        //                                                "'and {tbl_Present_class.Status}='" + "P" +
        //                                                "'and{Student.VarBranchID}=" + brachId;
        //        BoardExamineeReport.RefreshReport();
        //    }
    }

}