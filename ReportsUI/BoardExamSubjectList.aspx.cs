using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportsUI_BoardExamSubjectList : System.Web.UI.Page
{
    SWISDataContext db=new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void sessionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getSection = from c in db.tbl_ExamSessions
                         where c.SessionId == sessionDropDownList.SelectedValue
                         select new { c.ExamSessionId, c.ExamSessionName };

        examSessionDropDownList.DataSource = getSection;
        examSessionDropDownList.DataValueField = "ExamSessionId";
        examSessionDropDownList.DataTextField = "ExamSessionName";
        examSessionDropDownList.DataBind();
        examSessionDropDownList.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void showButton_Click(object sender, EventArgs e)
    {

    }

    private void GetAllSubject()
    {
        var getAllSubject =
            db.tbl_BoardExamSubAssigns.FirstOrDefault(
                x =>
                    x.Session == sessionDropDownList.SelectedValue &&
                    x.ExamSession == examSessionDropDownList.SelectedValue && x.Class == classDropDownList.SelectedItem.Text &&
                    x.Board == boardDropDownList.SelectedItem.Text);
    }
}