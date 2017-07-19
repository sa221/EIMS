using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_A_LevelStudentListWithSubject : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            GetReport();
        }
    }

    protected void ShowButton_Click(object sender, EventArgs e)
    {
        string userId = Session["uid"].ToString();
        string branch = Session["VarBranchId"].ToString();
        var isExist = from x in db.temp_AllSubjectWithUnitCodes
                      where x.VarUser == userId && x.VarBranch == branch
                      select x;
        if (isExist.FirstOrDefault() != null)
        {
            db.temp_AllSubjectWithUnitCodes.DeleteAllOnSubmit(isExist);
            db.SubmitChanges();
        }
        var isExistInId = from x in db.temp_IDCards
                      where x.VarUser == userId && x.VarBranch == branch
                      select x;
        if (isExistInId.FirstOrDefault() != null)
        {
            db.temp_IDCards.DeleteAllOnSubmit(isExistInId);
            db.SubmitChanges();
        }
        GetClassWiseIdCard();
        GetAllSubject();
        GetReport();
    }

    private void GetClassWiseIdCard()
    {
        int count = 0;
        string userId = Session["uid"].ToString();
        string branch = Session["VarBranchId"].ToString();
        if (sectionDropDownList.SelectedValue != "0")
        {
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            if (cls != null && cls.ClassType == 2)
            {
                IQueryable<tbl_EdexcelSubjectAssign> getSubject = from c in db.tbl_EdexcelSubjectAssigns
                                                                  join std in db.tbl_Present_classes on c.StudentId equals std.VarStudentID into stdGroup
                                                                  from std in stdGroup.DefaultIfEmpty()
                                                                  join sub in db.tbl_Subjects on new { c.SubjectId, c.ClassId } equals new { SubjectId = sub.VarSubjectCode, sub.ClassId } into subGroup
                                                                  from sub in subGroup.DefaultIfEmpty()
                                                                  where
                                                                      c.ClassId == classDropDownList.SelectedValue && c.Session == sessionDropDownList.SelectedValue &&
                                                                      c.Section == sectionDropDownList.SelectedValue && std.Status != "L" && c.VarBranchId==branch
                                                                      orderby sub.SubSerial
                                                                  select c;
                foreach (tbl_EdexcelSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_IDCard();

                    temp_IDCard getData =
                        db.temp_IDCards.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.SubjectId && x.StudentId == subjectAssign.StudentId && x.VarUser==userId && x.VarBranch==branch);
                    //db.temp_IDCards.DeleteOnSubmit(getData);
                    if (getData == null)
                    {
                        idCardData.StudentId = subjectAssign.StudentId;
                        idCardData.SubjectCode = subjectAssign.SubjectId;
                        idCardData.Unit = subjectAssign.UnitCode;
                        idCardData.VarUser = userId;
                        idCardData.VarBranch = branch;
                        idCardData.TotalUnit = count + 1;
                        db.temp_IDCards.InsertOnSubmit(idCardData);
                    }
                    else
                    {
                        getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                        getData.TotalUnit = getData.TotalUnit + 1;
                    }

                    db.SubmitChanges();
                }
            }
            else if (cls != null && cls.ClassType == 1)
            {
                IQueryable<tbl_StudentSubjectAssign> getSubject = from c in db.tbl_StudentSubjectAssigns
                                                                  join std in db.tbl_Present_classes on c.VarStudentId equals std.VarStudentID into stdGroup
                                                                  from std in stdGroup.DefaultIfEmpty()
                                                                  where
                                                                      std.VarClassID == classDropDownList.SelectedValue &&
                                                                      std.VarSessionId == sessionDropDownList.SelectedValue &&
                                                                      c.VarSection == sectionDropDownList.SelectedValue && std.Status != "L" && c.VarBranchId==branch
                                                                  select c;
                foreach (tbl_StudentSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_IDCard();

                    temp_IDCard getData =
                        db.temp_IDCards.FirstOrDefault(
                            x =>
                                x.SubjectCode == subjectAssign.VarSubjectCode &&
                                x.StudentId == subjectAssign.VarStudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);
                    if (getData == null)
                    {
                        idCardData.StudentId = subjectAssign.VarStudentId;
                        idCardData.SubjectCode = subjectAssign.VarSubjectCode;
                        idCardData.VarUser = userId;
                        idCardData.VarBranch = branch;
                        db.temp_IDCards.InsertOnSubmit(idCardData);
                    }
                    //else
                    //{
                    //    getData.SubjectCode = getData.SubjectCode + "  " + subjectAssign.VarSubjectCode;
                    //}

                    db.SubmitChanges();
                }
            }
        }
        else
        {
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            if (cls != null && cls.ClassType == 2)
            {
                //var getSubject = from p in db.tbl_Present_classes
                //                 join sub in db.tbl_EdexcelSubjectAssigns on p.VarStudentID equals sub.StudentId into stdGroup
                //                 from sub in stdGroup.DefaultIfEmpty()
                var getSubject = from c in db.tbl_EdexcelSubjectAssigns
                                 join std in db.tbl_Present_classes on c.StudentId equals std.VarStudentID into stdGroup
                                 from std in stdGroup.DefaultIfEmpty()
                                 join sub in db.tbl_Subjects on new { c.SubjectId, c.ClassId } equals new { SubjectId=sub.VarSubjectCode, sub.ClassId } into subGroup
                                 from sub in subGroup.DefaultIfEmpty()
                                 where
                                     c.ClassId == classDropDownList.SelectedValue &&
                                     c.Session == sessionDropDownList.SelectedValue &&
                                     std.Status != "L" && c.VarBranchId == branch
                                     orderby sub.SubSerial
                                 select new { c, std };
                foreach (var subjectAssign in getSubject)
                {
                    var idCardData = new temp_IDCard();

                    temp_IDCard getData =
                        db.temp_IDCards.FirstOrDefault(
                            x =>
                                x.SubjectCode == subjectAssign.c.SubjectId &&
                                x.StudentId == subjectAssign.c.StudentId && x.VarBranch == branch && x.VarUser == userId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);
                    if (getData == null)
                    {
                        idCardData.StudentId = subjectAssign.c.StudentId;
                        idCardData.SubjectCode = subjectAssign.c.SubjectId;
                        idCardData.Unit = subjectAssign.c.UnitCode;
                        idCardData.TotalUnit = count + 1;
                        idCardData.VarUser = userId;
                        idCardData.VarBranch = branch;
                        db.temp_IDCards.InsertOnSubmit(idCardData);
                    }
                    else
                    {
                        getData.Unit = getData.Unit + "," + subjectAssign.c.UnitCode;
                        getData.TotalUnit = getData.TotalUnit + 1;
                    }

                    db.SubmitChanges();
                }
            }
            else if (cls != null && cls.ClassType == 1)
            {
                IQueryable<tbl_StudentSubjectAssign> getSubject = from c in db.tbl_StudentSubjectAssigns
                                                                  join std in db.tbl_Present_classes on c.VarStudentId equals std.VarStudentID into stdGroup
                                                                  from std in stdGroup.DefaultIfEmpty()
                                                                  where
                                                                      std.VarClassID == classDropDownList.SelectedValue &&
                                                                      std.VarSessionId == sessionDropDownList.SelectedValue &&
                                                                      std.Status != "L" && c.VarBranchId==branch
                                                                  select c;
                foreach (tbl_StudentSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_IDCard();

                    temp_IDCard getData =
                        db.temp_IDCards.FirstOrDefault(
                            x =>
                                x.SubjectCode == subjectAssign.VarSubjectCode &&
                                x.StudentId == subjectAssign.VarStudentId && x.VarBranch==branch && x.VarUser==userId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);
                    if (getData == null)
                    {
                        idCardData.StudentId = subjectAssign.VarStudentId;
                        idCardData.SubjectCode = subjectAssign.VarSubjectCode;
                        idCardData.VarUser = userId;
                        idCardData.VarBranch = branch;
                        db.temp_IDCards.InsertOnSubmit(idCardData);
                    }
                    //else
                    //{
                    //    getData.SubjectCode = getData.SubjectCode + "  " + subjectAssign.VarSubjectCode;
                    //}

                    db.SubmitChanges();
                }
            }
        }
    }

    private void GetAllSubject()
    {
        string userId = Session["uid"].ToString();
        string branch = Session["VarBranchId"].ToString();
        int count = 0;
        IQueryable<temp_IDCard> getAllSubject = from t in db.temp_IDCards
                                                where t.VarUser==userId && t.VarBranch==branch
            select t;
        foreach (temp_IDCard allSub in getAllSubject)
        {
            tbl_Subject getSubjectName =
                db.tbl_Subjects.FirstOrDefault(
                    x => x.ClassId == classDropDownList.SelectedValue && x.VarSubjectCode == allSub.SubjectCode);
            var allSubject = new temp_AllSubjectWithUnitCode();
            temp_AllSubjectWithUnitCode check =
                db.temp_AllSubjectWithUnitCodes.FirstOrDefault(x => x.StudentId == allSub.StudentId && x.VarBranch==branch && x.VarUser==userId);
            if (check == null)
            {
                allSubject.StudentId = allSub.StudentId;
                
                allSubject.VarUser = Session["uid"].ToString();
                allSubject.VarBranch = Session["VarBranchId"].ToString();
                Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
                if (cls != null && cls.ClassType == 2)
                {
                    if (getSubjectName != null)
                        allSubject.Subject = getSubjectName.VarSubjectName + "(" + allSub.Unit + ")";
                    allSubject.TotalSub = allSub.TotalUnit;
                    db.temp_AllSubjectWithUnitCodes.InsertOnSubmit(allSubject);
                }
                else if (cls != null && cls.ClassType == 1)
                {
                    if (getSubjectName != null)
                        allSubject.Subject = getSubjectName.VarSubjectName;
                    allSubject.TotalSub = count + 1;
                    db.temp_AllSubjectWithUnitCodes.InsertOnSubmit(allSubject);
                }
            }
            else
            {
                Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
                if (cls != null && cls.ClassType == 2)
                {
                    if (getSubjectName != null)
                        check.Subject = check.Subject + "    " + getSubjectName.VarSubjectName + "(" + allSub.Unit + ")";
                    check.TotalSub = check.TotalSub + allSub.TotalUnit;
                }
                else if (cls != null && cls.ClassType == 1)
                {
                    if (getSubjectName != null)
                        check.Subject = check.Subject + "    " + getSubjectName.VarSubjectName;
                    check.TotalSub = check.TotalSub + 1;
                }
            }
            db.SubmitChanges();
        }
    }

    private void GetReport()
    {
        string userId = Session["uid"].ToString();
        string branch = Session["VarBranchId"].ToString();
        var report = new ReportDocument();
        report.Load(Server.MapPath("~/Reports/StudentListWithAllSubject.rpt"));
        var textObject = report.ReportDefinition.ReportObjects["ClassName"] as TextObject;
        if (textObject != null) textObject.Text = classDropDownList.SelectedItem.Text;
        StudentAllSubjectList.ReportSource = report;
        StudentAllSubjectList.SelectionFormula = "{temp_AllSubjectWithUnitCode.VarBranch}='" + branch + "'and {temp_AllSubjectWithUnitCode.VarUser}='" + userId + "'";
        //IdCardGenetaro.SelectionFormula = 
        StudentAllSubjectList.RefreshReport();
    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}