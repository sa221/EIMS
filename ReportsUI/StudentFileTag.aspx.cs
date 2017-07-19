using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_StudentFileTag : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void createButton_Click(object sender, EventArgs e)
    {
        if (classDropDownList.SelectedValue != "0" && studentIdTextBox.Text == "")
        {
            if (sectionDropDownList.SelectedValue != "0")
            {
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/StudentFileTag.rpt"));
                StudentFileTagReport.ReportSource = report;
                StudentFileTagReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                        classDropDownList.SelectedValue +
                                                        "'and {tbl_Present_class.VarSection}='" +
                                                        sectionDropDownList.SelectedValue +
                                                        "'and {tbl_Present_class.Status}='" + "P" + "'";
                StudentFileTagReport.RefreshReport();
            }
            else
            {
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/StudentFileTag.rpt"));
                StudentFileTagReport.ReportSource = report;
                StudentFileTagReport.SelectionFormula = "{tbl_Present_class.VarClassID} ='" +
                                                        classDropDownList.SelectedValue +
                                                        "'and {tbl_Present_class.Status}='" + "P" + "'";
                StudentFileTagReport.RefreshReport();
            }
        }
        else if (classDropDownList.SelectedValue == "0" && studentIdTextBox.Text != "")
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/StudentFileTag.rpt"));
            StudentFileTagReport.ReportSource = report;
            StudentFileTagReport.SelectionFormula = "{tbl_Present_class.VarStudentID} ='" + studentIdTextBox.Text +
                                                    "'and {tbl_Present_class.Status}='" + "P" + "'";
            StudentFileTagReport.RefreshReport();
        }
    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}