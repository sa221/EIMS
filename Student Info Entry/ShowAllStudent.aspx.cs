using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentInfoEntryShowAllStudent : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        saveButton.Visible = false;
    }

    protected void ShowButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        saveButton.Visible = false;
        allApplicantGridView.DataSource = null;
        allApplicantGridView.DataBind();
        admissionSelectionGridView.DataSource = null;
        admissionSelectionGridView.DataBind();
        
        if (admissionRadioButtonList.SelectedValue=="0")
        {
            GetApplicantStudent();
            radioValueTextBox.Text = admissionRadioButtonList.SelectedValue;
           
        }
        else if (admissionRadioButtonList.SelectedValue == "1")
        {
            GetSelectStudent();
            radioValueTextBox.Text = admissionRadioButtonList.SelectedValue;
            
        }
    }

    private void GetApplicantStudent()
    {
        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        if (classDropDownList.SelectedValue != "0")
        {
            
            var getAllApplicantStudent = from p in db.ParticipantStudents
                join c in db.Classes on p.admissionForClass equals c.VarClassID
                where
                    p.VarSession == sessionDropDownList.SelectedValue &&
                    p.admissionForClass == classDropDownList.SelectedValue && (p.Status == "1" || p.Status == "2") &&
                    p.VarBranchId == brachId
                select new
                {
                    p.varRegistrationId,
                    p.varStudentFirstName,
                    p.varStudentLastName,
                    p.varStudentMiddleName,
                    p.dob,
                    p.EmergencyPhone,
                    c.VarClassName,
                    p.Status,
                    p.InterviewDate,
                    p.InterviewSlot,
                    p.IntrviewTime
                };

            allApplicantGridView.DataSource = getAllApplicantStudent.AsEnumerable();
            //allApplicantGridView.DataSource = null;
            allApplicantGridView.DataBind();
            if (allApplicantGridView.PageCount > 0)
            {
                saveButton.Visible = true;
            }
        }
        else
        {
            
            var getAllApplicantStudent = from p in db.ParticipantStudents
                join c in db.Classes on p.admissionForClass equals c.VarClassID
                where p.VarSession == sessionDropDownList.SelectedValue && (p.Status == "1" || p.Status == "2") &&
                      p.VarBranchId == brachId
                select new
                {
                    p.varRegistrationId,
                    p.varStudentFirstName,
                    p.varStudentLastName,
                    p.varStudentMiddleName,
                    p.dob,
                    p.EmergencyPhone,
                    c.VarClassName,
                    p.Status,
                    p.InterviewDate,
                    p.InterviewSlot,
                    p.IntrviewTime
                };

            allApplicantGridView.DataSource = getAllApplicantStudent.AsEnumerable();
            
            allApplicantGridView.DataBind();
            if (allApplicantGridView.PageCount > 0)
            {
                saveButton.Visible = true;
            }
        }
    }

    private void GetSelectStudent()
    {
        int brachId = Convert.ToInt32(Session["VarBranchId"]);
        if (classDropDownList.SelectedValue != "0")
        {
            
            var getAllApplicantStudent = from p in db.ParticipantStudents
                                         join c in db.Classes on p.admissionForClass equals c.VarClassID
                                         where
                                             p.VarSession == sessionDropDownList.SelectedValue &&
                                             p.admissionForClass == classDropDownList.SelectedValue && (p.Status == "3" || p.Status == "2") &&
                                             p.VarBranchId == brachId
                                         select new
                                         {
                                             p.varRegistrationId,
                                             p.varStudentFirstName,
                                             p.varStudentLastName,
                                             p.varStudentMiddleName,
                                             p.dob,
                                             p.EmergencyPhone,
                                             c.VarClassName,
                                             p.Status,
                                             p.AdmissionDate
                                         };
            
            admissionSelectionGridView.DataSource = getAllApplicantStudent.AsEnumerable();
            
            admissionSelectionGridView.DataBind();
            if (admissionSelectionGridView.PageCount > 0)
            {
                saveButton.Visible = true;
            }
            
        }
        else
        {
            //foreach (GridViewRow gvrow in allApplicantGridView.Rows)
            //{
            //    ((DropDownList)gvrow.Cells[5].FindControl("statusDropDown")).ClearSelection();
            //}
            var getAllApplicantStudent = from p in db.ParticipantStudents
                                         join c in db.Classes on p.admissionForClass equals c.VarClassID
                                         where p.VarSession == sessionDropDownList.SelectedValue && (p.Status == "3" || p.Status == "2") &&
                                               p.VarBranchId == brachId
                                         select new
                                         {
                                             p.varRegistrationId,
                                             p.varStudentFirstName,
                                             p.varStudentLastName,
                                             p.varStudentMiddleName,
                                             p.dob,
                                             p.EmergencyPhone,
                                             c.VarClassName,
                                             p.Status,
                                             p.AdmissionDate
                                             
                                         };
            
            admissionSelectionGridView.DataSource = getAllApplicantStudent.AsEnumerable();
            //admissionSelectionGridView.DataSource = null;
            admissionSelectionGridView.DataBind();
            if (admissionSelectionGridView.PageCount > 0)
            {
                saveButton.Visible = true;
            }
            
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        if (radioValueTextBox.Text=="0")
        {
            SaveInterviewData();
        }
        else if(radioValueTextBox.Text=="1")
        {
            SaveAdmissionData();
        }
        
        
    }

    private void SaveInterviewData()
    {
        foreach (GridViewRow gvrow in allApplicantGridView.Rows)
        {
            string formId = ((Label) gvrow.Cells[1].FindControl("Label1")).Text;
            string status = ((DropDownList) gvrow.Cells[5].FindControl("statusDropDown")).SelectedValue;
            string interviewDate = ((TextBox)gvrow.Cells[6].FindControl("interviewDateTextBox")).Text;
            string interviewSlot = ((DropDownList)gvrow.Cells[7].FindControl("interviewDropDown")).SelectedValue;
            string interviewTime = ((DropDownList)gvrow.Cells[8].FindControl("interviewTimeDropDown")).SelectedValue;

            ParticipantStudent isStudentExist =
                (from d in db.ParticipantStudents
                    where d.varRegistrationId == formId && d.VarSession==sessionDropDownList.SelectedValue
                    select d).FirstOrDefault();
            if (isStudentExist != null)
            {
                isStudentExist.Status = status;
                if (interviewDate != "")
                {
                    DateTime date = DateTime.ParseExact(interviewDate, "dd/MM/yyyy", null);
                    isStudentExist.InterviewDate = date;
                }
                if (interviewSlot!="")
                {
                    isStudentExist.InterviewSlot = Convert.ToInt32(interviewSlot);
                }
                if (interviewTime != "")
                {
                    isStudentExist.IntrviewTime = Convert.ToInt32(interviewTime);
                }
                //isStudentExist.AdmissionDate = Convert.ToDateTime(admissionDate);}
            }
            db.SubmitChanges();
            ((DropDownList) gvrow.Cells[5].FindControl("statusDropDown")).ClearSelection();
        }
        successStatusLabel.InnerText = "Information Updated Successfully...";
        allApplicantGridView.DataSource = null;
        allApplicantGridView.DataBind();
    }

    private void SaveAdmissionData()
    {
        foreach (GridViewRow gvrow in admissionSelectionGridView.Rows)
        {
            string formId = ((Label)gvrow.Cells[1].FindControl("Label1")).Text;
            string status = ((DropDownList)gvrow.Cells[5].FindControl("statusDropDown")).SelectedValue;
            string admissionDate = ((TextBox)gvrow.Cells[6].FindControl("dateTextBox")).Text;

            ParticipantStudent isStudentExist =
                (from d in db.ParticipantStudents
                 where d.varRegistrationId == formId && d.VarSession==sessionDropDownList.SelectedValue
                 select d).FirstOrDefault();
            if (isStudentExist != null)
            {
                isStudentExist.Status = status;
                if (admissionDate != "")
                {
                    DateTime date = DateTime.ParseExact(admissionDate, "dd/MM/yyyy", null);
                    isStudentExist.AdmissionDate = date;
                }
                else
                {
                    isStudentExist.AdmissionDate = null;
                }
                //isStudentExist.AdmissionDate = Convert.ToDateTime(admissionDate);}
            }
            db.SubmitChanges();
            ((DropDownList)gvrow.Cells[5].FindControl("statusDropDown")).ClearSelection();
        }
        successStatusLabel.InnerText = "Information Updated Successfully...";
        admissionSelectionGridView.DataSource = null;
        admissionSelectionGridView.DataBind();
    }

    //protected void headinterviewDropDown_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    var ddl = (DropDownList)sender;
    //    string indexx = ddl.SelectedValue;
    //    foreach (GridViewRow row in allApplicantGridView.Rows)
    //    {
    //        var clsDownList = ((DropDownList)row.FindControl("interviewDropDown"));

    //        clsDownList.SelectedValue = indexx;
    //    }
    //}

    //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    DropDownList interviewDdl = (e.Row.FindControl("interviewDropDownList") as DropDownList);
    //    var getSlotData = from x in db.tbl_InterviewSlots
    //                      select new { x.InterviewSlot };
    //    if (interviewDdl != null)
    //    {
            
    //        interviewDdl.DataSource = getSlotData;
    //        interviewDdl.DataValueField = "InterviewSlot";
    //        interviewDdl.DataTextField = "InterviewSlot";
    //        interviewDdl.DataBind();
    //        interviewDdl.Items.Insert(0, new ListItem("Select", ""));
    //    }
    //}
    protected void admissionSelectionGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = admissionSelectionGridView.Rows[index];
            string s = ((Label) gvRow.Cells[1].FindControl("Label1")).Text;
            string status = ((DropDownList)gvRow.Cells[5].FindControl("statusDropDown")).SelectedValue;
            //if (status == "3")
            //{
               
            //}
            SaveAdmissionData();
            string session = sessionDropDownList.SelectedValue;
            
            var checkFromId = db.ParticipantStudents.FirstOrDefault(x => x.varRegistrationId == s && x.Status == "3" && x.VarSession==session);
            if (checkFromId!=null)
            {
                Response.Redirect("~/ReportsUI/AdmitRequest.aspx?varRegistrationId=" + s+ "&VarSession=" + session);
               // Response.Redirect("Default2.aspx?adi=" + adi + "&soyadi=" + soyadi);
            }
            
            //Page.ClientScript.RegisterStartupScript(GetType(), "OpenWindow", "window.open('~/Student Info Entry/StudentAddmission.aspx?VarStudentID=' ,'_blank');"+s , true);
        }
    }
}