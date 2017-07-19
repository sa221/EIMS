using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        else
        {
            Label1.Text = Session["uid"].ToString();
        }
    }

    protected void NavigationMenu_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        if (!Page.User.IsInRole("SuperAdmin"))
        {
            if (e.Item.NavigateUrl.Equals("/Admin/"))
            {
                if (e.Item.Parent != null)
                {
                    MenuItem menu = e.Item.Parent;

                    menu.ChildItems.Remove(e.Item);
                }
                else
                {
                    var menu = (Menu) sender;

                    menu.Items.Remove(e.Item);
                }
            }
        }
    }
}