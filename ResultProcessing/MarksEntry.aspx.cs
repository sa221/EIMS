using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResultProcessing_MarksEntry : Page
{
    private static readonly SWISDataContext db = new SWISDataContext();

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
                if (classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue == "0" &&
                    subjectDropDownList.SelectedValue == "" && unitcodeDropDownList.SelectedValue == "")
                {
                    failStatusLabel.InnerText = "No subject assigned on this class.";
                }
                else if (classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue == "0" &&
                         subjectDropDownList.SelectedValue != "" && unitcodeDropDownList.SelectedValue == "")
                {
                    var his = from u in db.tbl_Present_classes
                        join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                        from std in stdGroup.DefaultIfEmpty()
                        join sub in db.tbl_StudentSubjectAssigns on u.VarStudentID equals sub.VarStudentId into
                            subGroup
                        from sub in subGroup.DefaultIfEmpty()
                        join c in db.Classes on sub.ClassId equals c.VarClassID into cGroup
                        from c in cGroup.DefaultIfEmpty()
                        //join s in db.tblSections on sub.VarSection equals s.SectionId into uGroup
                        //from s in uGroup.DefaultIfEmpty()
                        //join m in db.tbl_ExamMarks on new { X1 = u.VarStudentID, X2 = sub.VarSubjectCode, X3 = (m.Examcode = examNameDropDownList.SelectedValue) } equals new { m.VarStudentId, m.VarSubjectCode, m.ExamCode } into mGroup
                        //from m in mGroup.DefaultIfEmpty()
                        join m in db.tbl_ExamMarks on
                            new
                            {
                                sub.VarStudentId,
                                sub.VarSubjectCode,
                                ExamCode = examNameDropDownList.SelectedValue
                            } equals
                            new {m.VarStudentId, m.VarSubjectCode, m.ExamCode} into mJoin
                        from m in mJoin.DefaultIfEmpty()
                        //new { u.VarStudentID, sub.VarSubjectCode } equals new { m..field1, m.VarSubjectCode }
                        orderby u.StudentRoll ascending
                        where
                            sub.ClassId == classDropDownList.SelectedValue && u.Status != "L" &&
                            sub.VarSubjectCode == subjectDropDownList.SelectedValue
                        select new
                        {
                            sub.VarStudentId,
                            std.VarStudentFirstName,
                            std.VarStudentMeddleName,
                            std.VarStudentLastName,
                            u.StudentRoll,
                            m.First_ST_Marks,
                            m.Second_ST_Marks,
                            m.Third_ST_Marks,
                            m.Final_Marks,
                        };
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();
                }
                else if (classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue != "0" &&
                         subjectDropDownList.SelectedValue != "" && unitcodeDropDownList.SelectedValue == "")
                {
                    var his = from u in db.tbl_Present_classes
                        join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                        from std in stdGroup.DefaultIfEmpty()
                        join sub in db.tbl_StudentSubjectAssigns on u.VarStudentID equals sub.VarStudentId into
                            subGroup
                        from sub in subGroup.DefaultIfEmpty()
                        join c in db.Classes on sub.ClassId equals c.VarClassID into cGroup
                        from c in cGroup.DefaultIfEmpty()
                        join s in db.tblSections on sub.VarSection equals s.SectionId into uGroup
                        from s in uGroup.DefaultIfEmpty()
                        //join m in db.tbl_ExamMarks on new { X1 = u.VarStudentID, X2 = sub.VarSubjectCode, X3 = (m.Examcode = examNameDropDownList.SelectedValue) } equals new { m.VarStudentId, m.VarSubjectCode, m.ExamCode } into mGroup
                        //from m in mGroup.DefaultIfEmpty()
                        join m in db.tbl_ExamMarks on
                            new
                            {
                                sub.VarStudentId,
                                sub.VarSubjectCode,
                                ExamCode = examNameDropDownList.SelectedValue
                            } equals
                            new {m.VarStudentId, m.VarSubjectCode, m.ExamCode} into mJoin
                        from m in mJoin.DefaultIfEmpty()
                        //new { u.VarStudentID, sub.VarSubjectCode } equals new { m..field1, m.VarSubjectCode }
                        orderby u.StudentRoll ascending
                        where
                            sub.ClassId == classDropDownList.SelectedValue && u.Status != "L" &&
                            sub.VarSubjectCode == subjectDropDownList.SelectedValue &&
                            sub.VarSection == sectionDropDownList.SelectedValue
                        select new
                        {
                            sub.VarStudentId,
                            std.VarStudentFirstName,
                            std.VarStudentMeddleName,
                            std.VarStudentLastName,
                            u.StudentRoll,
                            m.First_ST_Marks,
                            m.Second_ST_Marks,
                            m.Third_ST_Marks,
                            m.Final_Marks,
                        };
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();
                }
            }
            else if (getClassType != null && getClassType.ClassType == 2)
            {
                successStatusLabel.InnerText = "A-Level class";
                GridView1.Visible = true;
                saveButton.Visible = true;
                if (classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue == "0" &&
                    subjectDropDownList.SelectedValue == "" && unitcodeDropDownList.SelectedValue == "")
                {
                    failStatusLabel.InnerText = "No Subject assigned on this Class.";
                }
                else if (classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue != "0" &&
                         subjectDropDownList.SelectedValue == "" && unitcodeDropDownList.SelectedValue == "")
                {
                    failStatusLabel.InnerText = "No Unit COde assigned on this Subject.";
                }


                else if (classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue == "0" &&
                         subjectDropDownList.SelectedValue != "" && unitcodeDropDownList.SelectedValue != "")
                {
                    var his = from u in db.tbl_Present_classes
                        join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                        from std in stdGroup.DefaultIfEmpty()
                        join sub in db.tbl_EdexcelSubjectAssigns on u.VarStudentID equals sub.StudentId into
                            subGroup
                        from sub in subGroup.DefaultIfEmpty()
                        join c in db.Classes on sub.ClassId equals c.VarClassID into cGroup
                        from c in cGroup.DefaultIfEmpty()
                        //join s in db.tblSections on sub.VarSection equals s.SectionId into uGroup
                        //from s in uGroup.DefaultIfEmpty()
                        //join m in db.tbl_ExamMarks on new { X1 = u.VarStudentID, X2 = sub.VarSubjectCode, X3 = (m.Examcode = examNameDropDownList.SelectedValue) } equals new { m.VarStudentId, m.VarSubjectCode, m.ExamCode } into mGroup
                        //from m in mGroup.DefaultIfEmpty()
                        join m in db.tbl_ExamMarks on
                            new
                            {
                                sub.StudentId,
                                sub.SubjectId,
                                sub.UnitCode,
                                ExamCode = examNameDropDownList.SelectedValue
                            } equals
                            new
                            {
                                StudentId = m.VarStudentId,
                                SubjectId = m.VarSubjectCode,
                                m.UnitCode,
                                m.ExamCode
                            } into mJoin
                        from m in mJoin.DefaultIfEmpty()
                        //new { u.VarStudentID, sub.VarSubjectCode } equals new { m..field1, m.VarSubjectCode }
                        orderby u.StudentRoll ascending
                        where
                            sub.ClassId == classDropDownList.SelectedValue && u.Status != "L" &&
                            sub.SubjectId == subjectDropDownList.SelectedValue &&
                            sub.UnitCodeNo == unitcodeDropDownList.SelectedValue
                        select new
                        {
                            VarStudentID = sub.StudentId,
                            std.VarStudentFirstName,
                            std.VarStudentMeddleName,
                            std.VarStudentLastName,
                            u.StudentRoll,
                            m.First_ST_Marks,
                            m.Second_ST_Marks,
                            m.Third_ST_Marks,
                            m.Final_Marks,
                        };
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();
                }
                else if (classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue != "0" &&
                         subjectDropDownList.SelectedValue != "" && unitcodeDropDownList.SelectedValue != "")
                {
                    var his = from u in db.tbl_Present_classes
                        join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                        from std in stdGroup.DefaultIfEmpty()
                        join sub in db.tbl_EdexcelSubjectAssigns on u.VarStudentID equals sub.StudentId into
                            subGroup
                        from sub in subGroup.DefaultIfEmpty()
                        join c in db.Classes on sub.ClassId equals c.VarClassID into cGroup
                        from c in cGroup.DefaultIfEmpty()
                        join s in db.tblSections on sub.Section equals s.SectionId into uGroup
                        from s in uGroup.DefaultIfEmpty()
                        //join m in db.tbl_ExamMarks on new { X1 = u.VarStudentID, X2 = sub.VarSubjectCode, X3 = (m.Examcode = examNameDropDownList.SelectedValue) } equals new { m.VarStudentId, m.VarSubjectCode, m.ExamCode } into mGroup
                        //from m in mGroup.DefaultIfEmpty()
                        join m in db.tbl_ExamMarks on
                            new
                            {
                                sub.StudentId,
                                sub.SubjectId,
                                sub.UnitCode,
                                ExamCode = examNameDropDownList.SelectedValue
                            } equals
                            new
                            {
                                StudentId = m.VarStudentId,
                                SubjectId = m.VarSubjectCode,
                                m.UnitCode,
                                m.ExamCode
                            } into mJoin
                        from m in mJoin.DefaultIfEmpty()
                        //new { u.VarStudentID, sub.VarSubjectCode } equals new { m..field1, m.VarSubjectCode }
                        orderby u.StudentRoll ascending
                        where
                            sub.ClassId == classDropDownList.SelectedValue && u.Status != "L" &&
                            sub.SubjectId == subjectDropDownList.SelectedValue &&
                            sub.UnitCodeNo == unitcodeDropDownList.SelectedValue &&
                            sub.Section == sectionDropDownList.SelectedValue
                        select new
                        {
                            VarStudentID = sub.StudentId,
                            std.VarStudentFirstName,
                            std.VarStudentMeddleName,
                            std.VarStudentLastName,
                            u.StudentRoll,
                            m.First_ST_Marks,
                            m.Second_ST_Marks,
                            m.Third_ST_Marks,
                            m.Final_Marks,
                        };
                    GridView1.DataSource = his.AsEnumerable();
                    GridView1.DataBind();

                    //var his = from u in db.tbl_Present_classes
                    //          join std in db.Students on u.VarStudentID equals std.VarStudentID into stdGroup
                    //          from std in stdGroup.DefaultIfEmpty()
                    //          join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                    //          from c in cGroup.DefaultIfEmpty()
                    //          join s in db.tblSections on u.VarSection equals s.SectionId into uGroup
                    //          from s in uGroup.DefaultIfEmpty()
                    //          join sub in db.tbl_EdexcelSubjectAssigns on u.VarStudentID equals sub.StudentId into subGroup
                    //          from sub in subGroup.DefaultIfEmpty()
                    //          join m in db.tbl_ExamMarks on u.VarStudentID equals m.VarStudentId into mGroup
                    //          from m in mGroup.DefaultIfEmpty()
                    //          orderby u.StudentRoll ascending
                    //          where sub.ClassId == classDropDownList.SelectedValue && u.Status != "L" && sub.SubjectId == subjectDropDownList.SelectedValue && sub.Section == sectionDropDownList.SelectedValue && sub.UnitCode == unitcodeDropDownList.SelectedValue
                    //          select new
                    //          {
                    //              u.VarStudentID,
                    //              std.VarStudentFirstName,
                    //              std.VarStudentMeddleName,
                    //              //u.RecommendAdmissionSection,
                    //              //u.CampusId,
                    //              std.VarStudentLastName,
                    //              //u.PClassID,
                    //              u.StudentRoll,
                    //              //u.VarShiftCode,
                    //              //s.varSectionName,
                    //              m.First_ST_Marks,
                    //              m.Second_ST_Marks,
                    //              m.Third_ST_Marks,
                    //              m.Final_Marks,
                    //              //c.VarClassName,

                    //          };
                    //GridView1.DataSource = his.AsEnumerable();
                    //GridView1.DataBind();
                }
            }
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            var examMarks = new tbl_ExamMark();
            string unitCodeName = "";
            string session = sessionDropDownList.SelectedValue;
            string cls = classDropDownList.SelectedValue;
            string studentId = ((Label) gvrow.Cells[1].FindControl("Label1")).Text;
            string section = GetSection(studentId);
            string subjectCode = subjectDropDownList.SelectedValue;
            string subName = subjectDropDownList.SelectedItem.Text;
            string unitCodeNo = unitcodeDropDownList.SelectedValue;
            if (unitcodeDropDownList.SelectedValue!="")
            {
                 unitCodeName = unitcodeDropDownList.SelectedItem.Text;
            }
            
            string examCode = examNameDropDownList.SelectedValue;

            string firstSt = ((TextBox) gvrow.Cells[4].FindControl("firstStMarks")).Text;
            string secondSt = ((TextBox) gvrow.Cells[5].FindControl("secondStMarks")).Text;
            string thirdSt = ((TextBox) gvrow.Cells[6].FindControl("thirdStMarks")).Text;
            string final = ((TextBox) gvrow.Cells[7].FindControl("finalMarks")).Text;

            //tbl_Present_class pcl = db.tbl_Present_classes.FirstOrDefault(x => x.VarStudentID == studentId);
            //Class getClsssType = db.Classes.FirstOrDefault(x => x.VarClassID == pcl.VarClassID);
            //if (getClsssType != null && getClsssType.ClassType==1)
            //{
            //    tbl_StudentSubjectAssign getSectionAssign =
            //        db.tbl_StudentSubjectAssigns.FirstOrDefault(x => x.VarStudentId == studentId);

            //    if (getSectionAssign != null) section = getSectionAssign.VarSection;
            //}

            tbl_ExamMark check =
                (from d in db.tbl_ExamMarks
                    where
                        d.VarStudentId == studentId && d.VarSession == session && d.VarClassId == cls &&
                        d.VarSubjectCode == subjectCode && d.ExamCode == examCode && d.UnitCodeNO==unitCodeNo
                    select d).FirstOrDefault();

            if (check != null)
            {
                if (firstSt != "")
                {
                    check.First_ST_Marks = Convert.ToDouble(firstSt);
                }
                if (secondSt != "")
                {
                    check.Second_ST_Marks = Convert.ToDouble(secondSt);
                }
                if (thirdSt != "")
                {
                    check.Third_ST_Marks = Convert.ToDouble(thirdSt);
                }
                if (final != "")
                {
                    check.Final_Marks = Convert.ToDouble(final);
                }
                db.SubmitChanges();
            }
            else
            {
                examMarks.VarSession = session;
                examMarks.VarClassId = cls;
                examMarks.VarSection = section;
                examMarks.VarSubjectCode = subjectCode;
                examMarks.VarSubName = subName;
                examMarks.UniqueSubId = subjectCode + unitCodeNo;
                examMarks.UniqueSubName = subName + " " + unitCodeName;
                if (unitCodeNo != "")
                {
                    examMarks.UnitCodeNO = unitCodeNo;
                    examMarks.UnitCode = unitCodeName;
                }
                examMarks.ExamCode = examCode;
                examMarks.VarStudentId = studentId;
                if (firstSt != "")
                {
                    examMarks.First_ST_Marks = Convert.ToDouble(firstSt);
                }
                if (secondSt != "")
                {
                    examMarks.Second_ST_Marks = Convert.ToDouble(secondSt);
                }
                if (thirdSt != "")
                {
                    examMarks.Third_ST_Marks = Convert.ToDouble(thirdSt);
                }
                if (final != "")
                {
                    examMarks.Final_Marks = Convert.ToDouble(final);
                }

                db.tbl_ExamMarks.InsertOnSubmit(examMarks);
                db.SubmitChanges();
            }
        }
        successStatusLabel.InnerText = "Marks Added Successfully....!";
        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    private string GetSection(string studentId)
    {
        string section = null;
        Class clsType = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
        if (clsType != null && clsType.ClassType == 1)
        {
            tbl_StudentSubjectAssign studentSubjectAssign =
                db.tbl_StudentSubjectAssigns.FirstOrDefault(
                    x => x.VarStudentId == studentId && x.VarSubjectCode == subjectDropDownList.SelectedValue);
            if (studentSubjectAssign != null) section = studentSubjectAssign.VarSection;
        }
        else if (clsType != null && clsType.ClassType == 2)
        {
            tbl_EdexcelSubjectAssign studentSubjectAssign =
                db.tbl_EdexcelSubjectAssigns.FirstOrDefault(
                    x =>
                        x.StudentId == studentId && x.SubjectId == subjectDropDownList.SelectedValue &&
                        x.UnitCode == unitcodeDropDownList.SelectedValue);
            if (studentSubjectAssign != null) section = studentSubjectAssign.Section;
        }
        return section;
    }

    //private static void GetHifgestSt()
    //{
    //    tbl_ExamMark examMarks=new tbl_ExamMark();
    //    if (examMarks.Third_ST_Marks != null && examMarks.First_ST_Marks != null &&
    //        examMarks.Second_ST_Marks != null)
    //    {
    //        examMarks.Highest_ST_Marks =
    //            Math.Max(Math.Max((float) examMarks.First_ST_Marks, (float) examMarks.Second_ST_Marks),
    //                (float) examMarks.Third_ST_Marks);
    //    }
    //    else if (examMarks.Third_ST_Marks == null && examMarks.First_ST_Marks != null &&
    //             examMarks.Second_ST_Marks != null)
    //    {
    //        examMarks.Highest_ST_Marks = Math.Max((float) examMarks.First_ST_Marks, (float) examMarks.Second_ST_Marks);
    //    }
    //    else if (examMarks.Third_ST_Marks != null && examMarks.First_ST_Marks == null &&
    //             examMarks.Second_ST_Marks != null)
    //    {
    //        examMarks.Highest_ST_Marks = Math.Max((float) examMarks.Second_ST_Marks, (float) examMarks.Third_ST_Marks);
    //    }
    //    else if (examMarks.Third_ST_Marks != null && examMarks.First_ST_Marks != null &&
    //             examMarks.Second_ST_Marks == null)
    //    {
    //        examMarks.Highest_ST_Marks = Math.Max((float) examMarks.First_ST_Marks, (float) examMarks.Third_ST_Marks);
    //    }
    //    else if (examMarks.Third_ST_Marks != null && examMarks.First_ST_Marks == null &&
    //             examMarks.Second_ST_Marks == null)
    //    {
    //        examMarks.Highest_ST_Marks = (float) examMarks.Third_ST_Marks;
    //    }
    //    else if (examMarks.Third_ST_Marks == null && examMarks.First_ST_Marks != null &&
    //             examMarks.Second_ST_Marks == null)
    //    {
    //        examMarks.Highest_ST_Marks = (float) examMarks.First_ST_Marks;
    //    }
    //    else if (examMarks.Third_ST_Marks == null && examMarks.First_ST_Marks == null &&
    //             examMarks.Second_ST_Marks != null)
    //    {
    //        examMarks.Highest_ST_Marks = (float) examMarks.Second_ST_Marks;
    //    }
    //}
}