using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Info_Search_and_update_StudentInfoUpdateSecondary : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!Page.IsPostBack){
        //    classDropDownList.SelectedValue = "0";
        //    pSessionDropDownList.SelectedValue = "0";
        //}
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        failStatusLabel.InnerText = "";
        successStatusLabel.InnerText = "";
        if (studentIdTextBox.Text != "")
        {
            Student std = db.Students.FirstOrDefault(s => s.VarStudentID == studentIdTextBox.Text);
            if (std != null)
            {
                classDropDownList.SelectedValue = std.PClassID;
                pSessionDropDownList.SelectedValue = std.VarSessionName;
            }
            else
            {
                failStatusLabel.InnerText = "Student not Found..!";
            }
        }
        if (classDropDownList.SelectedItem.Value == "0" && studentIdTextBox.Text == "" &&
            pSessionDropDownList.SelectedValue == "0")
        {
            //var his = from u in db.Students
            //          join c in db.Classes on u.PClassID equals c.VarClassID
            //          join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId
            //          orderby u.VarStudentID descending
            //          select new { u.VarStudentID, u.VarStudentFirstName, u.VarStudentMeddleName,s.varSectionName, u.VarStudentLastName,u.PClassID, c.VarClassName };

            failStatusLabel.InnerText = "Please select class..!!";
            //GridView1.DataSource = his.AsEnumerable();
            //GridView1.DataBind();
        }
        else if (studentIdTextBox.Text != "" && classDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedValue == "0")
        {
            var his = from u in db.Students
                      where u.VarStudentID == studentIdTextBox.Text && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentFirstName ascending
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue == "0" &&
                 pSessionDropDownList.SelectedValue == "0")
        {
            var his = from u in db.Students
                      where u.PClassID == classDropDownList.SelectedItem.Value && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentFirstName ascending
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedValue != "0")
        {
            //var his = from u in db.Students
            //          where u.VarSessionName == pSessionDropDownList.SelectedItem.Value
            //          join c in db.Classes on u.PClassID equals c.VarClassID
            //          join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId
            //          select new { u.VarStudentID, u.VarStudentFirstName, u.VarStudentMeddleName, u.RecommendAdmissionSection, s.varSectionName, u.VarStudentLastName, u.PClassID, c.VarClassName };
            failStatusLabel.InnerText = "Please select class..!!";
            //GridView1.DataSource = his.AsEnumerable();
            //GridView1.DataBind();
        }
        else if (studentIdTextBox.Text != "" && classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue != "0" &&
                 pSessionDropDownList.SelectedValue == "0")
        {
            var his = from u in db.Students
                      where
                          u.VarStudentID == studentIdTextBox.Text &&
                          u.PClassID == classDropDownList.SelectedValue && u.Status != "L" && u.RecommendAdmissionSection == sectionDropDownList.SelectedValue
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentFirstName ascending
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text != "" && classDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedValue != "0")
        {
            Student std = db.Students.FirstOrDefault(s => s.VarStudentID == studentIdTextBox.Text);
            if (std != null) classDropDownList.SelectedValue = std.PClassID;

            var his = from u in db.Students
                      where
                          u.VarStudentID == studentIdTextBox.Text &&
                          u.VarSessionName == pSessionDropDownList.SelectedValue && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into
                          uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentFirstName ascending
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue == "0" &&
                 pSessionDropDownList.SelectedValue != "0")
        {
            var his = from u in db.Students
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      //join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into
                          uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into
                          shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentFirstName ascending
                      where
                          u.PClassID == classDropDownList.SelectedValue &&
                          u.VarSessionName == pSessionDropDownList.SelectedValue && u.Status != "L"
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          s.ClassID,
                          c.VarClassName,
                          c.VarClassID,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue != "0" &&
             pSessionDropDownList.SelectedValue != "0")
        {
            var his = from u in db.Students
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      //join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into
                          uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into
                          shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentFirstName ascending
                      where
                          u.PClassID == classDropDownList.SelectedValue &&
                          u.RecommendAdmissionSection == sectionDropDownList.SelectedValue &&
                          u.VarSessionName == pSessionDropDownList.SelectedValue && u.Status != "L"
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          s.ClassID,
                          c.VarClassName,
                          c.VarClassID,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else
        {
            var his = from u in db.Students
                      where
                          u.PClassID == classDropDownList.SelectedItem.Value &&
                          u.VarStudentID == studentIdTextBox.Text &&

                          u.VarSessionName == pSessionDropDownList.SelectedValue && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into
                          uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into
                          shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentFirstName ascending
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            var std = new Student();
            var pcl = new tbl_Present_class();
            string studentId = ((Label)gvrow.Cells[1].FindControl("Label1")).Text;
            //string classId = classDropDownList.SelectedValue;
            string sessionId = pSessionDropDownList.SelectedValue;
            string clsId = ((DropDownList)gvrow.Cells[3].FindControl("clsDropDown")).Text;
            string shiftId = ((DropDownList)gvrow.Cells[5].FindControl("tShiftDropDown")).Text;
            string sectionId = ((DropDownList)gvrow.Cells[4].FindControl("sectionDropDownList")).Text;
            string stdRoll = ((TextBox)gvrow.Cells[6].FindControl("rollTextBox")).Text;
            string campusId = ((DropDownList)gvrow.Cells[4].FindControl("tCampusDropDown")).Text;

            Student isStudentExist =
                (from d in db.Students
                 where d.VarStudentID == studentId
                 select d).SingleOrDefault();
            if (isStudentExist != null)
            {
                isStudentExist.VarShiftCode = shiftId;
                isStudentExist.RecommendAdmissionSection = sectionId;
                if (stdRoll != "")
                {
                    isStudentExist.StudentRoll = Convert.ToInt32(stdRoll);
                }

                isStudentExist.CampusId = campusId;
                isStudentExist.PClassID = clsId;
            }

            tbl_Present_class check =
                (from d in db.tbl_Present_classes
                 where d.VarStudentID == studentId
                 select d).SingleOrDefault();

            if (check != null)
            {
                check.VarShiftCode = shiftId;
                check.VarClassID = clsId;
                check.VarSection = sectionId;
                check.VarSessionId = sessionId;
                if (stdRoll != "")
                {
                    check.StudentRoll = Convert.ToInt32(stdRoll);
                }

                check.CampusId = campusId;
            }
            else
            {
                pcl.VarStudentID = studentId;
                pcl.VarShiftCode = shiftId;
                pcl.VarClassID = clsId;
                pcl.VarSection = sectionId;
                pcl.VarSessionId = sessionId;
                if (stdRoll != "")
                {
                    pcl.StudentRoll = Convert.ToInt32(stdRoll);
                }
                //pcl.StudentRoll = Convert.ToInt32(stdRoll);
                pcl.CampusId = campusId;
                db.tbl_Present_classes.InsertOnSubmit(pcl);
            }

            db.SubmitChanges();
        }
        successStatusLabel.InnerText = "Student Information Updated Successfully....!";
        GridView1.DataSource = null;
        GridView1.DataBind();
        classDropDownList.SelectedValue = "0";
        pSessionDropDownList.SelectedValue = "0";
        studentIdTextBox.Text = "";
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (classDropDownList.SelectedItem.Value == "0" && studentIdTextBox.Text == "" &&
            pSessionDropDownList.SelectedValue == "0")
        {
            //var his = from u in db.Students
            //          join c in db.Classes on u.PClassID equals c.VarClassID
            //          join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId
            //          orderby u.VarStudentID descending
            //          select new { u.VarStudentID, u.VarStudentFirstName, u.VarStudentMeddleName,s.varSectionName, u.VarStudentLastName,u.PClassID, c.VarClassName };

            failStatusLabel.InnerText = "Please select class..!!";
            //GridView1.DataSource = his.AsEnumerable();
            //GridView1.DataBind();
        }
        else if (studentIdTextBox.Text != "" && classDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedValue == "0")
        {
            var his = from u in db.Students
                      where u.VarStudentID == studentIdTextBox.Text && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue == "0" &&
                 pSessionDropDownList.SelectedValue == "0")
        {
            var his = from u in db.Students
                      where u.PClassID == classDropDownList.SelectedItem.Value && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue != "0" &&
             pSessionDropDownList.SelectedValue == "0")
        {
            var his = from u in db.Students
                      where u.PClassID == classDropDownList.SelectedItem.Value && u.Status != "L" && u.RecommendAdmissionSection == sectionDropDownList.SelectedValue
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedValue != "0")
        {
            //var his = from u in db.Students
            //          where u.VarSessionName == pSessionDropDownList.SelectedItem.Value
            //          join c in db.Classes on u.PClassID equals c.VarClassID
            //          join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId
            //          select new { u.VarStudentID, u.VarStudentFirstName, u.VarStudentMeddleName, u.RecommendAdmissionSection, s.varSectionName, u.VarStudentLastName, u.PClassID, c.VarClassName };
            failStatusLabel.InnerText = "Please select class..!!";
            //GridView1.DataSource = his.AsEnumerable();
            //GridView1.DataBind();
        }
        else if (studentIdTextBox.Text != "" && classDropDownList.SelectedItem.Value != "0" &&
                 pSessionDropDownList.SelectedValue == "0")
        {
            var his = from u in db.Students
                      where
                          u.VarStudentID == studentIdTextBox.Text &&
                          u.PClassID == classDropDownList.SelectedValue && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentID descending
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text != "" && classDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedValue != "0")
        {
            Student std = db.Students.FirstOrDefault(s => s.VarStudentID == studentIdTextBox.Text);
            classDropDownList.SelectedValue = std.PClassID;

            var his = from u in db.Students
                      where
                          u.VarStudentID == studentIdTextBox.Text &&
                          u.VarSessionName == pSessionDropDownList.SelectedValue && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into
                          uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue == "0" &&
                 pSessionDropDownList.SelectedValue != "0")
        {
            var his = from u in db.Students
                      where
                          u.PClassID == classDropDownList.SelectedValue &&
                          u.VarSessionName == pSessionDropDownList.SelectedValue && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      //join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into
                          uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into
                          shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentID descending
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else if (studentIdTextBox.Text == "" && classDropDownList.SelectedItem.Value != "0" && sectionDropDownList.SelectedValue != "0" &&
             pSessionDropDownList.SelectedValue != "0")
        {
            var his = from u in db.Students
                      where
                          u.PClassID == classDropDownList.SelectedValue &&
                          u.RecommendAdmissionSection == sectionDropDownList.SelectedValue &&
                          u.VarSessionName == pSessionDropDownList.SelectedValue && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      //join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into
                          uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into
                          shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentID descending
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
        else
        {
            var his = from u in db.Students
                      where
                          u.PClassID == classDropDownList.SelectedItem.Value &&
                          u.VarStudentID == studentIdTextBox.Text &&
                          u.VarSessionName == pSessionDropDownList.SelectedValue && u.Status != "L"
                      join c in db.Classes on u.PClassID equals c.VarClassID
                      join s in db.tblSections on u.RecommendAdmissionSection equals s.SectionId into
                          uGroup
                      from s in uGroup.DefaultIfEmpty()
                      join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into
                          shiGroup
                      from shi in shiGroup.DefaultIfEmpty()
                      join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                      from camp in campGroup.DefaultIfEmpty()
                      orderby u.VarStudentID descending
                      select new
                      {
                          u.VarStudentID,
                          u.VarStudentFirstName,
                          u.VarStudentMeddleName,
                          u.RecommendAdmissionSection,
                          u.CampusId,
                          u.VarStudentLastName,
                          u.PClassID,
                          u.StudentRoll,
                          u.VarShiftCode,
                          s.varSectionName,
                          c.VarClassName,
                          shi.VarShiftName,
                          camp.house_name
                      };
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
    }

    //protected void clsDropDown_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList sectionDropDownList = ((DropDownList)gvrow.Cells[5].FindControl("tShiftDropDown")).Text;
    //}
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GridView1.Rows[index];
            string s = ((Label)gvRow.Cells[1].FindControl("Label1")).Text;
            Response.Redirect("~/Student Info Entry/StudentAddmission.aspx?VarStudentID=" + s);
            //Page.ClientScript.RegisterStartupScript(GetType(), "OpenWindow", "window.open('~/Student Info Entry/StudentAddmission.aspx?VarStudentID=' ,'_blank');"+s , true);
        }
    }
}