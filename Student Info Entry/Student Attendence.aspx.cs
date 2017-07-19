using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Attendence_Student_Attendence : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    private string str;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    var data = db.Students.Where(d => d.VarStudentID = ).FirstOrDefault();
        //    GridView1.DataSource = data;
        //    GridView1.DataBind();


        //}
    }

    protected void drpClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList ddlListFind = (DropDownList)sender;
        //GridLines item1 = (GridLines)ddlListFind.NamingContainer;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //var data = db.Students.Where(d => d.RecommendAdmissionClass == drpClass.Text).FirstOrDefault();


        //    var data = db.students.Where(d => d.uID == Session["uID"].ToString()).FirstOrDefault();
        //tbl_Student_attendance at = new tbl_Student_attendance();

        //at.VarClassID = data.RecommendAdmissionClass.ToString();

        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            var tsa = new tbl_Student_attendance();

            var txt = (TextBox) gvrow.FindControl("txtstudId");
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


            //string studentId = (control.FindControl("txtstudId") as TextBox).Text;

            //CheckBox chk = (CheckBox)gvrow.FindControl("subCheckBox");

            //str += "<b>EmpId :- </b>" + gvrow.Cells[1].Text + ", ";
            //str = gvrow.Cells[2].Text;
            // str += "<b>Company :- </b>" + gvrow.Cells[3].Text + ", ";
            //str += "<b>Addess :- </b>" + gvrow.Cells[4].Text;
            //str += "<br />";

            tsa.classDate = Convert.ToDateTime(txtDate.Text);
            tsa.VarClassID = drpClass.SelectedValue;
            tsa.sectionId = Convert.ToInt32(drpSection.SelectedValue);
            tsa.VarStudentID = txt.Text;
            tsa.inTime = txtintime1.Text + ":" + txtintime2.Text + ":" + txtintime3.Text;
            tsa.outTime = txtouttime.Text + ":" + txtouttime2.Text + ":" + txtouttime3.Text;
            tsa.comments = txtComnts.Text;
            tsa.VarShiftCode = drpShift.SelectedValue;

            //if (chk.SelectedValue == "Present" && chk.SelectedValue == "Late")
            //{

            //    tsa.present = Convert.ToString(true);
            //    tsa.late = Convert.ToString(true);


            //}


            //else if (chk.SelectedValue == "Absent")
            //{
            //    tsa.absent = Convert.ToString(true);

            //}
            //else if (chk.SelectedValue == "Late")
            //{
            //    tsa.late = Convert.ToString(true);

            //}
            //else if (chk.SelectedValue == "Present")
            //{
            //    tsa.present = Convert.ToString(true);


            //}
            //else
            //{
            //    tsa.late = Convert.ToString(false);
            //    tsa.late = Convert.ToString(false);
            //    tsa.present = Convert.ToString(false);

            ////}
            //if (chk1.Checked == true && chk3.Checked == true)
            //{
            //    tsa.present = Convert.ToString(true);
            //    tsa.late = Convert.ToString(true);
            //    tsa.absent = Convert.ToString(false);
            //}


            if (chk2.Checked)
            {
                tsa.absent = Convert.ToString(true);
                tsa.present = Convert.ToString(false);
                tsa.late = Convert.ToString(false);
            }


            else if (chk3.Checked)
            {
                tsa.late = Convert.ToString(true);
                tsa.present = Convert.ToString(true);
                tsa.absent = Convert.ToString(false);
            }


            else if (chk1.Checked)
            {
                tsa.present = Convert.ToString(true);
                tsa.late = Convert.ToString(false);
                tsa.absent = Convert.ToString(false);
            }


            //subAssign.VarSubjectCode = str;
            db.tbl_Student_attendances.InsertOnSubmit(tsa);
            db.SubmitChanges();
        }


        Literal1.Text = "Subject successfully assigned with ID ";

        drpClass.SelectedValue = "0";
        drpSection.SelectedValue = "0";
        drpShift.SelectedValue = "0";
        txtDate.Text = "";
    }
}