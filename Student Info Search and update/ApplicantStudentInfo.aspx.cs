using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ApplicantStudentInfo : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "cmd")
        {
            string s = ((Label) ListView1.Items[e.Item.DataItemIndex].FindControl("varRegistrationIdLabel")).Text;
            Session["varRegistrationId"] =
                ((Label) ListView1.Items[e.Item.DataItemIndex].FindControl("varRegistrationIdLabel")).Text;
            Response.Redirect("~/Student Info Entry/StudentAddmission.aspx?varRegistrationId=" + s);
        }
    }
}