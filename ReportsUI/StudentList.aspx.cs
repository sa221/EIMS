using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_StudentList : Page
{
    SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudentReport();
        }

    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        failStatusLabel.InnerText = "";
        successStatusLabel.InnerText = "";
        LoadStudentReport();
    }

    private void LoadStudentReport()
    {
        var report = new ReportDocument();

        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        //var br = db.Branches.FirstOrDefault(x => x.VarBranchID == brachId);
        // var getBrName = db.Branches.FirstOrDefault(x => x.VarBranchID == Convert.ToInt32(brachId));
        if (newSessionCheckBox.Checked)
        {
            if (sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue == "0")
            {
                if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionRoll.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    //CrystalReportViewer1.DataBind();
                    CrystalReportViewer1.RefreshReport();
                }
                else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionName.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    //CrystalReportViewer1.DataBind();
                    CrystalReportViewer1.RefreshReport();
                }
                else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    failStatusLabel.InnerText = "Select Roll Short or Name Short";
                }
                else
                {

                    //report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionId.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + ""; 
                    //report.SetParameterValue("@gdf", brachId);
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
            }
            else if (sectionDropDownList.SelectedValue != "0" && shiftDropDownList.SelectedValue == "0")
            {
                if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionRoll.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionName.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    failStatusLabel.InnerText = "Select Roll Short or Name Short";
                }
                else
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionId.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
            }
            else if (sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue != "0")
            {
                if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionRoll.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionName.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }

                else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    failStatusLabel.InnerText = "Select Roll Short or Name Short";
                }
                else
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionId.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
            }

            else
            {
                if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionRoll.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionName.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    failStatusLabel.InnerText = "Select Roll Short or Name Short";
                }
                else
                {
                    //
                    report.Load(Server.MapPath("~/Reports/StudentListNewSessionId.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
            }

        }
        else
        {
            if (sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue == "0")
            {
                if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithRollShorting.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    //CrystalReportViewer1.DataBind();
                    CrystalReportViewer1.RefreshReport();
                }
                else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithNameShorting.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    //CrystalReportViewer1.DataBind();
                    CrystalReportViewer1.RefreshReport();
                }
                else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    failStatusLabel.InnerText = "Select Roll Short or Name Short";
                }
                else
                {

                    //report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
                    report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + ""; 
                    //report.SetParameterValue("@gdf", brachId);
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
            }
            else if (sectionDropDownList.SelectedValue != "0" && shiftDropDownList.SelectedValue == "0")
            {
                if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithRollShorting.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithNameShorting.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    failStatusLabel.InnerText = "Select Roll Short or Name Short";
                }
                else
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
            }
            else if (sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue != "0")
            {
                if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithRollShorting.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithNameShorting.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }

                else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    failStatusLabel.InnerText = "Select Roll Short or Name Short";
                }
                else
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
            }

            else
            {
                if (sortingCheckBox.Checked && !nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithRollShorting.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (!sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    report.Load(Server.MapPath("~/Reports/StudentListWithNameShorting.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
                else if (sortingCheckBox.Checked && nameShortCheckBox.Checked)
                {
                    failStatusLabel.InnerText = "Select Roll Short or Name Short";
                }
                else
                {
                    //
                    report.Load(Server.MapPath("~/Reports/StudentListWithRoll.rpt"));
                    //report.DataDefinition.FormulaFields["gdf"].Text = "" + Session["VarBranchId"] + "";
                    //var textObject = report.ReportDefinition.ReportObjects["branchName"] as TextObject;
                    //if (textObject != null)
                    //    if (br != null) textObject.Text = "(" + br.VarBranchName + ")";
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                            classDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSection}='" +
                                                            sectionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarSessionId}='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and {tbl_Present_class.VarShiftCode}='" +
                                                            shiftDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" +
                                                            "'and{Student.VarBranchID}=" + brachId;
                    CrystalReportViewer1.RefreshReport();
                }
            }
        }
    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}