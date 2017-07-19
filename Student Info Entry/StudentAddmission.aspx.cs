using System;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentAddmission : Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    private string studentId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        studentId = Request.QueryString["VarStudentID"];

        if (!IsPostBack)
        {
            subAssignButton.Visible = false;
            ModalPopupExtender2.Enabled = false;
            ModalPopupExtender2.Hide();
            raModalPopupExtender.Enabled = false;
            raModalPopupExtender.Hide();
            LoadPreviousSchoolDdl();
            LoadResidentialAreaDdl();
            if (studentId != null)
            {
                BindTextBoxvalues();

            }

            if (Session["VarBranchId"] != null)
            {
                int branchId = Convert.ToInt32(Session["VarBranchId"]);
                Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
                if (branchInitial != null) branchTextBox.Text = branchInitial.VarBranchName;
                //drpBranch.SelectedItem.Text = branchInitial.VarBranchName;
            }
        }
        txtmdmu.ReadOnly = true;
        txtid.ReadOnly = true;
    }
    private void BindTextBoxvalues()
    {
        if (studentId != null)
        {
            Student std = db.Students.FirstOrDefault(c => c.VarStudentID == studentId);
            txtregid.Text = std.VarRegistrationID;
            txtmdmu.Text = std.VarStudentID.Substring(0, 2);
            txtid.Text = std.VarStudentID.Substring(2, 7);
            txtfname.Text = std.VarStudentFirstName;
            //txtmname.Text = std.VarStudentMeddleName;
            txtlname.Text = std.VarStudentLastName;
            int branchId = std.VarBranchID;
            Branch branchName = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
            if (branchName != null) branchTextBox.Text = branchName.VarBranchName;
            if (!String.IsNullOrWhiteSpace(std.VarShiftCode))
            {
                drpshift.SelectedValue = std.VarShiftCode;
            }

            drpsession.SelectedValue = std.VarSessionName;


            txtpresent.Text = std.VarStudenAddress;
            if (std.VarStudentBirth != null)
            {
                txtdob.Text = Convert.ToDateTime(std.VarStudentBirth.ToString())
                    .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }

            previousAttendedDropDownList.SelectedValue = std.VarPreviousSchoolAttended;
            rAreaDropDownList.SelectedValue = std.VarStudentArea;
            if (std.VarStudentGender == "Male")
            {
                malerbutton.Checked = true;
            }
            else if (std.VarStudentGender == "Female")
            {
                femalerbutton.Checked = true;
            }
            txtnational.Text = std.VarStudentNationality;
            religionDropDownList.SelectedValue = std.VarReligion;
            //txtrel.Text = std.VarReligion;
            txtphone.Text = std.VarStudenHomePhone;
            txtmobile.Text = std.VarStudenHomeCell;
            if (!String.IsNullOrWhiteSpace(std.BloodGroup))
            {
                DropDownList1.SelectedValue = std.BloodGroup;
            }

            //Retrive image
            imgstudent.ImageUrl = "~/Student Info Search and update/MyPhoto.ashx?id=" + studentId + "&&image=0";
            Image2.ImageUrl = "~/Student Info Search and update/MyPhoto.ashx?id=" + studentId + "&&image=1";
            Image3.ImageUrl = "~/Student Info Search and update/MyPhoto.ashx?id=" + studentId + "&&image=2";
            txtfather.Text = std.VarFatherName;
            txtfocc.Text = std.VarFatherOccupation;
            txtfoff.Text = std.VarFatherOfficeAddress;
            txtfmob.Text = std.VarFatherMobile;
            txtfemail.Text = std.VarFatherEmail;
            txtmother.Text = std.VarMotherName;
            txtmotheroc.Text = std.VarMotherOccupation;
            txtmadd.Text = std.VarMotherOfficeAddress;
            txtmothermob.Text = std.VarMotherMobile;
            txtmemail.Text = std.VarMotherEmail;
            txtsibilingsname.Text = std.VarSiblingName;
            txtsshift.Text = std.VarSiblingShift;
            txtsclass.Text = std.VarSiblingClass;
            txtssec.Text = std.VarSiblingSection;
            txtsroll.Text = std.VarSiblingRoll;
            statusDropDownList.SelectedValue = std.Status;
            remarksTextBox.Text = std.Remarks;
            leaveDateTextBox.Text = std.SDate.ToString();
            if (!String.IsNullOrWhiteSpace(std.RecommendAdmissionClass))
            {
                drpclass.SelectedValue = std.RecommendAdmissionClass;
            }

            if (!String.IsNullOrWhiteSpace(std.PClassID))
            {
                presentClassDropDownList.SelectedValue = std.PClassID;
            }
            sectionDropDownList.Items.Clear();
            LoadSection(std.PClassID);
            if (!String.IsNullOrWhiteSpace(std.CampusId))
            {
                campusDropDownList.SelectedValue = std.CampusId;
            }

            if (!String.IsNullOrWhiteSpace(std.RecommendAdmissionSection) && std.RecommendAdmissionSection != "0")
            {
                sectionDropDownList.SelectedValue = std.RecommendAdmissionSection;
            }
            txtpremarks.Text = std.VarPrincipalRemarks;
            //txtrdate.Text = std.RecommendDate.ToString();
            if (std.RecommendDate != null)
            {
                txtrdate.Text = Convert.ToDateTime(std.RecommendDate.ToString())
                    .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            rollTextBox.Text = std.StudentRoll.ToString();
            btnSave.Text = "Update";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string studentId = GenarateStudentId();
        //Student std = new Student();
        searchButtonLiteral.Text = "";
        if (studentId != null)
        {
            IQueryable<string> existId = from c in db.Students
                                         where c.VarStudentID == studentId
                                         select c.VarStudentID;

            if (existId.FirstOrDefault() == null)
            {
                InsertStudent(studentId);
            }
            else
            {
                UpdateStudent(studentId);
            }
        }
        else
        {
            failStatusLabel.InnerText = "Provided Student ID not Correct.....!";
        }
    }
    private void UpdateStudent(string studentId)
    {
        Student check =
            (from d in db.Students
             where d.VarStudentID == studentId
             select d).SingleOrDefault();

        //Student std = new Student();
        if (check != null)
        {
            ClassChange(studentId);
            check.VarStudentFirstName = txtfname.Text.ToUpper();
            //check.VarStudentMeddleName = txtmname.Text;
            check.VarStudentLastName = txtlname.Text.ToUpper();

            if (malerbutton.Checked)
            {
                check.VarStudentGender = malerbutton.Text;
            }
            else if (femalerbutton.Checked)
            {
                check.VarStudentGender = femalerbutton.Text;
            }

            else
            {
                check.VarStudentGender = "";
            }
            //check.VarStudentBirth = Convert.ToDateTime(txtdob.Text);
            if (!String.IsNullOrWhiteSpace(txtdob.Text))
            {
                DateTime date = DateTime.ParseExact(txtdob.Text, "dd-MM-yyyy", null);
                check.VarStudentBirth = Convert.ToDateTime(date);
            }

            check.VarStudentNationality = txtnational.Text.ToUpper();
            check.VarStudenAddress = txtpresent.Text.ToUpper();
            check.VarStudenHomePhone = txtphone.Text;
            check.VarStudenHomeCell = txtmobile.Text;
            //check.VarReligion = txtrel.Text;
            check.VarReligion = religionDropDownList.SelectedValue;
            check.VarFatherName = txtfather.Text.ToUpper();
            check.VarFatherOccupation = txtfocc.Text.ToUpper();
            check.VarFatherOfficeAddress = txtfoff.Text.ToUpper();
            //  std.VarFatherOfficePhone = "";
            check.VarFatherMobile = txtfmob.Text;
            check.VarFatherEmail = txtfemail.Text;
            check.VarMotherName = txtmother.Text.ToUpper();
            check.VarMotherOccupation = txtmotheroc.Text.ToUpper();
            check.VarMotherOfficeAddress = txtmadd.Text.ToUpper();
            //  std.VarMotherOfficePhone = "";
            check.VarMotherMobile = txtmothermob.Text;
            check.VarMotherEmail = txtmemail.Text;
            check.VarRegistrationID = txtregid.Text;


            //check.VarSiblingYesNo = RadioButtonList1.SelectedValue;
            //if (RadioButtonList1.SelectedValue == "No")
            //{
            //    check.VarSiblingName = "";
            //    check.VarSiblingShift = "";
            //    check.VarSiblingClass = "";
            //    check.VarSiblingSection = "";
            //    check.VarSiblingRoll = "";
            //}
            if (sradio1.Checked)
            {
                check.VarSiblingYesNo = sradio1.Text;
                check.VarSiblingName = txtsibilingsname.Text.ToUpper();
                check.VarSiblingShift = siblingsIdTextBox.Text;
                check.VarSiblingClass = txtsclass.Text;
                check.VarSiblingSection = txtssec.Text;
                check.VarSiblingRoll = txtsroll.Text;
            }
            else
            {
                check.VarSiblingYesNo = sradio2.Text;
                check.VarSiblingName = "";
                check.VarSiblingShift = "";
                check.VarSiblingClass = "";
                check.VarSiblingSection = "";
                check.VarSiblingRoll = "";
            }
            check.VarSiblingName = txtsibilingsname.Text.ToUpper();
            check.VarSiblingShift = txtsshift.Text;
            check.VarSiblingClass = txtsclass.Text;
            check.VarSiblingSection = txtssec.Text;
            check.VarSiblingRoll = txtsroll.Text;
            if (previousAttendedDropDownList.SelectedValue != "" && previousAttendedDropDownList.SelectedValue != "0")
            {
                check.VarPreviousSchoolAttended = previousAttendedDropDownList.SelectedValue;
            }
            if (rAreaDropDownList.SelectedValue != "" && rAreaDropDownList.SelectedValue != "ADD NEW")
            {
                check.VarStudentArea = rAreaDropDownList.SelectedValue;
            }

            check.VarPrincipalRemarks = txtpremarks.Text.ToUpper();
            check.CampusId = campusDropDownList.SelectedValue;
            check.RecommendAdmissionClass = drpclass.SelectedValue;
            check.RecommendAddmissionClassName = drpclass.SelectedItem.Text.ToUpper();
            check.RecommendAdmissionSection = sectionDropDownList.SelectedValue;
            check.PClassID = presentClassDropDownList.SelectedValue;
            //check.RecommendDate = Convert.ToDateTime(txtrdate.Text);
            if (!String.IsNullOrWhiteSpace(txtrdate.Text))
            {
                DateTime date = DateTime.ParseExact(txtrdate.Text, "dd-MM-yyyy", null);
                check.RecommendDate = date;
            }
            check.VarBranchID = Convert.ToInt32(Session["VarBranchId"]);
            check.uid = Session["uid"].ToString();
            check.InputTime = DateTime.Now;
            check.VarRegistrationID = txtregid.Text;
            check.VarSessionName = drpsession.SelectedValue;
            check.VarShiftCode = drpshift.SelectedValue;
            check.BloodGroup = DropDownList1.SelectedValue;


            if (statusDropDownList.SelectedItem.Value != "P")
            {
                if (remarksTextBox.Text == "")
                {
                    statusLiteral.Text = "<p style=color:Red>Please Write Remarks";
                    return;
                }
                if (leaveDateTextBox.Text == "")
                {
                    statusLiteral.Text = "<p style=color:red>Please Insert Leave Date";
                    return;
                }
                check.Status = statusDropDownList.SelectedValue;
                check.Remarks = remarksTextBox.Text.ToUpper();
                
                if (!String.IsNullOrWhiteSpace(leaveDateTextBox.Text))
                {
                    DateTime date = DateTime.ParseExact(leaveDateTextBox.Text, "dd-MM-yyyy", null);
                    check.SDate = date;
                }
            }
            else
            {
                check.Status = statusDropDownList.SelectedValue;
                check.SDate = null;
                check.Remarks = remarksTextBox.Text.ToUpper();
            }
            if (rollTextBox.Text != "")
            {
                check.StudentRoll = Convert.ToInt32(rollTextBox.Text);
            }
        }


        StudentDoc stdDoc =
            (from d in db.StudentDocs
             where d.VarStudentID == studentId
             select d).SingleOrDefault();

        if (stdDoc != null)
        {
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
        }
        else
        {
            var docs = new StudentDoc();
            docs.VarStudentID = studentId;
            docs.VarRegistrationID = txtregid.Text;

            if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
            {
                string fileName = FileUpload1.FileName;

                byte[] fileByte = FileUpload1.FileBytes;
                var binaryObj = new Binary(fileByte);

                docs.ImgStudentPircture = binaryObj;
            }


            if (FileUpload2.HasFile && FileUpload2.PostedFile.ContentLength > 0)
            {
                string fileName = FileUpload2.FileName;

                byte[] fileByte = FileUpload2.FileBytes;
                var binaryObj = new Binary(fileByte);

                docs.ImgBirthcertificate = binaryObj;
            }

            if (FileUpload3.HasFile && FileUpload3.PostedFile.ContentLength > 0)
            {
                string fileName = FileUpload3.FileName;

                byte[] fileByte = FileUpload3.FileBytes;
                var binaryObj = new Binary(fileByte);

                docs.ImgAdmissionForm = binaryObj;
            }
            db.StudentDocs.InsertOnSubmit(docs);
        }

        tbl_Present_class pcl =
            (from d in db.tbl_Present_classes
             where d.VarStudentID == studentId
             select d).SingleOrDefault();

        if (pcl != null)
        {
            pcl.VarSessionId = drpsession.Text;
            pcl.VarShiftCode = drpshift.Text;
            pcl.VarClassID = presentClassDropDownList.Text;
            pcl.VarSection = sectionDropDownList.SelectedValue;

            if (rollTextBox.Text != "")
            {
                pcl.StudentRoll = Convert.ToInt32(rollTextBox.Text);
            }
            pcl.CampusId = campusDropDownList.SelectedValue;
            pcl.Status = statusDropDownList.SelectedValue;
        }
        else
        {
            var presentClass = new tbl_Present_class();
            presentClass.VarStudentID = studentId;
            presentClass.VarSessionId = drpsession.Text;
            presentClass.VarShiftCode = drpshift.Text;
            presentClass.VarClassID = presentClassDropDownList.Text;
            presentClass.VarSection = sectionDropDownList.SelectedValue;
            if (rollTextBox.Text != "")
            {
                presentClass.StudentRoll = Convert.ToInt32(rollTextBox.Text);
            }

            presentClass.CampusId = campusDropDownList.SelectedValue;
            presentClass.Status = statusDropDownList.SelectedValue;
            db.tbl_Present_classes.InsertOnSubmit(presentClass);
        }

        db.SubmitChanges();
        successStatusLabel.InnerText = "Student Information Updated Successfully..........!";
        tbl_Present_class getClassId = db.tbl_Present_classes.FirstOrDefault(x => x.VarStudentID == studentId);
        Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == getClassId.VarClassID);
        if (cls != null)
        {
            if (cls.ClassType == 1 || cls.ClassType == 2)
            {
                subAssignButton.Visible = true;
                stdIdTextBox.Text = studentId;
            } 
        }
       

        txtid.Text = "";
        txtfname.Text = "";
        //txtmname.Text = "";
        txtlname.Text = "";

        malerbutton.Checked = false;
        femalerbutton.Checked = false;

        txtdob.Text = "";
        txtnational.Text = "";
        txtpresent.Text = "";
        txtphone.Text = "";
        txtmobile.Text = "";
        religionDropDownList.SelectedValue = "0";
        txtfather.Text = "";
        txtfocc.Text = "";
        txtfoff.Text = "";
        //  std.VarFatherOfficePhone = "";
        txtfmob.Text = "";
        txtfemail.Text = "";
        //txtmname.Text = "";
        txtmotheroc.Text = "";
        txtmadd.Text = "";
        //  std.VarMotherOfficePhone = "";
        txtmothermob.Text = "";
        txtmemail.Text = "";
        statusLiteral.Text = "";
        //RadioButtonList1.SelectedIndex = -1;


        txtsibilingsname.Text = "";
        txtsshift.Text = "";
        txtsclass.Text = "";
        txtssec.Text = "";
        txtsroll.Text = "";
        presentClassDropDownList.SelectedValue = "0";

        txtpremarks.Text = "";

        txtrdate.Text = "";
        idCheckBox.Checked = false;
        txtregid.Text = "";
        remarksTextBox.Text = "";
        txtmdmu.Text = "";
        rollTextBox.Text = "";
        campusDropDownList.SelectedValue = "0";
        presentClassDropDownList.SelectedValue = "0";
        txtmother.Text = "";
        siblingsIdTextBox.Text = "";
        sradio1.Checked = false;
        sradio2.Checked = false;
        drpclass.SelectedValue = "0";
        //sectionDropDownList.SelectedValue = "1";
        leaveDateTextBox.Text = "";
        //statusDropDownList.SelectedValue = "1";
        DropDownList1.SelectedValue = "0";
        btnSave.Text = "Save";
    }
    private void InsertStudent(string studentId)
    {
        var std = new Student();
        if (studentId != null)
        {
            if (Session["VarBranchId"] != null)
            {
                int branchId = Convert.ToInt32(Session["VarBranchId"]);
                Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
                if (branchInitial != null) std.VarBranchID = branchInitial.VarBranchID;
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            std.VarStudentID = studentId;
            std.VarStudentFirstName = txtfname.Text.ToUpper();
            //std.VarStudentMeddleName = txtmname.Text;
            std.VarStudentLastName = txtlname.Text.ToUpper();

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
            //if (!String.IsNullOrWhiteSpace(txtdob.Text))
            //{
            //    DateTime date = DateTime.ParseExact(txtdob.Text, "M/d/yyyy", null);
            //    std.VarStudentBirth = date;
            //}
            if (!String.IsNullOrWhiteSpace(txtdob.Text))
            {
                DateTime date = DateTime.ParseExact(txtdob.Text, "dd-MM-yyyy", null);
                std.VarStudentBirth = date;
            }
            std.VarStudentNationality = txtnational.Text.ToUpper();
            std.VarStudenAddress = txtpresent.Text.ToUpper();
            std.VarStudenHomePhone = txtphone.Text;
            std.VarStudenHomeCell = txtmobile.Text;
            //std.VarReligion = txtrel.Text;
            std.VarReligion = religionDropDownList.SelectedValue;
            std.VarFatherName = txtfather.Text.ToUpper();
            std.VarFatherOccupation = txtfocc.Text.ToUpper();
            std.VarFatherOfficeAddress = txtfoff.Text.ToUpper();
            //  std.VarFatherOfficePhone = "";
            std.VarFatherMobile = txtfmob.Text;
            std.VarFatherEmail = txtfemail.Text;
            std.VarMotherName = txtmother.Text.ToUpper();
            std.VarMotherOccupation = txtmotheroc.Text.ToUpper();
            std.VarMotherOfficeAddress = txtmadd.Text.ToUpper();
            //  std.VarMotherOfficePhone = "";
            std.VarMotherMobile = txtmothermob.Text;
            std.VarMotherEmail = txtmemail.Text;


            //std.VarSiblingYesNo = RadioButtonList1.SelectedValue;
            //if (RadioButtonList1.SelectedValue == "No")
            //{
            //    std.VarSiblingName = "";
            //    std.VarSiblingShift = "";
            //    std.VarSiblingClass = "";
            //    std.VarSiblingSection = "";
            //    std.VarSiblingRoll = "";
            //}
            if (sradio1.Checked)
            {
                std.VarSiblingYesNo = sradio1.Text;
                std.VarSiblingName = txtsibilingsname.Text.ToUpper();
                std.VarSiblingShift = siblingsIdTextBox.Text;
                std.VarSiblingClass = txtsclass.Text;
                std.VarSiblingSection = txtssec.Text;
                std.VarSiblingRoll = txtsroll.Text;
            }
            else
            {
                std.VarSiblingYesNo = sradio2.Text;
                std.VarSiblingName = "";
                std.VarSiblingShift = "";
                std.VarSiblingClass = "";
                std.VarSiblingSection = "";
                std.VarSiblingRoll = "";
            }
            
            if (previousAttendedDropDownList.SelectedValue != "" && previousAttendedDropDownList.SelectedValue != "0")
            {
                std.VarPreviousSchoolAttended = previousAttendedDropDownList.SelectedValue;
            }
            if (rAreaDropDownList.SelectedValue != "" && rAreaDropDownList.SelectedValue != "ADD NEW")
            {
                std.VarStudentArea = rAreaDropDownList.SelectedValue;
            }

            std.VarPrincipalRemarks = txtpremarks.Text.ToUpper();
            std.CampusId = campusDropDownList.SelectedValue;
            std.RecommendAdmissionClass = drpclass.SelectedValue;
            std.RecommendAdmissionSection = sectionDropDownList.SelectedValue;
            if (!String.IsNullOrWhiteSpace(txtrdate.Text))
            {
                DateTime date = DateTime.ParseExact(txtrdate.Text, "dd-MM-yyyy", null);
                std.RecommendDate = date;
            }
            //std.RecommendDate = Convert.ToDateTime(txtrdate.Text);
            //std.VarBranchID = Convert.ToInt32(Session["VarBranchId"]);
            std.VarRegistrationID = txtregid.Text;
            std.VarSessionName = drpsession.SelectedValue;
            std.VarAdmissionSession = drpsession.SelectedValue;
            std.VarShiftCode = drpshift.SelectedValue;
            std.BloodGroup = DropDownList1.SelectedValue;


            if (statusDropDownList.SelectedItem.Value != "P")
            {
                if (remarksTextBox.Text == "")
                {
                    statusLiteral.Text = "<p style=color:Red>Please Write Remarks";
                    return;
                }
                if (leaveDateTextBox.Text == "")
                {
                    statusLiteral.Text = "<p style=color:red>Please Insert Leave Date";
                    return;
                }
                std.Status = statusDropDownList.SelectedValue;
                std.Remarks = remarksTextBox.Text.ToUpper();
                std.SDate = Convert.ToDateTime(leaveDateTextBox.Text);
            }
            else
            {
                std.Status = statusDropDownList.SelectedValue;
                std.Remarks = remarksTextBox.Text.ToUpper();
                //std.SDate = Convert.ToDateTime(leaveDateTextBox.Text);
            }
            std.uid = Session["uid"].ToString();
            std.InputTime = DateTime.Now;
            std.PClassID = presentClassDropDownList.SelectedItem.Value;
            if (rollTextBox.Text != "")
            {
                std.StudentRoll = Convert.ToInt32(rollTextBox.Text);
            }


            var stdDoc = new StudentDoc();

            stdDoc.VarStudentID = studentId;

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

            var pcl = new tbl_Present_class();

            pcl.VarStudentID = studentId;


            pcl.Status = statusDropDownList.SelectedValue;
            pcl.VarSessionId = drpsession.Text;
            pcl.VarShiftCode = drpshift.Text;
            pcl.VarClassID = presentClassDropDownList.SelectedValue;
            pcl.VarSection = sectionDropDownList.SelectedValue;
            if (rollTextBox.Text != "")
            {
                pcl.StudentRoll = Convert.ToInt32(rollTextBox.Text);
            }

            pcl.CampusId = campusDropDownList.SelectedValue;
            ///////////////////////////////////////////////////////
            //AdmissionFees and Tution fees assign for new admitted student

            IQueryable<tbl_feesInfo> feesInfo = from f in db.tbl_feesInfos
                                                where f.VarClassId == drpclass.SelectedValue &&
                                                      (f.FeesId == 1 ||
                                                       f.FeesId == 2 ||
                                                       f.FeesId == 4)
                                                select f;
            foreach (tbl_feesInfo fees in feesInfo)
            {
                var stdAccount = new tbl_Students_Account();
                tbl_Students_Account stdAccountChk = (from a in db.tbl_Students_Accounts
                                                      where
                                                          a.VarStudentId == studentId && a.VarSessionId == drpsession.SelectedValue &&
                                                          a.PaidFeesId == fees.FeesId
                                                      select a).SingleOrDefault();
                if (stdAccountChk == null)
                {
                    if (fees.FeesType == 2)
                    {
                        decimal amount = fees.Fees * 12;
                        decimal vat = (fees.Fees * 12 * (decimal).075);
                        stdAccount.VarSessionId = drpsession.SelectedValue;
                        stdAccount.VarStudentId = studentId;
                        stdAccount.PayableFeesId = fees.FeesId;
                        stdAccount.PayableAmount = amount;
                        stdAccount.PayableVat = vat;
                        stdAccount.NetPayable = amount + vat;
                        stdAccount.FeesAssignDate = DateTime.Now;
                        stdAccount.uid = Session["uid"].ToString();
                        //db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
                    }
                    else
                    {
                        decimal amount = fees.Fees;
                        decimal vat = (fees.Fees * (decimal).075);
                        stdAccount.VarSessionId = drpsession.SelectedValue;
                        stdAccount.VarStudentId = studentId;
                        stdAccount.PayableFeesId = fees.FeesId;
                        stdAccount.PayableAmount = amount;
                        stdAccount.PayableVat = vat;
                        stdAccount.NetPayable = amount + vat;
                        stdAccount.FeesAssignDate = DateTime.Now;
                        stdAccount.uid = Session["uid"].ToString();
                    }
                }
                db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
                //db.SubmitChanges();
            }

            ParticipantStudent ps = db.ParticipantStudents.FirstOrDefault(x => x.varRegistrationId == txtregid.Text);
            if (ps != null && ps.varRegistrationId != "")
            {
                ps.Status = "4"; //Status 4 means this student admitted
            }
            db.tbl_Present_classes.InsertOnSubmit(pcl);

            db.StudentDocs.InsertOnSubmit(stdDoc);


            db.Students.InsertOnSubmit(std);

            db.SubmitChanges();

            successStatusLabel.InnerText = "Student Admission Successfull with ID: " + studentId;
            tbl_Present_class getClassId = db.tbl_Present_classes.FirstOrDefault(x => x.VarStudentID == studentId);
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == getClassId.VarClassID);
            if (cls != null)
            {
                if (cls.ClassType == 1 || cls.ClassType == 2)
                {
                    subAssignButton.Visible = true;
                    stdIdTextBox.Text = studentId;
                }
            }
          
           
            txtregid.Text = "";
            txtid.Text = "";
            txtmdmu.Text = "";
            TextBoxClear();
        }
        else
        {
            failStatusLabel.InnerText = "Provided Student ID Invalid...!!";
        }
    }
    private void TextBoxClear()
    {
        txtfname.Text = "";
        //txtmname.Text = "";
        txtlname.Text = "";
        malerbutton.Checked = false;
        femalerbutton.Checked = false;
        txtdob.Text = "";
        txtnational.Text = "";
        txtpresent.Text = "";
        txtphone.Text = "";
        txtmobile.Text = "";
        religionDropDownList.SelectedValue = "0";
        txtfather.Text = "";
        txtfocc.Text = "";
        txtfoff.Text = "";
        txtfmob.Text = "";
        txtfemail.Text = "";
        txtmother.Text = "";
        txtmotheroc.Text = "";
        txtmadd.Text = "";
        txtmothermob.Text = "";
        txtmemail.Text = "";
        //RadioButtonList1.SelectedIndex = -1;
        txtsibilingsname.Text = "";
        txtsshift.Text = "";
        txtsclass.Text = "";
        txtssec.Text = "";
        txtsroll.Text = "";
        previousAttendedDropDownList.SelectedValue = "";
        rAreaDropDownList.SelectedValue = "";
        txtpremarks.Text = "";
        txtrdate.Text = "";
        campusDropDownList.SelectedValue = "0";
        presentClassDropDownList.SelectedValue = "0";
        drpclass.SelectedValue = "0";
        rollTextBox.Text = "";
        remarksTextBox.Text = "";
        leaveDateTextBox.Text = "";
        DropDownList1.SelectedValue = "0";
        statusLiteral.Text = "";
        siblingsIdTextBox.Text = "";
        sradio1.Checked = false;
        sradio2.Checked = false;
    }
    private string GenarateStudentId()
    {
        if (idCheckBox.Checked)
        {
            if (txtmdmu.Text.Length == 2 && txtid.Text.Length == 7)
            {
                return (txtmdmu.Text + "" + txtid.Text);
            }
            return null;
        }
        if (txtmdmu.Text == "" && txtid.Text == "")
        {
            int branchId = Convert.ToInt32(Session["VarBranchId"]);
            Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
            if (branchInitial != null)
            {
                string branchIni = branchInitial.VarBranchInitial;
                //txtmdmu.Text = branchInitial.VarBranchInitial;
                int seedNums = 1;
                char pads = '0';
                string studentId = null;
                var stds = from u in db.Students
                           where u.VarStudentID.Substring(0, 2) == branchIni
                           select new { u.VarStudentID };
                string result = stds.Max(element => element.VarStudentID);
                if (result != null)
                {
                    string subs = result.Substring(2);
                    seedNums = Convert.ToInt32(subs);
                    seedNums = seedNums + 1;
                    return (branchIni + "" + seedNums.ToString().PadLeft(7, pads));
                }
                return (branchIni + "" + seedNums.ToString().PadLeft(7, pads));
            }
        }
        return (txtmdmu.Text + "" + txtid.Text);
    }
    private void ClassChange(string studentId)
    {
        Student getStudentInfo = db.Students.FirstOrDefault(x => x.VarStudentID == studentId);
        if (getStudentInfo != null && getStudentInfo.PClassID != presentClassDropDownList.SelectedValue)
        {
            IQueryable<tbl_Students_Account> getAllFees = from a in db.tbl_Students_Accounts
                                                          where a.VarStudentId == studentId && a.VarSessionId == drpsession.SelectedValue
                                                          select a;

            foreach (tbl_Students_Account allFee in getAllFees)
            {
                db.tbl_Students_Accounts.DeleteOnSubmit(allFee);
                //db.SubmitChanges();
            }

            IQueryable<tbl_feesInfo> feesInfo = from f in db.tbl_feesInfos
                                                where f.VarClassId == drpclass.SelectedValue &&
                                                      (f.FeesId == 1 ||
                                                       f.FeesId == 2 ||
                                                       f.FeesId == 4)
                                                select f;
            foreach (tbl_feesInfo fees in feesInfo)
            {
                var stdAccount = new tbl_Students_Account();
                tbl_Students_Account stdAccountChk = (from a in db.tbl_Students_Accounts
                                                      where
                                                          a.VarStudentId == studentId && a.VarSessionId == drpsession.SelectedValue &&
                                                          a.PaidFeesId == fees.FeesId
                                                      select a).SingleOrDefault();
                if (getStudentInfo.VarAdmissionSession == drpsession.SelectedValue)
                {
                    if (stdAccountChk == null)
                    {
                        if (fees.FeesType == 2)
                        {
                            decimal amount = fees.Fees * 12;
                            decimal vat = (fees.Fees * 12 * (decimal).075);
                            stdAccount.VarSessionId = drpsession.SelectedValue;
                            stdAccount.VarStudentId = studentId;
                            stdAccount.PayableFeesId = fees.FeesId;
                            stdAccount.PayableAmount = amount;
                            stdAccount.PayableVat = vat;
                            stdAccount.NetPayable = amount + vat;
                            stdAccount.FeesAssignDate = DateTime.Now;
                            stdAccount.uid = Session["uid"].ToString();
                            //db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
                        }
                        else
                        {
                            Student std = db.Students.FirstOrDefault(x => x.VarStudentID == studentId);
                            if (std != null && std.VarAdmissionSession == drpsession.SelectedValue)
                            {
                                decimal amount = fees.Fees;
                                decimal vat = (fees.Fees * (decimal).075);
                                stdAccount.VarSessionId = drpsession.SelectedValue;
                                stdAccount.VarStudentId = studentId;
                                stdAccount.PayableFeesId = fees.FeesId;
                                stdAccount.PayableAmount = amount;
                                stdAccount.PayableVat = vat;
                                stdAccount.NetPayable = amount + vat;
                                stdAccount.FeesAssignDate = DateTime.Now;
                                stdAccount.uid = Session["uid"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    if (stdAccountChk == null)
                    {
                        if (fees.FeesType == 2)
                        {
                            decimal amount = fees.Fees * 12;
                            decimal vat = (fees.Fees * 12 * (decimal).075);
                            stdAccount.VarSessionId = drpsession.SelectedValue;
                            stdAccount.VarStudentId = studentId;
                            stdAccount.PayableFeesId = fees.FeesId;
                            stdAccount.PayableAmount = amount;
                            stdAccount.PayableVat = vat;
                            stdAccount.NetPayable = amount + vat;
                            stdAccount.FeesAssignDate = DateTime.Now;
                            stdAccount.uid = Session["uid"].ToString();
                            //db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
                        }
                    }
                }

                db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
                //db.SubmitChanges();
            }
            tbl_TransferHistory traHistory = db.tbl_TransferHistories.FirstOrDefault(x => x.VarStudentId == studentId);
            if (traHistory != null)
            {
                traHistory.TraClass = presentClassDropDownList.SelectedValue;
            }

            IQueryable<tbl_WaiverHistory> getAllWaiver = from w in db.tbl_WaiverHistories
                                                         where w.VarStudentId == studentId && w.VarSessiuon == drpsession.SelectedValue
                                                         select w;
            foreach (tbl_WaiverHistory allWaiver in getAllWaiver)
            {
                db.tbl_WaiverHistories.DeleteOnSubmit(allWaiver);
                //db.SubmitChanges();
            }
            Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == getStudentInfo.PClassID);
            if (cls != null && cls.ClassType == 1)
            {
                IQueryable<tbl_StudentSubjectAssign> getAllSubject = from c in db.tbl_StudentSubjectAssigns
                                                                     where c.VarSessionId == drpsession.SelectedValue && c.VarStudentId == studentId
                                                                     select c;
                foreach (tbl_StudentSubjectAssign removeSubject in getAllSubject)
                {
                    db.tbl_StudentSubjectAssigns.DeleteOnSubmit(removeSubject);
                    //db.SubmitChanges();
                }
            }
            else if (cls != null && cls.ClassType == 2)
            {
                IQueryable<tbl_EdexcelSubjectAssign> getAllSubject = from c in db.tbl_EdexcelSubjectAssigns
                                                                     where c.Session == drpsession.SelectedValue && c.StudentId == studentId
                                                                     select c;
                foreach (tbl_EdexcelSubjectAssign removeSubject in getAllSubject)
                {
                    db.tbl_EdexcelSubjectAssigns.DeleteOnSubmit(removeSubject);
                    //db.SubmitChanges();
                }
            }
            db.SubmitChanges();
        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {

        TextBoxClear();
        subAssignButton.Visible = false;
        //sectionDropDownList.Items.Clear();
        //sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        searchButtonLiteral.Text = "";
        string stdId = txtmdmu.Text + "" + txtid.Text;
        if (txtregid.Text != "" && stdId == "")
        {
            if (!String.IsNullOrWhiteSpace(txtregid.Text))
            {
                Student std = db.Students.FirstOrDefault(s => s.VarRegistrationID == txtregid.Text && s.VarAdmissionSession == drpsession.SelectedValue);
                if (std == null)
                {
                    IQueryable<string> checkExistingStudentId = from c in db.ParticipantStudents
                                                                where c.varRegistrationId == txtregid.Text.Trim() && c.Status == "3"
                                                                select c.varRegistrationId;
                    searchButtonLiteral.Text = "";

                    if (checkExistingStudentId.FirstOrDefault() != null)
                    {
                        ParticipantStudent ps =
                            db.ParticipantStudents.FirstOrDefault(u => u.varRegistrationId == txtregid.Text && u.VarSession == drpsession.SelectedValue && u.VarBranchId == Convert.ToInt32(Session["VarBranchId"]));
                        if (ps != null)
                        {
                            txtregid.Text = ps.varRegistrationId;

                            txtlname.Text = ps.varStudentLastName;
                            //txtmname.Text = ps.varStudentMiddleName;
                            txtfname.Text = ps.varStudentFirstName;
                            txtdob.Text = Convert.ToDateTime(ps.dob.ToString())
                                .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                            txtfather.Text = ps.varFatherName;
                            //txtfocc.Text = ps.fatherOccupation;
                            txtfmob.Text = ps.fatherPhone;
                            txtmother.Text = ps.varMotherName;
                            txtmotheroc.Text = ps.motherOccupation;
                            txtmothermob.Text = ps.motherPhone;
                            txtpresent.Text = ps.PresentAddress;
                            txtmobile.Text = ps.EmergencyPhone;
                            txtfemail.Text = ps.Email;
                            drpclass.SelectedValue = ps.admissionForClass;
                            presentClassDropDownList.SelectedValue = ps.admissionForClass;
                            sectionDropDownList.Items.Clear();
                            LoadSection(ps.admissionForClass);
                            txtsibilingsname.Text = ps.VarSiblingName;
                            txtsclass.Text = ps.VarSiblingClass;
                            txtssec.Text = ps.VarSiblingSection;
                            txtsroll.Text = ps.VarSiblingRoll;
                            previousAttendedDropDownList.SelectedValue = ps.priviousSchoolName;
                            if (ps.VarStudentGender == "Male")
                            {
                                malerbutton.Checked = true;
                            }
                            else if (ps.VarStudentGender == "Female")
                            {
                                femalerbutton.Checked = true;
                            }
                            DateTime dateTime = DateTime.Now;
                            DateTime date = dateTime.Date;
                            txtrdate.Text = date.ToString("dd-MM-yyyy");
                            if (ps.StudentPhoto != null)
                            {
                                imgstudent.ImageUrl = "st_participant.ashx?id=" + txtregid.Text;
                            }


                            searchButtonLiteral.Text = "<p style=color:green>All data  successfully retrived.";
                        }
                        else
                        {
                            searchButtonLiteral.Text = "<p style=color:red>Form ID Not Found";
                        }
                    }
                    else
                    {
                        searchButtonLiteral.Text = "<p style=color:red>Form ID Not Found";
                    }
                }
                else
                {
                    searchButtonLiteral.Text = "<p style=color:red>Student Already Admitted";
                }
            }
            else
            {
                searchButtonLiteral.Text = "<p style=color:red>Please Insert Form ID";
            }
        }
        else if (txtregid.Text == "" && stdId != "")
        {
            if (!String.IsNullOrWhiteSpace(txtmdmu.Text) && !String.IsNullOrWhiteSpace(txtid.Text))
            {
                studentId = txtmdmu.Text + "" + txtid.Text;
                if (studentId != null)
                {
                    Student std = db.Students.FirstOrDefault(c => c.VarStudentID == studentId);
                    if (std != null)
                    {
                        //txtregid.Text = std.VarRegistrationID;
                        //txtmdmu.Text = std.VarStudentID.Substring(0, 2);
                        //txtid.Text = std.VarStudentID.Substring(2, 7);
                        txtfname.Text = std.VarStudentFirstName;
                        //txtmname.Text = std.VarStudentMeddleName;
                        txtlname.Text = std.VarStudentLastName;
                        int branchId = std.VarBranchID;
                        Branch branchName = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
                        if (branchName != null) branchTextBox.Text = branchName.VarBranchName;
                        if (!String.IsNullOrWhiteSpace(std.VarShiftCode))
                        {
                            drpshift.SelectedValue = std.VarShiftCode;
                        }

                        drpsession.SelectedValue = std.VarSessionName;

                        txtpresent.Text = std.VarStudenAddress;
                        if (std.VarStudentBirth != null)
                        {
                            txtdob.Text = Convert.ToDateTime(std.VarStudentBirth.ToString())
                                .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                        }

                        previousAttendedDropDownList.SelectedValue = std.VarPreviousSchoolAttended;
                        rAreaDropDownList.SelectedValue = std.VarStudentArea;
                        if (std.VarStudentGender == "Male")
                        {
                            malerbutton.Checked = true;
                        }
                        else if (std.VarStudentGender == "Female")
                        {
                            femalerbutton.Checked = true;
                        }
                        txtnational.Text = std.VarStudentNationality;
                        //txtrel.Text = std.VarReligion;
                        religionDropDownList.SelectedValue = std.VarReligion;
                        txtphone.Text = std.VarStudenHomePhone;
                        txtmobile.Text = std.VarStudenHomeCell;
                        if (!String.IsNullOrWhiteSpace(std.BloodGroup))
                        {
                            DropDownList1.SelectedValue = std.BloodGroup;
                        }

                        //Retrive image
                        imgstudent.ImageUrl = "~/Student Info Search and update/MyPhoto.ashx?id=" + studentId +
                                              "&&image=0";
                        Image2.ImageUrl = "~/Student Info Search and update/MyPhoto.ashx?id=" + studentId + "&&image=1";
                        Image3.ImageUrl = "~/Student Info Search and update/MyPhoto.ashx?id=" + studentId + "&&image=2";

                        txtfather.Text = std.VarFatherName;
                        txtfocc.Text = std.VarFatherOccupation;
                        txtfoff.Text = std.VarFatherOfficeAddress;
                        txtfmob.Text = std.VarFatherMobile;
                        txtfemail.Text = std.VarFatherEmail;
                        txtmother.Text = std.VarMotherName;
                        txtmotheroc.Text = std.VarMotherOccupation;
                        txtmadd.Text = std.VarMotherOfficeAddress;
                        txtmothermob.Text = std.VarMotherMobile;
                        txtmemail.Text = std.VarMotherEmail;

                        txtsibilingsname.Text = std.VarSiblingName;
                        txtsshift.Text = std.VarSiblingShift;
                        txtsclass.Text = std.VarSiblingClass;
                        txtssec.Text = std.VarSiblingSection;
                        txtsroll.Text = std.VarSiblingRoll;
                        siblingsIdTextBox.Text = std.VarSiblingShift;
                        if (std.VarSiblingYesNo == "Yes")
                        {
                            sradio1.Checked=true;
                        }
                        else
                        {
                            sradio2.Checked = true;
                        }
                        //Present Status
                        //string presentStatus = std.Status;
                        //tbl_StudentPresentStatus presentState = db.tbl_StudentPresentStatus.FirstOrDefault(c => c.StatusInitial == presentStatus);
                        statusDropDownList.SelectedValue = std.Status;
                        remarksTextBox.Text = std.Remarks;
                        leaveDateTextBox.Text = std.SDate.ToString();
                        if (!String.IsNullOrWhiteSpace(std.RecommendAdmissionClass))
                        {
                            drpclass.SelectedValue = std.RecommendAdmissionClass;
                        }

                        if (!String.IsNullOrWhiteSpace(std.PClassID))
                        {
                            presentClassDropDownList.SelectedValue = std.PClassID;
                        }
                        sectionDropDownList.Items.Clear();
                        LoadSection();
                        if (!String.IsNullOrWhiteSpace(std.CampusId))
                        {
                            campusDropDownList.SelectedValue = std.CampusId;
                        }

                        if (!String.IsNullOrWhiteSpace(std.RecommendAdmissionSection) &&
                            std.RecommendAdmissionSection != "0")
                        {
                            sectionDropDownList.SelectedValue = std.RecommendAdmissionSection;
                        }
                        txtpremarks.Text = std.VarPrincipalRemarks;
                        //txtrdate.Text = std.RecommendDate.ToString();
                        if (std.RecommendDate != null)
                        {
                            txtrdate.Text = Convert.ToDateTime(std.RecommendDate.ToString())
                                .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                        }
                        rollTextBox.Text = std.StudentRoll.ToString();
                        btnSave.Text = "Update";
                    }
                    else
                    {
                        //failStatusLabel.InnerText = "Student Not Found..!";
                        string message = string.Format("Message:Student Not Found..!");
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert(\"" + message + "\");", true);
                    }
                    
                }
            }
        }
        else if (txtregid.Text == "" && stdId == "")
        {
            searchButtonLiteral.Text = "<p style=color:red>Please Insert Form ID or Student ID..!";
        }
        else
        {
            searchButtonLiteral.Text = "<p style=color:red>Please Insert Only Form ID or Student ID..!";
        }
    }
    protected void idCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (idCheckBox.Checked)
        {
            txtmdmu.ReadOnly = false;
            txtid.ReadOnly = false;
            txtregid.Text = "";
            int branchId = Convert.ToInt32(Session["VarBranchId"]);
            Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
            //string branchIni = branchInitial.VarBranchInitial;
            if (branchInitial != null) txtmdmu.Text = branchInitial.VarBranchInitial;
        }
        else
        {
            txtmdmu.Text = "";
            txtid.Text = "";
            txtmdmu.ReadOnly = true;
            txtid.ReadOnly = true;
        }
    }
    protected void presentClassDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        //sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
        LoadSection();
        sectionDropDownList.Focus();
        //sectionDropDownList.Items.Insert(0, new ListItem(string.Empty, string.Empty));
    }
    private void LoadPreviousSchoolDdl()
    {
        var getPreSChool = from x in db.tbl_PreviousSchools
                           orderby x.SchoolName ascending
                           select new { x.Id, x.SchoolName };
        previousAttendedDropDownList.DataSource = getPreSChool;
        previousAttendedDropDownList.DataValueField = "SchoolName";
        previousAttendedDropDownList.DataTextField = "SchoolName";
        previousAttendedDropDownList.DataBind();
        previousAttendedDropDownList.Items.Insert(0, new ListItem("Select", ""));
        //previousAttendedDropDownList.Items.Insert(0, new ListItem("Add New", "0"));
    }
    protected void previousAttendedDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        if (previousAttendedDropDownList.SelectedItem.Text == "ADD NEW")
        {
            ModalPopupExtender2.Enabled = true;
            ModalPopupExtender2.Show();//popup show
        }
        else
        {
            ModalPopupExtender2.Enabled = false;
            ModalPopupExtender2.Hide();
        }
        presentClassDropDownList.Focus();
    }
    protected void btnClose_OnClick_(object sender, EventArgs e)
    {
        ModalPopupExtender2.Enabled = false;
    }
    private void LoadSection()
    {
        var getSection = from x in db.tblSections
                         where x.ClassID == presentClassDropDownList.SelectedValue
                         select new { x.SectionId, x.varSectionName };

        sectionDropDownList.DataSource = getSection;
        sectionDropDownList.DataValueField = "SectionId";
        sectionDropDownList.DataTextField = "varSectionName";
        sectionDropDownList.DataBind();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    private void LoadSection(string pClassId)
    {
        var getSection = from x in db.tblSections
                         where x.ClassID == pClassId
                         select new { x.SectionId, x.varSectionName };

        sectionDropDownList.DataSource = getSection;
        sectionDropDownList.DataValueField = "SectionId";
        sectionDropDownList.DataTextField = "varSectionName";
        sectionDropDownList.DataBind();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void saveButton_OnClick_OnClick_(object sender, EventArgs e)
    {
        var check = db.tbl_PreviousSchools.FirstOrDefault(x => x.SchoolName == TextBox1.Text.Trim());
        if (check == null)
        {
            tbl_PreviousSchool previousSchool = new tbl_PreviousSchool();

            previousSchool.SchoolName = TextBox1.Text.Trim();
            db.tbl_PreviousSchools.InsertOnSubmit(previousSchool);
            db.SubmitChanges();
            TextBox1.Text = String.Empty;
            LoadPreviousSchoolDdl();
        }
    }
    protected void subAssignButton_Click(object sender, EventArgs e)
    {
        string stdId = stdIdTextBox.Text;
        tbl_Present_class getClassId = db.tbl_Present_classes.FirstOrDefault(x => x.VarStudentID == stdId);
        Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == getClassId.VarClassID);
        if (cls != null && cls.ClassType == 1)
        {
            if (getClassId != null)
                Response.Redirect("~/SubjectUI/StudentSubjectsAssign.aspx?VarStudentID=" + stdId + "&VarSessionId=" + getClassId.VarSessionId );
        }
        else if (cls != null && cls.ClassType == 2)
        {
            if (getClassId != null)
                Response.Redirect("~/SubjectUI/EdexcelSubjectAssignUpdate.aspx?VarStudentID=" + stdId + "&VarSessionId=" + getClassId.VarSessionId);
        }

    }
    private void LoadResidentialAreaDdl()
    {
        var getResindialArea = from x in db.tbl_StudentAreas
                           orderby x.AreaName ascending
                           select new { x.Id, x.AreaName };
        rAreaDropDownList.DataSource = getResindialArea;
        rAreaDropDownList.DataValueField = "AreaName";
        rAreaDropDownList.DataTextField = "AreaName";
        rAreaDropDownList.DataBind();
        rAreaDropDownList.Items.Insert(0, new ListItem("Select", ""));
        //previousAttendedDropDownList.Items.Insert(0, new ListItem("Add New", "0"));
    }
    protected void areaCloseButton_OnClick(object sender, EventArgs e)
    {
        raModalPopupExtender.Enabled = false;
        raModalPopupExtender.Hide();
    }
    protected void areaSaveButton_OnClick(object sender, EventArgs e)
    {
        var checkArea = db.tbl_StudentAreas.FirstOrDefault(x => x.AreaName == areaNameTextBox.Text.Trim());
        if (checkArea == null)
        {
            tbl_StudentArea studentArea=new tbl_StudentArea();

            studentArea.AreaName = areaNameTextBox.Text.Trim();
            db.tbl_StudentAreas.InsertOnSubmit(studentArea);
            db.SubmitChanges();
            areaNameTextBox.Text = String.Empty;
            LoadResidentialAreaDdl();
        }
    }
    protected void rAreaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        raModalPopupExtender.Enabled = false;
        raModalPopupExtender.Hide();
        areaNameTextBox.Text = "";
        if (rAreaDropDownList.SelectedItem.Text == "ADD NEW")
        {
            raModalPopupExtender.Enabled = true;
            raModalPopupExtender.Show();//popup show
        }
        else
        {
            raModalPopupExtender.Enabled = false;
            raModalPopupExtender.Hide();
        }
    }
    protected void siblingsIdButton_Click(object sender, EventArgs e)
    {
        var getSiblings = db.Students.FirstOrDefault(x => x.VarStudentID == siblingsIdTextBox.Text);
        if (getSiblings!=null)
        {
            txtsibilingsname.Text = getSiblings.VarStudentFirstName + " " + getSiblings.VarStudentLastName;
            txtsshift.Text = getSiblings.VarStudenHomeCell;
            txtsroll.Text = getSiblings.StudentRoll.ToString();
            var getClass = db.Classes.FirstOrDefault(x => x.VarClassID == getSiblings.PClassID);
            if (getClass!=null)
            {
                txtsclass.Text = getClass.VarClassName;
            }
            var getSection = db.tblSections.FirstOrDefault(x => x.SectionId == getSiblings.RecommendAdmissionSection);
            if (getSection!=null)
            {
                txtssec.Text = getSection.varSectionName;
            }
        }
    }
}