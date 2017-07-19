using System;
using System.Data.Linq;
using System.Linq;
using System.Web.UI;

public partial class Student_Admission_Modify : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FileUpload1.Attributes.Add("accept", "image/jpg");
            //CheckBoxList1.DataSource = ;
            //CheckBoxList1.DataBind();


            ////Populate Dropdown List
            //drpid.DataSource = db.UserInfos.ToList();
            //drpid.DataTextField = "uID"; //Display
            //drpid.DataValueField = "uID"; //Return Value
            //drpid.DataBind();
            //string id = txtid.Text;
            //var data = db.UserInfos.Where(u => u.uID == id).FirstOrDefault();
            if (Session["VarStudentID"] != null)
                txtid.Text = Session["VarStudentID"].ToString();

            if (Session["uid"] != null)
                txtuid.Text = Session["uid"].ToString();

            if (Session["VarBranchId"] != null)
                drpbranch.SelectedValue = Session["VarBranchId"].ToString();
            if (Session["VarShiftCode"] != null)
                drpshift.SelectedValue = Session["VarShiftCode"].ToString();

            Student std = db.Students.Where(u => u.VarStudentID == txtid.Text).FirstOrDefault();

            txtid.Text = std.VarStudentID;
            txtfname.Text = std.VarStudentFirstName;
            txtmname.Text = std.VarStudentMeddleName;
            txtlname.Text = std.VarStudentLastName;


            if (std.VarStudentGender == "Male")
            {
                malerbutton.Checked = true;
            }
            else if (std.VarStudentGender == "Female")
            {
                femalerbutton.Checked = true;
            }

            //

            txtdob.Text = std.VarStudentBirth.ToString();
            txtnational.Text = std.VarStudentNationality;
            txtpresent.Text = std.VarStudenAddress;
            txtphone.Text = std.VarStudenHomePhone;

            txtmobile.Text = std.VarStudenHomeCell;
            txtrel.Text = std.VarReligion;
            txtfather.Text = std.VarFatherName;
            txtfocc.Text = std.VarFatherOccupation;
            txtfoff.Text = std.VarFatherOfficeAddress;
            //  std.VarFatherOfficePhone   "";
            txtfmob.Text = std.VarFatherMobile;
            txtfemail.Text = std.VarFatherEmail;
            txtmname.Text = std.VarMotherName;
            txtmotheroc.Text = std.VarMotherOccupation;
            txtmadd.Text = std.VarMotherOfficeAddress;
            //  std.VarMotherOfficePhone   "";
            txtmothermob.Text = std.VarMotherMobile;
            txtmemail.Text = std.VarMotherEmail;

            //if (sradio1.Checked)
            //{
            //    std.VarSiblingYesNo   sradio1.Text;
            //}
            //else if (sradio2.Checked)
            //{
            //    std.VarSiblingYesNo   sradio2.Text;
            //}

            //else
            //{
            //    std.VarSiblingYesNo   "";

            //}

            if (std.VarSiblingYesNo == "yes")
            {
                sradio1.Checked = true;
            }
            else if (std.VarSiblingYesNo == "no")
            {
                sradio2.Checked = true;
            }


            txtsibilingsname.Text = std.VarSiblingName;
            txtsshift.Text = std.VarSiblingShift;
            txtsclass.Text = std.VarSiblingClass;
            txtssec.Text = std.VarSiblingSection;
            txtsroll.Text = std.VarSiblingRoll;
            txtprivscl.Text = std.VarPreviousSchoolAttended;

            if (std.VarPrivateYes == "True")
            {
                chkprivate.Checked = true;
            }
            else
            {
                chkprivate.Checked = false;
            }

            txtpremarks.Text = std.VarPrincipalRemarks;
            drpclass.SelectedValue = std.RecommendAdmissionClass;
            txtrdate.Text = std.RecommendDate.ToString();
            txtregid.Text = std.VarRegistrationID;
            drpsession.SelectedValue = std.VarSessionName;
            //    drpshift.SelectedValue=std.VarShiftCode  ;
            DropDownList1.SelectedValue = std.BloodGroup;
            //For Student Doc

            StudentDoc stdoc = db.StudentDocs.Where(s => s.VarStudentID.ToString() == txtid.Text).FirstOrDefault();

            imgstudent.ImageUrl = "MyPhoto.ashx?id=" + txtid.Text;
            Image2.ImageUrl = "Image2.ashx?id=" + txtid.Text;
            Image3.ImageUrl = "Image3.ashx?id=" + txtid.Text;


            Literal1.Text = "Your all data are successfully showed";
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Student std = db.Students.Where(u => u.VarStudentID == txtid.Text).FirstOrDefault();

        txtid.Text = std.VarStudentID;
        txtfname.Text = std.VarStudentFirstName;
        txtmname.Text = std.VarStudentMeddleName;
        txtlname.Text = std.VarStudentLastName;


        if (std.VarStudentGender == "Male")
        {
            malerbutton.Checked = true;
        }
        else if (std.VarStudentGender == "Female")
        {
            femalerbutton.Checked = true;
        }

        txtdob.Text = std.VarStudentBirth.ToString();
        txtnational.Text = std.VarStudentNationality;
        txtpresent.Text = std.VarStudenAddress;
        txtphone.Text = std.VarStudenHomePhone;

        txtmobile.Text = std.VarStudenHomeCell;
        txtrel.Text = std.VarReligion;
        txtfather.Text = std.VarFatherName;
        txtfocc.Text = std.VarFatherOccupation;
        txtfoff.Text = std.VarFatherOfficeAddress;
        //  std.VarFatherOfficePhone   "";
        txtfmob.Text = std.VarFatherMobile;
        txtfemail.Text = std.VarFatherEmail;
        txtmname.Text = std.VarMotherName;
        txtmotheroc.Text = std.VarMotherOccupation;
        txtmadd.Text = std.VarMotherOfficeAddress;
        //  std.VarMotherOfficePhone   "";
        txtmothermob.Text = std.VarMotherMobile;
        txtmemail.Text = std.VarMotherEmail;

        //if (sradio1.Checked)
        //{
        //    std.VarSiblingYesNo   sradio1.Text;
        //}
        //else if (sradio2.Checked)
        //{
        //    std.VarSiblingYesNo   sradio2.Text;
        //}

        //else
        //{
        //    std.VarSiblingYesNo   "";

        //}

        if (std.VarSiblingYesNo == "yes")
        {
            sradio1.Checked = true;
        }
        else if (std.VarSiblingYesNo == "no")
        {
            sradio2.Checked = true;
        }


        txtsibilingsname.Text = std.VarSiblingName;
        txtsshift.Text = std.VarSiblingShift;
        txtsclass.Text = std.VarSiblingClass;
        txtssec.Text = std.VarSiblingSection;
        txtsroll.Text = std.VarSiblingRoll;
        txtprivscl.Text = std.VarPreviousSchoolAttended;

        if (std.VarPrivateYes == "True")
        {
            chkprivate.Checked = true;
        }
        else
        {
            chkprivate.Checked = false;
        }

        txtpremarks.Text = std.VarPrincipalRemarks;
        drpclass.SelectedValue = std.RecommendAdmissionClass;
        txtrdate.Text = std.RecommendDate.ToString();
        //  txtbranch.Text = std.VarBranchID;
        txtregid.Text = std.VarRegistrationID;
        drpsession.SelectedValue = std.VarSessionName;
        drpshift.SelectedValue = std.VarShiftCode;
        DropDownList1.SelectedValue = std.BloodGroup;
        //For Student Doc

        StudentDoc stdoc = db.StudentDocs.Where(s => s.VarStudentID.ToString() == txtid.Text).FirstOrDefault();

        imgstudent.ImageUrl = "MyPhoto.ashx?id=" + txtid.Text;
        Image2.ImageUrl = "Image2.ashx?id=" + txtid.Text;
        Image3.ImageUrl = "Image3.ashx?id=" + txtid.Text;


        Literal1.Text = "Your all data are successfully showed";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Student std = db.Students.Where(u => u.VarStudentID == txtid.Text).FirstOrDefault();

        std.VarStudentID = txtid.Text;
        std.VarStudentFirstName = txtfname.Text;
        std.VarStudentMeddleName = txtmname.Text;
        std.VarStudentLastName = txtlname.Text;

        if (malerbutton.Checked)
        {
            std.VarStudentGender = malerbutton.Text;
        }
        else if (femalerbutton.Checked)
        {
            std.VarStudentGender = femalerbutton.Text;
        }

        else
        {
            std.VarStudentGender = "";
        }
        std.VarStudentBirth = Convert.ToDateTime(txtdob.Text);
        std.VarStudentNationality = txtnational.Text;
        std.VarStudenAddress = txtpresent.Text;
        std.VarStudenHomePhone = txtphone.Text;
        std.VarStudenHomeCell = txtmobile.Text;
        std.VarReligion = txtrel.Text;
        std.VarFatherName = txtfather.Text;
        std.VarFatherOccupation = txtfocc.Text;
        std.VarFatherOfficeAddress = txtfoff.Text;
        //  std.VarFatherOfficePhone = "";
        std.VarFatherMobile = txtfmob.Text;
        std.VarFatherEmail = txtfemail.Text;
        std.VarMotherName = txtmname.Text;
        std.VarMotherOccupation = txtmotheroc.Text;
        std.VarMotherOfficeAddress = txtmadd.Text;
        //  std.VarMotherOfficePhone = "";
        std.VarMotherMobile = txtmothermob.Text;
        std.VarMotherEmail = txtmemail.Text;

        //if (sradio1.Checked)
        //{
        //    std.VarSiblingYesNo = sradio1.Text;
        //}
        //else if (sradio2.Checked)
        //{
        //    std.VarSiblingYesNo = sradio2.Text;
        //}

        //else
        //{
        //    std.VarSiblingYesNo = "";

        //}

        if (sradio1.Checked)
        {
            std.VarSiblingYesNo = sradio1.Text;
        }
        else if (sradio2.Checked)
        {
            std.VarSiblingYesNo = sradio2.Text;
            std.VarSiblingName = "";
            std.VarSiblingShift = "";
            std.VarSiblingClass = "";
            std.VarSiblingSection = "";
            std.VarSiblingRoll = "";
        }

        else
        {
            std.VarStudentGender = "";
        }

        std.VarSiblingName = txtsibilingsname.Text;
        std.VarSiblingShift = txtsshift.Text;
        std.VarSiblingClass = txtsclass.Text;
        std.VarSiblingSection = txtssec.Text;
        std.VarSiblingRoll = txtsroll.Text;
        std.VarPreviousSchoolAttended = txtprivscl.Text;
        std.VarPrivateYes = chkprivate.Checked.ToString();
        std.VarPrincipalRemarks = txtpremarks.Text;
        std.RecommendAdmissionClass = drpclass.SelectedValue;
        std.RecommendDate = Convert.ToDateTime(txtrdate.Text);
        //std.VarBranchID = txtbranch.Text;
        std.VarRegistrationID = txtregid.Text;
        std.VarSessionName = drpsession.SelectedValue;
        std.VarShiftCode = drpshift.SelectedValue;
        std.BloodGroup = DropDownList1.SelectedValue;


        StudentDoc stdDoc = db.StudentDocs.Where(u => u.VarStudentID == txtid.Text).FirstOrDefault();
        stdDoc.VarStudentID = txtid.Text;
        stdDoc.VarRegistrationID = txtregid.Text;

        if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
        {
            string fileName = FileUpload1.FileName;

            byte[] fileByte = FileUpload1.FileBytes;
            var binaryObj = new Binary(fileByte);

            stdDoc.ImgStudentPircture = binaryObj;
        }


        if (FileUpload2.HasFile && FileUpload2.PostedFile.ContentLength > 0)
        {
            string fileName = FileUpload2.FileName;

            byte[] fileByte = FileUpload2.FileBytes;
            var binaryObj = new Binary(fileByte);

            stdDoc.ImgBirthcertificate = binaryObj;
        }

        if (FileUpload3.HasFile && FileUpload3.PostedFile.ContentLength > 0)
        {
            string fileName = FileUpload3.FileName;

            byte[] fileByte = FileUpload3.FileBytes;
            var binaryObj = new Binary(fileByte);

            stdDoc.ImgAdmissionForm = binaryObj;
        }


        db.SubmitChanges();

        Literal2.Text = " Data Updated Successfully..........";
    }
}