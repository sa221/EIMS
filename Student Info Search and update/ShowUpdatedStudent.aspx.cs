using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Info_Search_and_update_ShowUpdatedStudent : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        //schoolLabel.Text = "MASTERMIND";
        //SessionLabel.Text = "Session: " + sessionDropDownList.SelectedItem.Text;
        //classLabel.Text = "Class: " + classDropDownList.SelectedItem.Text;

        //#1
        if (classDropDownList.SelectedItem.Value != "0" && sessionDropDownList.SelectedValue == "0" &&
            sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue == "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where u.VarClassID == classDropDownList.SelectedItem.Value && stu.Status != "L"

                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#2
        else if (classDropDownList.SelectedItem.Value == "0" && sessionDropDownList.SelectedValue != "0" &&
                 sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue == "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where u.VarSessionId == sessionDropDownList.SelectedValue && stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#3
        else if (classDropDownList.SelectedItem.Value == "0" && sessionDropDownList.SelectedValue == "0" &&
                 sectionDropDownList.SelectedValue != "0" && shiftDropDownList.SelectedValue == "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where u.VarSection == sectionDropDownList.SelectedValue && stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#4
        else if (classDropDownList.SelectedItem.Value == "0" && sessionDropDownList.SelectedValue == "0" &&
                 sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where u.VarShiftCode == shiftDropDownList.SelectedValue && stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#5
        else if (classDropDownList.SelectedItem.Value != "0" && sessionDropDownList.SelectedValue != "0" &&
                 sectionDropDownList.SelectedValue == "0" && shiftDropDownList.SelectedValue == "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarClassID == classDropDownList.SelectedItem.Value &&
                    u.VarSessionId == sessionDropDownList.SelectedValue && stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#6
        else if (classDropDownList.SelectedItem.Value != "0" && sessionDropDownList.SelectedValue == "0" &&
                 sectionDropDownList.SelectedValue != "0" && shiftDropDownList.SelectedValue == "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarClassID == classDropDownList.SelectedItem.Value &&
                    u.VarSection == sectionDropDownList.SelectedValue && stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#7
        else if (classDropDownList.SelectedItem.Value == "0" &&
                 sessionDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0" &&
                 shiftDropDownList.SelectedValue == "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into
                    shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarSection == sectionDropDownList.SelectedItem.Value &&
                    u.VarSessionId == sessionDropDownList.SelectedValue && stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#8
        else if (classDropDownList.SelectedItem.Value != "0" &&
                 sessionDropDownList.SelectedValue == "0" &&
                 sectionDropDownList.SelectedValue == "0" &&
                 shiftDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId into
                    sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID into
                    stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into
                    shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into
                    campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarClassID == classDropDownList.SelectedItem.Value &&
                    u.VarShiftCode == shiftDropDownList.SelectedValue && stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#9
        else if (classDropDownList.SelectedItem.Value == "0" &&
                 sessionDropDownList.SelectedValue == "0" &&
                 sectionDropDownList.SelectedValue != "0" &&
                 shiftDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId into
                    sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID into
                    stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode into
                    shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into
                    campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into
                    uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarSection == sectionDropDownList.SelectedItem.Value &&
                    u.VarShiftCode == shiftDropDownList.SelectedValue &&
                    stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#10
        else if (classDropDownList.SelectedItem.Value == "0" &&
                 sessionDropDownList.SelectedValue != "0" &&
                 sectionDropDownList.SelectedValue == "0" &&
                 shiftDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId
                    into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals stu.VarStudentID
                    into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals shi.VarShiftCode
                    into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code into
                    campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId into
                    uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarSessionId == sessionDropDownList.SelectedItem.Value &&
                    u.VarShiftCode == shiftDropDownList.SelectedValue &&
                    stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }

            //#11
        else if (classDropDownList.SelectedItem.Value != "0" &&
                 sessionDropDownList.SelectedValue != "0" &&
                 sectionDropDownList.SelectedValue != "0" &&
                 shiftDropDownList.SelectedValue == "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID into
                    cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals
                    s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals
                    stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals
                    shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals camp.house_Code
                    into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals sec.SectionId
                    into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarClassID == classDropDownList.SelectedItem.Value &&
                    u.VarSessionId == sessionDropDownList.SelectedValue &&
                    u.VarSection == sectionDropDownList.SelectedValue &&
                    stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }


            //#12
        else if (classDropDownList.SelectedItem.Value != "0" &&
                 sessionDropDownList.SelectedValue != "0" &&
                 sectionDropDownList.SelectedValue == "0" &&
                 shiftDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID
                    into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals
                    s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals
                    stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals
                    shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals
                    camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals
                    sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarClassID == classDropDownList.SelectedItem.Value &&
                    u.VarSessionId == sessionDropDownList.SelectedValue &&
                    u.VarShiftCode == shiftDropDownList.SelectedValue &&
                    stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }

            //#13
        else if (classDropDownList.SelectedItem.Value != "0" &&
                 sessionDropDownList.SelectedValue == "0" &&
                 sectionDropDownList.SelectedValue != "0" &&
                 shiftDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals c.VarClassID
                    into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals
                    s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals
                    stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals
                    shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals
                    camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals
                    sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarClassID == classDropDownList.SelectedItem.Value &&
                    u.VarShiftCode == shiftDropDownList.SelectedValue &&
                    u.VarSection == sectionDropDownList.SelectedValue &&
                    stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }

            //#14
        else if (classDropDownList.SelectedItem.Value == "0" &&
                 sessionDropDownList.SelectedValue != "0" &&
                 sectionDropDownList.SelectedValue != "0" &&
                 shiftDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals
                    c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId equals
                    s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals
                    stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode equals
                    shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals
                    camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection equals
                    sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarShiftCode ==
                    shiftDropDownList.SelectedItem.Value &&
                    u.VarSessionId ==
                    sessionDropDownList.SelectedValue &&
                    u.VarSection ==
                    sectionDropDownList.SelectedValue &&
                    stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }

            //#15
        else if (classDropDownList.SelectedItem.Value != "0" &&
                 sessionDropDownList.SelectedValue != "0" &&
                 sectionDropDownList.SelectedValue != "0" &&
                 shiftDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                join c in db.Classes on u.VarClassID equals
                    c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId
                    equals s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals
                    stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode
                    equals shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals
                    camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection
                    equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where
                    u.VarClassID ==
                    classDropDownList.SelectedItem.Value &&
                    u.VarSessionId ==
                    sessionDropDownList.SelectedValue &&
                    u.VarSection ==
                    sectionDropDownList.SelectedValue &&
                    u.VarShiftCode ==
                    shiftDropDownList.SelectedValue &&
                    stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
            //#16
        else
        {
            var his = from u in db.tbl_Present_classes
                //where u.VarClassID == classDropDownList.SelectedItem.Value
                join c in db.Classes on u.VarClassID equals
                    c.VarClassID into cGroup
                from c in cGroup.DefaultIfEmpty()
                join s in db.SessionInfos on u.VarSessionId
                    equals s.VarSessionId into sGroup
                from s in sGroup.DefaultIfEmpty()
                join stu in db.Students on u.VarStudentID equals
                    stu.VarStudentID into stuGroup
                from stu in stuGroup.DefaultIfEmpty()
                join shi in db.ShiftInfos on u.VarShiftCode
                    equals shi.VarShiftCode into shiGroup
                from shi in shiGroup.DefaultIfEmpty()
                join camp in db.tblhouses on u.CampusId equals
                    camp.house_Code into campGroup
                from camp in campGroup.DefaultIfEmpty()
                join sec in db.tblSections on u.VarSection
                    equals sec.SectionId into uGroup
                from sec in uGroup.DefaultIfEmpty()
                where stu.Status != "L"
                //orderby u.VarStudentID descending
                select
                    new
                    {
                        u.VarStudentID,
                        u.StudentRoll,
                        u.VarSection,
                        stu.VarStudentFirstName,
                        stu.VarStudentMeddleName,
                        stu.VarStudentLastName,
                        shi.VarShiftName,
                        c.VarClassName,
                        s.VarSessionName,
                        camp.house_name,
                        sec.varSectionName
                    };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
        }
    }

    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void OnDataBound(object sender, EventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        for (int i = 0; i < GridView1.Columns.Count; i++)
        {
            TableHeaderCell cell = new TableHeaderCell();
            TextBox txtSearch = new TextBox();
            txtSearch.Attributes["placeholder"] = GridView1.Columns[i].HeaderText;
            txtSearch.CssClass = "search_textbox";
            cell.Controls.Add(txtSearch);
            row.Controls.Add(cell);
        }
        if (row!=null)
        {
            GridView1.HeaderRow.Parent.Controls.AddAt(1, row);
        }
        
    }
}