using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BoardExam
{
    public partial class BoardExamBoardExamSubEntry : System.Web.UI.Page
    {
        private readonly SWISDataContext db = new SWISDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            successStatusLabel.InnerText = "";
            failStatusLabel.InnerText = "";
            if (sessionDropDownList.SelectedValue != "0" && examSessionDropDownList.SelectedValue!="")
            {


                studentNameLabel.Text = "";
                GridView1.DataSource = null;
                GridView1.DataBind();
                string studentId = branchInitialTextBox.Text + txtStdId.Text;
                tbl_Present_class presentClass = db.tbl_Present_classes.FirstOrDefault(p => p.VarStudentID == studentId && p.Status=="P");
                if (presentClass != null)
                {
                    Student getStudent = db.Students.FirstOrDefault(p => p.VarStudentID == studentId);

                    Class cls = db.Classes.FirstOrDefault(c => c.VarClassID == presentClass.VarClassID);
                    IQueryable<string> isSubjectAssign = from c in db.tbl_BoardExamSubAssigns
                                                         where c.StudentId == studentId && c.Session == sessionDropDownList.SelectedValue
                                                         select c.StudentId;
                    if (cls != null && cls.ClassType == 1)
                    {
                        classTextBox.Text = "O-LEVEL";
                        
                        //boardTextBox.Text = cls.Board;
                        //classDropDownList.Items.Clear();
                        //classDropDownList.Items.Insert(0, new ListItem(cls.VarClassName, cls.VarClassID));
                        if (getStudent != null)
                            studentNameLabel.Text = getStudent.VarStudentFirstName + " " + getStudent.VarStudentLastName +
                                                    "       ROLL:" + getStudent.StudentRoll;
                        if (getStudent != null) numberTextBox.Text = getStudent.ExamineeSMSNumber;
                        if (isSubjectAssign.FirstOrDefault() != null)
                        {
                            var his = from u in db.tbl_BoardExamSubAssigns

                                where
                                    u.StudentId == studentId && u.Session == sessionDropDownList.SelectedValue &&
                                    u.Class == classTextBox.Text && //u.Board == boardDropDownList.SelectedValue &&
                                    u.ExamSession == examSessionDropDownList.SelectedValue 
                                    orderby u.SubjectName
                                      select new { u.Board, u.Class, u.ExamSession, u.SubjectId, u.SubjectName, u.UnitCode, u.UnitCodeName, u.UniqueId };
                            
                            GridView1.DataSource = his.AsEnumerable();
                            GridView1.DataBind();
                        }

                        var allSubject = (
                            from s in db.tbl_BoardSubjects
                            join es in db.tbl_BoardExamSubAssigns on new { s.UniqueId } equals
                                new { es.UniqueId } into esJoin
                            from es in esJoin.DefaultIfEmpty()
                            where
                                s.ClassLevel == classTextBox.Text && s.Board == boardDropDownList.SelectedValue & s.QualificationLevel==qLevelDropDownList.SelectedValue
                            //orderby s.SubName
                            select new
                            {
                                s.SubCode,
                                s.SubName,
                                s.UnitCode,
                                s.UnitName,
                                s.UniqueId
                            }
                        ).Except
                        (
                            from s in db.tbl_BoardSubjects
                            join es in db.tbl_BoardExamSubAssigns on new { s.UniqueId } equals
                                new { es.UniqueId } into esJoin
                            from es in esJoin.DefaultIfEmpty()
                            where
                                es.Class == classTextBox.Text &&
                                es.StudentId == studentId && s.Board == boardDropDownList.SelectedValue && es.ExamSession == examSessionDropDownList.SelectedValue &&
                                es.Session == sessionDropDownList.SelectedValue
                                orderby s.SubName
                            select new
                            {
                                s.SubCode,
                                s.SubName,
                                s.UnitCode,
                                s.UnitName,
                                s.UniqueId
                            }
                        );

                        GridView2.DataSource = allSubject.AsEnumerable();
                        GridView2.DataBind();
                    }
                    else if (cls != null && cls.ClassType == 2)
                    {
                        classTextBox.Text = "A-LEVEL";
                        //boardTextBox.Text = cls.Board;
                        //classDropDownList.Items.Clear();
                        //classDropDownList.Items.Insert(0, new ListItem(cls.VarClassName, cls.VarClassID));
                        if (getStudent != null)
                            studentNameLabel.Text = getStudent.VarStudentFirstName + " " + getStudent.VarStudentLastName +
                                                    "       ROLL:" + getStudent.StudentRoll;
                        if (getStudent != null) numberTextBox.Text = getStudent.ExamineeSMSNumber;
                        if (isSubjectAssign.FirstOrDefault() != null)
                        {
                            var his = from u in db.tbl_BoardExamSubAssigns

                                      where
                                          u.StudentId == studentId && u.Session == sessionDropDownList.SelectedValue &&
                                          u.Class == classTextBox.Text && //u.Board == boardDropDownList.SelectedValue &&
                                          u.ExamSession == examSessionDropDownList.SelectedValue
                                      orderby u.SubjectName
                                      select new { u.Board, u.Class, u.ExamSession, u.SubjectId, u.SubjectName, u.UnitCode, u.UnitCodeName, u.UniqueId };

                            GridView1.DataSource = his.AsEnumerable();
                            GridView1.DataBind();
                        }

                        var allSubject = (
                            from s in db.tbl_BoardSubjects
                            join es in db.tbl_BoardExamSubAssigns on new { s.UniqueId } equals
                                new { es.UniqueId } into esJoin
                            from es in esJoin.DefaultIfEmpty()
                            where
                                //s.ClassLevel == classTextBox.Text && 
                                s.Board == boardDropDownList.SelectedValue & s.QualificationLevel == qLevelDropDownList.SelectedValue
                            //orderby s.SubName
                            select new
                            {
                                s.SubCode,
                                s.SubName,
                                s.UnitCode,
                                s.UnitName,
                                s.UniqueId
                            }
                        ).Except
                        (
                            from s in db.tbl_BoardSubjects
                            join es in db.tbl_BoardExamSubAssigns on new { s.UniqueId } equals
                                new { es.UniqueId } into esJoin
                            from es in esJoin.DefaultIfEmpty()
                            where
                                //es.Class == classTextBox.Text &&
                                es.StudentId == studentId && s.Board == boardDropDownList.SelectedValue && es.ExamSession == examSessionDropDownList.SelectedValue &&
                                es.Session == sessionDropDownList.SelectedValue
                            orderby s.SubName
                            select new
                            {
                                s.SubCode,
                                s.SubName,
                                s.UnitCode,
                                s.UnitName,
                                s.UniqueId
                            }
                        );

                        GridView2.DataSource = allSubject.AsEnumerable();
                        GridView2.DataBind();
                    }
                   
                }
                else
                {
                    failStatusLabel.InnerText = "Student Not Found on this Session.";
                }
               
                //failStatusLabel.InnerText = "Subject Already Assign for ID: " + branchInitialTextBox.Text + "" + txtStdId.Text;
            }
            else
            {
                failStatusLabel.InnerText = "Please Select Session and Exam Session.";
            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string studentId = branchInitialTextBox.Text + txtStdId.Text;
            if (e.CommandName == "AddButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = GridView2.Rows[index];
                string subjectName = ((Label)gvRow.FindControl("subjectLabel")).Text;
                string subjectCode = ((Label)gvRow.FindControl("subjectCodeLabel")).Text;
                string unitName = ((Label)gvRow.FindControl("unitNameLabel")).Text;
                string unitCode = ((Label)gvRow.FindControl("unitCodeLabel")).Text;
                string uniqueId = ((Label)gvRow.FindControl("uniqueIdLabel")).Text;
                string session = sessionDropDownList.SelectedValue;
                string exmSession = examSessionDropDownList.SelectedValue;
                string className = classTextBox.Text;
                string board = boardDropDownList.SelectedValue;


                tbl_BoardExamSubAssign subAssign = new tbl_BoardExamSubAssign();

                subAssign.Session = session;
                subAssign.Class = className;
                subAssign.Board = board;
                subAssign.ExamSession = exmSession;
                subAssign.StudentId = studentId;
                subAssign.SubjectId = subjectCode;
                subAssign.QualificationLevel = qLevelDropDownList.SelectedValue;
                subAssign.SubjectName = subjectName;
                subAssign.UnitCode = unitCode;
                subAssign.UnitCodeName = unitName;
                subAssign.UniqueId = uniqueId;
                Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == Convert.ToInt32(Session["VarBranchId"]));
                if (branchInitial != null) subAssign.VarBranchId = branchInitial.VarBranchID.ToString();
                subAssign.uid = Session["uid"].ToString();
                subAssign.EntryDate = DateTime.Now.Date;
                db.tbl_BoardExamSubAssigns.InsertOnSubmit(subAssign);

                Student std=new Student();
                var checkSmsNumber = db.Students.FirstOrDefault(z => z.VarStudentID == studentId);
                if (checkSmsNumber!=null)
                {
                    checkSmsNumber.ExamineeSMSNumber = numberTextBox.Text;
                }
                db.SubmitChanges();

                var btn = ((Button)gvRow.FindControl("btnAdd"));
                btn.Text = "Taken";
                btn.Enabled = false;
                var his = from u in db.tbl_BoardExamSubAssigns
                          //join s in db.tbl_BoardSubjects on u.SubjectId equals s.SubCode into sGroup
                          //from s in sGroup.DefaultIfEmpty()

                          where
                              u.StudentId == studentId && u.Session == session &&
                              u.Class == className && u.ExamSession == exmSession //&& u.Board == board
                          select new { u.Board, u.Class, u.ExamSession, u.SubjectId, u.SubjectName, u.UnitCode, u.UnitCodeName, u.UniqueId };
                GridView1.DataSource = his.AsEnumerable();
                GridView1.DataBind();
            }
        }

       

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string studentId = branchInitialTextBox.Text + txtStdId.Text;
            
            if (e.CommandName == "DeleteButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = GridView1.Rows[index];
                string subjectName = ((Label)gvRow.FindControl("subjectLabel")).Text;
                string subjectCode = ((Label)gvRow.FindControl("subjectCodeLabel")).Text;
                string unitName = ((Label)gvRow.FindControl("unitNameLabel")).Text;
                string unitCode = ((Label)gvRow.FindControl("unitCodeLabel")).Text;
                string uniqueId = ((Label)gvRow.FindControl("uniqueIdLabel")).Text;
                string session = sessionDropDownList.SelectedValue;
                string exmSession = examSessionDropDownList.SelectedValue;
                string className = classTextBox.Text;
                string board = boardDropDownList.SelectedValue;

                tbl_BoardExamSubAssign checkSub =
                    db.tbl_BoardExamSubAssigns.FirstOrDefault(
                        x =>
                            x.UniqueId == uniqueId && x.StudentId == studentId && x.Session == session &&
                            x.ExamSession == exmSession);
            
                if (checkSub != null)
                {
                    db.tbl_BoardExamSubAssigns.DeleteOnSubmit(checkSub);
                    db.SubmitChanges();
                }

                var his = from u in db.tbl_BoardExamSubAssigns
                          //join s in db.tbl_BoardSubjects on u.SubjectId equals s.SubCode into sGroup
                          //from s in sGroup.DefaultIfEmpty()

                          where
                              u.StudentId == studentId && u.Session == session &&
                              u.Class == className && u.ExamSession == exmSession //&& u.Board == board
                          select new { u.Board, u.Class, u.ExamSession, u.SubjectId, u.SubjectName, u.UnitCode, u.UnitCodeName, u.UniqueId };
                GridView1.DataSource = his.AsEnumerable();
                GridView1.DataBind();

                var allSubject = (
                        from s in db.tbl_BoardSubjects
                        join es in db.tbl_BoardExamSubAssigns on new { s.UniqueId } equals
                            new { es.UniqueId } into esJoin
                        from es in esJoin.DefaultIfEmpty()
                        where
                            s.ClassLevel == classTextBox.Text && s.Board == boardDropDownList.SelectedValue
                        select new
                        {
                            s.SubCode,
                            s.SubName,
                            s.UnitCode,
                            s.UnitName,
                            s.UniqueId
                        }
                    ).Except
                    (
                        from s in db.tbl_BoardSubjects
                        join es in db.tbl_BoardExamSubAssigns on new { s.UniqueId } equals
                            new { es.UniqueId } into esJoin
                        from es in esJoin.DefaultIfEmpty()
                        where
                            es.Class == classTextBox.Text &&
                            es.StudentId == studentId && s.Board == boardDropDownList.SelectedValue && es.ExamSession == examSessionDropDownList.SelectedValue &&
                            es.Session == sessionDropDownList.SelectedValue
                        select new
                        {
                            s.SubCode,
                            s.SubName,
                            s.UnitCode,
                            s.UnitName,
                            s.UniqueId
                        }
                    );

                GridView2.DataSource = allSubject.AsEnumerable();
                GridView2.DataBind();
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
    }
}