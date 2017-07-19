using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResultProcessing_ExamNameAndTypeSetup : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllExam();
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        if (examCodeTextBox.Text != "")
        {
            if (examNameTextBox.Text != "")
            {
                tbl_ExamName getExamInfo = db.tbl_ExamNames.FirstOrDefault(t => t.ExamName == examNameTextBox.Text);
                if (getExamInfo == null)
                {
                    tbl_ExamName check = (from d in db.tbl_ExamNames
                        where d.ExamCode == examCodeTextBox.Text
                        select d).SingleOrDefault();
                    if (check != null)
                    {
                        check.ExamName = examNameTextBox.Text;
                        db.SubmitChanges();
                        examNameTextBox.Text = string.Empty;
                        examCodeTextBox.Text = string.Empty;
                        successStatusLabel.InnerText = "Exam Name Updated Successfully.";
                        GetAllExam();
                    }
                    else
                    {
                        var examName = new tbl_ExamName();
                        examName.ExamCode = examCodeTextBox.Text;
                        examName.ExamName = examNameTextBox.Text;
                        db.tbl_ExamNames.InsertOnSubmit(examName);
                        db.SubmitChanges();
                        examNameTextBox.Text = string.Empty;
                        examCodeTextBox.Text = string.Empty;
                        successStatusLabel.InnerText = "Exam Name Added Successfully.";
                        GetAllExam();
                    }
                }
                else
                {
                    failStatusLabel.InnerText = "This Exam Name already exist.";
                }
            }

            else
            {
                failStatusLabel.InnerText = "Please insert Exam Name.";
            }
        }
        else
        {
            failStatusLabel.InnerText = "Please insert Exam Code.";
        }
        examCodeTextBox.ReadOnly = false;
    }

    private void GetAllExam()
    {
        var getExam = from x in db.tbl_ExamNames
            select new {x.ExamName, x.ExamCode};
        allExamGridView.DataSource = getExam;
        allExamGridView.DataBind();
    }

    protected void allExamGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = allExamGridView.Rows[index];
        string examName = ((Label) gvRow.FindControl("examNameLabel")).Text;
        string examCode = ((Label) gvRow.FindControl("examCodeLabel")).Text;
        //tbl_ExamName getExam = db.tbl_ExamNames.FirstOrDefault(t => t.ExamName == examName);

        examNameTextBox.Text = examName;
        examCodeTextBox.Text = examCode;
        examCodeTextBox.ReadOnly = true;
        //if (e.CommandName == "DeleteButton")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow gvRow = allExamGridView.Rows[index];
        //    string examName = ((Label)gvRow.FindControl("examNameLabel")).Text;

        //    tbl_ExamName getExam = db.tbl_ExamNames.FirstOrDefault(t => t.ExamName == examName);
        //    if (getExam != null)
        //    {
        //        db.tbl_ExamNames.DeleteOnSubmit(getExam);
        //        db.SubmitChanges();
        //    }
        //    GetAllExam();
        //}
        //else if (e.CommandName == "EditButton")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow gvRow = allExamGridView.Rows[index];
        //    string examName = ((Label)gvRow.FindControl("examNameLabel")).Text;
        //    //string fee = ((Label)gvRow.FindControl("feesLabel")).Text;
        //    //string typeName = ((Label)gvRow.FindControl("typeNameLabel")).Text;

        //    tbl_ExamName getExam = db.tbl_ExamNames.FirstOrDefault(t => t.ExamName == examName);

        //    examNameTextBox.Text = examName;

        //    //if (testTypeId != null) testTypeDropDownList.SelectedValue = Convert.ToString(testTypeId.Id);

        //}
    }
}