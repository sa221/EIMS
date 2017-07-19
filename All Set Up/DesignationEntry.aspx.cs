using System;
using System.Linq;
using System.Web.UI;

public partial class Employee_DesignationEntry : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (IsPostBack != null)
        //{


        //    if (Session["uid"] != null)
        //        txtuid.Text = Session["uid"].ToString();

        //    if (Session["VarBranchId"] != null)
        //        DropDownBranch.SelectedValue = Session["VarBranchId"].ToString();
        //    if (Session["VarShiftCode"] != null)
        //        drpshift.SelectedValue = Session["VarShiftCode"].ToString();

        //}
    }

    //protected void desigSave_Click(object sender, EventArgs e)
    //{
    //    IQueryable<string> checkExistingdesigId = from c in db.EmployeeDesignations
    //        where c.NumDesignationId==(Convert.ToInt32(txtEmpDegId.Text))
    //        select c.NumDesignationId;

    //    if (checkExistingdesigId.FirstOrDefault() == null)
    //    {
    //        var desig = new EmployeeDesignation();
    //        desig.uid = Session["uid"].ToString();
    //        desig.VarBranchId = Session["VarBranchId"].ToString();
    //        desig.VarShiftCode = Session["VarShiftCode"].ToString();
    //        desig.NumDesignationId = txtEmpDegId.Text;
    //        desig.VarDesignationName = txtEmpDegName.Text;
    //        db.EmployeeDesignations.InsertOnSubmit(desig);
    //        db.SubmitChanges();
    //        Literal1.Text = "Designation entry successful";
    //        Response.Redirect("~/All Set Up/DesignationEntry.aspx");

    //        txtEmpDegId.Text = "";
    //        txtEmpDegName.Text = "";
    //    }
    //    else
    //    {
    //        Literal1.Text = "Designation already exists";
    //    }
    //}
}