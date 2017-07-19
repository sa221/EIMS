using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class Employee_EmployeeInformation : System.Web.UI.Page
{
    static SWISDataContext db = new SWISDataContext();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridVIEWData();
            DegreeGridViewData();
            emergencyContactGridView.DataSource = dt;
            emergencyContactGridView.DataBind();
            degreeModalPopupExtender.Enabled = false;
            degreeModalPopupExtender.Hide();
            LoadDegreeDdl();
        }
        //if (IsPostBack != null)
        //{



        //    if (Session["uid"] != null)
        //        Textuid.Text = Session["uid"].ToString();

        //    if (Session["VarBranchId"] != null)
        //        DropDownBranch.SelectedValue = Session["VarBranchId"].ToString();
        //    if (Session["VarShiftCode"] != null)
        //        drpshift.SelectedValue = Session["VarShiftCode"].ToString();

        //}
        if (!Page.IsPostBack)
        {
            
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        searchLiteral.Text = "";
        string empId = GenarateEmployeeId();
        var checkExistingempId = from c in db.Employees
                                 where c.VarEmployeeid.Contains(empId)
                                 select c.VarEmployeeid;

        if (checkExistingempId.FirstOrDefault() == null)
        {

            SaveEmployee(empId);
        }
        else
        {
            UpdateEmployee(empId);

        }
    }

    private void UpdateEmployee(string empId)
    {
        var checkEmployee = db.Employees.FirstOrDefault(x => x.VarEmployeeid == empId);
        if (checkEmployee != null)
        {
            checkEmployee.EmployeeCategory = ctgDropDownList.SelectedValue;
            checkEmployee.EmployeeDesignation = Convert.ToInt32(designationDropDownList.SelectedValue);
            checkEmployee.VarCurrentStatus =currentStatusDropDownList.SelectedValue;
            checkEmployee.VarEmployeeName = txtEmpName.Text;
            if (!String.IsNullOrWhiteSpace(txtDoB.Text))
            {
                DateTime date = DateTime.ParseExact(txtDoB.Text, "dd-MM-yyyy", null);
                checkEmployee.DOB = date;
            }
            checkEmployee.VarBlood = Convert.ToInt32(dropDownBlood.SelectedValue);
            checkEmployee.VarReligion = religionDropDownList.SelectedValue;
            checkEmployee.VarEmployeePhoneNo = txtEmpMob.Text;
            checkEmployee.VarNationality = nationalityTextBox.Text;
            checkEmployee.VarNID = nidTextBox.Text;
            if (radioMale.Checked)
            {
                checkEmployee.VarEmployeeSex = radioMale.Text;
            }
            else if (radioFemale.Checked)
            {
                checkEmployee.VarEmployeeSex = radioFemale.Text;
            }
            else
            {
                checkEmployee.VarEmployeeSex = "";
            }
            checkEmployee.VarPresentAddress = txtPresentAdd.Text;
            checkEmployee.VarPermanentAddress = txtPermanentAdd.Text;
            checkEmployee.VarDrivLicPassport = driPassNoTextBox.Text;
            checkEmployee.VarCampusId = campusDropDownList.SelectedValue;
            if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
            {
                string fileName = FileUpload1.FileName;

                byte[] fileByte = FileUpload1.FileBytes;
                Binary binaryObj = new Binary(fileByte);

                checkEmployee.VarPicture = binaryObj;
            }
            checkEmployee.JoinSubject = joinSubTextBox.Text;
            if (!String.IsNullOrWhiteSpace(txtJoinDate.Text))
            {
                DateTime date = DateTime.ParseExact(txtJoinDate.Text, "dd-MM-yyyy", null);
                checkEmployee.JoinDate = date;
            }
            if (!String.IsNullOrWhiteSpace(txtLeaveDate.Text))
            {
                DateTime date = DateTime.ParseExact(txtLeaveDate.Text, "dd-MM-yyyy", null);
                checkEmployee.DatLeavedDate = date;
            }
            checkEmployee.VarLeavedFor = txtLeavedFor.Text;
            checkEmployee.VarFatherName = txtfather.Text;
            checkEmployee.VarFContactNo = txtfmob.Text;
            checkEmployee.VarMotherName = txtmother.Text;
            checkEmployee.VarMContactNo = txtmothermob.Text;
            if (sradio1.Checked)
            {
                txtSpoName.Visible = true;
                txtSpoOcu.Visible = true;
                txtSpoPhn.Visible = true;
                checkEmployee.VarMaritalstatus = sradio1.Text;
                checkEmployee.VarSpouseName = txtSpoName.Text;
                checkEmployee.VarSpouseOccupation = txtSpoOcu.Text;
                checkEmployee.VarSpouseContact = txtSpoPhn.Text;
            }
            else if (sradio2.Checked)
            {
                checkEmployee.VarMaritalstatus = sradio2.Text;
                txtSpoName.Visible = false;
                txtSpoOcu.Visible = false;
                txtSpoPhn.Visible = false;
            }
            else
            {
                checkEmployee.VarMaritalstatus = "";
            }
            checkEmployee.VarBranchId = Convert.ToInt32(Session["VarBranchId"].ToString());
            checkEmployee.VarShiftCode = Session["VarShiftCode"].ToString();
            checkEmployee.UpdateUid = Session["uid"].ToString();
            checkEmployee.UpdateDate = DateTime.Now.Date;
            //insert into EmployeeDoc
            var chkEmpDoc = db.EmployeeDocs.FirstOrDefault(x => x.EmployeeId == empId);
            if (chkEmpDoc != null)
            {
                if (degree1FileUpload.HasFile && degree1FileUpload.PostedFile.ContentLength > 0 || degree2FileUpload.HasFile && degree2FileUpload.PostedFile.ContentLength > 0 ||
                degree3FileUpload.HasFile && degree3FileUpload.PostedFile.ContentLength > 0 || degree4FileUpload.HasFile && degree4FileUpload.PostedFile.ContentLength > 0)
                {

                    if (degree1FileUpload.HasFile && degree1FileUpload.PostedFile.ContentLength > 0)
                    {
                        byte[] fileByte = degree1FileUpload.FileBytes;
                        Binary binaryObj = new Binary(fileByte);
                        chkEmpDoc.DegreeName1 = degree1TextBox.Text;
                        chkEmpDoc.File1 = binaryObj;
                    }
                    if (degree2FileUpload.HasFile && degree2FileUpload.PostedFile.ContentLength > 0)
                    {
                        byte[] fileByte = degree2FileUpload.FileBytes;
                        Binary binaryObj = new Binary(fileByte);
                        chkEmpDoc.DegreeName2 = degree2TextBox.Text;
                        chkEmpDoc.File2 = binaryObj;
                    }
                    if (degree3FileUpload.HasFile && degree3FileUpload.PostedFile.ContentLength > 0)
                    {
                        byte[] fileByte = degree3FileUpload.FileBytes;
                        Binary binaryObj = new Binary(fileByte);
                        chkEmpDoc.DegreeName3 = degree3TextBox.Text;
                        chkEmpDoc.File3 = binaryObj;
                    }
                    if (degree4FileUpload.HasFile && degree4FileUpload.PostedFile.ContentLength > 0)
                    {
                        byte[] fileByte = degree4FileUpload.FileBytes;
                        Binary binaryObj = new Binary(fileByte);
                        chkEmpDoc.DegreeName4 = degree4TextBox.Text;
                        chkEmpDoc.File4 = binaryObj;
                    }

                }
            }
            else
            {
                EmployeeDoc empDoc = new EmployeeDoc();
                if (degree1FileUpload.HasFile && degree1FileUpload.PostedFile.ContentLength > 0 || degree2FileUpload.HasFile && degree2FileUpload.PostedFile.ContentLength > 0 ||
                degree3FileUpload.HasFile && degree3FileUpload.PostedFile.ContentLength > 0 || degree4FileUpload.HasFile && degree4FileUpload.PostedFile.ContentLength > 0)
                {
                    empDoc.EmployeeId = empId;
                    if (degree1FileUpload.HasFile && degree1FileUpload.PostedFile.ContentLength > 0)
                    {
                        byte[] fileByte = degree1FileUpload.FileBytes;
                        Binary binaryObj = new Binary(fileByte);
                        empDoc.DegreeName1 = degree1TextBox.Text;
                        empDoc.File1 = binaryObj;
                    }
                    if (degree2FileUpload.HasFile && degree2FileUpload.PostedFile.ContentLength > 0)
                    {
                        byte[] fileByte = degree2FileUpload.FileBytes;
                        Binary binaryObj = new Binary(fileByte);
                        empDoc.DegreeName2 = degree2TextBox.Text;
                        empDoc.File2 = binaryObj;
                    }
                    if (degree3FileUpload.HasFile && degree3FileUpload.PostedFile.ContentLength > 0)
                    {
                        byte[] fileByte = degree3FileUpload.FileBytes;
                        Binary binaryObj = new Binary(fileByte);
                        empDoc.DegreeName3 = degree3TextBox.Text;
                        empDoc.File3 = binaryObj;
                    }
                    if (degree4FileUpload.HasFile && degree4FileUpload.PostedFile.ContentLength > 0)
                    {
                        byte[] fileByte = degree4FileUpload.FileBytes;
                        Binary binaryObj = new Binary(fileByte);
                        empDoc.DegreeName4 = degree4TextBox.Text;
                        empDoc.File4 = binaryObj;
                    }

                    db.EmployeeDocs.InsertOnSubmit(empDoc);

                }
            }


            //Update into EmployeeEmergencyContact Table
            var chkContactTbl = db.tbl_EmployeeEmergencyContacts.FirstOrDefault(x => x.EmployeeId == empId);
            if (chkContactTbl != null)
            {
                var deletePreContact = from c in db.tbl_EmployeeEmergencyContacts
                                       where c.EmployeeId == empId
                                       select c;
                foreach (var contact in deletePreContact)
                {
                    db.tbl_EmployeeEmergencyContacts.DeleteOnSubmit(contact);
                }

                foreach (GridViewRow gvrow in emergencyContactGridView.Rows)
                {
                    tbl_EmployeeEmergencyContact empEmgContact = new tbl_EmployeeEmergencyContact();

                    string cName = gvrow.Cells[1].Text;
                    string cRelation = gvrow.Cells[2].Text;
                    string cNumber = gvrow.Cells[3].Text;
                    empEmgContact.EmployeeId = empId;
                    empEmgContact.ContactPersonName = cName;
                    empEmgContact.ContactPersonRelation = cRelation;
                    empEmgContact.ContactNumber = cNumber;
                    db.tbl_EmployeeEmergencyContacts.InsertOnSubmit(empEmgContact);
                }
            }

            //Update into EmployeeEducation Table
            double maxYear = 0;
            string maxDegree = "";
            var chkEmpEduTbl = db.EmployeeEducations.FirstOrDefault(x => x.VarEmployeeid == empId);
            if (chkEmpEduTbl != null)
            {
                var deletePreEdu = from c in db.EmployeeEducations
                                       where c.VarEmployeeid== empId
                                       select c;
                foreach (var edu in deletePreEdu)
                {
                    db.EmployeeEducations.DeleteOnSubmit(edu);
                }
                
                foreach (GridViewRow gvrow in degreeGridView.Rows)
                {
                    EmployeeEducation empEducation = new EmployeeEducation();

                    string degreeName = gvrow.Cells[1].Text;
                    string institute = gvrow.Cells[2].Text;
                    string passYear = gvrow.Cells[3].Text;
                    string result = gvrow.Cells[4].Text;
                    empEducation.VarExamName = degreeName;
                    empEducation.VarInstituteName = institute;
                    empEducation.VarExamPass = passYear;
                    empEducation.VarExamResult = result;
                    empEducation.VarEmployeeid = empId;
                    empEducation.VarBranchId = Session["VarBranchId"].ToString();
                    empEducation.VarShiftCode = Session["VarShiftCode"].ToString();
                    empEducation.uid = Session["uid"].ToString();
                    empEducation.EntryDate = DateTime.Now.Date;
                    db.EmployeeEducations.InsertOnSubmit(empEducation);
                    if (maxYear < Convert.ToDouble(passYear))
                    {
                        maxYear = Convert.ToDouble(passYear);
                        maxDegree = degreeName;
                    }
                }
            }
            checkEmployee.VarQualification = maxDegree;
            db.SubmitChanges();

            successStatusLabel.InnerText = "Employee Info updated with ID: " + empId;
            degreeGridView.DataSource = null;
            degreeGridView.DataBind();
            emergencyContactGridView.DataSource = null;
            emergencyContactGridView.DataBind();
            txtEmpId.Text = "";
            txtEmpName.Text = "";
            txtPresentAdd.Text = "";
            txtPermanentAdd.Text = "";
            joinSubTextBox.Text = "";
            joiningSalaryTextBox.Value = "";
            currentSalaryTextBox.Text = "";
            addNoteTextBox.Text = "";
            expTextBox.Text = "";
            driPassNoTextBox.Text = "";
            nidTextBox.Text = "";
            radioMale.Checked = false;
            radioFemale.Checked = false;
            txtDoB.Text = "";
            txtfather.Text = "";
            txtfmob.Text = "";
            txtmother.Text = "";
            txtmothermob.Text = "";
            sradio1.Checked = false;
            sradio2.Checked = false;
            txtSpoName.Text = "";
            txtSpoOcu.Text = "";
            txtSpoPhn.Text = "";
            //txtReligion.Text = "";
            religionDropDownList.SelectedValue = "0";
            campusDropDownList.SelectedValue = "0";
            txtEmpMob.Text = "";
            txtJoinDate.Text = "";
            txtLeaveDate.Text = "";
            txtLeavedFor.Text = "";
            Session.Remove("dtInSession");
            Session.Remove("degreeDataInSession");
        }
    }

    private void SaveEmployee(string empId)
    {
        Employee emp = new Employee();
        EmployeeDoc empDoc = new EmployeeDoc();
       

        emp.VarEmployeeid = empId;
        emp.EmployeeCategory = ctgDropDownList.SelectedValue;
        emp.EmployeeDesignation = Convert.ToInt32(designationDropDownList.SelectedValue);
        emp.VarCurrentStatus = currentStatusDropDownList.SelectedValue;
        emp.VarEmployeeName = txtEmpName.Text;
        if (!String.IsNullOrWhiteSpace(txtDoB.Text))
        {
            DateTime date = DateTime.ParseExact(txtDoB.Text, "dd-MM-yyyy", null);
            emp.DOB = date;
        }
        emp.VarBlood = Convert.ToInt32(dropDownBlood.SelectedValue);
        emp.VarReligion = religionDropDownList.SelectedValue;
        emp.VarEmployeePhoneNo = txtEmpMob.Text;
        emp.VarNationality = nationalityTextBox.Text;
        emp.VarNID = nidTextBox.Text;
        if (radioMale.Checked)
        {
            emp.VarEmployeeSex = radioMale.Text;
        }
        else if (radioFemale.Checked)
        {
            emp.VarEmployeeSex = radioFemale.Text;
        }
        else
        {
            emp.VarEmployeeSex = "";
        }
        emp.VarPresentAddress = txtPresentAdd.Text;
        emp.VarPermanentAddress = txtPermanentAdd.Text;
        emp.VarDrivLicPassport = driPassNoTextBox.Text;
        emp.VarCampusId = campusDropDownList.SelectedValue;
        if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
        {
            string fileName = FileUpload1.FileName;

            byte[] fileByte = FileUpload1.FileBytes;
            Binary binaryObj = new Binary(fileByte);
            emp.VarPicture = binaryObj;
        }
        emp.JoinSubject = joinSubTextBox.Text;
        if (!String.IsNullOrWhiteSpace(txtJoinDate.Text))
        {
            DateTime date = DateTime.ParseExact(txtJoinDate.Text, "dd-MM-yyyy", null);
            emp.JoinDate = date;
        }
        if (!String.IsNullOrWhiteSpace(txtLeaveDate.Text))
        {
            DateTime date = DateTime.ParseExact(txtLeaveDate.Text, "dd-MM-yyyy", null);
            emp.DatLeavedDate = date;
        }
        if (joiningSalaryTextBox.Value!="")
        {
            emp.JoinSalary = Convert.ToDecimal(joiningSalaryTextBox.Value);
        }
        if (currentSalaryTextBox.Text!="")
        {
            emp.CurrentSalary = Convert.ToDecimal(currentSalaryTextBox.Text);
        }
        emp.AdditionalNote = addNoteTextBox.Text;
        emp.Experience = expTextBox.Text;
        emp.VarLeavedFor = txtLeavedFor.Text;
        emp.VarFatherName = txtfather.Text;
        emp.VarFContactNo = txtfmob.Text;
        emp.VarMotherName = txtmother.Text;
        emp.VarMContactNo = txtmothermob.Text;
        if (sradio1.Checked)
        {
            txtSpoName.Visible = true;
            txtSpoOcu.Visible = true;
            txtSpoPhn.Visible = true;
            emp.VarMaritalstatus = sradio1.Text;
            emp.VarSpouseName = txtSpoName.Text;
            emp.VarSpouseOccupation = txtSpoOcu.Text;
            emp.VarSpouseContact = txtSpoPhn.Text;
        }
        else if (sradio2.Checked)
        {
            emp.VarMaritalstatus = sradio2.Text;
            txtSpoName.Visible = false;
            txtSpoOcu.Visible = false;
            txtSpoPhn.Visible = false;
        }
        else
        {
            emp.VarMaritalstatus = "";
        }
        emp.VarBranchId = Convert.ToInt32(Session["VarBranchId"].ToString());
        emp.VarShiftCode = Session["VarShiftCode"].ToString();
        emp.InsertUid = Session["uid"].ToString();
        emp.InsertDate = DateTime.Now.Date;
        //insert into EmployeeDoc
        if (degree1FileUpload.HasFile && degree1FileUpload.PostedFile.ContentLength > 0 || degree2FileUpload.HasFile && degree2FileUpload.PostedFile.ContentLength > 0 ||
            degree3FileUpload.HasFile && degree3FileUpload.PostedFile.ContentLength > 0 || degree4FileUpload.HasFile && degree4FileUpload.PostedFile.ContentLength > 0)
        {
            empDoc.EmployeeId = empId;
            if (degree1FileUpload.HasFile && degree1FileUpload.PostedFile.ContentLength > 0)
            {
                byte[] fileByte = degree1FileUpload.FileBytes;
                Binary binaryObj = new Binary(fileByte);
                empDoc.DegreeName1 = degree1TextBox.Text;
                empDoc.File1 = binaryObj;
            }
            if (degree2FileUpload.HasFile && degree2FileUpload.PostedFile.ContentLength > 0)
            {
                byte[] fileByte = degree2FileUpload.FileBytes;
                Binary binaryObj = new Binary(fileByte);
                empDoc.DegreeName2 = degree2TextBox.Text;
                empDoc.File2 = binaryObj;
            }
            if (degree3FileUpload.HasFile && degree3FileUpload.PostedFile.ContentLength > 0)
            {
                byte[] fileByte = degree3FileUpload.FileBytes;
                Binary binaryObj = new Binary(fileByte);
                empDoc.DegreeName3 = degree3TextBox.Text;
                empDoc.File3 = binaryObj;
            }
            if (degree4FileUpload.HasFile && degree4FileUpload.PostedFile.ContentLength > 0)
            {
                byte[] fileByte = degree4FileUpload.FileBytes;
                Binary binaryObj = new Binary(fileByte);
                empDoc.DegreeName4 = degree4TextBox.Text;
                empDoc.File4 = binaryObj;
            }

            db.EmployeeDocs.InsertOnSubmit(empDoc);

        }

        //Insert into EmployeeEmergencyContact Table
        foreach (GridViewRow gvrow in emergencyContactGridView.Rows)
        {
            tbl_EmployeeEmergencyContact empEmgContact = new tbl_EmployeeEmergencyContact();

            string cName = gvrow.Cells[1].Text;
            string cRelation = gvrow.Cells[2].Text;
            string cNumber = gvrow.Cells[3].Text;
            empEmgContact.EmployeeId = empId;
            empEmgContact.ContactPersonName = cName;
            empEmgContact.ContactPersonRelation = cRelation;
            empEmgContact.ContactNumber = cNumber;
            db.tbl_EmployeeEmergencyContacts.InsertOnSubmit(empEmgContact);
        }
        //Insert Into EmployeeEducation Table
        double maxYear = 0;
        string maxDegree = "";
        foreach (GridViewRow gvrow in degreeGridView.Rows)
        {
            EmployeeEducation empEducation = new EmployeeEducation();
            
            string degreeName = gvrow.Cells[1].Text;
            string institute = gvrow.Cells[2].Text;
            string passYear = gvrow.Cells[3].Text;
            string result = gvrow.Cells[4].Text;
            empEducation.VarExamName = degreeName;
            empEducation.VarInstituteName = institute;
            empEducation.VarExamPass = passYear;
            empEducation.VarExamResult = result;
            empEducation.VarEmployeeid = empId;
            empEducation.VarBranchId = Session["VarBranchId"].ToString();
            empEducation.VarShiftCode = Session["VarShiftCode"].ToString();
            empEducation.uid = Session["uid"].ToString();
            empEducation.EntryDate = DateTime.Now.Date;
            db.EmployeeEducations.InsertOnSubmit(empEducation);
            if (maxYear<Convert.ToDouble(passYear))
            {
                maxYear = Convert.ToDouble(passYear);
                maxDegree = degreeName;
            }
        }
        emp.VarQualification = maxDegree;
        db.Employees.InsertOnSubmit(emp);

        db.SubmitChanges();

        successStatusLabel.InnerText = "Employee Added Successfull with ID: " + empId;
        degreeGridView.DataSource = null;
        degreeGridView.DataBind();
        emergencyContactGridView.DataSource = null;
        emergencyContactGridView.DataBind();
        txtEmpId.Text = "";
        txtEmpName.Text = "";
        txtPresentAdd.Text = "";
        txtPermanentAdd.Text = "";
        radioMale.Checked = false;
        radioFemale.Checked = false;
        txtDoB.Text = "";
        txtfather.Text = "";
        txtfmob.Text = "";
        txtmother.Text = "";
        txtmothermob.Text = "";
        sradio1.Checked = false;
        sradio2.Checked = false;
        txtSpoName.Text = "";
        txtSpoOcu.Text = "";
        txtSpoPhn.Text = "";
        //txtReligion.Text = "";
        religionDropDownList.SelectedValue = "0";
        txtEmpMob.Text = "";
        txtJoinDate.Text = "";
        txtLeaveDate.Text = "";
        txtLeavedFor.Text = "";
        joinSubTextBox.Text = "";
        joiningSalaryTextBox.Value = "";
        currentSalaryTextBox.Text = "";
        addNoteTextBox.Text = "";
        expTextBox.Text = "";
        driPassNoTextBox.Text = "";
        campusDropDownList.SelectedValue = "0";
        nidTextBox.Text = "";
        Session.Remove("dtInSession");
        Session.Remove("degreeDataInSession");
    }

    private string GenarateEmployeeId()
    {
        if (txtEmpId.Text == "")
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
                var stds = from u in db.Employees
                           where u.VarEmployeeid.Substring(0, 2) == branchIni
                           select new { u.VarEmployeeid };
                string result = stds.Max(element => element.VarEmployeeid);
                if (result != null)
                {
                    string subs = result.Substring(3);
                    seedNums = Convert.ToInt32(subs);
                    seedNums = seedNums + 1;
                    return (branchIni + "E" + seedNums.ToString().PadLeft(4, pads));
                }
                return (branchIni + "E" + seedNums.ToString().PadLeft(4, pads));
            }
        }
        return (txtEmpId.Text);
    }

    private void gridVIEWData()
    {
        dt.Columns.Add(new DataColumn("ContactPersonName", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactPersonRelation", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactNumber", typeof(string)));
        Session["dtInSession"] = dt;     //Saving Datatable To Session 
    }
    protected void addButton_Click(object sender, EventArgs e)
    {
        
        if (Session["dtInSession"] != null)
        {
            dt = (DataTable)Session["dtInSession"]; //Getting datatable from session 
        }
        else
        {
            gridVIEWData();
            dt = (DataTable)Session["dtInSession"];
        }

        DataRow dr = dt.NewRow();
        dr["ContactPersonName"] = emgContactNameTextBox.Text;
        dr["ContactPersonRelation"] = emgContRelationTextBox.Text;
        dr["ContactNumber"] = emgContNoTextBox.Text;


        dt.Rows.Add(dr);
        Session["dtInSession"] = dt;     //Saving Datatable To Session 
        emergencyContactGridView.DataSource = dt;
        emergencyContactGridView.DataBind();
        emgContactNameTextBox.Text = String.Empty;
        emgContRelationTextBox.Text = String.Empty;
        emgContNoTextBox.Text = String.Empty;
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        dt = Session["dtInSession"] as DataTable;
        if (dt != null)
        {
            dt.Rows[index].Delete();
            Session["dtInSession"] = dt;
            emergencyContactGridView.DataSource = dt;
        }
        emergencyContactGridView.DataBind();
    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        searchLiteral.Text = "";
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        Session.Remove("dtInSession");
        Session.Remove("degreeDataInSession");
        //["dtInSession"]=String.Empty;
        //Session["degreeDataInSession"]= "";
        gridVIEWData();
        DegreeGridViewData();
        if (txtEmpId.Text != "")
        {
            Employee getEmployee = db.Employees.FirstOrDefault(x => x.VarEmployeeid == txtEmpId.Text);

            if (getEmployee != null)
            {
                if (!String.IsNullOrWhiteSpace(getEmployee.EmployeeCategory))
                {
                    ctgDropDownList.SelectedValue = getEmployee.EmployeeCategory;
                }
                if (!String.IsNullOrWhiteSpace(getEmployee.EmployeeDesignation.ToString()))
                {
                    designationDropDownList.SelectedValue = getEmployee.EmployeeDesignation.ToString();
                }
                txtEmpName.Text = getEmployee.VarEmployeeName;

                if (!String.IsNullOrWhiteSpace(getEmployee.VarCurrentStatus.ToString()))
                {
                    currentStatusDropDownList.SelectedValue = getEmployee.VarCurrentStatus.ToString();
                }
                if (getEmployee.DOB != null)
                {
                    txtDoB.Text = Convert.ToDateTime(getEmployee.DOB.ToString())
                        .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                dropDownBlood.SelectedValue = getEmployee.VarBlood.ToString();
                religionDropDownList.SelectedValue = getEmployee.VarReligion;
                if (getEmployee.VarEmployeeSex == "Male")
                {
                    radioMale.Checked = true;
                }
                else if (getEmployee.VarEmployeeSex == "Female")
                {
                    radioFemale.Checked = true;
                }
                if (getEmployee.JoinSalary!=null)
                {
                    joiningSalaryTextBox.Value = getEmployee.JoinSalary.ToString();
                }
                if (getEmployee.CurrentSalary != null)
                {
                    currentSalaryTextBox.Text = getEmployee.CurrentSalary.ToString();
                }
                addNoteTextBox.Text = getEmployee.AdditionalNote;
                expTextBox.Text = getEmployee.Experience;
                nationalityTextBox.Text = getEmployee.VarNationality;
                txtEmpMob.Text = getEmployee.VarEmployeePhoneNo;
                nidTextBox.Text = getEmployee.VarNID;
                driPassNoTextBox.Text = getEmployee.VarDrivLicPassport;
                txtPresentAdd.Text = getEmployee.VarPresentAddress;
                txtPermanentAdd.Text = getEmployee.VarPermanentAddress;
                campusDropDownList.SelectedValue = getEmployee.VarCampusId;
                //Retrive image
                imgEmployee.ImageUrl = "~/Student Info Search and update/EmployeeImage.ashx?id=" + txtEmpId.Text + "&&image=0";
                joinSubTextBox.Text = getEmployee.JoinSubject;
                if (getEmployee.JoinDate != null)
                {
                    txtJoinDate.Text = Convert.ToDateTime(getEmployee.JoinDate.ToString())
                        .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                if (getEmployee.DatLeavedDate != null)
                {
                    txtLeaveDate.Text = Convert.ToDateTime(getEmployee.DatLeavedDate.ToString())
                        .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                txtLeavedFor.Text = getEmployee.VarLeavedFor;
                txtfather.Text = getEmployee.VarFatherName;
                txtfmob.Text = getEmployee.VarFContactNo;
                txtmother.Text = getEmployee.VarMotherName;
                txtmothermob.Text = getEmployee.VarMContactNo;
                if (getEmployee.VarMaritalstatus == "Yes")
                {
                    sradio1.Checked = true;
                }
                else if (getEmployee.VarEmployeeSex == "No")
                {
                    sradio2.Checked = true;
                }
                txtSpoName.Text = getEmployee.VarSpouseName;
                txtSpoOcu.Text = getEmployee.VarSpouseOccupation;
                txtSpoPhn.Text = getEmployee.VarSpouseContact;

                var getEmgContact = from c in db.tbl_EmployeeEmergencyContacts
                                    where c.EmployeeId == txtEmpId.Text
                                    select new { c.ContactPersonName, c.ContactPersonRelation, c.ContactNumber };
                if (getEmgContact.FirstOrDefault() != null)
                {
                    foreach (var bindData in getEmgContact)
                    {
                        if (Session["dtInSession"] != null)
                            dt = (DataTable)Session["dtInSession"]; //Getting datatable from session 

                        DataRow dr = dt.NewRow();
                        dr["ContactPersonName"] = bindData.ContactPersonName;
                        dr["ContactPersonRelation"] = bindData.ContactPersonRelation;
                        dr["ContactNumber"] = bindData.ContactNumber;


                        dt.Rows.Add(dr);
                        Session["dtInSession"] = dt;     //Saving Datatable To Session 
                        emergencyContactGridView.DataSource = dt;
                        emergencyContactGridView.DataBind();
                    }
                }

                var getEmpEducation = from c in db.EmployeeEducations
                                    where c.VarEmployeeid == txtEmpId.Text
                                    select new { c.VarExamName, c.VarExamPass, c.VarExamResult,c.VarInstituteName };
                if (getEmpEducation.FirstOrDefault() != null)
                {
                    foreach (var bindData in getEmpEducation)
                    {
                        if (Session["degreeDataInSession"] != null)
                            dt1 = (DataTable)Session["degreeDataInSession"]; //Getting datatable from session 

                        DataRow dr = dt1.NewRow();
                        dr["DegreeName"] = bindData.VarExamName;
                        dr["InstituteName"] = bindData.VarInstituteName;
                        dr["PassingYear"] = bindData.VarExamPass;
                        dr["Result"] = bindData.VarExamResult;


                        dt1.Rows.Add(dr);
                        Session["degreeDataInSession"] = dt1;     //Saving Datatable To Session 
                        degreeGridView.DataSource = dt1;
                        degreeGridView.DataBind();
                    }
                }
            }
            else
            {
                searchLiteral.Text = "<span style='color:#A94464;background-color: #F2DEDE'>Employee not found on this ID.";
            }

        }
    }
    private void DegreeGridViewData()
    {
        dt1.Columns.Add(new DataColumn("DegreeName", typeof(string)));
        dt1.Columns.Add(new DataColumn("InstituteName", typeof(string)));
        dt1.Columns.Add(new DataColumn("PassingYear", typeof(string)));
        dt1.Columns.Add(new DataColumn("Result", typeof(string)));
        Session["degreeDataInSession"] = dt1;     //Saving Datatable To Session 
    }
    protected void degreeAddButton_Click(object sender, EventArgs e)
    {

        if (Session["degreeDataInSession"] != null)
        {
            dt1 = (DataTable)Session["degreeDataInSession"];
        }
        else
        {
            DegreeGridViewData();
            dt1 = (DataTable)Session["degreeDataInSession"];
        }
             //Getting datatable from session 

        DataRow dr = dt1.NewRow();
        if (degreeNameDropDownList.SelectedValue!="ADD NEW")
        {
            dr["DegreeName"] = degreeNameDropDownList.SelectedValue;
            dr["InstituteName"] = instituteTextBox.Text;
            dr["PassingYear"] = passYearTextBox.Text;
            dr["Result"] = resultTextBox.Text;
            dt1.Rows.Add(dr);
            Session["degreeDataInSession"] = dt1;     //Saving Datatable To Session 
            degreeGridView.DataSource = dt1;
            degreeGridView.DataBind();
            degreeNameDropDownList.SelectedValue = "";
            instituteTextBox.Text = String.Empty;
            passYearTextBox.Text = String.Empty;
            resultTextBox.Text = String.Empty;
        }
       
    }
    protected void OnRowDeletingDegree(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        dt1 = Session["degreeDataInSession"] as DataTable;
        if (dt1 != null)
        {
            dt1.Rows[index].Delete();
            Session["degreeDataInSession"] = dt1;
            degreeGridView.DataSource = dt1;
        }
        degreeGridView.DataBind();
    }
    private void LoadDegreeDdl()
    {
        var getDegreeName = from x in db.tbl_EmployeeDegreeNames
                               orderby x.Id ascending
                               select new { x.VarExamName };
        degreeNameDropDownList.DataSource = getDegreeName;
        degreeNameDropDownList.DataValueField = "VarExamName";
        degreeNameDropDownList.DataTextField = "VarExamName";
        degreeNameDropDownList.DataBind();
        degreeNameDropDownList.Items.Insert(0, new ListItem("--Select--", ""));
        //previousAttendedDropDownList.Items.Insert(0, new ListItem("Add New", "0"));
    }
    protected void degreeCloseButton_OnClick(object sender, EventArgs e)
    {
        degreeModalPopupExtender.Enabled = false;
        degreeModalPopupExtender.Hide();
    }
    protected void degreeSaveButton_OnClick(object sender, EventArgs e)
    {
        var checkDegree = db.tbl_EmployeeDegreeNames.FirstOrDefault(x => x.VarExamName == dgNameTextBox.Text.Trim());
        if (checkDegree == null)
        {
            tbl_EmployeeDegreeName empDegree = new tbl_EmployeeDegreeName();

            empDegree.VarExamName = dgNameTextBox.Text.Trim();
            db.tbl_EmployeeDegreeNames.InsertOnSubmit(empDegree);
            db.SubmitChanges();
            dgNameTextBox.Text = String.Empty;
            LoadDegreeDdl();
        }
    }
    protected void degreeNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        degreeModalPopupExtender.Enabled = false;
        degreeModalPopupExtender.Hide();
        dgNameTextBox.Text = "";
        if (degreeNameDropDownList.SelectedItem.Text == "ADD NEW")
        {
            degreeModalPopupExtender.Enabled = true;
            degreeModalPopupExtender.Show();//popup show
        }
        else
        {
            degreeModalPopupExtender.Enabled = false;
            degreeModalPopupExtender.Hide();
        }
    }
    
    [WebMethod]
    public static object GetAllSub()
    {

        var getSalesPerson = (from x in db.Employees
                              
                              select new { x.JoinSubject }).Distinct();
        return getSalesPerson;
    }
}