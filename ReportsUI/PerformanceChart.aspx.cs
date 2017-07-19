using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace ReportsUI
{
    public partial class ReportsUiPerformanceChart : Page
    {
        private readonly SWISDataContext db = new SWISDataContext();
        private string reportId = "PerformanceChart";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudentReport();
            }
        }

        protected void ShowButton_Click(object sender, EventArgs e)
        {
            var isExist =
                db.Temp_ReportTextObjects.FirstOrDefault(
                    x =>
                        x.VarReport == reportId && x.VarUser == Session["uid"].ToString() &&
                        x.VarBranch == Convert.ToInt32(Session["VarBranchId"].ToString()));
            if (isExist != null)
            {
                isExist.VarTextObject = descTextBox.Text;
                db.SubmitChanges();
            }
            else
            {
                Temp_ReportTextObject reportText = new Temp_ReportTextObject();
                reportText.VarTextObject = descTextBox.Text;
                reportText.VarReport = reportId;
                reportText.VarUser = Session["uid"].ToString();
                reportText.VarBranch = Convert.ToInt32(Session["VarBranchId"].ToString());
                db.Temp_ReportTextObjects.InsertOnSubmit(reportText);
                db.SubmitChanges();
            }
            LoadStudentReport();
        }

        private void LoadStudentReport()
        {
            int brachId = Convert.ToInt32(Session["VarBranchId"]);
            var report = new ReportDocument();
            if (studentIdTextBox.Text != "")
            {
                tbl_Present_class pcl = db.tbl_Present_classes.FirstOrDefault(x => x.VarStudentID == studentIdTextBox.Text);
                Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == pcl.VarClassID);
                if (cls != null && cls.ClassType == 2)
                {
                    report.Load(Server.MapPath("~/Reports/SPC_A_Level_Class.rpt"));
                    performanceChartCrystalReportViewer.ReportSource = report;
                    performanceChartCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarStudentID} ='" +
                                                                           studentIdTextBox.Text +
                                                                           "'and {tbl_Present_class.Status}='" + "P" +
                                                                           "'and {Temp_ReportTextObject.VarReport}='" + reportId +
                                                                           //"'and {Temp_ReportTextObject.VarBranch}='" + brachId +
                                                                           "'and {Temp_ReportTextObject.VarUser}='" + Session["uid"] +
                                                                           "'and{Student.VarBranchID}=" + brachId;
                    performanceChartCrystalReportViewer.RefreshReport();
                    //{Temp_ReportTextObject.VarReport}{Temp_ReportTextObject.VarBranch}{Temp_ReportTextObject.VarUser}
                }
                else if (cls != null && cls.ClassType == 1)
                {
                    report.Load(Server.MapPath("~/Reports/SPC_O_Level_Class.rpt"));
                    performanceChartCrystalReportViewer.ReportSource = report;
                    performanceChartCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarStudentID} ='" +
                                                                           studentIdTextBox.Text +
                                                                           "'and {tbl_Present_class.Status}='" + "P" +
                                                                           "'and {Temp_ReportTextObject.VarReport}='" + reportId +
                                                                           //"'and {Temp_ReportTextObject.VarBranch}='" + brachId +
                                                                           "'and {Temp_ReportTextObject.VarUser}='" + Session["uid"] +
                                                                           "'and{Student.VarBranchID}=" + brachId;
                    performanceChartCrystalReportViewer.RefreshReport();
                }
                else
                {
                    report.Load(Server.MapPath("~/Reports/SPCJuniorClass.rpt"));
                    performanceChartCrystalReportViewer.ReportSource = report;
                    //performanceChartCrystalReportViewer.DataBind();
                    performanceChartCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarStudentID} ='" +
                                                                           studentIdTextBox.Text +
                                                                           "'and {tbl_Present_class.Status}='" + "P" +
                                                                           "'and {Temp_ReportTextObject.VarReport}='" + reportId +
                                                                           //"'and {Temp_ReportTextObject.VarBranch}='" + brachId +
                                                                           "'and {Temp_ReportTextObject.VarUser}='" + Session["uid"] +
                                                                           "'and{Student.VarBranchID}=" + brachId;
                    performanceChartCrystalReportViewer.RefreshReport();
                }
            }
            else
            {
                Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
                if (cls != null && cls.ClassType == 2)
                {
                    if (sessionDropDownList.SelectedValue != "" && sectionDropDownList.SelectedValue == "0" &&
                        classDropDownList.SelectedValue != "0")
                    {
                        report.Load(Server.MapPath("~/Reports/SPC_A_Level_Class.rpt"));
                        performanceChartCrystalReportViewer.ReportSource = report;
                        //performanceChartCrystalReportViewer.DataBind();
                        performanceChartCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                               classDropDownList.SelectedValue +
                                                                               "'and {tbl_Present_class.Status}='" + "P" +
                                                                               "'and {Temp_ReportTextObject.VarReport}='" + reportId +
                                                                           //"'and {Temp_ReportTextObject.VarBranch}='" + brachId +
                                                                           "'and {Temp_ReportTextObject.VarUser}='" + Session["uid"] +
                                                                               "'and{Student.VarBranchID}=" + brachId;
                        performanceChartCrystalReportViewer.RefreshReport();
                    }
                    else if (sessionDropDownList.SelectedValue != "" &&
                             classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
                    {
                        report.Load(Server.MapPath("~/Reports/SPC_A_Level_Class.rpt"));
                        performanceChartCrystalReportViewer.ReportSource = report;
                        //performanceChartCrystalReportViewer.DataBind();
                        performanceChartCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                               classDropDownList.SelectedValue +
                                                                               "'and {tbl_Present_class.VarSection}='" +
                                                                               sectionDropDownList.SelectedValue +
                                                                               "'and {tbl_Present_class.Status}='" + "P" +
                                                                               "'and {Temp_ReportTextObject.VarReport}='" + reportId +
                                                                           //"'and {Temp_ReportTextObject.VarBranch}='" + brachId +
                                                                           "'and {Temp_ReportTextObject.VarUser}='" + Session["uid"] +
                                                                               "'and{Student.VarBranchID}=" + brachId;
                        performanceChartCrystalReportViewer.RefreshReport();
                    }
                }
                else if (cls != null && cls.ClassType == 1)
                {
                    if (sessionDropDownList.SelectedValue != "" && sectionDropDownList.SelectedValue == "0" &&
                        classDropDownList.SelectedValue != "0")
                    {
                        report.Load(Server.MapPath("~/Reports/SPC_O_Level_Class.rpt"));
                        performanceChartCrystalReportViewer.ReportSource = report;
                        //performanceChartCrystalReportViewer.DataBind();
                        performanceChartCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                               classDropDownList.SelectedValue +
                                                                               "'and {tbl_Present_class.Status}='" + "P" +
                                                                               "'and {Temp_ReportTextObject.VarReport}='" + reportId +
                                                                           //"'and {Temp_ReportTextObject.VarBranch}='" + brachId +
                                                                           "'and {Temp_ReportTextObject.VarUser}='" + Session["uid"] +
                                                                               "'and{Student.VarBranchID}=" + brachId;
                        performanceChartCrystalReportViewer.RefreshReport();
                    }
                    else if (sessionDropDownList.SelectedValue != "" &&
                             classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
                    {
                        report.Load(Server.MapPath("~/Reports/SPC_O_Level_Class.rpt"));
                        performanceChartCrystalReportViewer.ReportSource = report;
                        //performanceChartCrystalReportViewer.DataBind();
                        performanceChartCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                               classDropDownList.SelectedValue +
                                                                               "'and {tbl_Present_class.VarSection}='" +
                                                                               sectionDropDownList.SelectedValue +
                                                                               "'and {tbl_Present_class.Status}='" + "P" +
                                                                               "'and {Temp_ReportTextObject.VarReport}='" + reportId +
                                                                           //"'and {Temp_ReportTextObject.VarBranch}='" + brachId +
                                                                           "'and {Temp_ReportTextObject.VarUser}='" + Session["uid"] +
                                                                               "'and{Student.VarBranchID}=" + brachId;
                        performanceChartCrystalReportViewer.RefreshReport();
                    }
                }
                else
                {
                    if (sessionDropDownList.SelectedValue != "" && sectionDropDownList.SelectedValue == "0" &&
                        classDropDownList.SelectedValue != "0")
                    {
                        report.Load(Server.MapPath("~/Reports/SPCJuniorClass.rpt"));
                        performanceChartCrystalReportViewer.ReportSource = report;
                        performanceChartCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                               classDropDownList.SelectedValue +
                                                                               "'and {tbl_Present_class.Status}='" + "P" +
                                                                               "'and {Temp_ReportTextObject.VarReport}='" + reportId +
                                                                           //"'and {Temp_ReportTextObject.VarBranch}='" + brachId +
                                                                           "'and {Temp_ReportTextObject.VarUser}='" + Session["uid"] +
                                                                               "'and{Student.VarBranchID}=" + brachId;
                        performanceChartCrystalReportViewer.RefreshReport();
                    }
                    else if (sessionDropDownList.SelectedValue != "" &&
                             classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
                    {
                        report.Load(Server.MapPath("~/Reports/SPCJuniorClass.rpt"));
                        performanceChartCrystalReportViewer.ReportSource = report;
                        performanceChartCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                               classDropDownList.SelectedValue +
                                                                               "'and {tbl_Present_class.VarSection}='" +
                                                                               sectionDropDownList.SelectedValue +
                                                                               "'and {tbl_Present_class.Status}='" + "P" +
                                                                               "'and {Temp_ReportTextObject.VarReport}='" + reportId +
                                                                           //"'and {Temp_ReportTextObject.VarBranch}='" + brachId +
                                                                           "'and {Temp_ReportTextObject.VarUser}='" + Session["uid"] +
                                                                              "'and{Student.VarBranchID}=" + brachId;
                        performanceChartCrystalReportViewer.RefreshReport();
                    }
                }
            }
        }

        protected void classDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            sectionDropDownList.Items.Clear();
            sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
}