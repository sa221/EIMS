using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_UpdateFileTag : System.Web.UI.Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
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
        var checkClassType = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
        if (checkClassType!=null && checkClassType.ClassType==3)
        {
            if (studentIdTextBox.Text != "" && classDropDownList.SelectedValue == "0")
            {
                string userId = Session["uid"].ToString();
                string branch = Session["VarBranchId"].ToString();
                var isExistInId = from x in db.temp_FileTags
                                  where x.VarUser == userId && x.VarBranch == branch
                                  select x;
                if (isExistInId.FirstOrDefault() != null)
                {
                    db.temp_FileTags.DeleteAllOnSubmit(isExistInId);
                    db.SubmitChanges();
                }
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/UpdateFileTagJuniorClass.rpt"));
                FileTagGenerator.ReportSource = report;
                FileTagGenerator.SelectionFormula = "{tbl_Present_class.VarStudentID}='" + studentIdTextBox.Text +
                    "'and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";
                //FileTagGenerator.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
                FileTagGenerator.RefreshReport();
            }

            else if (studentIdTextBox.Text == "" && classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
            {
                string userId = Session["uid"].ToString();
                string branch = Session["VarBranchId"].ToString();
                var isExistInId = from x in db.temp_FileTags
                                  where x.VarUser == userId && x.VarBranch == branch
                                  select x;
                if (isExistInId.FirstOrDefault() != null)
                {
                    db.temp_FileTags.DeleteAllOnSubmit(isExistInId);
                    db.SubmitChanges();
                }
                
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/UpdateFileTagJuniorClass.rpt"));
                FileTagGenerator.ReportSource = report;
                FileTagGenerator.SelectionFormula = "{tbl_Present_class.VarClassID}='" + classDropDownList.SelectedValue +
                                                    "'and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                                    "'and {tbl_Present_class.VarSection}='" + sectionDropDownList.SelectedValue +
                                                    "'and {Student.Status}='" + "P" + "'";
                //FileTagGenerator.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
                FileTagGenerator.RefreshReport();
            }
            else if (studentIdTextBox.Text == "" && classDropDownList.SelectedValue != "0")
            {
                string userId = Session["uid"].ToString();
                string branch = Session["VarBranchId"].ToString();
                var isExistInId = from x in db.temp_FileTags
                                  where x.VarUser == userId && x.VarBranch == branch
                                  select x;
                if (isExistInId.FirstOrDefault() != null)
                {
                    db.temp_FileTags.DeleteAllOnSubmit(isExistInId);
                    db.SubmitChanges();
                }
                
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/UpdateFileTagJuniorClass.rpt"));
                FileTagGenerator.ReportSource = report;
                FileTagGenerator.SelectionFormula = "{tbl_Present_class.VarClassID}='" + classDropDownList.SelectedValue +
                                                    "'and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                                    "'and {Student.Status}='" + "P" + "'";
                //FileTagGenerator.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
                FileTagGenerator.RefreshReport();
            }
        }
        else
        {
            if (studentIdTextBox.Text != "" && classDropDownList.SelectedValue == "0")
            {
                string userId = Session["uid"].ToString();
                string branch = Session["VarBranchId"].ToString();
                var isExistInId = from x in db.temp_FileTags
                                  where x.VarUser == userId && x.VarBranch == branch
                                  select x;
                if (isExistInId.FirstOrDefault() != null)
                {
                    db.temp_FileTags.DeleteAllOnSubmit(isExistInId);
                    db.SubmitChanges();
                }
                GetStudentWaiseIdCard();
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/UpdateFileTag.rpt"));
                FileTagGenerator.ReportSource = report;
                FileTagGenerator.SelectionFormula = "{tbl_Present_class.VarStudentID}='" + studentIdTextBox.Text +
                    "'and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue + "'";
                //FileTagGenerator.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
                FileTagGenerator.RefreshReport();
            }

            else if (studentIdTextBox.Text == "" && classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
            {
                string userId = Session["uid"].ToString();
                string branch = Session["VarBranchId"].ToString();
                var isExistInId = from x in db.temp_FileTags
                                  where x.VarUser == userId && x.VarBranch == branch
                                  select x;
                if (isExistInId.FirstOrDefault() != null)
                {
                    db.temp_FileTags.DeleteAllOnSubmit(isExistInId);
                    db.SubmitChanges();
                }
                GetClassWiseIdCard();
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/UpdateFileTag.rpt"));
                FileTagGenerator.ReportSource = report;
                FileTagGenerator.SelectionFormula = "{tbl_Present_class.VarClassID}='" + classDropDownList.SelectedValue +
                                                    "'and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                                    "'and {tbl_Present_class.VarSection}='" + sectionDropDownList.SelectedValue +
                                                    "'and {Student.Status}='" + "P" + "'";
                //FileTagGenerator.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
                FileTagGenerator.RefreshReport();
            }
            else if (studentIdTextBox.Text == "" && classDropDownList.SelectedValue != "0")
            {
                string userId = Session["uid"].ToString();
                string branch = Session["VarBranchId"].ToString();
                var isExistInId = from x in db.temp_FileTags
                                  where x.VarUser == userId && x.VarBranch == branch
                                  select x;
                if (isExistInId.FirstOrDefault() != null)
                {
                    db.temp_FileTags.DeleteAllOnSubmit(isExistInId);
                    db.SubmitChanges();
                }
                GetClassWiseIdCard();
                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/UpdateFileTag.rpt"));
                FileTagGenerator.ReportSource = report;
                FileTagGenerator.SelectionFormula = "{tbl_Present_class.VarClassID}='" + classDropDownList.SelectedValue +
                                                    "'and {tbl_Present_class.VarSessionId}='" + sessionDropDownList.SelectedValue +
                                                    "'and {Student.Status}='" + "P" + "'";
                //FileTagGenerator.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
                FileTagGenerator.RefreshReport();
            }
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
                                                                  where
                                                                      c.ClassId == classDropDownList.SelectedValue && c.Session == sessionDropDownList.SelectedValue &&
                                                                      c.Section == sectionDropDownList.SelectedValue && c.VarBranchId == branch
                                                                  orderby c.StudentId
                                                                  select c;
                string stdId = "";
                int count = 0;
                foreach (tbl_EdexcelSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_FileTag();
                    if (stdId != "" && stdId != subjectAssign.StudentId && count < 11)
                    {

                        for (int i = count; i < 10; i++)
                        {
                            var idCardDataEmptyData = new temp_FileTag();
                            idCardDataEmptyData.StudentId = stdId;
                            idCardDataEmptyData.SubjectCode = i.ToString();
                            idCardDataEmptyData.Unit = "";
                            idCardDataEmptyData.VarBranch = branch;
                            idCardDataEmptyData.VarUser = userId;
                            db.temp_FileTags.InsertOnSubmit(idCardDataEmptyData);
                            db.SubmitChanges();
                        }
                        stdId = "";
                        count = 0;
                    }
                    temp_FileTag getData =
                        db.temp_FileTags.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.SubjectId && x.StudentId == subjectAssign.StudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);|| subjectAssign.SubjectId == "YFM01" || subjectAssign.SubjectId == "XPM01"
                    if (count < 10)
                    {
                        if (getData == null)
                        {
                            idCardData.StudentId = subjectAssign.StudentId;
                            idCardData.SubjectCode = subjectAssign.SubjectId;
                            //if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709")
                            //{
                                idCardData.Unit = subjectAssign.UnitCode;
                            //}
                            idCardData.VarBranch = branch;
                            idCardData.VarUser = userId;
                            db.temp_FileTags.InsertOnSubmit(idCardData);
                            stdId = subjectAssign.StudentId;
                            count = count + 1;
                        }
                        else
                        {
                            //if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709")
                            //{
                                getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                            //}
                        }
                        db.SubmitChanges();
                    }

                }
                var checkRecord = (from x in db.temp_FileTags
                                   where x.StudentId == stdId
                                   select x).Count();
                if (checkRecord < 11)
                {
                    for (int i = count; i < 10; i++)
                    {
                        var idCardDataEmptyData = new temp_FileTag();
                        idCardDataEmptyData.StudentId = stdId;
                        idCardDataEmptyData.SubjectCode = i.ToString();
                        idCardDataEmptyData.Unit = "";
                        idCardDataEmptyData.VarBranch = branch;
                        idCardDataEmptyData.VarUser = userId;
                        db.temp_FileTags.InsertOnSubmit(idCardDataEmptyData);
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
                    var idCardData = new temp_FileTag();
                    if (stdId != "" && stdId != subjectAssign.VarStudentId && count < 11)
                    {

                        for (int i = count; i < 10; i++)
                        {
                            var idCardDataEmptyData = new temp_FileTag();
                            idCardDataEmptyData.StudentId = stdId;
                            idCardDataEmptyData.SubjectCode = i.ToString();
                            idCardDataEmptyData.Unit = "";
                            idCardDataEmptyData.VarBranch = branch;
                            idCardDataEmptyData.VarUser = userId;
                            db.temp_FileTags.InsertOnSubmit(idCardDataEmptyData);
                            db.SubmitChanges();
                        }
                        stdId = "";
                        count = 0;
                    }
                    temp_FileTag getData =
                        db.temp_FileTags.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.VarSubjectCode && x.StudentId == subjectAssign.VarStudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);|| subjectAssign.SubjectId == "YFM01" || subjectAssign.SubjectId == "XPM01"
                    if (count < 10)
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
                            db.temp_FileTags.InsertOnSubmit(idCardData);
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
                var checkRecord = (from x in db.temp_FileTags
                                   where x.StudentId == stdId
                                   select x).Count();
                if (checkRecord < 11)
                {
                    for (int i = count; i < 10; i++)
                    {
                        var idCardDataEmptyData = new temp_FileTag();
                        idCardDataEmptyData.StudentId = stdId;
                        idCardDataEmptyData.SubjectCode = i.ToString();
                        idCardDataEmptyData.Unit = "";
                        idCardDataEmptyData.VarBranch = branch;
                        idCardDataEmptyData.VarUser = userId;
                        db.temp_FileTags.InsertOnSubmit(idCardDataEmptyData);
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
                                                                  where c.ClassId == classDropDownList.SelectedValue && c.Session == sessionDropDownList.SelectedValue
                                                                  orderby c.StudentId
                                                                  select c;
                string stdId = "";
                int count = 0;
                foreach (tbl_EdexcelSubjectAssign subjectAssign in getSubject)
                {
                    var idCardData = new temp_FileTag();
                    if (stdId != "" && stdId != subjectAssign.StudentId && count < 11)
                    {

                        for (int i = count; i < 10; i++)
                        {
                            var idCardDataEmptyData = new temp_FileTag();
                            idCardDataEmptyData.StudentId = stdId;
                            idCardDataEmptyData.SubjectCode = i.ToString();
                            idCardDataEmptyData.Unit = "";
                            idCardDataEmptyData.VarBranch = branch;
                            idCardDataEmptyData.VarUser = userId;
                            db.temp_FileTags.InsertOnSubmit(idCardDataEmptyData);
                            db.SubmitChanges();
                        }
                        stdId = "";
                        count = 0;
                    }
                    temp_FileTag getData =
                        db.temp_FileTags.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.SubjectId && x.StudentId == subjectAssign.StudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);|| subjectAssign.SubjectId == "YFM01" || subjectAssign.SubjectId == "XPM01"
                    if (count < 10)
                    {
                        if (getData == null)
                        {
                            idCardData.StudentId = subjectAssign.StudentId;
                            idCardData.SubjectCode = subjectAssign.SubjectId;
                            //if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709")
                            //{
                                idCardData.Unit = subjectAssign.UnitCode;
                            //}
                            idCardData.VarBranch = branch;
                            idCardData.VarUser = userId;
                            db.temp_FileTags.InsertOnSubmit(idCardData);
                            stdId = subjectAssign.StudentId;
                            count = count + 1;
                        }
                        else
                        {
                            //if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709")
                            //{
                                getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                            //}
                        }
                        db.SubmitChanges();
                    }

                }
                var checkRecord = (from x in db.temp_FileTags
                                   where x.StudentId == stdId
                                   select x).Count();
                if (checkRecord < 11)
                {
                    for (int i = count; i < 10; i++)
                    {
                        var idCardDataEmptyData = new temp_FileTag();
                        idCardDataEmptyData.StudentId = stdId;
                        idCardDataEmptyData.SubjectCode = i.ToString();
                        idCardDataEmptyData.Unit = "";
                        idCardDataEmptyData.VarBranch = branch;
                        idCardDataEmptyData.VarUser = userId;
                        db.temp_FileTags.InsertOnSubmit(idCardDataEmptyData);
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
                    var idCardData = new temp_FileTag();
                    if (stdId != "" && stdId != subjectAssign.VarStudentId && count < 11)
                    {

                        for (int i = count; i < 10; i++)
                        {
                            var idCardDataEmptyData = new temp_FileTag();
                            idCardDataEmptyData.StudentId = stdId;
                            idCardDataEmptyData.SubjectCode = i.ToString();
                            idCardDataEmptyData.Unit = "";
                            idCardDataEmptyData.VarBranch = branch;
                            idCardDataEmptyData.VarUser = userId;
                            db.temp_FileTags.InsertOnSubmit(idCardDataEmptyData);
                            db.SubmitChanges();
                        }
                        stdId = "";
                        count = 0;
                    }
                    temp_FileTag getData =
                        db.temp_FileTags.FirstOrDefault(
                            x => x.SubjectCode == subjectAssign.VarSubjectCode && x.StudentId == subjectAssign.VarStudentId);
                    //db.temp_IDCards.DeleteOnSubmit(getData);|| subjectAssign.SubjectId == "YFM01" || subjectAssign.SubjectId == "XPM01"
                    if (count < 10)
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
                            db.temp_FileTags.InsertOnSubmit(idCardData);
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
                var checkRecord = (from x in db.temp_FileTags
                                   where x.StudentId == stdId
                                   select x).Count();
                if (checkRecord < 11)
                {
                    for (int i = count; i < 10; i++)
                    {
                        var idCardDataEmptyData = new temp_FileTag();
                        idCardDataEmptyData.StudentId = stdId;
                        idCardDataEmptyData.SubjectCode = i.ToString();
                        idCardDataEmptyData.Unit = "";
                        idCardDataEmptyData.VarBranch = branch;
                        idCardDataEmptyData.VarUser = userId;
                        db.temp_FileTags.InsertOnSubmit(idCardDataEmptyData);
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
        Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == pcl.VarClassID);
        if (cls != null && cls.ClassType == 2)
        {
            IQueryable<tbl_EdexcelSubjectAssign> getSubject = from c in db.tbl_EdexcelSubjectAssigns
                                                              where c.StudentId == studentIdTextBox.Text && c.Session == sessionDropDownList.SelectedValue
                                                              select c;
            string stdId = "";
            int count = 0;
            foreach (tbl_EdexcelSubjectAssign subjectAssign in getSubject)
            {
                var idCardData = new temp_FileTag();

                temp_FileTag getData =
                    db.temp_FileTags.FirstOrDefault(
                        x => x.SubjectCode == subjectAssign.SubjectId && x.StudentId == subjectAssign.StudentId);
                //db.temp_IDCards.DeleteOnSubmit(getData);
                if (count < 10)
                {


                    if (getData == null)
                    {
                        idCardData.StudentId = subjectAssign.StudentId;
                        idCardData.SubjectCode = subjectAssign.SubjectId;
                        //if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709")
                        //{
                            idCardData.Unit = subjectAssign.UnitCode;
                        //}
                        idCardData.VarBranch = branch;
                        idCardData.VarUser = userId;
                        //idCardData.Unit = subjectAssign.UnitCode;
                        db.temp_FileTags.InsertOnSubmit(idCardData);
                        stdId = subjectAssign.StudentId;
                        count = count + 1;
                    }
                    else
                    {
                        //if (subjectAssign.SubjectId == "YMA01" || subjectAssign.SubjectId == "9709")
                        //{
                            getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                        //}
                        //getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                    }

                    db.SubmitChanges();
                }
            }
            var checkRecord = (from x in db.temp_FileTags
                               where x.StudentId == stdId
                               select x).Count();
            if (checkRecord < 11)
            {
                for (int i = count; i < 10; i++)
                {
                    var idCardDataEmptyData = new temp_FileTag();
                    idCardDataEmptyData.StudentId = stdId;
                    idCardDataEmptyData.SubjectCode = i.ToString();
                    idCardDataEmptyData.Unit = "";
                    idCardDataEmptyData.VarBranch = branch;
                    idCardDataEmptyData.VarUser = userId;
                    db.temp_FileTags.InsertOnSubmit(idCardDataEmptyData);
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
                var idCardData = new temp_FileTag();
                //temp_IDCard getData = db.temp_IDCards.FirstOrDefault(x => x.SubjectCode == subjectAssign.VarSubjectCode && x.StudentId == subjectAssign.VarStudentId);
                //db.temp_IDCards.DeleteOnSubmit(getData);
                //if (getData == null)
                //{
                idCardData.StudentId = subjectAssign.VarStudentId;
                idCardData.SubjectCode = subjectAssign.VarSubjectCode;
                idCardData.VarBranch = branch;
                idCardData.VarUser = userId;
                //idCardData.Unit = subjectAssign.U;
                db.temp_FileTags.InsertOnSubmit(idCardData);
                //}
                //else
                //{
                //getData.Unit = getData.Unit + "," + subjectAssign.UnitCode;
                //}

                db.SubmitChanges();
            }
        }
    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}