using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentInfoEntryAttendanceEntry : System.Web.UI.Page
{
    SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadOffdayGrid();

    }
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void saveOffdayButton_Click(object sender, EventArgs e)
    {
        tbl_OffDayStatus offDay = new tbl_OffDayStatus();

        offDay.VarSession = sessionDropDownList.SelectedValue;
        DateTime date = DateTime.ParseExact(dateTextBox.Text, "dd/MM/yyyy", null);
        offDay.DatDate = date;
        offDay.VarStatus = commentTextBox.Text;
        db.tbl_OffDayStatus.InsertOnSubmit(offDay);
        db.SubmitChanges();

        LoadOffdayGrid();
    }

    private void LoadOffdayGrid()
    {
        var getOffday = from x in db.tbl_OffDayStatus
                        orderby x.DatDate descending
                        select new { x.DatDate, x.VarSession, x.VarStatus };

        offDayGridView.DataSource = getOffday.AsEnumerable();
        offDayGridView.DataBind();
    }
    protected void showButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        attendanceGridView.DataSource = null;
        attendanceGridView.DataBind();
        DateTime date = DateTime.ParseExact(dateAtdTextBox.Text, "dd-MM-yyyy", null);
        tbl_OffDayStatus getOffDayStatus = db.tbl_OffDayStatus.FirstOrDefault(x => x.DatDate == date);
        if (getOffDayStatus != null)
        {
            failStatusLabel.InnerText = getOffDayStatus.VarStatus;
        }
        else if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday)
        {
            failStatusLabel.InnerText = "  It's Weekend.  ";
        }

        else
        {
            var getAllStudent = from x in db.tbl_Present_classes
                                join s in db.Students on x.VarStudentID equals s.VarStudentID into sGroup
                                from s in sGroup.DefaultIfEmpty()
                                //join a in db.tbl_StudentAttendances on x.VarStudentID equals a.VarStudentId into aGroup
                                //from a in aGroup.DefaultIfEmpty()
                                join y in db.tbl_StudentAttendances on new { VarStudentId = x.VarStudentID, DatDate = (DateTime?)date } equals new { y.VarStudentId, y.DatDate } into mJoin
                                from y in mJoin.DefaultIfEmpty()
                                orderby x.StudentRoll ascending
                                where
                                    x.VarSessionId == sessionAtdDropDownList.SelectedValue &&
                                    x.VarClassID == classDropDownList.SelectedValue && x.VarSection == sectionDropDownList.SelectedValue && x.Status == "P" && s.VarBranchID == Convert.ToInt32(Session["VarBranchId"])
                                select new { x.VarStudentID, s.VarStudentFirstName, s.VarStudentLastName, x.StudentRoll,y.AttendanceStatus };
            foreach (var a in getAllStudent)
            {
                string s = a.AttendanceStatus;
            }
            attendanceGridView.DataSource = getAllStudent.AsEnumerable();
            attendanceGridView.DataBind();
           
        }

    }
    protected void atdSaveButton_Click(object sender, EventArgs e)
    {
        string session = sessionAtdDropDownList.SelectedValue;
        DateTime date = DateTime.ParseExact(dateAtdTextBox.Text, "dd-MM-yyyy", null);
        int classId = Convert.ToInt32(classDropDownList.SelectedValue);
        string sectionId = sectionDropDownList.SelectedValue;
        foreach (GridViewRow gvrow in attendanceGridView.Rows)
        {
            tbl_StudentAttendance studentAttendance = new tbl_StudentAttendance();
            string studentId = ((Label)gvrow.Cells[1].FindControl("Label1")).Text;
            //string stdRoll = ((Label)gvrow.Cells[3].FindControl("Label3")).Text;
            var attRecord = ((RadioButtonList)gvrow.Cells[4].FindControl("attRadioButtonList"));

            tbl_StudentAttendance checkAttendance =
                db.tbl_StudentAttendances.FirstOrDefault(x => x.ClassId == classId && x.DatDate == date && x.VarStudentId==studentId && x.VarSession==session);
            if (checkAttendance!=null)
            {
                checkAttendance.AttendanceStatus = attRecord.SelectedValue;
                successStatusLabel.InnerText = "Attendance Updated Successfully.";
            }
            else
            {
                studentAttendance.VarSession = session;
                studentAttendance.VarMonth = date.Month;
                studentAttendance.VarStudentId = studentId;
                studentAttendance.ClassId = classId;
                studentAttendance.VarSection = sectionId;
                studentAttendance.DatDate = date;
                studentAttendance.VarBranch = (string)Session["VarBranchId"];
                studentAttendance.AttendanceStatus = attRecord.SelectedValue;
                studentAttendance.EntryDate = DateTime.Now.Date;
                studentAttendance.Uid = Session["uid"].ToString();
                db.tbl_StudentAttendances.InsertOnSubmit(studentAttendance);
                successStatusLabel.InnerText = "Attendance Save Successfully.";
            }
            

            db.SubmitChanges();
            
        }
    }

   
}