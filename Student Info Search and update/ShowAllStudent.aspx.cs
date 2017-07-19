using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class Student_Info_Search_and_update_ShowAllStudent : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        if (classDropDownList.SelectedItem.Value == "0" && studentIdTextBox.Text == "")
        {
            var his = from u in db.Students
                join c in db.Classes on u.PClassID equals c.VarClassID
                orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.VarStudentFirstName,
                        u.VarStudentMeddleName,
                        u.VarStudentLastName,
                        u.VarFatherName,
                        c.VarClassName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text != "" && classDropDownList.SelectedItem.Value == "0")
        {
            var his = from u in db.Students
                where u.VarStudentID == studentIdTextBox.Text
                join c in db.Classes on u.PClassID equals c.VarClassID
                select
                    new
                    {
                        u.VarStudentID,
                        u.VarStudentFirstName,
                        u.VarStudentMeddleName,
                        u.VarStudentLastName,
                        u.VarFatherName,
                        c.VarClassName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value != "0")
        {
            var his = from u in db.Students
                where u.PClassID == classDropDownList.SelectedItem.Value
                join c in db.Classes on u.PClassID equals c.VarClassID
                select
                    new
                    {
                        u.VarStudentID,
                        u.VarStudentFirstName,
                        u.VarStudentMeddleName,
                        u.VarStudentLastName,
                        u.VarFatherName,
                        c.VarClassName
                    };

            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else
        {
            var his = from u in db.Students
                where u.PClassID == classDropDownList.SelectedItem.Value && u.VarStudentID == studentIdTextBox.Text
                join c in db.Classes on u.PClassID equals c.VarClassID
                select
                    new
                    {
                        u.VarStudentID,
                        u.VarStudentFirstName,
                        u.VarStudentMeddleName,
                        u.VarStudentLastName,
                        u.VarFatherName,
                        c.VarClassName
                    };

            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
    }

    protected void allStudentGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (classDropDownList.SelectedItem.Value == "0" && studentIdTextBox.Text == "")
        {
            var his = from u in db.Students
                join c in db.Classes on u.PClassID equals c.VarClassID
                orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.VarStudentFirstName,
                        u.VarStudentMeddleName,
                        u.VarStudentLastName,
                        u.VarFatherName,
                        c.VarClassName
                    };

            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text != "" && classDropDownList.SelectedItem.Value == "0")
        {
            var his = from u in db.Students
                where u.VarStudentID == studentIdTextBox.Text
                join c in db.Classes on u.PClassID equals c.VarClassID
                select
                    new
                    {
                        u.VarStudentID,
                        u.VarStudentFirstName,
                        u.VarStudentMeddleName,
                        u.VarStudentLastName,
                        u.VarFatherName,
                        c.VarClassName
                    };

            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value != "0")
        {
            var his = from u in db.Students
                where u.PClassID == classDropDownList.SelectedItem.Value
                join c in db.Classes on u.PClassID equals c.VarClassID
                select
                    new
                    {
                        u.VarStudentID,
                        u.VarStudentFirstName,
                        u.VarStudentMeddleName,
                        u.VarStudentLastName,
                        u.VarFatherName,
                        c.VarClassName
                    };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else
        {
            var his = from u in db.Students
                where u.PClassID == classDropDownList.SelectedItem.Value && u.VarStudentID == studentIdTextBox.Text
                join c in db.Classes on u.PClassID equals c.VarClassID
                select
                    new
                    {
                        u.VarStudentID,
                        u.VarStudentFirstName,
                        u.VarStudentMeddleName,
                        u.VarStudentLastName,
                        u.VarFatherName,
                        c.VarClassName
                    };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GridView1.Rows[index];
            string s = ((Label) gvRow.Cells[1].FindControl("Label1")).Text;
            Response.Redirect("~/Student Info Entry/StudentAddmission.aspx?VarStudentID=" + s);
            //Page.ClientScript.RegisterStartupScript(GetType(), "OpenWindow", "window.open('~/Student Info Entry/StudentAddmission.aspx?VarStudentID=' ,'_blank');"+s , true);
        }
        else if (e.CommandName == "ViewButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GridView1.Rows[index];
            string s = ((Label)gvRow.Cells[1].FindControl("Label1")).Text;
            Response.Redirect("~/ReportsUI/StudentProfile.aspx?VarStudentID=" + s);
        }
    }

    

    
}