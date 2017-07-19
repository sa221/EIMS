using System;
using System.Web.UI;

public partial class Admin_admin : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uID"] != null)
            Label1.Text = Session["uID"].ToString();
    }
}