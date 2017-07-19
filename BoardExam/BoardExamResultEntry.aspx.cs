using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BoardExam
{
    public partial class BoardExamBoardExamResultEntry : System.Web.UI.Page
    {
        SWISDataContext db = new SWISDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            saveButton.Visible = false;
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            successStatusLabel.InnerText = "";
            failStatusLabel.InnerText = "";
            if (sessionDropDownList.SelectedValue != "0" && examSessionDropDownList.SelectedValue != "")
            {


                studentNameLabel.Text = "";
                //GridView1.DataSource = null;
                //GridView1.DataBind();
                string studentId = branchInitialTextBox.Text + txtStdId.Text;
                tbl_Present_class presentClass =
                    db.tbl_Present_classes.FirstOrDefault(
                        p => p.VarStudentID == studentId);//&& p.VarSessionId == sessionDropDownList.SelectedValue
                if (presentClass != null)
                {
                    Student getStudent = db.Students.FirstOrDefault(p => p.VarStudentID == studentId);

                    Class cls = db.Classes.FirstOrDefault(c => c.VarClassID == presentClass.VarClassID);
                    if (cls != null && cls.ClassType == 2)
                    {
                        classTextBox.Text = "A-LEVEL";
                        boardTextBox.Text = cls.Board;
                        //classDropDownList.Items.Clear();
                        //classDropDownList.Items.Insert(0, new ListItem(cls.VarClassName, cls.VarClassID));
                        if (getStudent != null)
                            studentNameLabel.Text = getStudent.VarStudentFirstName + " " + getStudent.VarStudentLastName +
                                                    "       ROLL:" + getStudent.StudentRoll;

                        var getAllSubject = (from c in db.tbl_BoardExamSubAssigns
                                             //join r in db.tbl_BoardExamResults on c.SubjectId equals r.SubCode into subGroup
                                             // from r in subGroup.DefaultIfEmpty()
                                             join r in db.tbl_BoardExamResults on new { X1 = c.SubjectId, X2 = c.StudentId,X3=c.Session } equals
                       new
                       {
                           X1 = r.SubCode,
                           X2 = r.VarStudentId,X3=r.VarSession
                       }
                        into subGroup
                                             from r in subGroup.DefaultIfEmpty()

                                             where
                                                 c.Session == sessionDropDownList.SelectedValue &&
                                                 c.ExamSession == examSessionDropDownList.SelectedValue && c.StudentId == studentId &&
                                                 c.Board == boardTextBox.Text && c.Class == classTextBox.Text
                                             select new { c.SubjectId, c.SubjectName, r.Grade }).Distinct().ToList();

                        resultEntryGridView.DataSource = getAllSubject.AsEnumerable();
                        resultEntryGridView.DataBind();
                        if (resultEntryGridView.PageCount > 0)
                        {
                            saveButton.Visible = true;
                        }
                        //foreach (var examSubAssign in getAllSubject)
                        //    {
                        //        string s1 = examSubAssign.SubjectName;
                        //        string s2 = examSubAssign.SubjectId;
                        //    }
                        //    var getdata=getAllSubject.Select(x => x.SubjectName).Distinct().ToList();

                    }
                }
            }
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
        protected void saveButton_Click(object sender, EventArgs e)
        {

            //string subCode = ((TextBox)gvrow.Cells[4].FindControl("firstStMarks")).Text;
            foreach (GridViewRow gvrow in resultEntryGridView.Rows)
            {
                tbl_BoardExamResult examResult = new tbl_BoardExamResult();

                string studentId = branchInitialTextBox.Text + txtStdId.Text;
                string session = sessionDropDownList.SelectedValue;
                string examSession = examSessionDropDownList.SelectedValue;
                string clas = classTextBox.Text;
                string board = boardTextBox.Text;
                string subCode = ((Label)gvrow.Cells[0].FindControl("subjectCodeLabel")).Text;
                string subName = ((Label)gvrow.Cells[1].FindControl("subjectLabel")).Text;
                string grade = ((TextBox)gvrow.Cells[2].FindControl("gradeTextBox")).Text;

                var checkResult =
                    db.tbl_BoardExamResults.FirstOrDefault(
                        x => x.VarStudentId == studentId && x.VarSession == session && x.ExamSession == examSession
                             && x.SubCode == subCode && x.Board == board && x.Class == clas);
                if (checkResult == null)
                {
                    examResult.VarStudentId = studentId;
                    examResult.VarSession = session;
                    examResult.ExamSession = examSession;
                    examResult.Class = clas;
                    examResult.Board = board;
                    examResult.SubCode = subCode;
                    examResult.SubName = subName;
                    examResult.Grade = grade;
                    db.tbl_BoardExamResults.InsertOnSubmit(examResult);
                }
                else
                {
                    checkResult.Grade = grade;
                }

                db.SubmitChanges();
            }

            successStatusLabel.InnerText = "Result Added Successfully.";
            resultEntryGridView.DataSource = null;
            resultEntryGridView.DataBind();
        }
    }
}