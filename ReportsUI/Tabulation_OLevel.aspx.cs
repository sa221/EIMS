using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_Tabulation_OLevel : System.Web.UI.Page
{
    SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRepeatStudent();
        }
    }
    protected void showButton_Click(object sender, EventArgs e)
    {
        //db.ExecuteCommand("truncate table tempTabulationSheet");
        var chkUserData = from c in db.tempTabulationSheets
                          where c.VarBranchId == Convert.ToInt32(Session["VarBranchId"])
                          select c;
        if (chkUserData.FirstOrDefault() != null)
        {
            db.tempTabulationSheets.DeleteAllOnSubmit(chkUserData);
            db.SubmitChanges();
        }
        string session = sessionDropDownList.SelectedValue;
        int cls = Convert.ToInt32(classDropDownList.SelectedValue);
        string sec = sectionDropDownList.SelectedValue;
        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        string examCode = examNameDropDownList.SelectedValue;
        if (examCode == "E101")
        {
            var getAttendence = from x in db.tbl_StudentAttendances
                                where x.VarSession == session && x.ClassId == cls && x.VarSection == sec && (x.VarMonth > 6 && x.VarMonth < 13) && x.VarBranch == brachId.ToString() && x.AttendanceStatus != "A"
                                group new { x } by new
                                {
                                    x.VarStudentId,x.AttendanceStatus
                                }
                                    into g
                                    select new
                                    {
                                        STD = g.Key.VarStudentId,TOT = g.Key.AttendanceStatus.Count()
                                    };
            var getPercentage = from x in db.tbl_ExamMarks
                                where x.VarSession == session && x.VarClassId == cls.ToString() && x.VarSection == sec && x.ExamCode==examCode //&& x.VarBranchId == brachId.ToString() 
                                group x by x.VarStudentId into g
                                orderby g.Sum(p => p.Total_Marks) / g.Count() descending 
                                    select new
                                    {
                                        STD = g.Key,
                                        totalSub = g.Count(),
                                        //STD = g.Key.VarStudentId,
                                       totalMarks=g.Sum(p=>p.Total_Marks),
                                       //totalSub = g.Key.VarSubjectCode.Count(),
                                        per = g.Sum(p=>p.Total_Marks)/g.Count()
                                    };
            int position = 0;
            foreach (var tt in getPercentage)
            {
                if (position==0)
                {
                    position = 1;
                }
                tempTabulationSheet tempTabulation = new tempTabulationSheet();
                tempTabulation.StudentId = tt.STD;
                tempTabulation.Percentage = Math.Round((double) tt.per,2);
                tempTabulation.Position = position;
                tempTabulation.VarBranchId = Convert.ToInt32(Session["VarBranchId"]);
                db.tempTabulationSheets.InsertOnSubmit(tempTabulation);
                db.SubmitChanges();
                position = position + 1;
            }

            foreach (var tt in getAttendence)
            {
                //tempTabulationSheet tempTabulation = new tempTabulationSheet();
                var checkData = db.tempTabulationSheets.FirstOrDefault(x => x.StudentId == tt.STD);
                if (checkData!=null)
                {
                    checkData.Attendence = tt.TOT;
                    //checkData.Project = "A";
                    db.SubmitChanges();
                }
            }
        }
        else if (examCode == "E102")
        {
            var getAttendence = from x in db.tbl_StudentAttendances
                                where x.VarSession == session && x.ClassId == cls && x.VarSection == sec && (x.VarMonth > 0 && x.VarMonth < 7) && x.VarBranch == brachId.ToString() && x.AttendanceStatus != "A"
                                group new { x } by new
                                {
                                    x.VarStudentId,
                                    x.AttendanceStatus
                                }
                                    into g
                                    select new
                                    {
                                        STD = g.Key.VarStudentId,
                                        TOT = g.Key.AttendanceStatus.Count()
                                    };
            var getPercentage = from x in db.tbl_ExamMarks
                                where x.VarSession == session && x.VarClassId == cls.ToString() && x.VarSection == sec && x.ExamCode == examCode //&& x.VarBranchId == brachId.ToString() 
                                group x by x.VarStudentId into g
                                orderby g.Sum(p => p.Total_Marks) / g.Count() descending
                                select new
                                {
                                    STD = g.Key,
                                    totalSub = g.Count(),
                                    //STD = g.Key.VarStudentId,
                                    totalMarks = g.Sum(p => p.Total_Marks),
                                    //totalSub = g.Key.VarSubjectCode.Count(),
                                    per = g.Sum(p => p.Total_Marks) / g.Count()
                                };
            int position = 0;
            foreach (var tt in getPercentage)
            {
                if (position == 0)
                {
                    position = 1;
                }
                tempTabulationSheet tempTabulation = new tempTabulationSheet();
                tempTabulation.StudentId = tt.STD;
                tempTabulation.Percentage = Math.Round((double)tt.per, 2);
                tempTabulation.Position = position;
                tempTabulation.VarBranchId = Convert.ToInt32(Session["VarBranchId"]);
                db.tempTabulationSheets.InsertOnSubmit(tempTabulation);
                db.SubmitChanges();
                position = position + 1;
            }

            foreach (var tt in getAttendence)
            {
                //tempTabulationSheet tempTabulation = new tempTabulationSheet();
                var checkData = db.tempTabulationSheets.FirstOrDefault(x => x.StudentId == tt.STD);
                if (checkData != null)
                {
                    checkData.Attendence = tt.TOT;
                    //checkData.Project = "A";
                    db.SubmitChanges();
                }
            }
        }

        GetRepeatStudent();
    }
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    private void GetRepeatStudent()
    {
        //Class getClassType = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
        //{tbl_TransferHistory.TraSession}{Student.VarAdmissionSession}{Student.Status}
        //"'and {tbl_TransferHistory.TraSession}='" +
        //sessionDropDownList.SelectedValue +
        //"'or {tbl_TransferHistory.TraSession}='" +sessionDropDownList.SelectedValue +

        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        string session = sessionDropDownList.SelectedValue;
        string cls = classDropDownList.SelectedValue;
        string sec = sectionDropDownList.SelectedValue;
        string examCode = examNameDropDownList.SelectedValue;
        var report = new ReportDocument();
        report.Load(Server.MapPath("~/Reports/TabulationSheetOlevel.rpt"));

        if (sessionDropDownList.SelectedValue != "")
        {
            //{tbl_ExamMarks.VarClassId}
            TotalStudent.ReportSource = report;
            TotalStudent.SelectionFormula = "{tbl_ExamMarks.VarSession}='" + session +
                                            "'and{tbl_ExamMarks.VarClassId}='" + cls +
                                            "'and{tbl_ExamMarks.VarSection}='" + sec +
                                            "'and{tbl_ExamMarks.ExamCode}='" + examCode +
                                            "'and{Student.VarBranchID}=" + brachId;
            TotalStudent.RefreshReport();
        }
    }
}