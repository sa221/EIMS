using System;
using System.Web.UI;

public partial class Admin_Role_Entry : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var tr = new tbl_role();
        tr.role_name = txtrole.Text;
        db.tbl_roles.InsertOnSubmit(tr);
        db.SubmitChanges();
        Literal1.Text = "Role saved";
        txtrole.Text = "";
        Response.Redirect("~/Admin/Role Entry.aspx");
    }
}