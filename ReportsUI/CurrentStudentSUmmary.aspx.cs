using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_CurrentStudentSUmmary : System.Web.UI.Page
{
    SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void showButton_Click(object sender, EventArgs e)
    {
        if (Session["VarBranchId"] != null)
        {
            string br=null;
            int branchId = Convert.ToInt32(Session["VarBranchId"]);
            Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
            if (branchInitial != null) br = branchInitial.VarBranchInitial;

            var getAll = from a in db.Students
                group a by new
                {
                    a.PClassID
                }
                into g
                select new
                {
                    Class = g.Key.PClassID,
                    oldStudent = (from Students in db.Students
                        where
                            Students.Status == "P" &&
                            (Students.VarStudentID.Substring(1 - 1, 2) != br ||
                             Students.VarAdmissionSession != sessionDropDownList.SelectedValue ||
                             Students.VarAdmissionSession == null) &&
                            Students.VarSessionName == sessionDropDownList.SelectedValue &&
                            Students.PClassID == g.Key.PClassID
                        select new
                        {
                            Students
                        }).Count(),
                    newStudent = (from Students in db.Students
                        where Students.Status == "P" && Students.VarStudentID.Substring(0,2)==br &&
                              Students.VarAdmissionSession == sessionDropDownList.SelectedValue &&
                              Students.PClassID == g.Key.PClassID
                        select new
                        {
                            Students
                        }).Count(),
                    TotalCount =
                        (from Students in db.Students
                            where Students.Status == "P" &&
                                  Students.VarSessionName == sessionDropDownList.SelectedValue &&
                                  Students.PClassID == g.Key.PClassID
                            select new
                            {
                                Students
                            }).Count()
                };
            var delAllData=from x in db.TempCurrentStudents
                           where x.UserId==Session["uid"].ToString()
                               select x;
            db.TempCurrentStudents.DeleteAllOnSubmit(delAllData);
            db.SubmitChanges();
            foreach (var allStd in getAll)
            {

                string clsId = allStd.Class;
                int oldStudent = allStd.oldStudent;
                int newStudent = allStd.newStudent;
                int totalStudent = allStd.TotalCount;
                var getCls = db.Classes.FirstOrDefault(c => c.VarClassID == clsId);
                TempCurrentStudent currentStudent=new TempCurrentStudent();
                currentStudent.ClassId = clsId;
                currentStudent.OldStudent = oldStudent;
                currentStudent.NewStudent = newStudent;
                currentStudent.TotalStudent = totalStudent;
                //if (getCls != null) currentStudent.ClassName = getCls.VarClassName.Substring(0, 10);
                currentStudent.BranchId = Convert.ToInt32(Session["VarBranchId"]);
                currentStudent.UserId = Session["uid"].ToString();
                db.TempCurrentStudents.InsertOnSubmit(currentStudent);
                db.SubmitChanges();
            }
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/CurrentStudentSummary.rpt"));
            TotalStudent.ReportSource = report;
            TotalStudent.RefreshReport();
        }
       
    }
}