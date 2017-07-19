using System;
using System.Linq;
using System.Web.UI;

public partial class SessionEntry : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void sessionSave_Click(object sender, EventArgs e)
    {
        IQueryable<string> checkExisting = from c in db.SessionInfos
            where c.VarSessionId.Contains(txtSessionCode.Text)
            select c.VarSessionId;

        //var data = db.tblSections.Where(d => d.ClassID == Convert.ToInt32(classDropDownList.Text)).ToList();
        //if (data.ClassID == Convert.ToInt32(classDropDownList.Text) && data.varSectionName == txtsection.Text)
        if (checkExisting.FirstOrDefault() == null)
        {
            
            var sesi = new SessionInfo();
            for (int i = 1; i < 5; i++)
            {
                tbl_ExamSession examSession = new tbl_ExamSession();
                if (txtSessionCode.Text != "" && i == 2)
                {
                    string s1 = txtSessionCode.Text.Substring(3, 2);
                    examSession.ExamSessionName = "JUNE 20" + s1;
                }
                if (txtSessionCode.Text != "" && i == 1)
                {
                    string s1 = txtSessionCode.Text.Substring(3, 2);
                    examSession.ExamSessionName = "JAN 20" + s1;
                }
                if (txtSessionCode.Text != "" && i == 3)
                {
                    string s1 = txtSessionCode.Text.Substring(1, 2);
                    examSession.ExamSessionName = "NOVEMBER 20" + s1;
                }
                if (txtSessionCode.Text != "" && i == 4)
                {
                    string s1 = txtSessionCode.Text.Substring(3, 2);
                    examSession.ExamSessionName = "MAY/JUNE 20" + s1;
                }
                examSession.SessionId = txtSessionCode.Text;
                examSession.ExamSessionId = txtSessionCode.Text + i;
                db.tbl_ExamSessions.InsertOnSubmit(examSession);
                db.SubmitChanges();
            }
           
            sesi.uid = Session["uid"].ToString();
            sesi.VarBranchId = Session["VarBranchId"].ToString();
            sesi.VarShiftCode = Session["VarShiftCode"].ToString();
            sesi.VarSessionId = txtSessionCode.Text;
            sesi.VarSessionName = txtSessiontName.Text;
            db.SessionInfos.InsertOnSubmit(sesi);
            
            db.SubmitChanges();
            Literal1.Text = "Session Entry Successfully";
            txtSessionCode.Text = "";
            txtSessiontName.Text = "";
            Response.Redirect("~/All Set Up/SessionEntry.aspx");
        }
        else
        {
            Literal1.Text = "Session ID already exists";
        }
    }
}