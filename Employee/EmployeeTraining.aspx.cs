using System;
using System.Data;
using System.Web.UI;

public partial class Employee_EmployeeTraining : Page
{
    private DataTable _dataTable = new DataTable();
    private SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Session["uid"] != null)
        //        Textuid.Text = Session["uid"].ToString();

        //    if (Session["VarBranchId"] != null)
        //        DropDownBranch.SelectedValue = Session["VarBranchId"].ToString();
        //    if (Session["VarShiftCode"] != null)
        //        drpshift.SelectedValue = Session["VarShiftCode"].ToString();


        //    Session.Clear();
        //    //ListItem liDisease = new ListItem("Select Subject", "-1");
        //    //subjectDropDown.Items.Insert(0, liDisease);
        //    //saveButton.Attributes.Add("onClientClick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(saveButton, null) + ";");
        //    //addButton.Attributes.Add("onClientClick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(addButton, null) + ";");


        //}
    }

    //public void PopulateGridView()
    //{
    //    _dataTable.Columns.Add("NumEmployeeid", typeof(int));
    //    _dataTable.Columns.Add("NumSlNo", typeof(int));
    //    _dataTable.Columns.Add("VarTrainingTitles", typeof(string));
    //    _dataTable.Columns.Add("VarTrainingDuration", typeof(string));
    //    _dataTable.Columns.Add("DatTrainingStart", typeof(DateTime));
    //    _dataTable.Columns.Add("DatTrainingEnd", typeof(DateTime));
    //    _dataTable.Columns.Add("VarTrainingAchievement", typeof(string));


    //    _dataTable.AcceptChanges();
    //    Session["addEmployyetrainingGridViewData"] = _dataTable;
    //}

    //private bool InsertDataIntoGridView()
    //{


    //    _dataTable = (DataTable)Session["addEmployyetrainingGridViewData"];


    //    _dataTable.Rows.Add(txtEmpId.Text, txtEmpSlNo.Text, txtEmpExmName.Text, dropDownExmYear.SelectedValue, txtExmSession.Text, txtExmPass.Text, txtExmResult.Text);
    //    _dataTable.AcceptChanges();
    //    Session["addEmployyetrainingGridViewData"] = _dataTable;
    //    GridView1.DataSource = _dataTable;
    //    GridView1.DataBind();

    //    return true;
    //}
    ////Delete row of SubjectAddGridView
    //protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int index = Convert.ToInt32(e.RowIndex);
    //    _dataTable = Session["addEmployyetrainingGridViewData"] as DataTable;
    //    _dataTable.Rows[index].Delete();
    //    Session["addEmployyetrainingGridViewData"] = _dataTable;
    //    GridView1.DataSource = _dataTable;
    //    GridView1.DataBind();
    //}

    //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        //string item = e.Row.Cells[2].Text;
    //        foreach (Button button in e.Row.Cells[7].Controls.OfType<Button>())
    //        {
    //            if (button.CommandName == "Delete")
    //            {
    //                button.Attributes["onclick"] = "if(!confirm('Do you want to delete ?')){ return false; };";
    //            }
    //        }
    //    }
    //}

    //protected void empTrainingSave_Click(object sender, EventArgs e)
    //{
    //    EmployeeTraining empTraining=new EmployeeTraining();
    //    empTraining.NumEmployeeid = Convert.ToInt32(txtEmpId.Text);
    //    empTraining.NumSlNo = Convert.ToInt32(txtEmpSlNo.Text);
    //    empTraining.VarTrainingTitles = txtTrainingTit.Text;
    //    empTraining.VarTrainingDuration = txtTrainDur.Text;
    //    empTraining.DatTrainingStart = Convert.ToDateTime(txtTrainStart.Text);
    //    empTraining.DatTrainingEnd = Convert.ToDateTime(txtTrainEnd.Text);
    //    empTraining.VarTrainingAchievement = txtTrainAchiv.Text;
    //    db.EmployeeTrainings.InsertOnSubmit(empTraining);
    //    db.SubmitChanges();
    //    Literal1.Text = "Employee Training Information Inserted Successful";

    //}
}