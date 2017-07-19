using System;
using System.Web.UI;

public partial class Admin_default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
            Label1.Text = Session["uid"].ToString();
    }
}