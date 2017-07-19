using System;
using System.Web.UI;

public partial class ReportsUI_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CrystalReportViewer1.RefreshReport();
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        CrystalReportViewer1.SelectionFormula = "{Class.VarClassID} ='" + classDropDownList.SelectedValue +
                                                "' and {tblSection.SectionId}='" + sectionDropDownList.SelectedValue +
                                                "'";
        CrystalReportViewer1.RefreshReport();
    }
}