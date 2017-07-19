using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employee_EmployeeEducation : Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    private DataTable _dataTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["uid"] != null)
                Textuid.Text = Session["uid"].ToString();

            if (Session["VarBranchId"] != null)
                DropDownBranch.SelectedValue = Session["VarBranchId"].ToString();
            if (Session["VarShiftCode"] != null)
                drpshift.SelectedValue = Session["VarShiftCode"].ToString();

            dropDownExmYear.Items.Clear();
            dropDownExmYear.Items.Add("--Year--");
            int currentYear = DateTime.Today.Year;
            for (int i = 70; i >= 0; i--)
            {
                dropDownExmYear.Items.Add((currentYear - i).ToString());
                //dropDownExmYear.Items.Add(new ListItem(NumE));
            }


            Session.Clear();
            //ListItem liDisease = new ListItem("Select Subject", "-1");
            //subjectDropDown.Items.Insert(0, liDisease);
            //saveButton.Attributes.Add("onClientClick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(saveButton, null) + ";");
            //addButton.Attributes.Add("onClientClick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(addButton, null) + ";");
        }
    }


    public void PopulateGridView()
    {
        _dataTable.Columns.Add("VarEmployeeid", typeof (int));
        _dataTable.Columns.Add("NumSlNo", typeof (int));
        _dataTable.Columns.Add("VarExamName", typeof (string));
        _dataTable.Columns.Add("NumExamYear", typeof (string));
        _dataTable.Columns.Add("VarExamSession", typeof (string));
        _dataTable.Columns.Add("VarExamPass", typeof (string));
        _dataTable.Columns.Add("VarExamResult", typeof (string));


        _dataTable.AcceptChanges();
        Session["addEmployyeEducationGridViewData"] = _dataTable;
    }

    private bool InsertDataIntoGridView()
    {
        _dataTable = (DataTable) Session["addEmployyeEducationGridViewData"];


        _dataTable.Rows.Add(txtEmpId.Text, txtEmpSlNo.Text, txtEmpExmName.Text, dropDownExmYear.SelectedValue,
            txtExmSession.Text, txtExmPass.Text, txtExmResult.Text);
        _dataTable.AcceptChanges();
        Session["addEmployyeEducationGridViewData"] = _dataTable;
        addEmployyeEducationGridView.DataSource = _dataTable;
        addEmployyeEducationGridView.DataBind();

        return true;
    }

    //Delete row of SubjectAddGridView
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        _dataTable = Session["addEmployyeEducationGridViewData"] as DataTable;
        _dataTable.Rows[index].Delete();
        Session["addEmployyeEducationGridViewData"] = _dataTable;
        addEmployyeEducationGridView.DataSource = _dataTable;
        addEmployyeEducationGridView.DataBind();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string item = e.Row.Cells[2].Text;
            foreach (Button button in e.Row.Cells[7].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete ?')){ return false; };";
                }
            }
        }
    }


    protected void empEduSave_Click(object sender, EventArgs e)
    {
        var empEdu = new EmployeeEducation();
        foreach (GridViewRow gvrow in addEmployyeEducationGridView
            .Rows)
        {
            //empEdu.VarEmployeeid = Convert.ToInt32(gvrow.Cells[0].Text);
            //empEdu.NumSlNo = Convert.ToInt32(gvrow.Cells[1].Text);
            //empEdu.VarExamName = gvrow.Cells[2].Text;
            //empEdu.NumExamYear = gvrow.Cells[3].Text;
            //empEdu.VarExamSession = gvrow.Cells[4].Text;
            //empEdu.VarExamPass = gvrow.Cells[5].Text;
            //empEdu.VarExamResult = gvrow.Cells[6].Text;


            empEdu.uid = Textuid.Text;
            empEdu.VarBranchId = DropDownBranch.Text;
            empEdu.VarShiftCode = drpshift.Text;

            db.EmployeeEducations.InsertOnSubmit(empEdu);
            db.SubmitChanges();
            Literal1.Text = "Employee Education insert Successfully";
        }

        //empEdu.VarEmployeeid = Convert.ToInt32(txtEmpId.Text);
        //empEdu.NumSlNo = Convert.ToInt32(txtEmpSlNo.Text);
        //empEdu.VarExamName = txtEmpExmName.Text;
        //empEdu.NumExamYear = dropDownExmYear.SelectedValue;
        //empEdu.VarExamSession = txtExmSession.Text;
        //empEdu.VarExamPass = txtExmPass.Text;
        //empEdu.VarExamResult = txtExmResult.Text;
        //empEdu.VarBranchId = DropDownBranch.Text;
        //empEdu.VarShiftCode = drpshift.Text;
        //empEdu.uid = Textuid.Text;
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        if (Session["addEmployyeEducationGridViewData"] == null)
        {
            PopulateGridView();
        }
        if (!InsertDataIntoGridView())
        {
            Literal1.Text = "Error Message";
        }
        txtEmpId.Text = "";
        txtEmpSlNo.Text = "";
        txtEmpExmName.Text = "";

        txtExmSession.Text = "";
        txtExmPass.Text = "";
        txtExmResult.Text = "";
    }
}