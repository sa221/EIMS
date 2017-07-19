using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_IdCardGererator : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        //db.ExecuteCommand("TRUNCATE TABLE temp_IDCard");
        if (IsPostBack)
        {
            //GenarateIdCard();
        }

        //GenarateIdCard();
    }

    protected void ShowButton_Click(object sender, EventArgs e)
    {
        //db.ExecuteCommand("TRUNCATE TABLE temp_IDCard");
        GenarateIdCard();
    }

    private void GenarateIdCard()
    {
        if (studentIdTextBox.Text != "" && classDropDownList.SelectedValue == "0")
        {
            string userId = Session["uid"].ToString();
            string branch = Session["VarBranchId"].ToString();
            var isExistInId = from x in db.temp_IDCards
                              where x.VarUser == userId && x.VarBranch == branch
                              select x;
            if (isExistInId.FirstOrDefault() != null)
            {
                db.temp_IDCards.DeleteAllOnSubmit(isExistInId);
                db.SubmitChanges();
            }
            GetStudentWaiseIdCard();
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/Copy of ALevelIdCardPaull.rpt"));
            IdCardGenetaro.ReportSource = report;
            IdCardGenetaro.SelectionFormula = "{tbl_Present_class.VarStudentID}='" + studentIdTextBox.Text +
                "'and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";
            //IdCardGenetaro.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
            IdCardGenetaro.RefreshReport();
        }

        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
        {
            string userId = Session["uid"].ToString();
            string branch = Session["VarBranchId"].ToString();
            var isExistInId = from x in db.temp_IDCards
                              where x.VarUser == userId && x.VarBranch == branch
                              select x;
            if (isExistInId.FirstOrDefault() != null)
            {
                db.temp_IDCards.DeleteAllOnSubmit(isExistInId);
                db.SubmitChanges();
            }
            GetClassWiseIdCard();
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/Copy of ALevelIdCardPaull.rpt"));
            IdCardGenetaro.ReportSource = report;
            IdCardGenetaro.SelectionFormula = "{tbl_Present_class.VarClassID}='" + classDropDownList.SelectedValue +
                                                "'and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                                "'and {tbl_Present_class.VarSection}='" + sectionDropDownList.SelectedValue +
                                                "'and {Student.Status}='" + "P" + "'";
            //IdCardGenetaro.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
            IdCardGenetaro.RefreshReport();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedValue != "0")
        {
            string userId = Session["uid"].ToString();
            string branch = Session["VarBranchId"].ToString();
            var isExistInId = from x in db.temp_IDCards
                              where x.VarUser == userId && x.VarBranch == branch
                              select x;
            if (isExistInId.FirstOrDefault() != null)
            {
                db.temp_IDCards.DeleteAllOnSubmit(isExistInId);
                db.SubmitChanges();
            }
            GetClassWiseIdCard();
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/Copy of ALevelIdCardPaull.rpt"));
            IdCardGenetaro.ReportSource = report;
            IdCardGenetaro.SelectionFormula = "{tbl_Present_class.VarClassID}='" + classDropDownList.SelectedValue +
                                                "'and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                                "'and {Student.Status}='" + "P" + "'";
            //IdCardGenetaro.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
            IdCardGenetaro.RefreshReport();
        }
    }

    private void GetClassWiseIdCard()
    {
        string userId = Session["uid"].ToString();
        string branch = Session["VarBranchId"].ToString();
        if (sectionDropDownList.SelectedValue != "0")
        {
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            if (cls != null && cls.ClassType == 2)
            {
                IQueryable<tbl_EdexcelSubjectAssign> getSubject = from c in db.tbl_EdexcelSubjectAssigns
                                                                  join s in db.tbl_Subjects on new { c.SubjectId, c.ClassId } equals new { SubjectId = s.VarSubjectCode, s.ClassId }
                                                                  where c.Section == sectionDropDownList.SelectedValue && c.VarBranchId == branch && c.Session == sessionDropDownList.SelectedValue && c.ClassId == classDropDownList.SelectedValue
                                                                  orderby s.SubSerial ascending
                                                                  select c;
                                                                  //where
                                                                  //    c.ClassId == classDropDownList.SelectedValue && c.Session == sessionDropDownList.SelectedValue &&
                                                                  //    c.Section == sectionDropDownList.SelectedValue && c.VarBranchId == branch
                                                                  //orderby c.StudentId
                                                                  //select c;
                string stdId = "";
                string subId = "";
                int count = 0;
                foreach (tbl_EdexcelSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_IDCard();
                    if (stdId != "" && stdId != subjectAssign.StudentId && count < 7)
                    {

                        for (int i = count; i < 6; i++)
                        {
                            var idCardDataEmptyData = new temp_IDCard();
                            idCardDataEmptyData.StudentId = stdId;
                            idCardDataEmptyData.SubjectCode = i.ToString();
                            idCardDataEmptyData.Unit = "";
                            idCardDataEmptyData.VarBranch = branch;
                            idCardDataEmptyData.VarUser = userId;
                            db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                            db.SubmitChanges();
                        }
                        stdId = "";
                        count = 0;
                    }
                    temp_IDCard getData =
                        db.temp_IDCards.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.SubjectId && x.StudentId == subjectAssign.StudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);|| subjectAssign.SubjectId == "YFM01" || subjectAssign.SubjectId == "XPM01"
                    if (subjectAssign.SubjectId == subId || count < 6)
                    {
                        if (getData == null)
                        {
                            idCardData.StudentId = subjectAssign.StudentId;
                            idCardData.SubjectCode = subjectAssign.SubjectId;
                            if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709" || subjectAssign.SubjectId == "YFM01")
                            {
                                idCardData.Unit = subjectAssign.UnitCode;
                            }
                            idCardData.VarBranch = branch;
                            idCardData.VarUser = userId;
                            db.temp_IDCards.InsertOnSubmit(idCardData);
                            stdId = subjectAssign.StudentId;
                            count = count + 1;
                            subId = subjectAssign.SubjectId;
                        }
                        else
                        {
                            if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709" || subjectAssign.SubjectId == "YFM01")
                            {
                                getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                            }
                        }
                        db.SubmitChanges();
                    }

                }
                var checkRecord = (from x in db.temp_IDCards
                                   where x.StudentId == stdId
                                   select x).Count();
                if (checkRecord < 7)
                {
                    for (int i = count; i < 6; i++)
                    {
                        var idCardDataEmptyData = new temp_IDCard();
                        idCardDataEmptyData.StudentId = stdId;
                        idCardDataEmptyData.SubjectCode = i.ToString();
                        idCardDataEmptyData.Unit = "";
                        idCardDataEmptyData.VarBranch = branch;
                        idCardDataEmptyData.VarUser = userId;
                        db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                        db.SubmitChanges();
                    }
                }
            }
            else if (cls != null && cls.ClassType == 1)
            {
                IQueryable<tbl_StudentSubjectAssign> getSubject = from c in db.tbl_StudentSubjectAssigns
                                                                  where
                                                                      c.ClassId == classDropDownList.SelectedValue && c.VarSessionId == sessionDropDownList.SelectedValue &&
                                                                      c.VarSection == sectionDropDownList.SelectedValue
                                                                  orderby c.VarStudentId
                                                                  select c;
                string stdId = "";
                int count = 0;
                foreach (tbl_StudentSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_IDCard();
                    if (stdId != "" && stdId != subjectAssign.VarStudentId && count < 7)
                    {

                        for (int i = count; i < 6; i++)
                        {
                            var idCardDataEmptyData = new temp_IDCard();
                            idCardDataEmptyData.StudentId = stdId;
                            idCardDataEmptyData.SubjectCode = i.ToString();
                            idCardDataEmptyData.Unit = "";
                            idCardDataEmptyData.VarBranch = branch;
                            idCardDataEmptyData.VarUser = userId;
                            db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                            db.SubmitChanges();
                        }
                        stdId = "";
                        count = 0;
                    }
                    temp_IDCard getData =
                        db.temp_IDCards.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.VarSubjectCode && x.StudentId == subjectAssign.VarStudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);|| subjectAssign.SubjectId == "YFM01" || subjectAssign.SubjectId == "XPM01"
                    if (count < 6)
                    {
                        if (getData == null)
                        {
                            idCardData.StudentId = subjectAssign.VarStudentId;
                            idCardData.SubjectCode = subjectAssign.VarSubjectCode;
                            //if (subjectAssign.VarSubjectCode == "YMA01" || subjectAssign.VarSubjectCode == "9709")
                            //{
                            //    idCardData.Unit = subjectAssign.UnitCode;
                            //}
                            idCardData.VarBranch = branch;
                            idCardData.VarUser = userId;
                            db.temp_IDCards.InsertOnSubmit(idCardData);
                            stdId = subjectAssign.VarStudentId;
                            count = count + 1;
                        }
                        //else
                        //{
                        //    if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709")
                        //    {
                        //        getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                        //    }
                        //}
                        db.SubmitChanges();
                    }

                }
                var checkRecord = (from x in db.temp_IDCards
                                   where x.StudentId == stdId
                                   select x).Count();
                if (checkRecord < 7)
                {
                    for (int i = count; i < 6; i++)
                    {
                        var idCardDataEmptyData = new temp_IDCard();
                        idCardDataEmptyData.StudentId = stdId;
                        idCardDataEmptyData.SubjectCode = i.ToString();
                        idCardDataEmptyData.Unit = "";
                        idCardDataEmptyData.VarBranch = branch;
                        idCardDataEmptyData.VarUser = userId;
                        db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                        db.SubmitChanges();
                    }
                }
            }
        }
        else
        {
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
            if (cls != null && cls.ClassType == 2)
            {
                IQueryable<tbl_EdexcelSubjectAssign> getSubject = from c in db.tbl_EdexcelSubjectAssigns
                                                                  join s in db.tbl_Subjects on new { c.SubjectId, c.ClassId } equals new { SubjectId = s.VarSubjectCode, s.ClassId }
                                                                  where c.VarBranchId == branch && c.Session == sessionDropDownList.SelectedValue && c.ClassId == classDropDownList.SelectedValue
                                                                  //orderby c.StudentId //&& s.SubSerial ascending
                                                                  orderby c.StudentId,s.SubSerial
                                                                  select c;
                                                                  //where c.ClassId == classDropDownList.SelectedValue && c.Session == sessionDropDownList.SelectedValue
                                                                  //orderby c.StudentId
                                                                  //select c;
               
                string stdId = "";
                string subId = "";
                int count = 0;
                foreach (tbl_EdexcelSubjectAssign subjectAssign in getSubject)
                {
                    
                    var idCardData = new temp_IDCard();
                    if (stdId != "" && stdId != subjectAssign.StudentId && count < 7)
                    {

                        for (int i = count; i < 6; i++)
                        {
                            var idCardDataEmptyData = new temp_IDCard();
                            idCardDataEmptyData.StudentId = stdId;
                            idCardDataEmptyData.SubjectCode = i.ToString();
                            idCardDataEmptyData.Unit = "";
                            idCardDataEmptyData.VarBranch = branch;
                            idCardDataEmptyData.VarUser = userId;
                            db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                            db.SubmitChanges();
                        }
                        stdId = "";
                        subId = "";
                        count = 0;
                    }
                    temp_IDCard getData =
                        db.temp_IDCards.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.SubjectId && x.StudentId == subjectAssign.StudentId);

                    //db.temp_IDCards.DeleteOnSubmit(getData);|| subjectAssign.SubjectId == "YFM01" || subjectAssign.SubjectId == "XPM01"
                    if (subjectAssign.SubjectId == subId || count < 6)
                    {
                        if (getData == null)
                        {
                            idCardData.StudentId = subjectAssign.StudentId;
                            idCardData.SubjectCode = subjectAssign.SubjectId;
                            if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709" || subjectAssign.SubjectId == "YFM01")
                            {
                                idCardData.Unit = subjectAssign.UnitCode;
                            }
                            idCardData.VarBranch = branch;
                            idCardData.VarUser = userId;
                            db.temp_IDCards.InsertOnSubmit(idCardData);
                            stdId = subjectAssign.StudentId;
                            count = count + 1;
                            subId = subjectAssign.SubjectId;
                        }
                        else
                        {
                            if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709" || subjectAssign.SubjectId == "YFM01")
                            {
                                getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                            }
                        }
                        db.SubmitChanges();
                    }

                }
                var checkRecord = (from x in db.temp_IDCards
                                   where x.StudentId == stdId
                                   select x).Count();
                if (checkRecord < 7)
                {
                    for (int i = count; i < 6; i++)
                    {
                        var idCardDataEmptyData = new temp_IDCard();
                        idCardDataEmptyData.StudentId = stdId;
                        idCardDataEmptyData.SubjectCode = i.ToString();
                        idCardDataEmptyData.Unit = "";
                        idCardDataEmptyData.VarBranch = branch;
                        idCardDataEmptyData.VarUser = userId;
                        db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                        db.SubmitChanges();
                    }
                }
                //db.temp_IDCards.FirstOrDefault(x=> x.StudentId == subjectAssign.StudentId);
            }
            else if (cls != null && cls.ClassType == 1)
            {
                IQueryable<tbl_StudentSubjectAssign> getSubject = from c in db.tbl_StudentSubjectAssigns
                                                                  where
                                                                      c.ClassId == classDropDownList.SelectedValue && c.VarSessionId == sessionDropDownList.SelectedValue
                                                                  orderby c.VarStudentId
                                                                  select c;
                string stdId = "";
                int count = 0;
                foreach (tbl_StudentSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_IDCard();
                    if (stdId != "" && stdId != subjectAssign.VarStudentId && count < 7)
                    {

                        for (int i = count; i < 6; i++)
                        {
                            var idCardDataEmptyData = new temp_IDCard();
                            idCardDataEmptyData.StudentId = stdId;
                            idCardDataEmptyData.SubjectCode = i.ToString();
                            idCardDataEmptyData.Unit = "";
                            idCardDataEmptyData.VarBranch = branch;
                            idCardDataEmptyData.VarUser = userId;
                            db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                            db.SubmitChanges();
                        }
                        stdId = "";
                        count = 0;
                    }
                    temp_IDCard getData =
                        db.temp_IDCards.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.VarSubjectCode && x.StudentId == subjectAssign.VarStudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);|| subjectAssign.SubjectId == "YFM01" || subjectAssign.SubjectId == "XPM01"
                    if (count < 6)
                    {
                        if (getData == null)
                        {
                            idCardData.StudentId = subjectAssign.VarStudentId;
                            idCardData.SubjectCode = subjectAssign.VarSubjectCode;
                            //if (subjectAssign.VarSubjectCode == "YMA01" || subjectAssign.VarSubjectCode == "9709")
                            //{
                            //    idCardData.Unit = subjectAssign.UnitCode;
                            //}
                            idCardData.VarBranch = branch;
                            idCardData.VarUser = userId;
                            db.temp_IDCards.InsertOnSubmit(idCardData);
                            stdId = subjectAssign.VarStudentId;
                            count = count + 1;
                        }
                        //else
                        //{
                        //    if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709")
                        //    {
                        //        getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                        //    }
                        //}
                        db.SubmitChanges();
                    }

                }
                var checkRecord = (from x in db.temp_IDCards
                                   where x.StudentId == stdId
                                   select x).Count();
                if (checkRecord < 7)
                {
                    for (int i = count; i < 6; i++)
                    {
                        var idCardDataEmptyData = new temp_IDCard();
                        idCardDataEmptyData.StudentId = stdId;
                        idCardDataEmptyData.SubjectCode = i.ToString();
                        idCardDataEmptyData.Unit = "";
                        idCardDataEmptyData.VarBranch = branch;
                        idCardDataEmptyData.VarUser = userId;
                        db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                        db.SubmitChanges();
                    }
                }
            }
        }
    }

    private void GetStudentWaiseIdCard()
    {
        string userId = Session["uid"].ToString();
        string branch = Session["VarBranchId"].ToString();
        tbl_Present_class pcl =
            db.tbl_Present_classes.FirstOrDefault(
                x =>
                    x.VarStudentID == studentIdTextBox.Text && x.VarSessionId == sessionDropDownList.SelectedValue &&
                    x.Status == "P");
        if (pcl != null)
        {
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == pcl.VarClassID);
            if (cls != null && cls.ClassType == 2)
            {
                IQueryable<tbl_EdexcelSubjectAssign> getSubject = from c in db.tbl_EdexcelSubjectAssigns
                                                                  //join eu in db.tbl_EdexelunitCodes
                                                                  //on new { s.VarSubjectCode, s.ClassId }
                                                                  //equals new { VarSubjectCode = eu.SpecificationCode, ClassId = eu.Class }
                                                                  join s in db.tbl_Subjects on new { c.SubjectId,c.ClassId} equals new { SubjectId=s.VarSubjectCode,s.ClassId }
                                                                  where c.StudentId == studentIdTextBox.Text && c.Session == sessionDropDownList.SelectedValue && c.ClassId == pcl.VarClassID
                                                                  orderby s.SubSerial ascending
                                                                  select c;
                string stdId = "";
                string subId = "";
                int count = 0;
                foreach (tbl_EdexcelSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_IDCard();

                    temp_IDCard getData =
                        db.temp_IDCards.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.SubjectId && x.StudentId == subjectAssign.StudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);
                    if (subjectAssign.SubjectId == subId || count < 6)
                    {


                        if (getData == null)
                        {
                            idCardData.StudentId = subjectAssign.StudentId;
                            idCardData.SubjectCode = subjectAssign.SubjectId;
                            if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709" || subjectAssign.SubjectId == "YFM01")
                            {
                                idCardData.Unit = subjectAssign.UnitCode;
                            }
                            idCardData.VarBranch = branch;
                            idCardData.VarUser = userId;
                            //idCardData.Unit = subjectAssign.UnitCode;
                            db.temp_IDCards.InsertOnSubmit(idCardData);
                            stdId = subjectAssign.StudentId;
                            count = count + 1;
                            subId = subjectAssign.SubjectId;
                        }
                        else
                        {
                            if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709" || subjectAssign.SubjectId == "YFM01")
                            {
                                getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                            }
                            //getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                        }

                        db.SubmitChanges();
                    }
                }
                var checkRecord = (from x in db.temp_IDCards
                                   where x.StudentId == stdId
                                   select x).Count();
                if (checkRecord < 7)
                {
                    for (int i = count; i < 6; i++)
                    {
                        var idCardDataEmptyData = new temp_IDCard();
                        idCardDataEmptyData.StudentId = stdId;
                        idCardDataEmptyData.SubjectCode = i.ToString();
                        idCardDataEmptyData.Unit = "";
                        idCardDataEmptyData.VarBranch = branch;
                        idCardDataEmptyData.VarUser = userId;
                        db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                        db.SubmitChanges();
                    }
                }
                //if (stdId != "" && count < 7)
                //{

                //    for (int i = count; i < 6; i++)
                //    {
                //        var idCardDataEmptyData = new temp_IDCard();
                //        idCardDataEmptyData.StudentId = stdId;
                //        idCardDataEmptyData.SubjectCode = i.ToString();
                //        idCardDataEmptyData.Unit = "";
                //        db.temp_IDCards.InsertOnSubmit(idCardDataEmptyData);
                //        db.SubmitChanges();
                //    }
                //}
            }
            else if (cls != null && cls.ClassType == 1)
            {
                IQueryable<tbl_StudentSubjectAssign> getSubject = from c in db.tbl_StudentSubjectAssigns
                                                                  where c.VarStudentId == studentIdTextBox.Text && c.VarSessionId == sessionDropDownList.SelectedValue
                                                                  select c;
                foreach (tbl_StudentSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_IDCard();
                    //temp_IDCard getData = db.temp_IDCards.FirstOrDefault(x => x.SubjectCode == subjectAssign.VarSubjectCode && x.StudentId == subjectAssign.VarStudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);
                    //if (getData == null)
                    //{
                    idCardData.StudentId = subjectAssign.VarStudentId;
                    idCardData.SubjectCode = subjectAssign.VarSubjectCode;
                    idCardData.VarBranch = branch;
                    idCardData.VarUser = userId;
                    //idCardData.Unit = subjectAssign.U;
                    db.temp_IDCards.InsertOnSubmit(idCardData);
                    //}
                    //else
                    //{
                    //getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                    //}

                    db.SubmitChanges();
                }
            }
        }
        //Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == pcl.VarClassID);

    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}