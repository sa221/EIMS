using System;
using System.Data.Linq;
using System.Linq;
using System.Web.UI;

public partial class Employee_Imployee_Information_Modify : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != null)
        {
            //if (Session["uid"] != null)
            //    Textuid.Text = Session["uid"].ToString();

            //if (Session["VarBranchId"] != null)
            //    DropDownBranch.SelectedValue = Session["VarBranchId"].ToString();
            //if (Session["VarShiftCode"] != null)
            //    drpshift.SelectedValue = Session["VarShiftCode"].ToString();


            //if (Session["VarEmployeeid"] != null)
            //    txtEmpId.Text = Session["VarEmployeeid"].ToString();


            //Employee emp = db.Employees.Where(u => u.VarEmployeeid == txtEmpId.Text).FirstOrDefault();
            //txtEmpName.Text = emp.VarEmployeeName;

            //txtPresentAdd.Text = emp.VarPresentAddress;


            //txtPermanentAdd.Text = emp.VarPermanentAddress;
            //txtEmpCity.Text = emp.VarEmployeeCity;

            //if (emp.VarEmployeeSex == "Male")
            //{
            //    radioMale.Checked = true;
            //}
            //else if (emp.VarEmployeeSex == "Female")
            //{
            //    radioFemale.Checked = true;
            //}

            //else
            //{
            //    emp.VarEmployeeSex = "";
            //}


            //dropDownBlood.SelectedValue = emp.VarBlood;

            //txtDoB.Text = emp.DatBirtDate.ToString();

            //txtfather.Text = emp.VarFatherName;
            //txtfocc.Text = emp.VarFatheOccupation;
            //txtfoff.Text = emp.VarFOrgAddress;
            //txtfmob.Text = emp.VarFContactNo;
            //txtmother.Text = emp.VarMotherName;

            //txtmotheroc.Text = emp.VarMotherOccupation;
            //txtmadd.Text = emp.VarMOrgAddress;
            //txtmothermob.Text = emp.VarMContactNo;

            //if (emp.VarMaritalstatus == "Yes")
            //{
            //    sradio1.Checked = true;
            //}
            //else if (emp.VarMaritalstatus == "No")
            //{
            //    sradio2.Checked = true;
            //}


            //txtReligion.Text = emp.VarReligion;
            //txtEmpMob.Text = emp.VarEmployeePhoneNo;
            //txtEmpEmail.Text = emp.VarEmployeeEmail;
            //txtEmpDepartment.Text = emp.NumDepartmentid.ToString();
            //dropDownDesignation.SelectedValue = emp.NumDesignationid.ToString();
            //dropDownSalaryscale.SelectedValue = emp.NumScaleID.ToString();
            ////DropDownBranch.SelectedValue = emp.VarBranchId.ToString();
            ////drpshift.SelectedValue = emp.VarShiftCode.ToString();

            //txtJoinDate.Text = emp.DatJoiningdate.ToString();
            //txtLeaveDate.Text = emp.DatLeavedDate.ToString();
            //txtLeavedFor.Text = emp.VarLeavedFor;
            //txtEmpStatus.Text = emp.VarStatus;
            //imgEmployee.ImageUrl = "Employee Image.ashx?id=" + txtEmpId.Text;


            //txtSpoName.Text = emp.VarSpouseName;
            //txtSpoAdd.Text = emp.VarAddress;
            //txtSpoOcu.Text = emp.VarSpouseOccupation;
            //txtSpoPhn.Text = emp.VarPhoneno;

            //txtNID.Text = emp.VarNID;
            //txtBankName.Text = emp.VarBankName;
            //txtAcc.Text = emp.VarBankAcc;
            //txtExCuNote.Text = emp.VarExtraCurriculumNote;
            //txtHobby.Text = emp.VarInterestedHobby;
            //txtBadNote.Text = emp.VarAnyBadNote;
            //  DropDownBranch.SelectedValue = emp.VarBranchId;
            Literal1.Text = "Data Showed Successfully";
            Session["VarEmployeeid"] = null;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Employee emp = db.Employees.Where(u => u.VarEmployeeid == txtEmpId.Text).FirstOrDefault();
        //txtEmpName.Text = emp.VarEmployeeName;
        //txtPresentAdd.Text = emp.VarPresentAddress;


        //txtPermanentAdd.Text = emp.VarPermanentAddress;
        //txtEmpCity.Text = emp.VarEmployeeCity;

        //if (emp.VarEmployeeSex == "Male")
        //{
        //    radioMale.Checked = true;
        //}
        //else if (emp.VarEmployeeSex == "Female")
        //{
        //    radioFemale.Checked = true;
        //}

        //else
        //{
        //    emp.VarEmployeeSex = "";
        //}


        //dropDownBlood.SelectedValue = emp.VarBlood;

        //txtDoB.Text = emp.DatBirtDate.ToString();

        //txtfather.Text = emp.VarFatherName;
        //txtfocc.Text = emp.VarFatheOccupation;
        //txtfoff.Text = emp.VarFOrgAddress;
        //txtfmob.Text = emp.VarFContactNo;
        //txtmother.Text = emp.VarMotherName;

        //txtmotheroc.Text = emp.VarMotherOccupation;
        //txtmadd.Text = emp.VarMOrgAddress;
        //txtmothermob.Text = emp.VarMContactNo;

        //if (emp.VarMaritalstatus == "Yes")
        //{
        //    sradio1.Checked = true;
        //}
        //else if (emp.VarMaritalstatus == "No")
        //{
        //    sradio2.Checked = true;
        //}


        //txtReligion.Text = emp.VarReligion;
        //txtEmpMob.Text = emp.VarEmployeePhoneNo;
        //txtEmpEmail.Text = emp.VarEmployeeEmail;
        //txtEmpDepartment.Text = emp.NumDepartmentid.ToString();
        //dropDownDesignation.SelectedValue = emp.NumDesignationid.ToString();
        //dropDownSalaryscale.SelectedValue = emp.NumScaleID.ToString();

        //txtJoinDate.Text = emp.DatJoiningdate.ToString();
        //txtLeaveDate.Text = emp.DatLeavedDate.ToString();
        //txtLeavedFor.Text = emp.VarLeavedFor;
        //txtEmpStatus.Text = emp.VarStatus;
        //imgEmployee.ImageUrl = "Employee Image.ashx?id=" + txtEmpId.Text;


        //txtSpoName.Text = emp.VarSpouseName;
        //txtSpoAdd.Text = emp.VarAddress;
        //txtSpoOcu.Text = emp.VarSpouseOccupation;
        //txtSpoPhn.Text = emp.VarPhoneno;

        //txtNID.Text = emp.VarNID;
        //txtBankName.Text = emp.VarBankName;
        //txtAcc.Text = emp.VarBankAcc;
        //txtExCuNote.Text = emp.VarExtraCurriculumNote;
        //txtHobby.Text = emp.VarInterestedHobby;
        //txtBadNote.Text = emp.VarAnyBadNote;

        //Literal1.Text = "Data Showed Successfully";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Session["VarEmployeeid"] = null;

        //Employee emp = db.Employees.Where(d => d.VarEmployeeid == txtEmpId.Text).FirstOrDefault();

        //emp.VarEmployeeid = txtEmpId.Text;
        //emp.VarEmployeeName = txtEmpName.Text;
        //emp.VarPresentAddress = txtPresentAdd.Text;
        //emp.VarPermanentAddress = txtPermanentAdd.Text;
        //emp.VarEmployeeCity = txtEmpCity.Text;

        //if (radioMale.Checked)
        //{
        //    emp.VarEmployeeSex = radioMale.Text;
        //}
        //else if (radioFemale.Checked)
        //{
        //    emp.VarEmployeeSex = radioFemale.Text;
        //}

        //else
        //{
        //    emp.VarEmployeeSex = "";
        //}

        //emp.VarBlood = dropDownBlood.SelectedValue;
        //emp.DatBirtDate = Convert.ToDateTime(txtDoB.Text);
        //emp.VarFatherName = txtfather.Text;
        //emp.VarFatheOccupation = txtfocc.Text;
        //emp.VarFOrgAddress = txtfoff.Text;
        //emp.VarFContactNo = txtfmob.Text;
        //emp.VarMotherName = txtmother.Text;
        //emp.VarMotherOccupation = txtmotheroc.Text;
        //emp.VarMOrgAddress = txtmadd.Text;
        //emp.VarMContactNo = txtmothermob.Text;
        //if (sradio1.Checked)
        //{
        //    emp.VarMaritalstatus = sradio1.Text;
        //    emp.VarSpouseName = txtSpoName.Text;
        //    emp.VarAddress = txtSpoAdd.Text;
        //    emp.VarSpouseOccupation = txtSpoOcu.Text;
        //    emp.VarPhoneno = txtSpoPhn.Text;
        //}
        //else if (sradio2.Checked)
        //{
        //    emp.VarMaritalstatus = sradio2.Text;
        //    txtSpoName.ReadOnly = true;
        //    txtSpoAdd.ReadOnly = true;
        //    txtSpoOcu.ReadOnly = true;
        //    txtSpoPhn.ReadOnly = true;
        //    emp.VarSpouseName = "";
        //    emp.VarAddress = "";
        //    emp.VarSpouseOccupation = "";
        //    emp.VarPhoneno = "";
        //}

        //else
        //{
        //    emp.VarMaritalstatus = "";
        //    emp.VarSpouseName = "";
        //    emp.VarAddress = "";
        //    emp.VarSpouseOccupation = "";
        //    emp.VarPhoneno = "";
        //}

        //emp.VarReligion = txtReligion.Text;
        //emp.VarEmployeePhoneNo = txtEmpMob.Text;
        //emp.VarEmployeeEmail = txtEmpEmail.Text;
        //emp.NumDepartmentid = Convert.ToInt32(txtEmpDepartment.Text);
        //emp.NumDesignationid = Convert.ToInt32(dropDownDesignation.SelectedValue);
        //emp.NumScaleID = Convert.ToInt32(dropDownSalaryscale.Text);
        //emp.DatJoiningdate = Convert.ToDateTime(txtJoinDate.Text);
        //emp.DatLeavedDate = Convert.ToDateTime(txtLeaveDate.Text);
        //emp.VarLeavedFor = txtLeavedFor.Text;
        //emp.VarStatus = txtEmpStatus.Text;

        //if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
        //{
        //    string fileName = FileUpload1.FileName;

        //    byte[] fileByte = FileUpload1.FileBytes;
        //    var binaryObj = new Binary(fileByte);

        //    emp.VarPicture = binaryObj;
        //}
        //emp.VarNID = txtNID.Text;
        //emp.VarBankName = txtBankName.Text;
        //emp.VarBankAcc = txtAcc.Text;
        //emp.VarExtraCurriculumNote = txtExCuNote.Text;
        //emp.VarInterestedHobby = txtHobby.Text;
        //emp.VarAnyBadNote = txtBadNote.Text;
        ////emp.VarBranchId = DropDownBranch.SelectedValue;
        ////emp.VarShiftCode = drpshift.SelectedValue;
        ////emp.uid = Textuid.Text;


        //db.SubmitChanges();

        //Literal2.Text = "Data Updated Successfully..........";


        ////txtEmpId.Text = "";
        ////txtEmpName.Text = "";
        ////txtPresentAdd.Text = "";
        ////txtPermanentAdd.Text = "";
        ////txtEmpCity.Text = "";

        ////radioMale.Checked = false;
        ////radioFemale.Checked = false;


        ////txtDoB.Text = "";
        ////txtfather.Text = "";
        ////txtfocc.Text = "";
        ////txtfoff.Text = "";
        ////txtfmob.Text = "";
        ////txtmother.Text = "";
        ////txtmotheroc.Text = "";
        ////txtmadd.Text = "";
        ////txtmothermob.Text = "";


        ////sradio1.Checked = false;
        ////sradio2.Checked = false;
        ////txtSpoName.Text = "";
        ////txtSpoAdd.Text = "";
        ////txtSpoOcu.Text = "";
        ////txtSpoPhn.Text = "";


        ////txtReligion.Text = "";
        ////txtEmpMob.Text = "";
        ////txtEmpEmail.Text = "";
        ////txtEmpDepartment.Text = "";


        ////txtJoinDate.Text = "";
        ////txtLeaveDate.Text = "";
        ////txtLeavedFor.Text = "";
        ////txtEmpStatus.Text = "";


        ////txtNID.Text = "";
        ////txtBankName.Text = "";
        ////txtAcc.Text = "";
        ////txtExCuNote.Text = "";
        ////txtHobby.Text = "";
        ////txtBadNote.Text = "";
    }
}