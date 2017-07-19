using System;
using System.Linq;
using System.Web.UI;

public partial class ShiftEntry : Page
{
    private readonly SWISDataContext db = new SWISDataContext();


    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    var data = db.ShiftInfos.Where(d => d.VarShiftCode == txtShiftCode.Text).ToList();
        //    GridView1.DataSource = data;
        //    GridView1.DataBind();
        //}
    }

    protected void shiftSave_Click(object sender, EventArgs e)
    {
        IQueryable<string> checkExisting = from c in db.ShiftInfos
            where c.VarShiftCode.Contains(txtShiftCode.Text)
            select c.VarShiftCode;

        //var data = db.tblSections.Where(d => d.ClassID == Convert.ToInt32(classDropDownList.Text)).ToList();
        //if (data.ClassID == Convert.ToInt32(classDropDownList.Text) && data.varSectionName == txtsection.Text)
        if (checkExisting.FirstOrDefault() == null)
        {
            var si = new ShiftInfo();
            si.uid = Session["uid"].ToString();
            si.VarBranchId = Session["VarBranchId"].ToString();
            si.VarShiftCode = Session["VarShiftCode"].ToString();

            //si.VarClassId = classDropDownList.SelectedItem.Text;
            si.VarShiftCode = txtShiftCode.Text;
            si.VarShiftName = txtShiftName.Text;
            db.ShiftInfos.InsertOnSubmit(si);
            db.SubmitChanges();
            Literal1.Text = "Shift entry successful";
            GridView1.DataBind();
            //Response.Redirect("ShiftEntry.aspx");

            //var data1 = db.ShiftInfos.Where(d => d.VarShiftCode == txtShiftCode.Text).ToList();
            //GridView1.DataSource = data1;
            //GridView1.DataBind();
        }

        else
        {
            Literal1.Text = "Shift id already Exists";
        }
    }
}