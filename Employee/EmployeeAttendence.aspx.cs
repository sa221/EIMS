using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employee_EmployeeAttendence : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            var emp = new tbl_employee_attendence();
            var txtempid = (TextBox) gvrow.FindControl("txtEmployeeid");

            var txtempname = (TextBox) gvrow.FindControl("txtEmployeename");
            var txtComnts = (TextBox) gvrow.FindControl("txtComments");

            var txtintime1 = (TextBox) gvrow.FindControl("txtInTime");

            var txtintime2 = (TextBox) gvrow.FindControl("txtMin1");


            var txtintime3 = (TextBox) gvrow.FindControl("txtAmPm");


            var txtouttime = (TextBox) gvrow.FindControl("outTime");
            var txtouttime2 = (TextBox) gvrow.FindControl("TextBoxminout");
            var txtouttime3 = (TextBox) gvrow.FindControl("TextBoxamout");

            var chk1 = (CheckBox) gvrow.FindControl("chkPresent");
            var chk2 = (CheckBox) gvrow.FindControl("chkAbsent");
            var chk3 = (CheckBox) gvrow.FindControl("chkLate");


            emp.VarEmployeeid = Convert.ToInt32(txtempid.Text);
            emp.VarEmployeeName = txtempname.Text;
            emp.AttendDate = Convert.ToDateTime(TextBox1.Text);
            emp.In_Time = txtintime1.Text + ":" + txtintime2.Text + ":" + txtintime3.Text;
            emp.Out_Time = txtouttime.Text + ":" + txtouttime2.Text + ":" + txtouttime3.Text;
            emp.Comments = txtComnts.Text;
            emp.NumDesignationid = Convert.ToInt32(drpDesgnation.SelectedValue);

            //if (chk.SelectedValue == "Present" && chk.SelectedValue == "Late")
            //{

            //    emp.present = Convert.ToString(true);
            //    emp.late = Convert.ToString(true);


            //}


            //else if (chk.SelectedValue == "Absent")
            //{
            //    emp.absent = Convert.ToString(true);

            //}
            //else if (chk.SelectedValue == "Late")
            //{
            //    emp.late = Convert.ToString(true);

            //}
            //else if (chk.SelectedValue == "Present")
            //{
            //    emp.present = Convert.ToString(true);


            //}
            //else
            //{
            //    emp.late = Convert.ToString(false);
            //    emp.late = Convert.ToString(false);
            //    emp.present = Convert.ToString(false);

            ////}
            //if (chk1.Checked == true && chk3.Checked == true)
            //{
            //    emp.present = Convert.ToString(true);
            //    emp.late = Convert.ToString(true);
            //    emp.absent = Convert.ToString(false);
            //}


            if (chk2.Checked)
            {
                emp.absent = Convert.ToString(true);
                emp.present = Convert.ToString(false);
                emp.late = Convert.ToString(false);
            }


            else if (chk3.Checked)
            {
                emp.late = Convert.ToString(true);
                emp.present = Convert.ToString(true);
                emp.absent = Convert.ToString(false);
            }


            else if (chk1.Checked)
            {
                emp.present = Convert.ToString(true);
                emp.late = Convert.ToString(false);
                emp.absent = Convert.ToString(false);
            }


            //subAssign.VarSubjectCode = str;
            db.tbl_employee_attendences.InsertOnSubmit(emp);
            db.SubmitChanges();
        }


        Literal1.Text = "Attendance Is successfully assigned ";

        drpDesgnation.SelectedValue = "0";
        TextBox1.Text = "";
    }
}