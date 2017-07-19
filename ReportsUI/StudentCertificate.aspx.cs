using System;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_StudentCertificate : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CertificateGenerators();
    }

    protected void showButton_Click(object sender, EventArgs e)
    {
        CertificateGenerators();
    }

    private void CertificateGenerators()
    {
        var report = new ReportDocument();
        report.Load(Server.MapPath("~/Reports/StudentCertificate.rpt"));
        string examName = string.Empty;
        //if (examDropDownList.SelectedItem != null)
        //{
        //    examName = examDropDownList.SelectedItem.Text;
        //    TextObject textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
        //    if (textObject != null) textObject.Text = examName;
        //    if (sessionDropDownList.SelectedValue != "" && studentIdTextBox.Text != "" &&
        //        classDropDownList.SelectedValue == "0")
        //    {
        StudentCertificate.ReportSource = report;
        StudentCertificate.SelectionFormula = "{tbl_Present_class.VarStudentID}='" + studentIdTextBox.Text +
                                              "'AND {tbl_Present_class.VarSessionId}='" +
                                              sessionDropDownList.SelectedValue + "'and {tbl_Present_class.Status}='" +
                                              "P" + "'";
        StudentCertificate.RefreshReport();
        //}
        //else if (sessionDropDownList.SelectedValue != "" && studentIdTextBox.Text == "" &&
        //         classDropDownList.SelectedValue != "")
        //{
        //    if (sectionDropDownList.SelectedValue != "0")
        //    {
        //        AdmitCardGenerator.ReportSource = report;
        //        AdmitCardGenerator.SelectionFormula = "{tbl_Present_class.VarClassID}='" + classDropDownList.SelectedValue + "'AND {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'AND {tbl_Present_class.VarSection}='" + sectionDropDownList.SelectedValue + "'and {tbl_Present_class.Status}='" + "P" + "'";
        //        AdmitCardGenerator.RefreshReport();
        //    }
        //    else
        //    {
        //        AdmitCardGenerator.ReportSource = report;
        //        AdmitCardGenerator.SelectionFormula = "{tbl_Present_class.VarClassID}='" + classDropDownList.SelectedValue + "'AND {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'and {tbl_Present_class.Status}='" + "P" + "'";
        //        AdmitCardGenerator.RefreshReport();
        //    }

        //}
        //else
        //{
        //    failStatusLabel.InnerText = "Please Insert Student ID OR Select Class.";
        //}
        // }
    }
}