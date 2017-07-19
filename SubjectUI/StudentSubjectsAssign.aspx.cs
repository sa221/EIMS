using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubjectUI_StudentSubjectsAssign : Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    private string _studentId = "";
    private string _sessionId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        _studentId = Request.QueryString["VarStudentID"];
        _sessionId = Request.QueryString["VarSessionId"];
        if (!IsPostBack)
        {
            if (_studentId != null )
            {
                branchInitialTextBox.Text = _studentId.Substring(0, 2);
                txtStdId.Text = _studentId.Substring(2);
                sessionDropDownList.SelectedValue = _sessionId;
                sessionDropDownList.DataBind();
                GetSubject();
            }
            if (Session["VarBranchId"] != null)
            {
                int branchId = Convert.ToInt32(Session["VarBranchId"]);
                Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
                if (branchInitial != null)
                {
                    branchInitialTextBox.Text = branchInitial.VarBranchInitial;
                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                stdSearchLiteral.Text = "";
            }
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        if (subCountTextBox.Text != "")
        {
            int totalSubject = Convert.ToInt32(subCountTextBox.Text);
            if (totalSubject >= 3)
            {
                string studentId = branchInitialTextBox.Text + txtStdId.Text;

                IQueryable<tbl_StudentSubjectAssign> items =
                    db.tbl_StudentSubjectAssigns.Where(
                        item => item.VarStudentId == studentId && item.VarSessionId == sessionDropDownList.SelectedValue);
                foreach (tbl_StudentSubjectAssign item in items)
                    db.tbl_StudentSubjectAssigns.DeleteOnSubmit(item);

                foreach (GridViewRow gvrow in studentSubjectGridView.Rows)
                {
                    var subAssign = new tbl_StudentSubjectAssign();
                    var chk = (CheckBox) gvrow.FindControl("subCheckBox");
                    if (chk != null && chk.Checked)
                    {
                        string str = gvrow.Cells[2].Text;
                        tbl_Subject isLabSubject =
                            db.tbl_Subjects.FirstOrDefault(
                                x => x.VarSubjectCode == str && x.ClassId == classDropDown.SelectedValue);
                        if (isLabSubject != null && isLabSubject.IsLab == 1)
                        {
                            IQueryable<tbl_feesInfo> feesInfo =
                                (db.tbl_feesInfos.Where(
                                    f => f.VarClassId == classDropDown.SelectedValue && f.FeesType == 3)).AsQueryable();
                            foreach (tbl_feesInfo fess in feesInfo)
                            {
                                var stdAccount = new tbl_Students_Account();

                                decimal fees = fess.Fees*12;
                                //decimal vat = (fess.Fees * 12 * (decimal).075);
                                tbl_Students_Account stdAccountChk = (from a in db.tbl_Students_Accounts
                                    where
                                        a.VarStudentId == studentId &&
                                        a.VarSessionId == sessionDropDownList.SelectedValue &&
                                        a.PayableFeesId == fess.FeesId
                                    select a).FirstOrDefault();
                                if (stdAccountChk == null)
                                {
                                    stdAccount.VarSessionId = sessionDropDownList.SelectedValue;
                                    stdAccount.VarStudentId = studentId;
                                    stdAccount.PayableFeesId = fess.FeesId;
                                    //stdAccount.PayableVat = vat;
                                    stdAccount.PayableAmount = fees;
                                    stdAccount.NetPayable = fees;
                                    stdAccount.FeesAssignDate = DateTime.Now;
                                    db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
                                }
                            }
                        }
                        subAssign.VarStudentId = studentId;
                        subAssign.VarSessionId = sessionDropDownList.SelectedValue;
                        subAssign.EntryDate = DateTime.Now;
                        subAssign.uid = Session["uid"].ToString();
                        subAssign.VarBranchId = Session["VarBranchId"].ToString();
                        subAssign.VarSection = sectionDropDownList.SelectedValue;
                        subAssign.ClassId = classDropDown.SelectedValue;
                        subAssign.VarSubjectCode = str;
                        db.tbl_StudentSubjectAssigns.InsertOnSubmit(subAssign);
                        db.SubmitChanges();
                    }
                }
                //if (remissionLabFeesCheckBox.Checked == false)
                //{
                //    IQueryable<tbl_feesInfo> feesInfo = (db.tbl_feesInfos.Where(f => f.VarClassId == classDropDown.SelectedValue && f.FeesType == 3)).AsQueryable();
                //    foreach (tbl_feesInfo fess in feesInfo)
                //    {
                //        tbl_Students_Account stdAccount = new tbl_Students_Account();

                //        decimal fees = fess.Fees * 12;
                //        //decimal vat = (fess.Fees * 12 * (decimal).075);
                //         var stdAccountChk = (from a in db.tbl_Students_Accounts
                //                                 where a.VarStudentId == studentId && a.VarSessionId == sessionDropDownList.SelectedValue && a.PayableFeesId==fess.FeesId
                //                                 select a).FirstOrDefault();
                //        if (stdAccountChk == null)
                //        {
                //            stdAccount.VarSessionId = sessionDropDownList.SelectedValue;
                //            stdAccount.VarStudentId = studentId;
                //            stdAccount.PayableFeesId = fess.FeesId;
                //            //stdAccount.PayableVat = vat;
                //            stdAccount.PayableAmount = fees;
                //            stdAccount.NetPayable = fees;
                //            stdAccount.FeesAssignDate = DateTime.Now;
                //            db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
                //        }
                //    }

                //}

                Literal1.Text = "<p style='color:Green;'>Subjects successfully assigned with ID " + studentId;
                CLearText();
            }
            else
            {
                Literal1.Text = "<p style='color:Red;'>Minimum requirement is seven subjects. ";
            }
        }

        else
        {
            Literal1.Text = "<p style='color:Red;'>Minimum requirement is seven subjects. ";
        }
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        GetSubject();
    }

    private void GetSubject()
    {
        stdSearchLiteral.Text = "";
        classDropDown.SelectedValue = "";
        sectionDropDownList.Items.Clear();
        string studentId = branchInitialTextBox.Text + txtStdId.Text;
        Student student = db.Students.FirstOrDefault(z => z.VarStudentID == studentId);
        if (student != null)
        {
            studentNameLabel.Text = student.VarStudentFirstName + " " + student.VarStudentMeddleName + " " +
                                    student.VarStudentLastName;
        }

        IQueryable<string> checkExistingStudentId = from c in db.tbl_Present_classes
                                                    where c.VarStudentID == studentId && c.VarSessionId == sessionDropDownList.SelectedValue
                                                    select c.VarStudentID;
        if (checkExistingStudentId.FirstOrDefault() != null)
        {
            tbl_Present_class presentClass = db.tbl_Present_classes.FirstOrDefault(p => p.VarStudentID == studentId);

            string clsId = presentClass.VarClassID;
            Class cls = db.Classes.FirstOrDefault(c => c.VarClassID == clsId);


            if (cls.ClassType == 1)
            {
                classDropDown.SelectedValue = cls.VarClassID;
                classDropDown.DataBind();
                //sectionDropDownList.Items.Insert(0, new ListItem("Select", "0"));
                if (presentClass.VarSection!="0")
                {
                    sectionDropDownList.SelectedValue = presentClass.VarSection;
                    sectionDropDownList.DataBind(); 
                }
                studentSubjectGridView.DataBind();
                foreach (GridViewRow gvrow in studentSubjectGridView.Rows)
                {
                    string str = gvrow.Cells[2].Text;
                    tbl_Subject subject =
                        db.tbl_Subjects.FirstOrDefault(s => s.ClassId == clsId && s.VarSubjectCode == str);
                    IQueryable<string> subTypeCheck = from u in db.tbl_Subjects
                                                      where u.VarSubjectCode == str && u.ClassId == clsId
                                                      select u.VarSubjectCode;
                    var chk = (CheckBox)gvrow.FindControl("subCheckBox");
                    if (subject != null && subject.Type == 1)
                    {
                        if (subTypeCheck.ToList().Contains(str))
                        {
                            chk.Checked = true;
                            chk.Enabled = false;
                        }
                    }
                }
                var assignCheck = from s in db.tbl_StudentSubjectAssigns
                                  where s.VarStudentId == studentId && s.VarSessionId == sessionDropDownList.SelectedValue
                                  select new { s.VarSubjectCode };
                if (assignCheck.FirstOrDefault() != null)
                {
                    IQueryable<string> subAssign = from u in db.tbl_StudentSubjectAssigns
                                                   where u.VarStudentId == studentId && u.VarSessionId == sessionDropDownList.SelectedValue
                                                   select u.VarSubjectCode;
                    if (assignCheck.FirstOrDefault() != null)
                    {
                        foreach (GridViewRow gvrow in studentSubjectGridView.Rows)
                        {
                            var chk = (CheckBox)gvrow.FindControl("subCheckBox");

                            string str2 = gvrow.Cells[2].Text;
                            if (subAssign.ToList().Contains(str2))
                            {
                                chk.Checked = true;
                            }
                        }
                    }
                }
                else
                {
                    IQueryable<string> subAssign = from u in db.tbl_StudentSubjectAssigns
                                                   where u.VarStudentId == studentId
                                                   select u.VarSubjectCode;
                    foreach (GridViewRow gvrow in studentSubjectGridView.Rows)
                    {
                        var chk = (CheckBox)gvrow.FindControl("subCheckBox");

                        string str2 = gvrow.Cells[2].Text;
                        if (subAssign.ToList().Contains(str2))
                        {
                            chk.Checked = true;
                        }
                    }
                }
                var test = from l in db.tbl_StudentSubjectAssigns
                           where
                               l.VarSessionId == sessionDropDownList.SelectedValue && l.ClassId == classDropDown.SelectedValue &&
                               l.VarSection == sectionDropDownList.SelectedValue
                           group l by l.VarStudentId
                               into g
                               select new
                               {
                                   VarStudentId = g.Key,
                                   Count = (from l in g select l.VarStudentId).Distinct().Count()
                               };

                totalStudentLabel.Text = test.Count().ToString();
            }
            else if (cls.ClassType == 2)
            {
                stdSearchLiteral.Text =
                    "<p style='Color:red;'>A-Level Student Subject assign could not possible in this page!";
            }
            else
            {
                stdSearchLiteral.Text =
                    "<p style='Color:red;'>Subject assign for Student between PlayGroup to Class-VII not required";
                classDropDown.Items.Clear();
            }
        }
        else
        {
            IQueryable<tbl_StudentSubjectAssign> studentSubject = from sa in db.tbl_StudentSubjectAssigns
                                                                  where sa.VarSessionId == sessionDropDownList.SelectedValue && sa.VarStudentId == studentId
                                                                  select sa;
            foreach (tbl_StudentSubjectAssign subAss in studentSubject.ToList())
            {
                string cls = subAss.ClassId;
                classDropDown.SelectedValue = cls;
                studentSubjectGridView.DataBind();
                foreach (GridViewRow gvrow in studentSubjectGridView.Rows)
                {
                    string str = gvrow.Cells[2].Text;
                    tbl_Subject subject =
                        db.tbl_Subjects.FirstOrDefault(s => s.ClassId == cls && s.VarSubjectCode == str);
                    IQueryable<string> subTypeCheck = from u in db.tbl_Subjects
                                                      where u.VarSubjectCode == str && u.ClassId == cls
                                                      select u.VarSubjectCode;
                    var chk = (CheckBox)gvrow.FindControl("subCheckBox");
                    if (subject != null && subject.Type == 1)
                    {
                        if (subTypeCheck.ToList().Contains(str))
                        {
                            chk.Checked = true;
                            chk.Enabled = false;
                        }
                    }
                }
                var assignCheck = from s in db.tbl_StudentSubjectAssigns
                                  where s.VarStudentId == studentId && s.VarSessionId == sessionDropDownList.SelectedValue
                                  select new { s.VarSubjectCode };
                IQueryable<string> subAssign = from u in db.tbl_StudentSubjectAssigns
                                               where u.VarStudentId == studentId && u.VarSessionId == sessionDropDownList.SelectedValue
                                               select u.VarSubjectCode;
                if (assignCheck.FirstOrDefault() != null)
                {
                    foreach (GridViewRow gvrow in studentSubjectGridView.Rows)
                    {
                        var chk = (CheckBox)gvrow.FindControl("subCheckBox");

                        string str2 = gvrow.Cells[2].Text;
                        if (subAssign.ToList().Contains(str2))
                        {
                            chk.Checked = true;
                        }
                    }
                }
            }

            stdSearchLiteral.Text = "<p style='Color:red;'>Student Not Found!";
        }
    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Student Info Entry/StudentAddmission.aspx");
    }

    private void CLearText()
    {
        txtStdId.Text = "";
        classDropDown.SelectedValue = "";
        totalStudentLabel.Text = "";
        studentNameLabel.Text = "";
        sectionDropDownList.Items.Clear();
        //sectionDropDownList.DataBind();
        subCountTextBox.Text = "";
        studentSubjectGridView.DataSource = null;
        studentSubjectGridView.DataBind();
    }
}