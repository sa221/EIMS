using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Info_Entry_ReAdmission : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["VarBranchId"] != null)
            {
                int branchId = Convert.ToInt32(Session["VarBranchId"]);
                Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
                if (branchInitial != null)
                {
                    branchinitialTextBox.Text = branchInitial.VarBranchInitial;
                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
        }
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        if (sessionDropdownlist.SelectedIndex != 0)
        {
            string stdId = branchinitialTextBox.Text + "" + studentIdTexBox.Text;
            tbl_Present_class getStudent =
                db.tbl_Present_classes.FirstOrDefault(
                    s => s.VarSessionId == sessionDropdownlist.SelectedValue && s.VarStudentID == stdId);
            if (getStudent != null)
            {
                if (sessionDropdownlist.SelectedValue != "0" && branchinitialTextBox.Text != "" &&
                    studentIdTexBox.Text != "")
                {

                    {
                        var his = from u in db.tbl_Present_classes
                            join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                            from c in cGroup.DefaultIfEmpty()
                            join s in db.Students on u.VarStudentID equals s.VarStudentID into sGroup
                            from s in sGroup.DefaultIfEmpty()
                            join sec in db.tblSections on u.VarSection equals sec.SectionId into secGroup
                            from sec in secGroup.DefaultIfEmpty()
                            where
                                u.VarSessionId == sessionDropdownlist.SelectedItem.Value && u.VarStudentID == stdId &&
                                s.Status != "L"
                            //orderby u.VarStudentID descending
                            select
                                new
                                {
                                    u.VarStudentID,
                                    u.StudentRoll,
                                    s.VarStudentFirstName,
                                    s.VarStudentLastName,
                                    c.VarClassName,
                                    sec.varSectionName,
                                    s.Status
                                };
                        Student stdd = db.Students.FirstOrDefault(s => s.VarStudentID == stdId);
                        if (stdd != null && stdd.Status == "L")
                        {
                            failStatusLabel.InnerText = "Student already left.";
                        }
                        else
                        {
                            foreach (var text in his.ToList())
                            {
                                nameTextBox.Text = text.VarStudentFirstName + "" + text.VarStudentLastName;
                                classTextBox.Text = text.VarClassName;
                                sectionTextBox.Text = text.varSectionName;
                                rollTextBox.Text = text.StudentRoll.ToString();
                            }
                        }
                    }
                }
                else
                {
                    failStatusLabel.InnerText = "Please Select Session and Insert Student ID.";
                }
            }
            else
            {
                failStatusLabel.InnerText = "Student not found.";
            }
        }
        else
        {
            failStatusLabel.InnerText = "Re-Admission only for previous session Student";
        }
    }

    protected void reAddClassDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        reAddSecDropDownList.Items.Clear();
        reAddSecDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
        reAddSecDropDownList.DataBind();
    }

    protected void reAddButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        //var transferHistory = new tbl_TransferHistory();
        var readmission = new tbl_ReAdmissionHistory();
        string studentId = branchinitialTextBox.Text + "" + studentIdTexBox.Text;
        tbl_Present_class pClass = db.tbl_Present_classes.FirstOrDefault(u => u.VarStudentID == studentId);
        Student studentCkh =
            (from d in db.Students
                where d.VarStudentID == studentId && d.VarSessionName == sessionDropdownlist.SelectedValue
                select d).SingleOrDefault();

        if (studentCkh != null)
        {
            studentCkh.VarSessionName = tSessionDropDownList.SelectedValue;
            studentCkh.RecommendAdmissionSection = reAddSecDropDownList.SelectedValue;

            studentCkh.PClassID = reAddClassDropDownList.SelectedValue;
            if (newRollTextBox.Text!="")
            {
                studentCkh.StudentRoll = Convert.ToInt32(newRollTextBox.Text);
            }
            
            studentCkh.VarShiftCode = pShiftDropDownList.SelectedValue;
            studentCkh.CampusId = headTCampusDropDown.SelectedValue;
            studentCkh.VarSessionName = tSessionDropDownList.SelectedValue;
            studentCkh.VarAdmissionSession = tSessionDropDownList.SelectedValue;
            readmission.VarStudentId = studentId;
            readmission.PreSession = sessionDropdownlist.SelectedValue;
            string className = classTextBox.Text;
            Class cls = db.Classes.FirstOrDefault(u => u.VarClassName == className);
            if (cls != null) readmission.PreClass = cls.VarClassID;
            tblSection secId = db.tblSections.FirstOrDefault(s => s.varSectionName == sectionTextBox.Text);
            if (secId != null) readmission.PreSection = secId.SectionId;
            if (pClass != null)
            {
                readmission.PreShift = pClass.VarShiftCode;
                readmission.PreRoll = pClass.StudentRoll.ToString();
                readmission.PreCampus = pClass.CampusId;
            }

            readmission.ReSession= tSessionDropDownList.SelectedValue;
            readmission.ReClass= reAddClassDropDownList.SelectedValue;
            readmission.ReSection = reAddSecDropDownList.SelectedValue;
            readmission.ReShift = pShiftDropDownList.SelectedValue;
            readmission.NewRoll = newRollTextBox.Text;
            readmission.ReCampus = headTCampusDropDown.SelectedValue;
            readmission.Status = 2; //If transfer then status=1,for re_admission status=2,for repeat status=3;
            readmission.uid = Session["uid"].ToString();
            readmission.InputDate = DateTime.Now;
            tbl_Present_class check =
                (from d in db.tbl_Present_classes
                    where d.VarStudentID == studentId 
                    select d).SingleOrDefault();

            if (check != null)
            {
                check.VarShiftCode = pShiftDropDownList.SelectedValue;
                check.VarClassID = reAddClassDropDownList.SelectedValue;
                check.VarSection = reAddSecDropDownList.SelectedValue;
                check.VarSessionId = tSessionDropDownList.SelectedValue;
                if (newRollTextBox.Text!="")
                {
                    check.StudentRoll = Convert.ToInt32(newRollTextBox.Text);
                }
                
                check.CampusId = headTCampusDropDown.SelectedValue;
            }

            IQueryable<tbl_feesInfo> feesInfo =
                (db.tbl_feesInfos.Where(
                    f =>
                        f.VarClassId == reAddClassDropDownList.SelectedValue &&
                        (f.FeesId == 2 || f.FeesId == 4 || f.FeesId == 6))).AsQueryable();
            //decimal netFees = feesInfo.Sum(x=>x.Fees)*12;

            foreach (tbl_feesInfo fess in feesInfo)
            {
                var stdAccount = new tbl_Students_Account();
                tbl_Students_Account stdAccountChk = (from a in db.tbl_Students_Accounts
                    where a.VarStudentId == studentId && a.VarSessionId == tSessionDropDownList.SelectedValue
                    select a).SingleOrDefault();
                if (stdAccountChk == null)
                {
                    if (fess.FeesType != null)
                    {
                        var feesIdType = (int) fess.FeesType;
                        if (feesIdType == 2)
                        {
                            decimal fees = fess.Fees*12;
                            decimal vat = (fess.Fees*12*(decimal) .075);
                            stdAccount.VarStudentId = studentId;
                            stdAccount.VarSessionId = tSessionDropDownList.SelectedValue;
                            stdAccount.PayableFeesId = fess.FeesId;
                            stdAccount.PayableAmount = fees;
                            stdAccount.PayableVat = vat;
                            stdAccount.NetPayable = fees + vat;
                            stdAccount.FeesAssignDate = DateTime.Now;
                        }
                        else if (feesIdType == 1)
                        {
                            decimal fees = fess.Fees;
                            decimal vat = (fess.Fees*(decimal) .075);
                            stdAccount.VarStudentId = studentId;
                            stdAccount.VarSessionId = tSessionDropDownList.SelectedValue;
                            stdAccount.PayableFeesId = fess.FeesId;
                            stdAccount.PayableAmount = fees;
                            stdAccount.PayableVat = vat;
                            stdAccount.NetPayable = fees + vat;
                            stdAccount.FeesAssignDate = DateTime.Now;
                        }
                    }
                }
                db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
            }


            db.tbl_ReAdmissionHistories.InsertOnSubmit(readmission);
        }

        db.SubmitChanges();
        successStatusLabel.InnerText = "Students Re-Admission Successfull....!!!!";
    }
}