using System;
using System.Web.UI;

public partial class ReportsUI_StudentListWithPhone : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StudentListWithMobileViewer.RefreshReport();
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        //string cls = "{tbl_Present_class.VarClassID} ='" + classDropDownList.SelectedValue + "' ";
        //string section = "{tbl_Present_class.VarSessionId} ='" + sectionDropDownList.SelectedValue + "'";
        //StudentListWithMobileViewer.SelectionFormula = cls + " and " + section;
        //string test = StudentListWithMobileViewer.SelectionFormula;
        StudentListWithMobileViewer.RefreshReport();
    }
}