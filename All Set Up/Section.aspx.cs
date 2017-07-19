using System;
using System.Linq;
using System.Web.UI;

public partial class Section : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var sec = new tblSection();

        IQueryable<string> checkExisting = from c in db.tblSections
            where c.varSectionName.Contains(txtsection.Text) && c.ClassID.Equals(classDropDownList.Text)
            select c.varSectionName;

        //var data = db.tblSections.Where(d => d.ClassID == Convert.ToInt32(classDropDownList.Text)).ToList();
        //if (data.ClassID == Convert.ToInt32(classDropDownList.Text) && data.varSectionName == txtsection.Text)
        if (checkExisting.FirstOrDefault() != null)
        {
            Literal1.Text = "Section already exist";
        }
        else
        {
            //sec.VarSessionId = sessionDropDownList.SelectedItem.Value;
            if (Session["uid"] != null)
            {
                sec.uid = Session["uid"].ToString();
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            var maxSection = from c in db.tblSections
                select new {c.NumSectionId};
           
            var r = db.tblSections.Max(x => x.NumSectionId);
            sec.VarBranchId = Session["VarBranchId"].ToString();
            sec.VarShiftCode = Session["VarShiftCode"].ToString();
            sec.ClassID = classDropDownList.Text;
            sec.SectionId = (r + 1).ToString();
            sec.NumSectionId = r + 1;
            //sec.VarSubjectId = subjectDropDownList.Text;
            //sec.VarUnitCode = unitCodeDropDownList.Text;
            sec.varSectionName = txtsection.Text;
            db.tblSections.InsertOnSubmit(sec);
            db.SubmitChanges();
            GridView1.DataBind();
            //Response.Redirect("~/All Set Up/Section.aspx");
            Literal1.Text = "<p style=color:Green>Section saved successfuly";
        }


        txtsection.Text = "";
    }
}