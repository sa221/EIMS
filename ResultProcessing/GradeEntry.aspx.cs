using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResultProcessing_GradeEntry : System.Web.UI.Page
{
    SWISDataContext db=new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            saveButton.Visible = false;
        }
    }
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    private string GetSection(string studentId)
    {
        string section = null;
        tbl_Present_class sec =
               db.tbl_Present_classes.FirstOrDefault(
                   x => x.VarStudentID == studentId);
        if (sec != null) section = sec.VarSection;
        
        return section;
    }
    protected void showButton_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;

        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        if (classDropDownList.SelectedItem.Value == "0")
        {
            failStatusLabel.InnerText = "Please select class..!!";
            saveButton.Visible = false;
        }
        else
        {
            Class getClassType = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            if (getClassType != null && getClassType.ClassType == 1)
            {
                successStatusLabel.InnerText = "O-Level class";
                GridView1.Visible = true;
                saveButton.Visible = true;
                if (sectionDropDownList.SelectedValue == "0")
                {
                    var his = from u in db.tbl_Present_classes
                              join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                              from std in stdGroup.DefaultIfEmpty()
                              join m in db.ProjectGrades on
                                  new
                                  {
                                      StudentId=u.VarStudentID,
                                      ProjectId = projectDropDownList.SelectedValue,
                                      ExamCode = examNameDropDownList.SelectedValue,
                                      VarSession=sessionDropDownList.SelectedValue

                                  } equals
                                  new { m.StudentId,m.ProjectId,m.ExamCode,m.VarSession } into mJoin
                              from m in mJoin.DefaultIfEmpty()
                              orderby u.StudentRoll
                              where
                                  u.VarClassID == classDropDownList.SelectedValue && u.Status != "L"
                                  && u.VarSessionId == sessionDropDownList.SelectedValue
                                  //&& m.ProjectId == projectDropDownList.SelectedValue && m.VarSession==sessionDropDownList.SelectedValue
                                  //&& m.ExamCode==examNameDropDownList.SelectedValue
                              select new
                              {
                                  std.VarStudentID,
                                  std.VarStudentFirstName,
                                  std.VarStudentMeddleName,
                                  std.VarStudentLastName,
                                  u.StudentRoll,
                                  m.ProjectGrade1
                              };
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();
                }
                else if (sectionDropDownList.SelectedValue != "0")
                {
                    var his = from u in db.tbl_Present_classes
                              join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                              from std in stdGroup.DefaultIfEmpty()
                              join m in db.ProjectGrades on
                                  new
                                  {
                                      X1 = u.VarStudentID,
                                      ProjectId = projectDropDownList.SelectedValue,
                                      ExamCode = examNameDropDownList.SelectedValue,
                                      VarSession = sessionDropDownList.SelectedValue

                                  } equals
                                  new { X1=m.StudentId, m.ProjectId, m.ExamCode, m.VarSession } into mJoin
                              from m in mJoin.DefaultIfEmpty()
                              orderby u.StudentRoll
                              where
                                  u.VarClassID == classDropDownList.SelectedValue && u.Status != "L"
                                  && u.VarSessionId == sessionDropDownList.SelectedValue && u.VarSection==sectionDropDownList.SelectedValue
                                  //&& m.ProjectId == projectDropDownList.SelectedValue //&& m.VarSession == sessionDropDownList.SelectedValue
                                  //&& m.ExamCode == examNameDropDownList.SelectedValue && m.VarSection==sectionDropDownList.SelectedValue
                              select new
                              {
                                  std.VarStudentID,
                                  std.VarStudentFirstName,
                                  std.VarStudentMeddleName,
                                  std.VarStudentLastName,
                                  u.StudentRoll,
                                  m.ProjectGrade1
                              };
                    foreach (var hi in his)
                    {
                        string id = hi.VarStudentID;
                        string g = hi.ProjectGrade1;
                    }
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();
                }
            }
            else if (getClassType != null && getClassType.ClassType == 2)
            {
                successStatusLabel.InnerText = "A-Level class";
                GridView1.Visible = true;
                saveButton.Visible = true;
                if (sectionDropDownList.SelectedValue == "0")
                {
                    var his = from u in db.tbl_Present_classes
                              join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                              from std in stdGroup.DefaultIfEmpty()
                              join m in db.ProjectGrades on
                                  new
                                  {
                                      StudentId = u.VarStudentID,
                                      ProjectId = projectDropDownList.SelectedValue,
                                      ExamCode = examNameDropDownList.SelectedValue,
                                      VarSession = sessionDropDownList.SelectedValue

                                  } equals
                                  new { m.StudentId, m.ProjectId, m.ExamCode, m.VarSession } into mJoin
                              from m in mJoin.DefaultIfEmpty()
                              orderby u.StudentRoll
                              where
                                  u.VarClassID == classDropDownList.SelectedValue && u.Status != "L"
                                  && u.VarSessionId == sessionDropDownList.SelectedValue
                              select new
                              {
                                  std.VarStudentID,
                                  std.VarStudentFirstName,
                                  std.VarStudentMeddleName,
                                  std.VarStudentLastName,
                                  u.StudentRoll,
                                  m.ProjectGrade1
                              };
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();
                }
                else if (sectionDropDownList.SelectedValue != "0")
                {
                    var his = from u in db.tbl_Present_classes
                              join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                              from std in stdGroup.DefaultIfEmpty()
                              join m in db.ProjectGrades on
                                  new
                                  {
                                      StudentId = u.VarStudentID,
                                      ProjectId = projectDropDownList.SelectedValue,
                                      ExamCode = examNameDropDownList.SelectedValue,
                                      VarSession = sessionDropDownList.SelectedValue

                                  } equals
                                  new { m.StudentId, m.ProjectId, m.ExamCode, m.VarSession } into mJoin
                              from m in mJoin.DefaultIfEmpty()
                              orderby u.StudentRoll
                              where
                                  u.VarClassID == classDropDownList.SelectedValue && u.Status != "L"
                                  && u.VarSessionId == sessionDropDownList.SelectedValue && u.VarSection == sectionDropDownList.SelectedValue
                                  
                              select new
                              {
                                  std.VarStudentID,
                                  std.VarStudentFirstName,
                                  std.VarStudentMeddleName,
                                  std.VarStudentLastName,
                                  u.StudentRoll,
                                  m.ProjectGrade1
                              };
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();
                }
            }
            else if (getClassType != null && getClassType.ClassType == 3)
            {
                successStatusLabel.InnerText = "Junior class";
                GridView1.Visible = true;
                saveButton.Visible = true;
                if (sectionDropDownList.SelectedValue == "0")
                {
                    var his = from u in db.tbl_Present_classes
                              join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                              from std in stdGroup.DefaultIfEmpty()
                              join m in db.ProjectGrades on
                                  new
                                  {
                                      StudentId = u.VarStudentID,
                                      ProjectId = projectDropDownList.SelectedValue,
                                      ExamCode = examNameDropDownList.SelectedValue,
                                      VarSession = sessionDropDownList.SelectedValue

                                  } equals
                                  new { m.StudentId, m.ProjectId, m.ExamCode, m.VarSession } into mJoin
                              from m in mJoin.DefaultIfEmpty()
                              orderby u.StudentRoll
                              where
                                  u.VarClassID == classDropDownList.SelectedValue && u.Status != "L"
                                  && u.VarSessionId == sessionDropDownList.SelectedValue
                              select new
                              {
                                  std.VarStudentID,
                                  std.VarStudentFirstName,
                                  std.VarStudentMeddleName,
                                  std.VarStudentLastName,
                                  u.StudentRoll,
                                  m.ProjectGrade1
                              };
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();
                }
                else if (sectionDropDownList.SelectedValue != "0")
                {
                    var his = from u in db.tbl_Present_classes
                              join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                              from std in stdGroup.DefaultIfEmpty()
                              join m in db.ProjectGrades on
                                  new
                                  {
                                      StudentId = u.VarStudentID,
                                      ProjectId = projectDropDownList.SelectedValue,
                                      ExamCode = examNameDropDownList.SelectedValue,
                                      VarSession = sessionDropDownList.SelectedValue

                                  } equals
                                  new { m.StudentId, m.ProjectId, m.ExamCode, m.VarSession } into mJoin
                              from m in mJoin.DefaultIfEmpty()
                              orderby u.StudentRoll
                              where
                                  u.VarClassID == classDropDownList.SelectedValue && u.Status != "L"
                                  && u.VarSessionId == sessionDropDownList.SelectedValue && u.VarSection == sectionDropDownList.SelectedValue

                              select new
                              {
                                  std.VarStudentID,
                                  std.VarStudentFirstName,
                                  std.VarStudentMeddleName,
                                  std.VarStudentLastName,
                                  u.StudentRoll,
                                  m.ProjectGrade1
                              };
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();
                }
            }
        }
    }
    protected void saveButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            var projectGrade = new ProjectGrade();
            //string unitCodeName = "";
            string session = sessionDropDownList.SelectedValue;
            string cls = classDropDownList.SelectedValue;
            string studentId = ((Label)gvrow.Cells[1].FindControl("Label1")).Text;
            string section = GetSection(studentId);
            string projectCode = projectDropDownList.SelectedValue;
            string projectName = projectDropDownList.SelectedItem.Text;
            

            string examCode = examNameDropDownList.SelectedValue;

            string grade = ((TextBox)gvrow.Cells[4].FindControl("gradeMarks")).Text;

            ProjectGrade check =
                (from d in db.ProjectGrades
                 where
                     d.StudentId == studentId && d.VarSession == session && d.VarClass == cls &&
                     d.ProjectId == projectCode && d.ExamCode == examCode
                 select d).FirstOrDefault();

            if (check != null)
            {
                if (grade != "")
                {
                    check.ProjectGrade1 = grade;
                    db.SubmitChanges();
                }
            }
            else
            {
                projectGrade.VarSession = session;
                projectGrade.VarClass = cls;
                projectGrade.VarSection = section;
                projectGrade.ProjectId = projectName;
                projectGrade.ExamCode = examCode;
                projectGrade.StudentId = studentId;
                if (grade != "")
                {
                    projectGrade.ProjectGrade1 = grade;
                }
                projectGrade.VarBranchID = Convert.ToInt32(Session["VarBranchId"]);
                db.ProjectGrades.InsertOnSubmit(projectGrade);
                db.SubmitChanges();
            }
        }
        successStatusLabel.InnerText = "Marks Added Successfully....!";
        GridView1.DataSource = null;
        GridView1.DataBind();
    }
}