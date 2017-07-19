using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Info_Entry_StudentTransfer : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //headTCampusDropDown.Visible = false;
            transferButton.Visible = false;
        }
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        GridView1.Visible = true;
        transferButton.Visible = true;

        //1
        if (pClassDropDownList.SelectedItem.Value != "0" && pSessionDropDownList.SelectedItem.Value != "0" &&
            pShiftDropDownList.SelectedItem.Value != "0" && pSectionDropDownList.SelectedItem.Value != "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarClassID == pClassDropDownList.SelectedItem.Value &&
                          u.VarSessionId == pSessionDropDownList.SelectedItem.Value &&
                          u.VarShiftCode == pShiftDropDownList.SelectedItem.Value &&
                          u.VarSection == pSectionDropDownList.SelectedItem.Value && s.Status != "L"
                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //2
        else if (pClassDropDownList.SelectedItem.Value != "0" && pSessionDropDownList.SelectedItem.Value != "0" &&
                 pShiftDropDownList.SelectedItem.Value == "0" && pSectionDropDownList.SelectedItem.Value != "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarClassID == pClassDropDownList.SelectedItem.Value &&
                          u.VarSessionId == pSessionDropDownList.SelectedItem.Value &&
                          u.VarSection == pSectionDropDownList.SelectedItem.Value && s.Status != "L"
                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //3
        else if (pClassDropDownList.SelectedItem.Value != "0" && pSessionDropDownList.SelectedItem.Value == "0" &&
                 pShiftDropDownList.SelectedItem.Value != "0" && pSectionDropDownList.SelectedItem.Value != "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarClassID == pClassDropDownList.SelectedItem.Value &&
                          u.VarShiftCode == pShiftDropDownList.SelectedItem.Value &&
                          u.VarSection == pSectionDropDownList.SelectedItem.Value && s.Status != "L"
                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //4
        else if (pClassDropDownList.SelectedItem.Value == "0" && pSessionDropDownList.SelectedItem.Value != "0" &&
                 pShiftDropDownList.SelectedItem.Value != "0" && pSectionDropDownList.SelectedItem.Value != "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarSessionId == pSessionDropDownList.SelectedItem.Value &&
                          u.VarShiftCode == pShiftDropDownList.SelectedItem.Value &&
                          u.VarSection == pSectionDropDownList.SelectedItem.Value && s.Status != "L"
                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //5
        else if (pClassDropDownList.SelectedItem.Value != "0" &&
                 pSessionDropDownList.SelectedItem.Value != "0" &&
                 pShiftDropDownList.SelectedItem.Value != "0" &&
                 pSectionDropDownList.SelectedItem.Value == "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarSessionId == pSessionDropDownList.SelectedItem.Value &&
                          u.VarSessionId == pSessionDropDownList.SelectedItem.Value &&
                          u.VarShiftCode == pShiftDropDownList.SelectedItem.Value && s.Status != "L"
                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //6
        else if (pClassDropDownList.SelectedItem.Value != "0" &&
                 pSessionDropDownList.SelectedItem.Value != "0" &&
                 pShiftDropDownList.SelectedItem.Value == "0" &&
                 pSectionDropDownList.SelectedItem.Value == "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarClassID == pClassDropDownList.SelectedItem.Value &&
                          u.VarSessionId == pSessionDropDownList.SelectedValue && s.Status != "L"

                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //7
        else if (pClassDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedItem.Value != "0" &&
                 pShiftDropDownList.SelectedItem.Value != "0" &&
                 pSectionDropDownList.SelectedItem.Value == "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarSessionId == pSessionDropDownList.SelectedItem.Value &&
                          u.VarShiftCode == pShiftDropDownList.SelectedItem.Value && s.Status != "L"

                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //8
        else if (pClassDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedItem.Value == "0" &&
                 pShiftDropDownList.SelectedItem.Value != "0" &&
                 pSectionDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarShiftCode == pShiftDropDownList.SelectedItem.Value &&
                          u.VarSection == pSectionDropDownList.SelectedValue && s.Status != "L"

                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //9
        else if (pClassDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedItem.Value != "0" &&
                 pShiftDropDownList.SelectedItem.Value == "0" &&
                 pSectionDropDownList.SelectedValue != "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      orderby s.VarStudentFirstName ascending 
                      where
                          u.VarSessionId == pSessionDropDownList.SelectedItem.Value &&
                          u.VarSection == pSectionDropDownList.SelectedValue &&
                          s.Status != "L"
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //10
        else if (pClassDropDownList.SelectedItem.Value != "0" &&
                 pSessionDropDownList.SelectedItem.Value == "0" &&
                 pShiftDropDownList.SelectedItem.Value != "0" &&
                 pSectionDropDownList.SelectedValue == "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarClassID == pClassDropDownList.SelectedItem.Value &&
                          u.VarShiftCode == pShiftDropDownList.SelectedItem.Value &&
                          s.Status != "L"

                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //11
        else if (pClassDropDownList.SelectedItem.Value != "0" &&
                 pSessionDropDownList.SelectedItem.Value == "0" &&
                 pShiftDropDownList.SelectedItem.Value == "0" &&
                 pSectionDropDownList.SelectedItem.Value != "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals s.VarStudentID
                      where
                          u.VarClassID == pClassDropDownList.SelectedItem.Value &&
                          u.VarSection == pSectionDropDownList.SelectedItem.Value &&
                          s.Status != "L"

                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //12
        else if (pClassDropDownList.SelectedItem.Value != "0" &&
                 pSessionDropDownList.SelectedItem.Value == "0" &&
                 pShiftDropDownList.SelectedItem.Value == "0" &&
                 pSectionDropDownList.SelectedItem.Value == "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals
                          s.VarStudentID
                      where
                          u.VarClassID == pClassDropDownList.SelectedItem.Value &&
                          s.Status != "L"

                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //13
        else if (pClassDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedItem.Value != "0" &&
                 pShiftDropDownList.SelectedItem.Value == "0" &&
                 pSectionDropDownList.SelectedItem.Value == "0")
        {
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals c.VarClassID
                      join s in db.Students on u.VarStudentID equals
                          s.VarStudentID
                      where
                          u.VarSessionId ==
                          pSessionDropDownList.SelectedItem.Value &&
                          s.Status != "L"

                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //14
        else if (pClassDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedItem.Value == "0" &&
                 pShiftDropDownList.SelectedItem.Value != "0" &&
                 pSectionDropDownList.SelectedItem.Value == "0")
        {
            //pSectionDropDownList.SelectedValue = std.VarSection;
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals
                          c.VarClassID
                      join s in db.Students on u.VarStudentID equals
                          s.VarStudentID
                      where
                          u.VarShiftCode ==
                          pShiftDropDownList.SelectedItem.Value &&
                          s.Status != "L"

                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        //15
        else if (pClassDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedItem.Value == "0" &&
                 pShiftDropDownList.SelectedItem.Value == "0" &&
                 pSectionDropDownList.SelectedItem.Value != "0")
        {
            //pSectionDropDownList.SelectedValue = std.VarSection;
            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals
                          c.VarClassID
                      join s in db.Students on u.VarStudentID equals
                          s.VarStudentID
                      where
                          u.VarSection ==
                          pSectionDropDownList.SelectedItem.Value &&
                          s.Status != "L"

                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }
        else if (studentIdTextBox.Text != "")
        {
            tbl_Present_class std =
                db.tbl_Present_classes.FirstOrDefault(
                    u => u.VarStudentID == studentIdTextBox.Text);
            if (std != null)
                pSessionDropDownList.SelectedValue =
                    std.VarSessionId;
            pClassDropDownList.SelectedValue = std.VarClassID;
            pShiftDropDownList.SelectedValue = std.VarShiftCode;
            //pSectionDropDownList.SelectedValue = std.VarSection;

            var his = from u in db.tbl_Present_classes
                      join c in db.Classes on u.VarClassID equals
                          c.VarClassID
                      join s in db.Students on u.VarStudentID equals
                          s.VarStudentID
                      where
                          s.Status != "L" &&
                          u.VarStudentID == studentIdTextBox.Text
                      orderby s.VarStudentFirstName ascending 
                      select
                          new
                          {
                              u.VarStudentID,
                              s.VarStudentFirstName,
                              s.VarStudentMeddleName,
                              s.VarStudentLastName,
                              c.VarClassName
                          };


            GridView1.DataSource = his.AsEnumerable();
            GridView1.DataBind();
            //headTCampusDropDown.Visible = true;
        }

            //else if (pClassDropDownList.SelectedItem.Value == "0" && pSessionDropDownList.SelectedItem.Value == "0" && pShiftDropDownList.SelectedItem.Value == "0")
        //{
        //    var his = from u in db.tbl_Present_classes
        //              where u.VarSection == pSectionDropDownList.SelectedItem.Value
        //              join c in db.Classes on u.VarClassID equals c.VarClassID
        //              join s in db.Students on u.VarStudentID equals s.VarStudentID
        //              //orderby u.VarStudentID descending
        //              select new { u.VarStudentID, s.VarStudentFirstName, s.VarStudentMeddleName, s.VarStudentLastName, c.VarClassName };


            //    GridView1.DataSource = his.AsEnumerable();
        //    GridView1.DataBind();

            //}
        //else if (pClassDropDownList.SelectedItem.Value == "0" && pSessionDropDownList.SelectedItem.Value == "0" && pShiftDropDownList.SelectedItem.Value != "0")
        //{
        //    var his = from u in db.tbl_Present_classes
        //              join c in db.Classes on u.VarClassID equals c.VarClassID
        //              join s in db.Students on u.VarStudentID equals s.VarStudentID
        //              where u.VarShiftCode == pShiftDropDownList.SelectedItem.Value && s.Status != "L"

            //              //orderby u.VarStudentID descending
        //              select new { u.VarStudentID, s.VarStudentFirstName, s.VarStudentMeddleName, s.VarStudentLastName, c.VarClassName };


            //    GridView1.DataSource = his.AsEnumerable();
        //    GridView1.DataBind();

            //}
        //else if (pClassDropDownList.SelectedItem.Value == "0" && pSessionDropDownList.SelectedItem.Value != "0" && pShiftDropDownList.SelectedItem.Value == "0" && studentIdTextBox.Text == "")
        //{
        //    var his = from u in db.tbl_Present_classes
        //              join c in db.Classes on u.VarClassID equals c.VarClassID
        //              join s in db.Students on u.VarStudentID equals s.VarStudentID
        //              where u.VarSessionId == pSessionDropDownList.SelectedItem.Value && s.Status != "L"

            //              //orderby u.VarStudentID descending
        //              select new { u.VarStudentID, s.VarStudentFirstName, s.VarStudentMeddleName, s.VarStudentLastName, c.VarClassName };


            //    GridView1.DataSource = his.AsEnumerable();
        //    GridView1.DataBind();

            //}
        //else if (pClassDropDownList.SelectedItem.Value != "0" && pSessionDropDownList.SelectedItem.Value == "0" && pShiftDropDownList.SelectedItem.Value == "0" && pSectionDropDownList.SelectedItem.Value == "0")
        //{
        //    var his = from u in db.tbl_Present_classes

            //              join c in db.Classes on u.VarClassID equals c.VarClassID
        //              join s in db.Students on u.VarStudentID equals s.VarStudentID
        //              where u.VarClassID == pClassDropDownList.SelectedItem.Value && s.Status != "L"
        //              //orderby u.VarStudentID descending
        //              select new { u.VarStudentID, s.VarStudentFirstName, s.VarStudentMeddleName, s.VarStudentLastName, c.VarClassName };


            //    GridView1.DataSource = his.AsEnumerable();
        //    GridView1.DataBind();

            //}
        //else if ( pClassDropDownList.SelectedItem.Value == "0" && pSessionDropDownList.SelectedItem.Value != "0" && pShiftDropDownList.SelectedItem.Value == "0")
        //{
        //    var his = from u in db.tbl_Present_classes

            //              join c in db.Classes on u.VarClassID equals c.VarClassID
        //              join s in db.Students on u.VarStudentID equals s.VarStudentID
        //              where u.VarStudentID == studentIdTextBox.Text && u.VarSessionId == pSessionDropDownList.SelectedItem.Value && s.Status != "L"
        //              //orderby u.VarStudentID descending
        //              select new { u.VarStudentID, s.VarStudentFirstName, s.VarStudentMeddleName, s.VarStudentLastName, c.VarClassName };


            //    GridView1.DataSource = his.AsEnumerable();
        //    GridView1.DataBind();
        //}
        else if (pClassDropDownList.SelectedItem.Value == "0" &&
                 pSessionDropDownList.SelectedItem.Value == "0" &&
                 pShiftDropDownList.SelectedItem.Value == "0")
        {
            failStatusLabel.InnerText =
                "Please select any Option";
        }


        else
        {
            failStatusLabel.InnerText = "Student not found...!";
        }
    }

    protected void transferButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";


        if (tSessionDropDownList.SelectedValue != "")
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                if (!((CheckBox)gvrow.Cells[9].FindControl("transferConfirmCheckBox")).Checked)
                {
                    string studentId = ((Label)gvrow.Cells[1].FindControl("Label1")).Text;

                    var transferHistory = new tbl_TransferHistory();

                    tbl_Present_class pClass = db.tbl_Present_classes.FirstOrDefault(u => u.VarStudentID == studentId);
                    Student studentCkh =
                        (from d in db.Students
                         where d.VarStudentID == studentId && d.VarSessionName == pSessionDropDownList.SelectedValue
                         select d).SingleOrDefault();

                    if (studentCkh != null)
                    {
                        string r = ((TextBox)gvrow.Cells[7].FindControl("rollTextBox")).Text;
                        studentCkh.VarSessionName = tSessionDropDownList.SelectedValue;
                        studentCkh.RecommendAdmissionSection =
                            ((DropDownList)gvrow.Cells[5].FindControl("tSectionDropDown")).Text;

                        studentCkh.PClassID = ((DropDownList)gvrow.Cells[4].FindControl("trnsClassDropDownList")).Text;
                        if (r != "") studentCkh.StudentRoll = Convert.ToInt32(r);
                        studentCkh.VarShiftCode = ((DropDownList)gvrow.Cells[6].FindControl("tShiftDropDown")).Text;
                        studentCkh.CampusId = ((DropDownList)gvrow.Cells[7].FindControl("tCampusDropDown")).Text;
                        studentCkh.VarSessionName = tSessionDropDownList.SelectedValue;
                        transferHistory.VarStudentId = studentId;
                        transferHistory.PreSession = pSessionDropDownList.SelectedValue;
                        string className = ((Label)gvrow.Cells[3].FindControl("Label5")).Text;
                        Class cls = db.Classes.FirstOrDefault(u => u.VarClassName == className);
                        if (cls != null) transferHistory.PreClass = cls.VarClassID;
                        transferHistory.PreSection = pSectionDropDownList.SelectedValue;
                        transferHistory.PreShift = pShiftDropDownList.SelectedValue;
                        if (pClass != null) transferHistory.PreRoll = pClass.StudentRoll.ToString();
                        if (pClass != null) transferHistory.PreCampus = pClass.CampusId;
                        string classId = ((DropDownList)gvrow.Cells[4].FindControl("trnsClassDropDownList")).Text;
                        transferHistory.TraSession = tSessionDropDownList.SelectedValue;
                        transferHistory.TraClass = classId;
                        transferHistory.TraSection =
                            ((DropDownList)gvrow.Cells[5].FindControl("tSectionDropDown")).Text;
                        transferHistory.TraShift = ((DropDownList)gvrow.Cells[6].FindControl("tShiftDropDown")).Text;
                        transferHistory.NewRoll = ((TextBox)gvrow.Cells[7].FindControl("rollTextBox")).Text;
                        transferHistory.TraCampus = ((DropDownList)gvrow.Cells[7].FindControl("tCampusDropDown")).Text;
                        transferHistory.Status =
                            ((CheckBox)gvrow.Cells[9].FindControl("repeatConfirmCheckBox")).Checked ? 3 : 1;

                        transferHistory.uid = Session["uid"].ToString();
                        transferHistory.InputDate = DateTime.Now;
                        tbl_Present_class check =
                            (from d in db.tbl_Present_classes
                             where d.VarStudentID == studentId
                             select d).SingleOrDefault();

                        if (check != null)
                        {
                            check.VarShiftCode = ((DropDownList)gvrow.Cells[6].FindControl("tShiftDropDown")).Text;
                            check.VarClassID = ((DropDownList)gvrow.Cells[4].FindControl("trnsClassDropDownList")).Text;
                            check.VarSection = ((DropDownList)gvrow.Cells[5].FindControl("tSectionDropDown")).Text;
                            check.VarSessionId = tSessionDropDownList.SelectedValue;
                            if (r != "") check.StudentRoll = Convert.ToInt32(r);
                            check.CampusId = ((DropDownList)gvrow.Cells[7].FindControl("tCampusDropDown")).Text;
                        }

                        IQueryable<tbl_feesInfo> feesInfo =
                            (db.tbl_feesInfos.Where(f => f.VarClassId == classId && f.FeesType != 1 && f.FeesId != 5))
                                .AsQueryable();
                        //decimal netFees = feesInfo.Sum(x=>x.Fees)*12;

                        foreach (tbl_feesInfo fess in feesInfo)
                        {
                            var stdAccount = new tbl_Students_Account();
                            tbl_Students_Account stdAccountChk = (from a in db.tbl_Students_Accounts
                                                                  where
                                                                      a.VarStudentId == studentId && a.VarSessionId == pSessionDropDownList.SelectedValue &&
                                                                      a.PaidFeesId == fess.FeesId
                                                                  select a).SingleOrDefault();
                            if (stdAccountChk == null)
                            {
                                if (((CheckBox)gvrow.Cells[10].FindControl("repeatConfirmCheckBox")).Checked)
                                {
                                    decimal fees = fess.Fees * 6;
                                    decimal vat = (fess.Fees * 6 * (decimal).075);
                                    stdAccount.VarStudentId = studentId;
                                    stdAccount.VarSessionId = tSessionDropDownList.SelectedValue;
                                    stdAccount.PayableFeesId = fess.FeesId;
                                    stdAccount.PayableAmount = fees;
                                    stdAccount.PayableVat = vat;
                                    stdAccount.NetPayable = fees + vat;
                                    stdAccount.FeesAssignDate = DateTime.Now;
                                }
                                else
                                {
                                    decimal fees = fess.Fees * 12;
                                    decimal vat = (fess.Fees * 12 * (decimal).075);
                                    stdAccount.VarStudentId = studentId;
                                    stdAccount.VarSessionId = tSessionDropDownList.SelectedValue;
                                    stdAccount.PayableFeesId = fess.FeesId;
                                    stdAccount.PayableAmount = fees;
                                    stdAccount.PayableVat = vat;
                                    stdAccount.NetPayable = fees + vat;
                                    stdAccount.FeesAssignDate = DateTime.Now;
                                }
                            }
                            db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
                        }


                        db.tbl_TransferHistories.InsertOnSubmit(transferHistory);
                        if (cls != null && cls.ClassType == 2)
                        {
                            var getNewClsSubject = (from unit in db.tbl_EdexelunitCodes
                                                    join subAssign in db.tbl_EdexcelSubjectAssigns on unit.SpecificationCode equals subAssign.SubjectId
                                                    where subAssign.StudentId == studentId && unit.Class == classId
                                                    select new
                                                    {
                                                        subAssign.SubjectId,
                                                        unit.UnitCodeSpeCode
                                                    }
                                               ).Except
                                               (
                                               from s in db.tbl_BoardExamSubAssigns

                                               where
                                                   s.StudentId == studentId
                                               select new
                                               {
                                                     s.SubjectId,
                                                   UnitCodeSpeCode = s.UnitCode
                                               });



                            foreach (var addSub in getNewClsSubject)
                            {
                                if (addSub.SubjectId != "YMA01" && addSub.SubjectId != "YFM01" &&
                                    addSub.SubjectId != "XPM01")
                                {
                                    var subjectAssign = new tbl_EdexcelSubjectAssign();
                                    subjectAssign.Session = tSessionDropDownList.SelectedValue;
                                    subjectAssign.ClassId = classId;
                                    subjectAssign.StudentId = studentId;
                                    subjectAssign.SubjectId = addSub.SubjectId;
                                    subjectAssign.Section =
                                        ((DropDownList)gvrow.Cells[5].FindControl("tSectionDropDown")).Text;
                                    subjectAssign.UnitCodeNo = addSub.UnitCodeSpeCode;
                                    var unitCod =
                                        db.tbl_EdexelunitCodes.FirstOrDefault(
                                            x => x.UnitCodeSpeCode == addSub.UnitCodeSpeCode);
                                    if (unitCod != null) subjectAssign.UnitCode = unitCod.UnitCode;
                                    subjectAssign.VarBranchId = Session["VarBranchId"].ToString();
                                    subjectAssign.uid = Session["uid"].ToString();
                                    subjectAssign.EntryDate = DateTime.Now;

                                    db.tbl_EdexcelSubjectAssigns.InsertOnSubmit(subjectAssign);
                                    db.SubmitChanges();
                                }

                            }
                            var getMathSubject = (from subAssign in db.tbl_EdexcelSubjectAssigns
                                                  where subAssign.StudentId == studentId && subAssign.ClassId == cls.VarClassID
                                                  select new
                                                  {
                                                      subAssign.SubjectId,
                                                      subAssign.UnitCodeNo
                                                  }
                                                    ).Except
                                                    (
                                                    from s in db.tbl_BoardExamSubAssigns

                                                    where
                                                        s.StudentId == studentId
                                                    select new
                                                    {
                                                        SubjectId = s.SubjectId,
                                                        UnitCodeNo = s.UnitCode
                                                    });
                            foreach (var addSubM in getMathSubject)
                            {
                                var checkData = db.tbl_EdexcelSubjectAssigns.FirstOrDefault(z => z.StudentId == studentId
                                                                                                 &&
                                                                                                 z.SubjectId ==
                                                                                                 addSubM.SubjectId &&
                                                                                                 z.UnitCodeNo ==
                                                                                                 addSubM.UnitCodeNo &&
                                                                                                 z.Session ==
                                                                                                 tSessionDropDownList
                                                                                                     .SelectedValue);
                                if (checkData == null)
                                {
                                    if (addSubM.SubjectId == "YMA01")
                                    {

                                        var subjectAssign = new tbl_EdexcelSubjectAssign();
                                        subjectAssign.Session = tSessionDropDownList.SelectedValue;
                                        subjectAssign.ClassId = classId;
                                        subjectAssign.StudentId = studentId;
                                        subjectAssign.SubjectId = addSubM.SubjectId;
                                        subjectAssign.Section = ((DropDownList)gvrow.Cells[5].FindControl("tSectionDropDown")).Text;
                                        subjectAssign.UnitCodeNo = addSubM.UnitCodeNo;
                                        var unitCod =
                                            db.tbl_EdexelunitCodes.FirstOrDefault(x => x.UnitCodeSpeCode == addSubM.UnitCodeNo);
                                        if (unitCod != null) subjectAssign.UnitCode = unitCod.UnitCode;
                                        subjectAssign.VarBranchId = Session["VarBranchId"].ToString();
                                        subjectAssign.uid = Session["uid"].ToString();
                                        subjectAssign.EntryDate = DateTime.Now;

                                        db.tbl_EdexcelSubjectAssigns.InsertOnSubmit(subjectAssign);
                                        db.SubmitChanges();
                                    }
                                }
                            }
                        }
                        else if (cls != null && cls.ClassType == 1)
                        {
                            var getPreviousSub = from stdSub in db.tbl_StudentSubjectAssigns
                                where
                                    stdSub.VarStudentId == studentId && stdSub.ClassId == cls.VarClassID &&
                                    stdSub.VarSessionId == pSessionDropDownList.SelectedValue &&
                                    stdSub.VarBranchId == Session["VarBranchId"].ToString()
                                select new {stdSub.VarSubjectCode, stdSub.VarStudentId};

                            foreach (var assign in getPreviousSub)
                            {
                                var subAssign = new tbl_StudentSubjectAssign();

                                subAssign.VarStudentId = assign.VarStudentId;
                                subAssign.ClassId = classId;
                                subAssign.VarSection = ((DropDownList)gvrow.Cells[5].FindControl("tSectionDropDown")).Text;
                                subAssign.VarSubjectCode = assign.VarSubjectCode;
                                subAssign.VarSessionId = tSessionDropDownList.SelectedValue;
                                subAssign.VarBranchId = Session["VarBranchId"].ToString();
                                subAssign.uid = Session["uid"].ToString();
                                subAssign.EntryDate = DateTime.Now.Date;
                                db.tbl_StudentSubjectAssigns.InsertOnSubmit(subAssign);
                                db.SubmitChanges();
                            }
                           
                        }
                    }

                    db.SubmitChanges();
                }
            }
            successStatusLabel.InnerText = "Students Transfer Successfull....!!!!";
            //headTCampusDropDown.Visible = false;
            transferButton.Visible = false;
            GridView1.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        else
        {
            failStatusLabel.InnerText = "Transfer Session Required....!";
        }
    }

    protected void pClassDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        pSectionDropDownList.Items.Clear();
        pSectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void headTClassDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddl = (DropDownList)sender;
        string indexx = ddl.SelectedValue;
        foreach (GridViewRow row in GridView1.Rows)
        {
            var clsDownList = ((DropDownList)row.FindControl("trnsClassDropDownList"));

            clsDownList.SelectedValue = indexx;
        }
    }

    protected void headTCampusDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddl = (DropDownList)sender;
        string indexx = ddl.SelectedValue;
        foreach (GridViewRow row in GridView1.Rows)
        {
            var clsDownList = ((DropDownList)row.FindControl("tCampusDropDown"));

            clsDownList.SelectedValue = indexx;
        }
    }
}