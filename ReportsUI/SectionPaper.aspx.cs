using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_SectionPaper : Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    private readonly ReportDocument report = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        SectionPaperGenerate();
    }

    protected void showButton_Click(object sender, EventArgs e)
    {
        tbl_EdexcelSubjectAssign getEdeStudent =
            db.tbl_EdexcelSubjectAssigns.FirstOrDefault(
                x => x.Session == sessionDropDownList.SelectedValue && x.StudentId == studentIdTextBox.Text);
        SectionPaperGenerate();
        //report.Close();
    }

    public void SectionPaperGenerate()
    {
        report.Load(Server.MapPath("~/Reports/SectionPaper.rpt"));
        SectionPaperGenerator.ReportSource = report;
        SectionPaperGenerator.SelectionFormula = "{tbl_Present_class.VarStudentID}='" + studentIdTextBox.Text +
                                                 "'AND {tbl_Present_class.VarSessionId}='" +
                                                 sessionDropDownList.SelectedValue + "'and {tbl_Present_class.Status}='" +
                                                 "P" + "'";
        SectionPaperGenerator.RefreshReport();
        //report.Close();
    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}