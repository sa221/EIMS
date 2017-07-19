using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employee_Whole_Employee_Info : Page
{
    private SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "cmd")
        {
            string s = ((Label) ListView1.Items[e.Item.DataItemIndex].FindControl("VarEmployeeidLabel")).Text;
            Session["VarEmployeeid"] =
                ((Label) ListView1.Items[e.Item.DataItemIndex].FindControl("VarEmployeeidLabel")).Text;
            Response.Redirect("~/Employee Search and update/Imployee Information Modify.aspx?VarEmployeeid=" + s);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //var data = db.Employees.Where(d => d.VarEmployeeid == Convert.ToInt32(TextBox1.Text)).ToList();
        //if (data != null)
        //{
        //    ListView1.DataSource = data;
        //    ListView1.DataBind();
        //}
        //else
        //{
        //    Literal1.Text = "User id is not available";

        //}
    }
}