using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubjectUI_EdexcelSubjectAssign : Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    private DataTable _dataTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            branchInitialTextBox.ReadOnly = true;
            //Session.Clear();
            Session["subjectAddGridViewData"] = null;
            if (Session["VarBranchId"] != null)
            {
                int branchId = Convert.ToInt32(Session["VarBranchId"]);
                Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
                branchInitialTextBox.Text = branchInitial.VarBranchInitial;
                //branchInitialTextBox.ReadOnly = true;
                stdSearchLiteral.Text = "";
                saveButton.Visible = false;
                addButton.Visible = false;
                clearButton.Visible = false;
            }
            //ListItem liDisease = new ListItem("Select Subject", "-1");
            //subjectDropDown.Items.Insert(0, liDisease);
            //saveButton.Attributes.Add("onClientClick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(saveButton, null) + ";");
            //addButton.Attributes.Add("onClientClick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(addButton, null) + ";");
        }
    }


    public void PopulateGridView()
    {
        //DataColumn Id = new DataColumn();
        ////Id.DataType = System.Type.GetType("System.Int32");
        //Id.AutoIncrement = true;
        //Id.AutoIncrementSeed = 1;
        //Id.AutoIncrementStep = 1;

        //_dataTable.Columns.Add("StudentId", typeof(string));
        _dataTable.Columns.Add("VarSubjectName", typeof (string));
        _dataTable.Columns.Add("UnitCode", typeof (string));
        _dataTable.Columns.Add("varSectionName", typeof (string));
        //_dataTable.Columns.Add("Id", typeof(int));
        _dataTable.PrimaryKey = new[] {_dataTable.Columns["UnitCode"], _dataTable.Columns["VarSubjectName"]};

        _dataTable.AcceptChanges();
        Session["subjectAddGridViewData"] = _dataTable;
    }

    //private string str;
    private bool InsertDataIntoGridView()
    {
        //ArrayList list = new ArrayList();
        _dataTable = (DataTable) Session["subjectAddGridViewData"];
        foreach (GridViewRow gvrow in unitCodeGrid.Rows)
        {
            var chk = (CheckBox) gvrow.FindControl("CheckBox1");
            string subjectName = subjectDropDown.SelectedItem.Text;
            string str = gvrow.Cells[0].Text;
            string section = ((DropDownList) gvrow.Cells[2].FindControl("sectionDropDown")).SelectedItem.Text;

            var bc = new object[2] {str, subjectName};
            DataRow foundRow = _dataTable.Rows.Find(bc);
            if (foundRow != null)
            {
                if (chk != null && chk.Checked)
                {
                    int index = _dataTable.Rows.IndexOf(foundRow);
                    _dataTable.Rows.RemoveAt(index);
                    _dataTable.Rows.Add(subjectDropDown.SelectedItem.Text, str, section);
                    _dataTable.AcceptChanges();
                }
                else
                {
                    int index = _dataTable.Rows.IndexOf(foundRow);
                    _dataTable.Rows.RemoveAt(index);
                }
            }
            else
            {
                if (chk != null && chk.Checked)
                {
                    _dataTable.Rows.Add(subjectDropDown.SelectedItem.Text, str, section);
                    _dataTable.AcceptChanges();
                }
            }
        }
        Session["subjectAddGridViewData"] = _dataTable;
        addSubjectGridView.DataSource = _dataTable;
        addSubjectGridView.DataBind();

        return true;
    }

    ////Delete row of SubjectAddGridView
    //protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int index = Convert.ToInt32(e.RowIndex);
    //    _dataTable = Session["subjectAddGridViewData"] as DataTable;
    //    if (_dataTable != null)
    //    {
    //        _dataTable.Rows[index].Delete();
    //        Session["subjectAddGridViewData"] = _dataTable;
    //        addSubjectGridView.DataSource = _dataTable;
    //    }
    //    addSubjectGridView.DataBind();
    //}

    //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        string item = e.Row.Cells[2].Text;
    //        foreach (Button button in e.Row.Cells[3].Controls.OfType<Button>())
    //        {
    //            if (button.CommandName == "Delete")
    //            {
    //                button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
    //            }
    //        }
    //    }
    //}


    protected void addButton_Click1(object sender, EventArgs e)
    {
        if (txtStdId.Text != "")
        {
            if (Session["subjectAddGridViewData"] == null)
            {
                PopulateGridView();
            }
            if (!InsertDataIntoGridView())
            {
                stdSearchLiteral.Text = "Error Message";
            }
        }
        else
        {
            stdSearchLiteral.Text = "Please Insert Student ID";
        }

        saveButton.Visible = true;
        clearButton.Visible = true;
        //Session["subjectAddGridViewData"] = null;
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        //var data = db.tbl_EdexcelSubjectAssigns.Where(d => d.StudentId == txtStdId.Text).FirstOrDefault();
        //if (data!=null)
        //{
        //    Literal2.Text = "<p style='color:Green;'>Subject already Assign to this student";
        //}

        foreach (GridViewRow gvrow in addSubjectGridView.Rows)
        {
            var edxSubAssign = new tbl_EdexcelSubjectAssign();
            //edxSubAssign.ClassId = gvrow.Cells[0].Text;
            //edxSubAssign.StudentId = gvrow.Cells[1].Text;

            string sectionName = gvrow.Cells[2].Text;
            string subjectName = ((Label) gvrow.Cells[1].FindControl("LabelSubject")).Text;
            tbl_Subject subject =
                db.tbl_Subjects.FirstOrDefault(
                    s => s.VarSubjectName == subjectName && s.ClassId == classDropDown.SelectedValue);

            tblSection sectionN =
                db.tblSections.FirstOrDefault(
                    s => s.varSectionName == sectionName && s.ClassID == classDropDown.SelectedValue);
            edxSubAssign.UnitCode = gvrow.Cells[1].Text;
            if (subject != null) edxSubAssign.SubjectId = subject.VarSubjectCode;
            if (sectionN != null) edxSubAssign.Section = sectionN.SectionId;
            edxSubAssign.Session = sessionDropDownList.SelectedValue;
            edxSubAssign.ClassId = classDropDown.SelectedValue;
            edxSubAssign.StudentId = branchInitialTextBox.Text + "" + txtStdId.Text;
            edxSubAssign.EntryDate = DateTime.Now;
            edxSubAssign.uid = Session["uid"].ToString();
            db.tbl_EdexcelSubjectAssigns.InsertOnSubmit(edxSubAssign);

            db.SubmitChanges();
        }
        successStatusLabel.InnerText = "Subject successfully assigned with ID " + branchInitialTextBox.Text + "" +
                                       txtStdId.Text;
        //Literal2.Text = "<p style='color:Green;'>Subject successfully assigned with ID " + txtStdId.Text;


        addSubjectGridView.DataSource = null;
        Session["subjectAddGridViewData"] = null;
        //unitCodeGrid.DataSource = null;
        addSubjectGridView.DataBind();
        classDropDown.Items.Clear();
        classDropDown.Items.Insert(0, new ListItem("--Select--", "0"));
        subjectDropDown.Items.Clear();
        subjectDropDown.Items.Insert(0, new ListItem("--Select--", "0"));
        //classDropDown.SelectedValue = "";
        txtStdId.Text = string.Empty;
        addButton.Visible = false;
        saveButton.Visible = false;
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        stdSearchLiteral.Text = "";
        Literal2.Text = "";
        failStatusLabel.InnerText = "";
        successStatusLabel.InnerText = "";
        string studentId = branchInitialTextBox.Text + txtStdId.Text;
        IQueryable<string> isSubjectAssign = from c in db.tbl_EdexcelSubjectAssigns
            where c.StudentId == studentId && c.Session == sessionDropDownList.SelectedValue
            select c.StudentId;
        if (isSubjectAssign.FirstOrDefault() == null)
        {
            IQueryable<string> checkExistingStudentId = from c in db.tbl_Present_classes
                where c.VarStudentID == studentId && c.VarSessionId == sessionDropDownList.SelectedValue
                select c.VarStudentID;
            tbl_Present_class presentClass = db.tbl_Present_classes.FirstOrDefault(p => p.VarStudentID == studentId);

            if (presentClass != null)
            {
                string clsId = presentClass.VarClassID;
                Class cls = db.Classes.FirstOrDefault(c => c.VarClassID == clsId);

                if (cls != null && (checkExistingStudentId.FirstOrDefault() != null && cls.ClassType == 2))
                {
                    classDropDown.Items.Clear();
                    classDropDown.Items.Insert(0, new ListItem(cls.VarClassName, cls.VarClassID));
                    //classDropDown.SelectedValue = clsId;
                }

                else
                {
                    stdSearchLiteral.Text = "<p style=color:red>Student Not Found..!";
                }
            }
            else
            {
                stdSearchLiteral.Text = "<p style=color:red>Student Not Exist..!";
            }
        }
        else
        {
            tbl_Present_class presentClass = db.tbl_Present_classes.FirstOrDefault(p => p.VarStudentID == studentId);
            Class cls = db.Classes.FirstOrDefault(c => c.VarClassID == presentClass.VarClassID);
            if (cls != null && cls.ClassType == 2)
            {
                classDropDown.Items.Clear();
                classDropDown.Items.Insert(0, new ListItem(cls.VarClassName, cls.VarClassID));
                //classDropDown.SelectedValue = clsId;

                var his = from u in db.tbl_EdexcelSubjectAssigns
                    where u.StudentId == studentId && u.Session == sessionDropDownList.SelectedValue
                    join s in db.tbl_Subjects on u.SubjectId equals s.VarSubjectCode into sGroup
                    from s in sGroup.DefaultIfEmpty()
                    join sec in db.tblSections on u.Section equals sec.SectionId into uGroup
                    from sec in uGroup.DefaultIfEmpty()
                    select new {s.VarSubjectName, u.UnitCode, sec.varSectionName};
                addSubjectGridView.DataSource = his.AsEnumerable();
                addSubjectGridView.DataBind();
                //_dataTable = his.AsEnumerable() as DataTable;
            }


            //failStatusLabel.InnerText = "Subject Already Assign for ID: " + branchInitialTextBox.Text + "" + txtStdId.Text;
        }
    }

    protected void classDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        subjectDropDown.Items.Clear();
        subjectDropDown.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void sectionDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in unitCodeGrid.Rows)
        {
            ((TextBox) gvrow.Cells[3].FindControl("takenTextBox")).Text = "";
            var chk = (CheckBox) gvrow.FindControl("CheckBox1");
            if (chk != null && chk.Checked)
            {
                //str += "<b>EmpId :- </b>" + gvrow.Cells[1].Text + ", ";
                string str = gvrow.Cells[0].Text;
                //section = gvrow.Cells[2].Text;
                string section = ((DropDownList) gvrow.Cells[2].FindControl("sectionDropDown")).SelectedItem.Value;
                int count = (from p in db.tbl_EdexcelSubjectAssigns
                    where
                        p.UnitCode == str && p.Section == section && p.Session == sessionDropDownList.SelectedValue &&
                        p.ClassId == classDropDown.SelectedValue
                    select p).Count();
                ((TextBox) gvrow.Cells[3].FindControl("takenTextBox")).Text = count.ToString();
            }
        }
    }

    protected void subjectDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        addButton.Visible = true;
    }

    protected void clearButton_Click(object sender, EventArgs e)
    {
        Session["subjectAddGridViewData"] = null;
        addSubjectGridView.DataSource = null;
        addSubjectGridView.DataBind();
        saveButton.Visible = false;
        clearButton.Visible = false;
    }

    protected void addSubjectGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            // Retrieve the row index stored in the 
            // CommandArgument property.
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button 
            // from the Rows collection.
            //GridViewRow gvRow = addSubjectGridView.Rows[index];

            //string deleteSubject = addSubjectGridView.DataKeys[index].Values["UnitCode"].ToString();
            // string s = ((Label)gvRow.Cells[1].FindControl("Label1")).Text;
            // Add code here to add the item to the shopping cart.
            //var delete =
            //from details in db.tbl_EdexcelSubjectAssigns
            //where details.UnitCode == deleteSubject
            //select details;

            //       foreach (var detail in delete)
            //        {
            //            db.tbl_EdexcelSubjectAssigns.DeleteOnSubmit(detail);
            //        }

            //        db.SubmitChanges();

            //    }
        }
    }
}