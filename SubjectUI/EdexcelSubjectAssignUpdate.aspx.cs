using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubjectUI_EdexcelSubjectAssignUpdate : Page
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
            if (_studentId != null)
            {
                branchInitialTextBox.Text = _studentId.Substring(0, 2);
                txtStdId.Text = _studentId.Substring(2);
                sessionDropDownList.SelectedValue = _sessionId;
                sessionDropDownList.DataBind();
                GetStudentSubject();
            }
        }
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        GetStudentSubject();
    }

    private void GetStudentSubject()
    {
        studentNameLabel.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
        string studentId = branchInitialTextBox.Text + txtStdId.Text;
        tbl_Present_class presentClass = db.tbl_Present_classes.FirstOrDefault(p => p.VarStudentID == studentId);
        Student getStudent = db.Students.FirstOrDefault(p => p.VarStudentID == studentId);
        if (presentClass != null)
        {
            sessionDropDownList.SelectedValue = presentClass.VarSessionId;
        }

        Class cls = db.Classes.FirstOrDefault(c => c.VarClassID == presentClass.VarClassID);
        IQueryable<string> isSubjectAssign = from c in db.tbl_EdexcelSubjectAssigns
            where c.StudentId == studentId && c.Session == sessionDropDownList.SelectedValue
            select c.StudentId;
        if (cls != null && cls.ClassType == 2)
        {
            classDropDownList.Items.Clear();
            classDropDownList.Items.Insert(0, new ListItem(cls.VarClassName, cls.VarClassID));
            if (getStudent != null)
                studentNameLabel.Text = getStudent.VarStudentFirstName + " " + getStudent.VarStudentLastName +
                                        "       ROLL:" + getStudent.StudentRoll;
            if (isSubjectAssign.FirstOrDefault() != null)
            {
                //classDropDown.SelectedValue = clsId;

                var his = from u in db.tbl_EdexcelSubjectAssigns
                    join s in db.tbl_Subjects on u.SubjectId equals s.VarSubjectCode into sGroup
                    from s in sGroup.DefaultIfEmpty()
                    join sec in db.tblSections on u.Section equals sec.SectionId into uGroup
                    from sec in uGroup.DefaultIfEmpty()
                    where
                        u.StudentId == studentId && u.Session == sessionDropDownList.SelectedValue &&
                        s.ClassId == classDropDownList.SelectedValue
                    select new {s.VarSubjectName, u.UnitCode, u.Section};
                GridView1.DataSource = his.AsEnumerable();
                GridView1.DataBind();
            }

            var allSubject = (
                from s in db.tbl_Subjects
                join eu in db.tbl_EdexelunitCodes
                    on new {s.VarSubjectCode, s.ClassId}
                    equals new {VarSubjectCode = eu.SpecificationCode, ClassId = eu.Class}
                join es in db.tbl_EdexcelSubjectAssigns on new {eu.UnitCodeSpeCode} equals
                    new {UnitCodeSpeCode = es.UnitCodeNo} into es_join
                from es in es_join.DefaultIfEmpty()
                where
                    s.ClassId == classDropDownList.SelectedValue
                select new
                {
                    s.VarSubjectName,
                    eu.UnitCode,
                    s.ClassId
                }
                ).Except
                (
                    from s in db.tbl_Subjects
                    join eu in db.tbl_EdexelunitCodes
                        on new { s.VarSubjectCode, s.ClassId }
                        equals new { VarSubjectCode = eu.SpecificationCode, ClassId = eu.Class }
                    join es in db.tbl_EdexcelSubjectAssigns on new { eu.UnitCodeSpeCode,eu.Class} equals
                        new { UnitCodeSpeCode = es.UnitCodeNo,Class=es.ClassId} into es_join
                    from es in es_join.DefaultIfEmpty()
                    where
                        s.ClassId == classDropDownList.SelectedValue &&
                        es.StudentId == studentId
                    select new
                    {
                        s.VarSubjectName,
                        eu.UnitCode,
                        s.ClassId
                    }
                );

            GridView2.DataSource = allSubject.AsEnumerable();
            GridView2.DataBind();

            //failStatusLabel.InnerText = "Subject Already Assign for ID: " + branchInitialTextBox.Text + "" + txtStdId.Text;
        }
    }

    //protected void sectionDropDown_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string studentId = branchInitialTextBox.Text + txtStdId.Text;
    //    foreach (GridViewRow gvrow in GridView1.Rows)
    //    {
    //        ((TextBox)gvrow.Cells[3].FindControl("countTextBox")).Text = "";

    //        string subject = ((Label)gvrow.FindControl("Label1")).Text;
    //        string unitCode = ((Label)gvrow.FindControl("Label2")).Text;
    //        //section = gvrow.Cells[2].Text;
    //        string section = ((DropDownList)gvrow.Cells[2].FindControl("sectionDropDown")).SelectedItem.Value;
    //        tbl_Subject sub = db.tbl_Subjects.FirstOrDefault(s => s.VarSubjectName == subject && s.ClassId == classDropDownList.SelectedValue);
    //        int count = (from p in db.tbl_EdexcelSubjectAssigns
    //                     where p.UnitCode == unitCode && p.Section == section && p.Session == sessionDropDownList.SelectedValue && p.ClassId == classDropDownList.SelectedValue && p.SubjectId == sub.VarSubjectCode && p.StudentId == studentId
    //                     select p).Count();
    //        ((TextBox)gvrow.Cells[3].FindControl("countTextBox")).Text = count.ToString();

    //    }
    //}
    //protected void findButton_Click(object sender, EventArgs e)
    //{
    //    string studentId = branchInitialTextBox.Text + "" + txtStdId.Text;

    //    var subUnitCode = (from u in db.tbl_EdxelSubjects
    //                       join s in db.tbl_EdexelunitCodes on u.SpecificationCode equals s.SpecificationCode

    //        where s.UnitCodeSpeCode == unitNoTextBox.Text
    //            //.Except(sAssign.UnitCodeNo
    //            //.Where(x=>sAssign.Session.Contains(sessionDropDownList.SelectedValue)))
    //        select new {s.UnitCode, u.VarSubjectName,s.UnitCodeSpeCode});
    //    if (subUnitCode.FirstOrDefault()!=null)
    //    {
    //        foreach (var subjet in subUnitCode)
    //        {
    //            tbl_EdexcelSubjectAssign subjectAssign =
    //                db.tbl_EdexcelSubjectAssigns.FirstOrDefault(
    //                    s =>
    //                        s.Session == sessionDropDownList.SelectedValue && s.StudentId == studentId &&
    //                        s.UnitCodeNo == subjet.UnitCodeSpeCode);
    //            if (subjectAssign == null)
    //            {
    //                subjectNameLabel.Text = subjet.VarSubjectName;
    //                unitCodeLabel.Text = subjet.UnitCode;
    //            }
    //            else
    //            {
    //                failStatusLabel.InnerText = "This Subject already taken.";
    //            }

    //        }
    //    }
    //    else
    //    {
    //        failStatusLabel.InnerText = "Subject not found";
    //    }  


    //}
    //protected void sectionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string unitcode = unitCodeLabel.Text;

    //    int count = (from p in db.tbl_EdexcelSubjectAssigns
    //                 where p.UnitCode == unitcode && p.Section == sectionDropDownList.SelectedValue && p.Session == sessionDropDownList.SelectedValue && p.ClassId == classDropDownList.SelectedValue
    //                 select p).Count();
    //    countTextBox.Text = count.ToString();
    //}
    //protected void addButton_Click(object sender, EventArgs e)
    //{
    //    tbl_EdexcelSubjectAssign subAssign=new tbl_EdexcelSubjectAssign();
    //    string studentId = branchInitialTextBox.Text + "" + txtStdId.Text;

    //    tbl_EdexelunitCode subId = db.tbl_EdexelunitCodes.FirstOrDefault(x => x.UnitCodeSpeCode==unitNoTextBox.Text);

    //    subAssign.Session = sessionDropDownList.SelectedValue;
    //    subAssign.ClassId = classDropDownList.SelectedValue;
    //    subAssign.StudentId = studentId;
    //    if (subId != null) subAssign.SubjectId = subId.SpecificationCode;
    //    subAssign.Section = sectionDropDownList.SelectedValue;
    //    subAssign.UnitCode = unitCodeLabel.Text;
    //    subAssign.UnitCodeNo = unitNoTextBox.Text;
    //    subAssign.uid=Session["uid"].ToString();
    //    subAssign.EntryDate=DateTime.Now;
    //    db.tbl_EdexcelSubjectAssigns.InsertOnSubmit(subAssign);
    //    db.SubmitChanges();

    //}
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string studentId = branchInitialTextBox.Text + txtStdId.Text;
        if (e.CommandName == "AddButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GridView2.Rows[index];
            string subject = ((Label) gvRow.FindControl("subjectLabel")).Text;
            string unitCode = ((Label) gvRow.FindControl("unitCodeLabel")).Text;
            string section = ((DropDownList) gvRow.FindControl("sectionDropDownList")).Text;

            tbl_Subject sub =
                db.tbl_Subjects.FirstOrDefault(
                    s => s.VarSubjectName == subject && s.ClassId == classDropDownList.SelectedValue);
            tbl_EdexelunitCode unitCod =
                db.tbl_EdexelunitCodes.FirstOrDefault(
                    u =>
                        u.UnitCode == unitCode && u.SpecificationCode == sub.VarSubjectCode &&
                        u.Class == classDropDownList.SelectedValue);


            var subjectAssign = new tbl_EdexcelSubjectAssign();
            //tbl_Students_Account stdAccount=new tbl_Students_Account();

            if (sub.IsLab == 1)
            {
                //var chkLabFees = db.tbl_Students_Accounts.FirstOrDefault(x => x.PayableFeesId == 5);
                //var chkLabFees = from sa in db.tbl_Students_Accounts
                //    where
                //        sa.VarStudentId == studentId && sa.VarSessionId == sessionDropDownList.SelectedValue &&
                //        sa.PayableFeesId == 5
                //    select sa;
                //if (chkLabFees.FirstOrDefault()==null)
                //{
                IQueryable<tbl_feesInfo> feesInfo =
                    (db.tbl_feesInfos.Where(f => f.VarClassId == classDropDownList.SelectedValue && f.FeesId == 5))
                        .AsQueryable();
                foreach (tbl_feesInfo fess in feesInfo)
                {
                    var stdAccount = new tbl_Students_Account();

                    decimal fees = fess.Fees*12;
                    //decimal vat = (fess.Fees * 12 * (decimal).075);
                    tbl_Students_Account stdAccountChk = (from a in db.tbl_Students_Accounts
                        where
                            a.VarStudentId == studentId && a.VarSessionId == sessionDropDownList.SelectedValue &&
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
                //}
            }
            subjectAssign.Session = sessionDropDownList.SelectedValue;
            subjectAssign.ClassId = classDropDownList.SelectedValue;
            subjectAssign.StudentId = branchInitialTextBox.Text + "" + txtStdId.Text;
            if (sub != null) subjectAssign.SubjectId = sub.VarSubjectCode;
            subjectAssign.Section = section;
            subjectAssign.UnitCode = unitCode;
            if (unitCod != null) subjectAssign.UnitCodeNo = unitCod.UnitCodeSpeCode;
            subjectAssign.VarBranchId = Session["VarBranchId"].ToString();
            subjectAssign.uid = Session["uid"].ToString();
            subjectAssign.EntryDate = DateTime.Now;

            db.tbl_EdexcelSubjectAssigns.InsertOnSubmit(subjectAssign);
            db.SubmitChanges();

            var btn = ((Button) gvRow.FindControl("btnAdd"));
            btn.Text = "Taken";
            btn.Enabled = false;
            var his = from u in db.tbl_EdexcelSubjectAssigns
                join s in db.tbl_Subjects on u.SubjectId equals s.VarSubjectCode into sGroup
                from s in sGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.Section equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.StudentId == studentId && u.Session == sessionDropDownList.SelectedValue &&
                    s.ClassId == classDropDownList.SelectedValue
                select new {s.VarSubjectName, u.UnitCode, u.Section};
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
    }

    protected void sectionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView2.Rows)
        {
            ((TextBox) gvrow.Cells[3].FindControl("takenTextBox")).Text = "";
            //string str = gvrow.Cells[1].Text;
            string subName = ((Label) gvrow.FindControl("subjectLabel")).Text;
            tbl_Subject getSubCode =
                db.tbl_Subjects.FirstOrDefault(
                    x => x.ClassId == classDropDownList.SelectedValue && x.VarSubjectName == subName);
            string unitCode = ((Label) gvrow.FindControl("unitCodeLabel")).Text;
            string section = ((DropDownList) gvrow.Cells[2].FindControl("sectionDropDownList")).SelectedItem.Value;
            int count = (from p in db.tbl_EdexcelSubjectAssigns
                where
                    p.UnitCode == unitCode && p.Section == section && p.Session == sessionDropDownList.SelectedValue &&
                    p.ClassId == classDropDownList.SelectedValue && p.SubjectId == getSubCode.VarSubjectCode
                select p).Count();
            ((TextBox) gvrow.Cells[3].FindControl("takenTextBox")).Text = count.ToString();
        }
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string studentId = branchInitialTextBox.Text + txtStdId.Text;
        if (e.CommandName == "SaveButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GridView1.Rows[index];
            string subject = ((Label) gvRow.FindControl("Label1")).Text;
            string unitCode = ((Label) gvRow.FindControl("Label2")).Text;
            string section = ((DropDownList) gvRow.FindControl("sectionDropDown")).Text;
            tbl_Subject sub =
                db.tbl_Subjects.FirstOrDefault(
                    s => s.VarSubjectName == subject && s.ClassId == classDropDownList.SelectedValue);
            tbl_EdexcelSubjectAssign subjectAs =
                db.tbl_EdexcelSubjectAssigns.FirstOrDefault(
                    a =>
                        a.SubjectId == sub.VarSubjectCode && a.UnitCode == unitCode && a.StudentId == studentId &&
                        a.Session == sessionDropDownList.SelectedValue);
            if (subjectAs != null)
            {
                subjectAs.Section = section;
                db.SubmitChanges();
            }
            //foreach (GridViewRow gvrow in GridView1.Rows)
            //{

            ((TextBox) gvRow.Cells[3].FindControl("countTextBox")).Text = "";

            //GridViewRow gvRow = GridView1.Rows[index];
            //string subject = ((Label)gvrow.FindControl("Label1")).Text;
            //string unitCode = ((Label)gvrow.FindControl("Label2")).Text;
            //string section = ((DropDownList)gvrow.FindControl("sectionDropDown")).Text;
            //tbl_Subject sub = db.tbl_Subjects.FirstOrDefault(s => s.VarSubjectName == subject && s.ClassId == classDropDownList.SelectedValue);

            int count = (from p in db.tbl_EdexcelSubjectAssigns
                where
                    p.UnitCode == unitCode && p.Section == section && p.Session == sessionDropDownList.SelectedValue &&
                    p.ClassId == classDropDownList.SelectedValue && p.SubjectId == sub.VarSubjectCode
                select p).Count();
            ((TextBox) gvRow.Cells[3].FindControl("countTextBox")).Text = count.ToString();

            //}
        }
        else if (e.CommandName == "DeleteButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GridView1.Rows[index];
            string subject = ((Label) gvRow.FindControl("Label1")).Text;
            string unitCode = ((Label) gvRow.FindControl("Label2")).Text;
            string section = ((DropDownList) gvRow.FindControl("sectionDropDown")).Text;

            tbl_Subject sub =
                db.tbl_Subjects.FirstOrDefault(
                    s => s.VarSubjectName == subject && s.ClassId == classDropDownList.SelectedValue);
            tbl_EdexelunitCode unitCod = db.tbl_EdexelunitCodes.FirstOrDefault(u => u.UnitCode == unitCode);
            tbl_EdexcelSubjectAssign subjectAs =
                db.tbl_EdexcelSubjectAssigns.FirstOrDefault(
                    a => a.SubjectId == sub.VarSubjectCode && a.UnitCode == unitCode && a.StudentId == studentId);
            if (subjectAs != null)
            {
                db.tbl_EdexcelSubjectAssigns.DeleteOnSubmit(subjectAs);
                db.SubmitChanges();
            }
            //tbl_EdexcelSubjectAssign subjectAssign = new tbl_EdexcelSubjectAssign();

            //subjectAssign.Session = sessionDropDownList.SelectedValue;
            //subjectAssign.ClassId = classDropDownList.SelectedValue;
            //subjectAssign.StudentId = branchInitialTextBox.Text + "" + txtStdId.Text;
            //if (sub != null) subjectAssign.SubjectId = sub.VarSubjectCode;
            //subjectAssign.Section = section;
            //subjectAssign.UnitCode = unitCode;
            //if (unitCod != null) subjectAssign.UnitCodeNo = unitCod.UnitCodeSpeCode;
            //subjectAssign.uid = Session["uid"].ToString();
            //subjectAssign.EntryDate = DateTime.Now;

            //db.tbl_EdexcelSubjectAssigns.InsertOnSubmit(subjectAssign);
            //db.SubmitChanges();

            //Button btn = ((Button)gvRow.FindControl("btnAdd"));
            //btn.Text = "Taken";
            //btn.Enabled = false;
            var his = from u in db.tbl_EdexcelSubjectAssigns
                join s in db.tbl_Subjects on u.SubjectId equals s.VarSubjectCode into sGroup
                from s in sGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.Section equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.StudentId == studentId && u.Session == sessionDropDownList.SelectedValue &&
                    s.ClassId == classDropDownList.SelectedValue
                select new {s.VarSubjectName, u.UnitCode, u.Section};
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();

            var allSubject = (
                from s in db.tbl_Subjects
                join eu in db.tbl_EdexelunitCodes
                    on new {s.VarSubjectCode, s.ClassId}
                    equals new {VarSubjectCode = eu.SpecificationCode, ClassId = eu.Class}
                join es in db.tbl_EdexcelSubjectAssigns on new {eu.UnitCodeSpeCode} equals
                    new {UnitCodeSpeCode = es.UnitCodeNo} into es_join
                from es in es_join.DefaultIfEmpty()
                where
                    s.ClassId == classDropDownList.SelectedValue
                select new
                {
                    s.VarSubjectName,
                    eu.UnitCode,
                    s.ClassId
                }
                ).Except
                (
                    from s in db.tbl_Subjects
                    join eu in db.tbl_EdexelunitCodes
                        on new {s.VarSubjectCode, s.ClassId}
                        equals new {VarSubjectCode = eu.SpecificationCode, ClassId = eu.Class}
                    join es in db.tbl_EdexcelSubjectAssigns on new {eu.UnitCodeSpeCode} equals
                        new {UnitCodeSpeCode = es.UnitCodeNo} into es_join
                    from es in es_join.DefaultIfEmpty()
                    where
                        s.ClassId == classDropDownList.SelectedValue &&
                        es.StudentId == studentId
                    select new
                    {
                        s.VarSubjectName,
                        eu.UnitCode,
                        s.ClassId
                    }
                );
            GridView2.DataSource = allSubject.AsEnumerable();
            GridView2.DataBind();
        }
    }

    protected void sectionDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            ((TextBox) gvrow.Cells[3].FindControl("countTextBox")).Text = "";

            //GridViewRow gvRow = GridView1.Rows[index];
            string subject = ((Label) gvrow.FindControl("Label1")).Text;
            string unitCode = ((Label) gvrow.FindControl("Label2")).Text;
            string section = ((DropDownList) gvrow.FindControl("sectionDropDown")).Text;
            tbl_Subject sub =
                db.tbl_Subjects.FirstOrDefault(
                    s => s.VarSubjectName == subject && s.ClassId == classDropDownList.SelectedValue);

            int count = (from p in db.tbl_EdexcelSubjectAssigns
                where
                    p.UnitCode == unitCode && p.Section == section && p.Session == sessionDropDownList.SelectedValue &&
                    p.ClassId == classDropDownList.SelectedValue && p.SubjectId == sub.VarSubjectCode
                select p).Count();
            ((TextBox) gvrow.Cells[3].FindControl("countTextBox")).Text = count.ToString();
        }
    }
}