using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_BoardExamTopSheet : System.Web.UI.Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            GetReport();
        }
    }
    protected void showButton_Click(object sender, EventArgs e)
    {
        GetAllSubject();
        GetReport();
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
    private void GetAllSubject()
    {
        string userId = Session["uid"].ToString();
        string branch = Session["VarBranchId"].ToString();
        var isExist = from x in db.temp_AllBoardExamSubjectWithUnitCodes
            where x.VarUser == userId && x.VarBranch == branch
            select x;
        if (isExist.FirstOrDefault()!=null)
        {
            db.temp_AllBoardExamSubjectWithUnitCodes.DeleteAllOnSubmit(isExist);
            db.SubmitChanges();
        }
        var getAllSubject = from t in db.tbl_BoardExamSubAssigns
                            where t.Session==sessionDropDownList.SelectedValue && t.ExamSession==examSessionDropDownList.SelectedValue && t.QualificationLevel==qLevelDropDownList.SelectedValue
                            orderby t.SubjectId
                                                select t;
        int count = 0;
        foreach (var allSub in getAllSubject)
        {
            var allSubject = new temp_AllBoardExamSubjectWithUnitCode();
            temp_AllBoardExamSubjectWithUnitCode check =
                db.temp_AllBoardExamSubjectWithUnitCodes.FirstOrDefault(x => x.StudentId == allSub.StudentId && x.VarUser==userId && x.VarBranch==branch);
            if (check == null)
            {
                if (allSub.UnitCode!="")
                {
                    allSubject.StudentId = allSub.StudentId;
                    allSubject.Subject = allSub.SubjectName + "(" + allSub.UnitCodeName + ")";
                    allSubject.TotalSub = count + 1;
                    allSubject.ExamSession = allSub.ExamSession;
                    allSubject.VarUser = Session["uid"].ToString();
                    allSubject.VarBranch = Session["VarBranchId"].ToString();
                    db.temp_AllBoardExamSubjectWithUnitCodes.InsertOnSubmit(allSubject);
                }
                else
                {
                    allSubject.StudentId = allSub.StudentId;
                    allSubject.Subject = allSub.SubjectName;
                    allSubject.TotalSub = count + 1;
                    allSubject.ExamSession = allSub.ExamSession;
                    allSubject.VarUser = Session["uid"].ToString();
                    allSubject.VarBranch = Session["VarBranchId"].ToString();
                    db.temp_AllBoardExamSubjectWithUnitCodes.InsertOnSubmit(allSubject);
                }
            }
            else
            {
                temp_AllBoardExamSubjectWithUnitCode checkSub =
                db.temp_AllBoardExamSubjectWithUnitCodes.FirstOrDefault(x => x.Subject.Contains(allSub.SubjectName) && x.StudentId == allSub.StudentId && x.VarUser == userId && x.VarBranch == branch);
                if (checkSub!=null)
                {
                    if (allSub.UnitCode != "")
                    {
                        check.Subject = check.Subject.Substring(0, check.Subject.Length - 1)+", "+ allSub.UnitCodeName + ")";
                        check.TotalSub = check.TotalSub + 1;
                    }
                    else
                    {
                        check.Subject = check.Subject + " ; " + allSub.SubjectName;
                        check.TotalSub = check.TotalSub + 1;
                    }
                }
                else
                {
                    if (allSub.UnitCode != "")
                    {
                        check.Subject = check.Subject + " ; " + allSub.SubjectName + "(" + allSub.UnitCodeName + ")";
                        check.TotalSub = check.TotalSub + 1;
                    }
                    else
                    {
                        check.Subject = check.Subject + " ; " + allSub.SubjectName;
                        check.TotalSub = check.TotalSub + 1;
                    }
                }
                
            }
            db.SubmitChanges();
        }
    }
    private void GetReport()
    {
        var report = new ReportDocument();
        report.Load(Server.MapPath("~/Reports/BoardExamSubjectTopSheet.rpt"));
        //var textObject = report.ReportDefinition.ReportObjects["ClassName"] as TextObject;
        //if (textObject != null) textObject.Text = classDropDownList.SelectedItem.Text;{temp_AllBoardExamSubjectWithUnitCode.VarUser}{temp_AllBoardExamSubjectWithUnitCode.VarBranch}
        SubjectTopSheet.ReportSource = report;
        SubjectTopSheet.SelectionFormula = "{temp_AllBoardExamSubjectWithUnitCode.VarUser}='" + Session["uid"] + "'and {temp_AllBoardExamSubjectWithUnitCode.VarBranch}='" + Session["VarBranchId"] + "'";
        //IdCardGenetaro.SelectionFormula = "{temp_IDCard.StudentId}='" + studentIdTextBox.Text + "'";
        SubjectTopSheet.RefreshReport();
    }
}