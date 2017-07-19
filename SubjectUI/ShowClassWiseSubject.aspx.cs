using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubjectUI_ShowClassWiseSubject : Page
{
    SWISDataContext db=new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ShowData()
    {
        var getData = from c in db.tbl_Subjects
            where c.ClassId == classDropDownList.SelectedValue
            select new {c.VarSubjectCode,c.VarSubjectName};
        allSubjectGridView.DataSource = getData.AsEnumerable();
        allSubjectGridView.DataBind();

    }   
    protected void allSubjectGridView_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    { 
        allSubjectGridView.EditIndex = e.NewEditIndex;
        ShowData();
    }
    protected void allSubjectGridView_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {  
        Label subjectCode = allSubjectGridView.Rows[e.RowIndex].FindControl("lbl_SubjectCode") as Label;
        TextBox subjectName = allSubjectGridView.Rows[e.RowIndex].FindControl("txt_SubjectName") as TextBox;
        string classs = classDropDownList.SelectedValue;
        tbl_Subject check =
            db.tbl_Subjects.FirstOrDefault(x => x.ClassId == classs && x.VarSubjectCode == subjectCode.Text);
        if (check!=null)
        {
            if (subjectName != null) check.VarSubjectName = subjectName.Text;
            db.SubmitChanges();
        }
        allSubjectGridView.EditIndex = -1;
        ShowData();
    }
    protected void allSubjectGridView_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        allSubjectGridView.EditIndex = -1;
        ShowData();
    }
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowData();
    }
}