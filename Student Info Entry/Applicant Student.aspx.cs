using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;

public partial class Applicant_Student : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtregId.Focus();
        if (IsPostBack != null)
        {
            //string s = (DateTime.Now.Year - 2).ToString();
            //DropDownList1.Items.Add(new ListItem(s));
            //string s1 = (DateTime.Now.Year - 3).ToString();
            //DropDownList1.Items.Add(new ListItem(s1));
            //string s2 = (DateTime.Now.Year - 4).ToString();
            //DropDownList1.Items.Add(new ListItem(s2));
            //string s3 = (DateTime.Now.Year - 5).ToString();
            //DropDownList1.Items.Add(new ListItem(s3));
            //string s4 = (DateTime.Now.Year - 6).ToString();
            //DropDownList1.Items.Add(new ListItem(s4));
            //string s5 = (DateTime.Now.Year - 7).ToString();
            //DropDownList1.Items.Add(new ListItem(s5));
            //string s6 = (DateTime.Now.Year - 8).ToString();
            //DropDownList1.Items.Add(new ListItem(s6));
            //string s7 = (DateTime.Now.Year - 9).ToString();
            //DropDownList1.Items.Add(new ListItem(s7));
            //string s8 = (DateTime.Now.Year - 10).ToString();
            //DropDownList1.Items.Add(new ListItem(s8));
            //string s9 = (DateTime.Now.Year - 11).ToString();
            //DropDownList1.Items.Add(new ListItem(s9));
            //string s10 = (DateTime.Now.Year - 12).ToString();
            //DropDownList1.Items.Add(new ListItem(s10));
            //string s11 = (DateTime.Now.Year - 13).ToString();
            //DropDownList1.Items.Add(new ListItem(s11));
            //string s12 = (DateTime.Now.Year - 14).ToString();
            //DropDownList1.Items.Add(new ListItem(s12));
            //string s13 = (DateTime.Now.Year - 15).ToString();
            //DropDownList1.Items.Add(new ListItem(s13));


            //string h = (DateTime.Now.Year).ToString();
            //DropDownList2.Items.Add(new ListItem(h));
            //string h1 = (DateTime.Now.Year - 1).ToString();
            //DropDownList2.Items.Add(new ListItem(h1));
            //string h2 = (DateTime.Now.Year - 2).ToString();
            //DropDownList2.Items.Add(new ListItem(h2));
            //string h3 = (DateTime.Now.Year - 3).ToString();
            //DropDownList2.Items.Add(new ListItem(h3));
            //string h4 = (DateTime.Now.Year - 4).ToString();
            //DropDownList2.Items.Add(new ListItem(h4));
            //string h5 = (DateTime.Now.Year - 5).ToString();
            //DropDownList2.Items.Add(new ListItem(h5));
            //string h6 = (DateTime.Now.Year - 6).ToString();
            //DropDownList2.Items.Add(new ListItem(h6));
            //string h7 = (DateTime.Now.Year - 7).ToString();
            //DropDownList2.Items.Add(new ListItem(h7));
            //string h8 = (DateTime.Now.Year - 8).ToString();
            //DropDownList2.Items.Add(new ListItem(h8));
            //string h9 = (DateTime.Now.Year - 9).ToString();
            //DropDownList2.Items.Add(new ListItem(h9));
            //string h10 = (DateTime.Now.Year - 10).ToString();
            //DropDownList2.Items.Add(new ListItem(h10));
            //string h11 = (DateTime.Now.Year - 11).ToString();
            //DropDownList2.Items.Add(new ListItem(h11));
            //string h12 = (DateTime.Now.Year - 12).ToString();
            //DropDownList2.Items.Add(new ListItem(h12));
            //string h13 = (DateTime.Now.Year - 13).ToString();
            //DropDownList2.Items.Add(new ListItem(h13));

            //if (Session["uid"] != null)
            //    txtuid.Text = Session["uid"].ToString();

            //if (Session["VarBranchId"] != null)
            //    drpbranch.SelectedValue = Session["VarBranchId"].ToString();
            //if (Session["VarShiftCode"] != null)
            //    drpshift.SelectedValue = Session["VarShiftCode"].ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        if (idTextBox.Text != "")
        {
            ParticipantStudent chkStudent = db.ParticipantStudents.FirstOrDefault(x=>x.Id==Convert.ToInt32(idTextBox.Text) && x.VarBranchId == Convert.ToInt32(Session["VarBranchId"]));
            if (chkStudent!=null)
            {
                db.ParticipantStudents.DeleteOnSubmit(chkStudent);
                db.SubmitChanges();
            }
        }

        ParticipantStudent pStudent = db.ParticipantStudents.FirstOrDefault(x => x.varRegistrationId == txtregId.Text && x.VarSession == sessionDropDownList.SelectedValue && x.VarBranchId == Convert.ToInt32(Session["VarBranchId"]));
        if (pStudent == null)
        {
            var ps = new ParticipantStudent();
            ps.varStudentFirstName = txtsName.Text;
            ps.varStudentLastName = lastNameTextBox.Text;
            ps.varRegistrationId = txtregId.Text;
            ps.VarSession = sessionDropDownList.SelectedValue;
            if (!String.IsNullOrWhiteSpace(txtdob.Text))
            {
                DateTime date = DateTime.ParseExact(txtdob.Text, "dd-MM-yyyy", null);
                //ps.dob = Convert.ToDateTime(txtdob.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                ps.dob = Convert.ToDateTime(date);
            }
            ps.varFatherName = txtfather.Text;
            ps.varMotherName = txtmother.Text;
            ps.EmergencyPhone = txtemrgency.Text;
            ps.admissionForClass = DropDownList3.Text;
            if (malerbutton.Checked)
            {
                ps.VarStudentGender = malerbutton.Text;
            }
            else if (femalerbutton.Checked)
            {
                ps.VarStudentGender = femalerbutton.Text;
            }
            if (Session["uid"] != null)
            {
                ps.uid = Session["uid"].ToString();
            }
            if (Session["VarBranchId"] != null)
            {
                ps.VarBranchId = Convert.ToInt32(Session["VarBranchId"]);
            }

            if (Session["VarShiftCode"] != null)
            {
                ps.VarShiftCode = Session["VarShiftCode"].ToString();
            }
            ps.Status = "1";

            ps.Type = 1;
            ps.InputDate = DateTime.Now;
            db.ParticipantStudents.InsertOnSubmit(ps);
            db.SubmitChanges();
            successStatusLabel.InnerText = "Student Information Inserted Successfully!";
            txtemrgency.Text = "880";
            txtregId.Text = string.Empty;
            ClearTextBox();
            Button1.Text = "Save";
        }
        else 
        {
            failStatusLabel.InnerText = "This Form ID already exists in selected Session.";
        }

        idTextBox.Text = "";

    }

    private void ClearTextBox()
    {
        txtsName.Text = string.Empty;

        txtdob.Text = string.Empty;
        txtfather.Text = string.Empty;
        txtfather.Text = string.Empty;
        txtemrgency.Text = string.Empty;
        txtmother.Text = string.Empty;
        txtsName.Text = string.Empty;
        DropDownList3.SelectedValue = "0";
        lastNameTextBox.Text = string.Empty;
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        ClearTextBox();
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        if (txtregId.Text != "")
        {
            int branchId = Convert.ToInt32(Session["VarBranchId"]);
            ParticipantStudent ps = db.ParticipantStudents.FirstOrDefault(x => x.varRegistrationId == txtregId.Text && x.VarSession == sessionDropDownList.SelectedValue && x.VarBranchId == branchId);
            if (ps != null)
            {
                idTextBox.Text = ps.Id.ToString();
                sessionDropDownList.SelectedValue = ps.VarSession;
                txtsName.Text = ps.varStudentFirstName;
                lastNameTextBox.Text = ps.varStudentLastName;
                if (ps.dob != null)
                {
                    txtdob.Text = Convert.ToDateTime(ps.dob.ToString())
                        .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                if (ps.VarStudentGender == "Male")
                {
                    malerbutton.Checked = true;
                }
                else if (ps.VarStudentGender == "Female")
                {
                    femalerbutton.Checked = true;
                }
                txtfather.Text = ps.varFatherName;
                txtmother.Text = ps.varMotherName;
                txtemrgency.Text = ps.EmergencyPhone;
                DropDownList3.SelectedValue = ps.admissionForClass;
                Button1.Text = "Update";
                successStatusLabel.InnerText = "Student Information Retrive Successfully";
            }
            else
            {
                failStatusLabel.InnerText = "Form ID Not Found.";
            }

        }
        else
        {
            failStatusLabel.InnerText = "Please Insert STudent ID";
        }
    }
}