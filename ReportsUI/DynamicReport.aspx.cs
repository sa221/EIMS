using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class ReportsUI_DynamicReport : System.Web.UI.Page
{
    SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        string userId = Session["uid"].ToString();
        int branchId = Convert.ToInt32(Session["VarBranchId"]);
        var deleteHistory = from x in db.TempDynamicReports
                            where x.UserId == userId && x.VarBranch == branchId
                            select x;
        db.TempDynamicReports.DeleteAllOnSubmit(deleteHistory);
        db.SubmitChanges();

        if (classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0" && shiftDropDownList.SelectedValue != "0")
        {
            var getAllStudent = from x in db.Students
                                join z in db.tblSections on x.RecommendAdmissionSection equals z.SectionId into secJoin
                                from z in secJoin.DefaultIfEmpty()
                                join cls in db.Classes on x.PClassID equals cls.VarClassID into clsJoin
                                from cls in clsJoin.DefaultIfEmpty()
                                join shift in db.ShiftInfos on x.VarShiftCode equals shift.VarShiftCode into sftJoin
                                from shift in sftJoin.DefaultIfEmpty()
                                join sess in db.SessionInfos on x.VarSessionName equals sess.VarSessionId into sessJoin
                                from sess in sessJoin.DefaultIfEmpty()
                                where x.VarSessionName == sessionDropDownList.SelectedValue && x.PClassID == classDropDownList.SelectedValue
                                      && x.RecommendAdmissionSection == sectionDropDownList.SelectedValue &&
                                      x.VarShiftCode == shiftDropDownList.SelectedValue && x.Status == "P"
                                select new
                                {
                                    x.VarStudentID,
                                    Name = x.VarStudentFirstName + " " + x.VarStudentLastName,
                                    x.StudentRoll,
                                    z.varSectionName,
                                    cls.VarClassName,
                                    shift.VarShiftName,
                                    x.VarStudenHomeCell,
                                    sess.VarSessionName
                                };
            GridView2.DataSource = getAllStudent.AsEnumerable();
            GridView2.DataBind();
        }
        else if (classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0" && shiftDropDownList.SelectedValue == "0")
        {
            var getAllStudent = from x in db.Students
                                join z in db.tblSections on x.RecommendAdmissionSection equals z.SectionId into secJoin
                                from z in secJoin.DefaultIfEmpty()
                                join cls in db.Classes on x.PClassID equals cls.VarClassID into clsJoin
                                from cls in clsJoin.DefaultIfEmpty()
                                join shift in db.ShiftInfos on x.VarShiftCode equals shift.VarShiftCode into sftJoin
                                from shift in sftJoin.DefaultIfEmpty()
                                join sess in db.SessionInfos on x.VarSessionName equals sess.VarSessionId into sessJoin
                                from sess in sessJoin.DefaultIfEmpty()
                                where x.VarSessionName == sessionDropDownList.SelectedValue && x.PClassID == classDropDownList.SelectedValue
                                      && x.RecommendAdmissionSection == sectionDropDownList.SelectedValue && x.Status == "P"
                                select new
                                {
                                    x.VarStudentID,
                                    Name = x.VarStudentFirstName + " " + x.VarStudentLastName,
                                    x.StudentRoll,
                                    z.varSectionName,
                                    cls.VarClassName,
                                    shift.VarShiftName,
                                    x.VarStudenHomeCell,
                                    sess.VarSessionName
                                };
            GridView2.DataSource = getAllStudent.AsEnumerable();
            GridView2.DataBind();
        }
        else if (classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue != "0")
        {
            var getAllStudent = from x in db.Students
                                join z in db.tblSections on x.RecommendAdmissionSection equals z.SectionId into secJoin
                                from z in secJoin.DefaultIfEmpty()
                                join cls in db.Classes on x.PClassID equals cls.VarClassID into clsJoin
                                from cls in clsJoin.DefaultIfEmpty()
                                join shift in db.ShiftInfos on x.VarShiftCode equals shift.VarShiftCode into sftJoin
                                from shift in sftJoin.DefaultIfEmpty()
                                join sess in db.SessionInfos on x.VarSessionName equals sess.VarSessionId into sessJoin
                                from sess in sessJoin.DefaultIfEmpty()
                                where x.VarSessionName == sessionDropDownList.SelectedValue && x.PClassID == classDropDownList.SelectedValue
                                      && x.VarShiftCode == shiftDropDownList.SelectedValue && x.Status == "P"
                                select new
                                {
                                    x.VarStudentID,
                                    Name = x.VarStudentFirstName + " " + x.VarStudentLastName,
                                    x.StudentRoll,
                                    z.varSectionName,
                                    cls.VarClassName,
                                    shift.VarShiftName,
                                    x.VarStudenHomeCell,
                                    sess.VarSessionName
                                };
            GridView2.DataSource = getAllStudent.AsEnumerable();
            GridView2.DataBind();
        }
        else if (classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue == "0")
        {
            var getAllStudent = from x in db.Students
                                join z in db.tblSections on x.RecommendAdmissionSection equals z.SectionId into secJoin
                                from z in secJoin.DefaultIfEmpty()
                                join cls in db.Classes on x.PClassID equals cls.VarClassID into clsJoin
                                from cls in clsJoin.DefaultIfEmpty()
                                join shift in db.ShiftInfos on x.VarShiftCode equals shift.VarShiftCode into sftJoin
                                from shift in sftJoin.DefaultIfEmpty()
                                join sess in db.SessionInfos on x.VarSessionName equals sess.VarSessionId into sessJoin
                                from sess in sessJoin.DefaultIfEmpty()
                                where x.VarSessionName == sessionDropDownList.SelectedValue && x.PClassID == classDropDownList.SelectedValue && x.Status == "P"
                                select new
                                {
                                    x.VarStudentID,
                                    Name = x.VarStudentFirstName + " " + x.VarStudentLastName,
                                    x.StudentRoll,
                                    z.varSectionName,
                                    cls.VarClassName,
                                    shift.VarShiftName,
                                    x.VarStudenHomeCell,
                                    sess.VarSessionName
                                };
            GridView2.DataSource = getAllStudent.AsEnumerable();
            GridView2.DataBind();
        }


    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string studentId = branchInitialTextBox.Text + txtStdId.Text;
        if (e.CommandName == "AddButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GridView2.Rows[index];
            string id = ((Label)gvRow.FindControl("idLabel")).Text;
            string name = ((Label)gvRow.FindControl("nameLabel")).Text;
            string sec = ((Label)gvRow.FindControl("sectionLabel")).Text;
            string shift = ((Label)gvRow.FindControl("shiftLabel")).Text;
            string roll = ((Label)gvRow.FindControl("rollLabel")).Text;
            string cls = ((Label)gvRow.FindControl("classLabel")).Text;
            string phone = ((Label)gvRow.FindControl("phoneLabel")).Text;
            string sess = ((Label)gvRow.FindControl("sessionLabel")).Text;

            TempDynamicReport dynamicReport = new TempDynamicReport();

            dynamicReport.VarStudentID = id;
            dynamicReport.StudentName = name;
            if (roll != "")
            {
                dynamicReport.Roll = Convert.ToInt32(roll);
            }
            dynamicReport.Section = sec;
            dynamicReport.VarClass = cls;
            dynamicReport.Mobile = phone;
            dynamicReport.Shift = shift;
            dynamicReport.VarSession = sess;
            dynamicReport.DatDate = DateTime.Now.Date;
            dynamicReport.UserId = Session["uid"].ToString();
            dynamicReport.VarBranch = Convert.ToInt32(Session["VarBranchId"]);

            db.TempDynamicReports.InsertOnSubmit(dynamicReport);
            db.SubmitChanges();

            var btn = ((Button)gvRow.FindControl("btnAdd"));
            btn.Text = "Taken";
            btn.Enabled = false;
        }
    }
    protected void reportButton_Click(object sender, EventArgs e)
    {
        var report = new ReportDocument();

        
       
            report.Load(Server.MapPath("~/Reports/ManualStudentList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            
            CrystalReportViewer1.RefreshReport();

        
    }
}