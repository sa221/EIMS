using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubjectUI_TeacherSubjectAssign : System.Web.UI.Page
{
    SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSection();
        }
    }

    private void LoadSection()
    {
        var getAllSection = from x in db.tblSections
            where x.ClassID == classDropDownList.SelectedValue
            select new {x.SectionId,x.varSectionName};
        sectionDropDownList.DataSource = getAllSection;
        sectionDropDownList.DataValueField = "SectionId";
        sectionDropDownList.DataTextField = "varSectionName";
        sectionDropDownList.DataBind();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ShowData()
    {
        
        var getData = from c in db.tbl_Subjects
                      join s in db.tbl_EmployeeSubjectAssigns on
                      new
                      {
                          c.VarSubjectCode,
                          VarSession = sessionDropDownList.SelectedValue,
                          VarSection=sectionDropDownList.SelectedValue

                      } equals
                            new { s.VarSubjectCode, s.VarSession,s.VarSection } into sGroup
                      from s in sGroup.DefaultIfEmpty()
                      where c.ClassId == classDropDownList.SelectedValue
                      select new { FullCode=c.VarSubjectCode, FUllSubject = c.VarSubjectName, s.VarEmpId };
        allSubjectAssignGridView.DataSource = getData.AsEnumerable();
        allSubjectAssignGridView.DataBind();

    }
    protected void ShowAlevelData()
    {

        var getData = from s in db.tbl_Subjects
                      join eu in db.tbl_EdexelunitCodes
                          on new { s.VarSubjectCode, s.ClassId }
                          equals new { VarSubjectCode = eu.SpecificationCode, ClassId = eu.Class }
                      join m in db.tbl_EmployeeSubjectAssigns on
                          new
                          {
                              VarSubjectCode=s.VarSubjectCode+""+eu.UnitCodeSpeCode,
                              VarSession = sessionDropDownList.SelectedValue,
                              VarSection=sectionDropDownList.SelectedValue
                          } equals
                                new { m.VarSubjectCode, m.VarSession,m.VarSection } into mGroup
                      from m in mGroup.DefaultIfEmpty()
                  where
                      s.ClassId==classDropDownList.SelectedValue
                      select new { FullCode=s.VarSubjectCode+""+eu.UnitCodeSpeCode, FUllSubject=s.VarSubjectName+" "+eu.UnitCode, m.VarEmpId };
        allSubjectAssignGridView.DataSource = getData.AsEnumerable();
        allSubjectAssignGridView.DataBind();

    }
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSection();   
    }

    //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        //Find the DropDownList in the Row
    //        DropDownList teacherDropDownList = (e.Row.FindControl("teacherDropDownList") as DropDownList);
    //        var getData = from c in db.Employees
    //                      where c.EmployeeCategory == "1" && c.VarCurrentStatus=="A"
    //                      select new { c.VarEmployeeName, c.VarEmployeeid };
    //        if (teacherDropDownList != null)
    //        {
    //            teacherDropDownList.DataSource = getData;
    //            teacherDropDownList.DataTextField = "VarEmployeeName";
    //            teacherDropDownList.DataValueField = "VarEmployeeid";
    //            teacherDropDownList.DataBind();
    //            //Add Default Item in the DropDownList
    //            teacherDropDownList.Items.Insert(0, new ListItem("Please select"));

    //            //Select the Country of Customer in DropDownList
    //            var label = e.Row.FindControl("lblTeacher") as Label;
    //            if (label != null)
    //            {
    //                string teacher = label.Text;
    //                teacherDropDownList.Items.FindByValue(teacher).Selected = true;
    //            }
    //        }


    //    }
    //}

    protected void saveButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        SaveSubAssignData();
    }
    private void SaveSubAssignData()
    {
        foreach (GridViewRow gvrow in allSubjectAssignGridView.Rows)
        {
            string subCode = ((Label)gvrow.Cells[1].FindControl("Label1")).Text;
            string teacherId = ((DropDownList)gvrow.Cells[3].FindControl("teacherDropDownList")).SelectedValue;
            string sessionId = sessionDropDownList.SelectedValue;
            string classId = classDropDownList.SelectedValue;
            string section = sectionDropDownList.SelectedValue;
            tbl_EmployeeSubjectAssign subjectAssign = new tbl_EmployeeSubjectAssign();

            var isExistSubject = db.tbl_EmployeeSubjectAssigns.FirstOrDefault(x => x.VarSession == sessionId && x.VarClass == classId && x.VarSubjectCode == subCode && x.VarSection==section);
            if (isExistSubject == null)
            {
                subjectAssign.VarSession = sessionId;
                subjectAssign.VarClass = classId;
                subjectAssign.VarSection = section;
                subjectAssign.VarSubjectCode = subCode;
                subjectAssign.VarEmpId = teacherId;
                subjectAssign.BranchId = Convert.ToInt32(Session["VarBranchId"]);
                subjectAssign.EntryBy = Session["uid"].ToString();
                subjectAssign.EntryDate = DateTime.Now.Date;
                db.tbl_EmployeeSubjectAssigns.InsertOnSubmit(subjectAssign);
                successStatusLabel.InnerText = "Subject assigned Successfully...";
            }
            else
            {
                isExistSubject.VarSession = sessionId;
                isExistSubject.VarClass = classId;
                isExistSubject.VarSection = section;
                isExistSubject.VarSubjectCode = subCode;
                isExistSubject.VarEmpId = teacherId;
                isExistSubject.BranchId = Convert.ToInt32(Session["VarBranchId"]);
                isExistSubject.EntryBy = Session["uid"].ToString();
                isExistSubject.EntryDate = DateTime.Now.Date;
                successStatusLabel.InnerText = "Subject assign updated Successfully...";
            }
            db.SubmitChanges();
        }
        successStatusLabel.InnerText = "Subject Assigned Successfully...";
        ShowData();
        ShowAlevelData();
    }
    protected void sectionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        Class cls = db.Classes.FirstOrDefault(c => c.VarClassID == classDropDownList.SelectedValue);
        if (cls != null && cls.ClassType != 2)
        {
            ShowData();
        }
        else
        {
            ShowAlevelData();
        }
    }
}