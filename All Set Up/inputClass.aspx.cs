using System;
using System.Web.UI;

public partial class inputClass : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != null)
        {
            //if (Session["uid"] != null)
            //    Textuid.Text = Session["uid"].ToString();

            //if (Session["VarBranchId"] != null)
            //    DropDownBranch.SelectedValue = Session["VarBranchId"].ToString();
            //if ()
            //    drpshift.SelectedValue = Session["VarShiftCode"].ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var cl = new Class();
        if (Session["uid"] != null)
        {
            cl.uid = Session["uid"].ToString();
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        if (Session["VarBranchId"] != null)
        {
            cl.VarBranchId = Session["VarBranchId"].ToString();
        }
        if (Session["VarShiftCode"] != null)
        {
            cl.VarShiftCode = Session["VarShiftCode"].ToString();
        }
        if (houseDropDownList.SelectedValue != "0")
        {
            cl.houseid = houseDropDownList.SelectedValue;
        }
        else
        {
            cl.houseid = "N/A";
        }
        cl.VarClassID = txtClassCode.Text;
        cl.VarClassName = txtclass.Text;
        if (typeCheckBox.Checked)
        {
            cl.ClassType = 2;
        }
        else
        {
            cl.ClassType = 1;
        }
        if (edexcelRB.Checked)
        {
            cl.Board = "EDEXCEL";
        }
        else if (cambridgeRB.Checked)
        {
            cl.Board = "CAMBRIDGE";
        }
        else
        {
            cl.Board = "N/A";
        }
        db.Classes.InsertOnSubmit(cl);
        db.SubmitChanges();
        Literal1.Text = "<p style=color:green>Class Saved Successfully";

        houseDropDownList.SelectedValue = "0";
        txtClassCode.Text = "";
        txtclass.Text = "";
        Response.Redirect("~/All Set Up/inputClass.aspx");
    }
}