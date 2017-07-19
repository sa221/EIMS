using System;
using System.Linq;
using System.Web.UI;

public partial class All_Set_Up_department : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void dptSave_Click(object sender, EventArgs e)
    {
        IQueryable<string> checkExistingdptId = from c in db.tbl_departments
            where c.dep_id.Contains(txtdptid.Text)
            select c.dep_id;

        if (checkExistingdptId.FirstOrDefault() == null)
        {
            var dpt = new tbl_department();
            dpt.uid = Session["uid"].ToString();
            dpt.VarBranchId = Session["VarBranchId"].ToString();
            dpt.VarShiftCode = Session["VarShiftCode"].ToString();
            dpt.dep_id = txtdptid.Text;
            dpt.dep_name = txtdptname.Text;
            db.tbl_departments.InsertOnSubmit(dpt);
            db.SubmitChanges();

            Literal1.Text = "department Saved Successfully";
            txtdptid.Text = "";
            txtdptname.Text = "";
            Response.Redirect("~/All Set Up/department.aspx");
        }
        else
        {
            Literal1.Text = "Department Already Exists";
        }
    }
}