using System;
using System.Data.Linq;
using System.Linq;
using System.Web.UI;

public partial class Student_Info_Search_and_update_Applicant_student_modify : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != null)
        {
            //if (Session["uid"] != null)
            //    txtuid.Text = Session["uid"].ToString();

            //if (Session["VarBranchId"] != null)
            //    drpbranch.SelectedValue = Session["VarBranchId"].ToString();
            //if (Session["VarShiftCode"] != null)
            //    drpshift.SelectedValue = Session["VarShiftCode"].ToString();
        }
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        IQueryable<string> checkExistingStudentId = from c in db.ParticipantStudents
            where c.varRegistrationId.Contains(txtregId.Text)
            select c.varRegistrationId;

        if (checkExistingStudentId.FirstOrDefault() != null)
        {
            //FileUpload1.Attributes.Add("accept", "image/jpg");
            //CheckBoxList1.DataSource = ;
            //CheckBoxList1.DataBind();


            //Populate Dropdown List
            //drpid.DataSource = db.UserInfos.ToList();
            //drpid.DataTextField = "uID"; //Display
            //drpid.DataValueField = "uID"; //Return Value
            //drpid.DataBind();


            ParticipantStudent ps =
                db.ParticipantStudents.Where(u => u.varRegistrationId == txtregId.Text).FirstOrDefault();

            txtsName.Text = ps.varStudentFirstName;
            middleNameTextBox.Text = ps.varStudentMiddleName;
            lastNameTextBox.Text = ps.varStudentLastName;
            //txtfather.Text = ps.varFatherName;
            txtdob.Text = ps.dob.ToString();
            txtfather.Text = ps.varFatherName;
            //txtfocc.Text = ps.fatherOccupation;
            txtfmob.Text = ps.fatherPhone;
            txtmother.Text = ps.varMotherName;
            txtmotheroc.Text = ps.motherOccupation;
            txtmothermob.Text = ps.motherPhone;
            txtpresentaddress.Text = ps.PresentAddress;
            txtemrgency.Text = ps.EmergencyPhone;
            txtfemail.Text = ps.Email;
            txtReferred.Text = ps.ReferredBy;
            DropDownList3.SelectedValue = ps.admissionForClass;
            txtsibilingsname.Text = ps.VarSiblingName;
            drpClass.Text = ps.VarSiblingClass;
            txtssec.Text = ps.VarSiblingSection;
            txtsroll.Text = ps.VarSiblingRoll;
            TextBox1.Text = ps.priviousSchoolName;
            TextBox2.Text = ps.priviousSClass;


            imgstudent.ImageUrl = "~/Student Info Search and update/st_participant.ashx?id=" + txtregId.Text;

            Literal1.Text = "Your all data are successfully showed";
        }


        else
        {
            Literal1.Text = "Data not Found";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ParticipantStudent ps = db.ParticipantStudents.Where(d => d.varRegistrationId == txtregId.Text).FirstOrDefault();
        ps.varStudentFirstName = txtsName.Text;
        ps.varStudentMiddleName = middleNameTextBox.Text;
        ps.varStudentLastName = lastNameTextBox.Text;
        ps.varRegistrationId = txtregId.Text;
        ps.dob = Convert.ToDateTime(txtdob.Text);
        ps.varFatherName = txtfather.Text;
        //ps.fatherOccupation = txtfocc.Text;
        ps.fatherPhone = txtfmob.Text;
        ps.varMotherName = txtmother.Text;
        ps.motherOccupation = txtmotheroc.Text;
        ps.motherPhone = txtmothermob.Text;
        ps.PresentAddress = txtpresentaddress.Text;
        ps.EmergencyPhone = txtemrgency.Text;
        ps.Email = txtfemail.Text;
        ps.admissionForClass = DropDownList3.Text;
        ps.ReferredBy = txtReferred.Text;
        ps.VarSiblingName = txtsibilingsname.Text;
        ps.VarSiblingClass = drpClass.Text;
        ps.VarSiblingSection = txtssec.Text;
        ps.VarSiblingRoll = txtsroll.Text;
        ps.priviousSchoolName = TextBox1.Text;
        ps.priviousSClass = TextBox2.Text;
        ps.PriviousSyear = DropDownList1.Text + "--To--" + DropDownList2.Text;
        //ps.uid = txtuid.Text;
        ps.VarBranchId = Convert.ToInt32(drpbranch.SelectedValue);
        ps.VarShiftCode = drpshift.SelectedValue;

        if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
        {
            string fileName = FileUpload1.FileName;

            byte[] fileByte = FileUpload1.FileBytes;
            var binaryObj = new Binary(fileByte);

            ps.StudentPhoto = binaryObj;
        }


        db.SubmitChanges();

        Literal1.Text = " Update success";
    }
}