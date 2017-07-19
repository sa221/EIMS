using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Info2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void ListView1_ItemCommand1(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "cmd")
        {
            string s = ((Label) ListView1.Items[e.Item.DataItemIndex].FindControl("VarStudentIDLabel")).Text;
            Session["VarStudentID"] =
                ((Label) ListView1.Items[e.Item.DataItemIndex].FindControl("VarStudentIDLabel")).Text;
            Response.Redirect("~/Student Info Search and update/Student Admission Modify.aspx?VarStudentID=" + s);
        }
    }
}