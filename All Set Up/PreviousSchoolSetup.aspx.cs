using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class All_Set_Up_PreviousSchoolSetup : System.Web.UI.Page
{
    SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
        }
    }
    protected void saveButton_Click(object sender, EventArgs e)
    {
        failStatusLabel.InnerText = "";
        successStatusLabel.InnerText = "";
        if (schoolNameTextBox.Text != "")
        {
            var check = db.tbl_PreviousSchools.FirstOrDefault(x => x.SchoolName == schoolNameTextBox.Text.Trim());
            if (check == null)
            {
                tbl_PreviousSchool previousSchool = new tbl_PreviousSchool();

                previousSchool.SchoolName = schoolNameTextBox.Text.Trim();
                db.tbl_PreviousSchools.InsertOnSubmit(previousSchool);
                db.SubmitChanges();
                successStatusLabel.InnerText = "School Save Successfully";
                schoolNameTextBox.Text = String.Empty;
                LoadGrid();
            }
            else
            {
                failStatusLabel.InnerText = "This School Name Already Exist";
            }

        }
        else
        {
            failStatusLabel.InnerText = "Please Insert School Name";
        }
    }

    private void LoadGrid()
    {
        var getSchool = from x in db.tbl_PreviousSchools
                        orderby x.SchoolName ascending
                        select new { x.SchoolName };
        PreviousSchoolGridView.DataSource = getSchool.AsEnumerable();
        PreviousSchoolGridView.DataBind();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PreviousSchoolGridView.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
}