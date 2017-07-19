using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace ReportsUI
{
    public partial class ReportsUiAdmitCardGenerator : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                AdmitCardGenerators();
            }
            //var report = new ReportDocument();
            //report.Load(Server.MapPath("~/Reports/AdmitCard.rpt"));
            //string examName = string.Empty;
            //examName = examDropDownList.SelectedItem.Text;
            //var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
            //if (textObject != null) textObject.Text = examName;
        }

        protected void ShowButton_Click(object sender, EventArgs e)
        {
            successStatusLabel.InnerText = "";
            failStatusLabel.InnerText = "";
            AdmitCardGenerators();
        }

        private void AdmitCardGenerators()
        {
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/AdmitCard.rpt"));
            string examName = string.Empty;
            if (examDropDownList.SelectedItem != null)
            {
                examName = examDropDownList.SelectedItem.Text;
                var textObject = report.ReportDefinition.ReportObjects["examName"] as TextObject;
                if (textObject != null) textObject.Text = examName;
                if (sessionDropDownList.SelectedValue != "" && studentIdTextBox.Text != "" &&
                    classDropDownList.SelectedValue == "0")
                {
                    AdmitCardGenerator.ReportSource = report;
                    AdmitCardGenerator.SelectionFormula = "{tbl_Present_class.VarStudentID}='" + studentIdTextBox.Text +
                                                          "'AND {tbl_Present_class.VarSessionId}='" +
                                                          sessionDropDownList.SelectedValue +
                                                          "'and {tbl_Present_class.Status}='" + "P" + "'";
                    AdmitCardGenerator.RefreshReport();
                }
                else if (sessionDropDownList.SelectedValue != "" && studentIdTextBox.Text == "" &&
                         classDropDownList.SelectedValue != "0")
                {
                    if (sectionDropDownList.SelectedValue != "0")
                    {
                        AdmitCardGenerator.ReportSource = report;
                        AdmitCardGenerator.SelectionFormula = "{tbl_Present_class.VarClassID}='" +
                                                              classDropDownList.SelectedValue +
                                                              "'AND {tbl_Present_class.VarSessionId}='" +
                                                              sessionDropDownList.SelectedValue +
                                                              "'AND {tbl_Present_class.VarSection}='" +
                                                              sectionDropDownList.SelectedValue +
                                                              "'and {tbl_Present_class.Status}='" + "P" + "'";
                        AdmitCardGenerator.RefreshReport();
                    }
                    else
                    {
                        AdmitCardGenerator.ReportSource = report;
                        AdmitCardGenerator.SelectionFormula = "{tbl_Present_class.VarClassID}='" +
                                                              classDropDownList.SelectedValue +
                                                              "'AND {tbl_Present_class.VarSessionId}='" +
                                                              sessionDropDownList.SelectedValue +
                                                              "'and {tbl_Present_class.Status}='" + "P" + "'";
                        AdmitCardGenerator.RefreshReport();
                    }
                }
                else
                {
                    failStatusLabel.InnerText = "Please Insert Student ID OR Select Class.";
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