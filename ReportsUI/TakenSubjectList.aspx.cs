using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_TakenSubjectList : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadReport();
        }
    }

    protected void ShowButton_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

    private void LoadReport()
    {
        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        var report = new ReportDocument();
        if (studentIdTextBox.Text != "")
        {
            tbl_Present_class pcl = db.tbl_Present_classes.FirstOrDefault(x => x.VarStudentID == studentIdTextBox.Text);
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == pcl.VarClassID);
            if (cls != null && cls.ClassType == 2)
            {
                report.Load(Server.MapPath("~/Reports/StudentSubjectTakenListA-Level.rpt"));
                takenSubjectListCrystalReportViewer.ReportSource = report;
                //takenSubjectListCrystalReportViewer.DataBind();
                takenSubjectListCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarStudentID} ='" +
                                                                       studentIdTextBox.Text + "'and{tbl_EdexcelSubjectAssign.Session}='" + sessionDropDownList.SelectedValue +
                                                                       "'and {tbl_Present_class.Status}='" + "P" + "'and{Student.VarBranchID}=" + brachId;
                takenSubjectListCrystalReportViewer.RefreshReport();
            }
            else if (cls != null && cls.ClassType == 1)
            {
                report.Load(Server.MapPath("~/Reports/StudentTakenSubjectListO-Level.rpt"));
                takenSubjectListCrystalReportViewer.ReportSource = report;
                // takenSubjectListCrystalReportViewer.DataBind();
                takenSubjectListCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarStudentID} ='" +
                                                                       studentIdTextBox.Text + "'and{tbl_StudentSubjectAssign.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                                                       "'and {tbl_Present_class.Status}='" + "P" + "'and{Student.VarBranchID}=" + brachId;
                takenSubjectListCrystalReportViewer.RefreshReport();
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/StudentSubjectTakenList.rpt"));
                takenSubjectListCrystalReportViewer.ReportSource = report;
                //takenSubjectListCrystalReportViewer.DataBind();
                takenSubjectListCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarStudentID} ='" +
                                                                       studentIdTextBox.Text +
                                                                       "'and {tbl_Present_class.Status}='" + "P" + "'and{Student.VarBranchID}=" + brachId;
                takenSubjectListCrystalReportViewer.RefreshReport();
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
                    report.Load(Server.MapPath("~/Reports/StudentSubjectTakenListA-Level.rpt"));
                    takenSubjectListCrystalReportViewer.ReportSource = report;
                    //takenSubjectListCrystalReportViewer.DataBind();
                    takenSubjectListCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                           classDropDownList.SelectedValue +
                                                                           "'and{tbl_EdexcelSubjectAssign.Session}='" + sessionDropDownList.SelectedValue +
                                                                           "'and {tbl_Present_class.Status}='" + "P" +
                                                                           "'and{Student.VarBranchID}=" + brachId;
                    takenSubjectListCrystalReportViewer.RefreshReport();
                }
                else if (sessionDropDownList.SelectedValue != "" &&
                         classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
                {
                    report.Load(Server.MapPath("~/Reports/StudentSubjectTakenListA-Level.rpt"));
                    takenSubjectListCrystalReportViewer.ReportSource = report;
                    //takenSubjectListCrystalReportViewer.DataBind();
                    takenSubjectListCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                           classDropDownList.SelectedValue +
                                                                           "'and{tbl_EdexcelSubjectAssign.Session}='" + sessionDropDownList.SelectedValue +
                                                                           "'and {tbl_Present_class.VarSection}='" +
                                                                           sectionDropDownList.SelectedValue +
                                                                           "'and {tbl_Present_class.Status}='" + "P" +
                                                                           "'and{Student.VarBranchID}=" + brachId;
                    takenSubjectListCrystalReportViewer.RefreshReport();
                }
            }
            else if (cls != null && cls.ClassType == 1)
            {
                if (sessionDropDownList.SelectedValue != "" && sectionDropDownList.SelectedValue == "0" &&
                    classDropDownList.SelectedValue != "0")
                {
                    report.Load(Server.MapPath("~/Reports/StudentTakenSubjectListO-Level.rpt"));
                    takenSubjectListCrystalReportViewer.ReportSource = report;
                    //takenSubjectListCrystalReportViewer.DataBind();
                    takenSubjectListCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                           classDropDownList.SelectedValue +
                                                                           "'and{tbl_StudentSubjectAssign.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                                                           "'and {tbl_Present_class.Status}='" + "P" +
                                                                           "'and{Student.VarBranchID}=" + brachId;
                    takenSubjectListCrystalReportViewer.RefreshReport();
                }
                else if (sessionDropDownList.SelectedValue != "" &&
                         classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
                {
                    report.Load(Server.MapPath("~/Reports/StudentTakenSubjectListO-Level.rpt"));
                    takenSubjectListCrystalReportViewer.ReportSource = report;
                    //takenSubjectListCrystalReportViewer.DataBind();
                    takenSubjectListCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                           classDropDownList.SelectedValue +
                                                                           "'and{tbl_StudentSubjectAssign.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                                                           "'and {tbl_Present_class.VarSection}='" +
                                                                           sectionDropDownList.SelectedValue +
                                                                           "'and {tbl_Present_class.Status}='" + "P" +
                                                                           "'and{Student.VarBranchID}=" + brachId;
                    takenSubjectListCrystalReportViewer.RefreshReport();
                }
            }
            else
            {
                if (sessionDropDownList.SelectedValue != "" && sectionDropDownList.SelectedValue == "0" &&
                    classDropDownList.SelectedValue != "0")
                {
                    report.Load(Server.MapPath("~/Reports/StudentSubjectTakenList.rpt"));
                    takenSubjectListCrystalReportViewer.ReportSource = report;
                    takenSubjectListCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                           classDropDownList.SelectedValue +
                                                                           "'and {tbl_Present_class.Status}='" + "P" +
                                                                           "'and{Student.VarBranchID}=" + brachId;
                    takenSubjectListCrystalReportViewer.RefreshReport();
                }
                else if (sessionDropDownList.SelectedValue != "" &&
                         classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
                {
                    report.Load(Server.MapPath("~/Reports/StudentSubjectTakenList.rpt"));
                    takenSubjectListCrystalReportViewer.ReportSource = report;
                    takenSubjectListCrystalReportViewer.SelectionFormula = "{tbl_Present_class.VarClassId} ='" +
                                                                           classDropDownList.SelectedValue +
                                                                           "'and {tbl_Present_class.VarSection}='" +
                                                                           sectionDropDownList.SelectedValue +
                                                                           "'and {tbl_Present_class.Status}='" + "P" +
                                                                           "'and{Student.VarBranchID}=" + brachId;
                    takenSubjectListCrystalReportViewer.RefreshReport();
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
