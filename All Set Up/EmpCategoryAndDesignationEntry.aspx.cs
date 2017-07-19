using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AllSetUpEmpCategoryAndDesignationEntry : System.Web.UI.Page
{
    private SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadCategoryGrid();
        LoadDesignationGrid();
        LoadDegreeGrid();
    }

    protected void LoadCategoryGrid()
    {
        var getCategory = from x in db.EmployeeCategories
            select new{x.CategoryName};
        categoryGridView.DataSource = getCategory.AsEnumerable();
        categoryGridView.DataBind();

    }
    protected void LoadDesignationGrid()
    {
        var getDesignation = from x in db.EmployeeDesignations
                          select new { x.VarDesignationName };
        designationGridView.DataSource = getDesignation.AsEnumerable();
        designationGridView.DataBind();

    }
    protected void LoadDegreeGrid()
    {
        var getDegree = from x in db.tbl_EmployeeDegreeNames
                        where x.Id>0
                             select new { x.VarExamName };
        degreeGridView.DataSource = getDegree.AsEnumerable();
        degreeGridView.DataBind();

    }
    protected void ctgSaveButton_Click1(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        EmployeeCategory chkCtgName = db.EmployeeCategories.FirstOrDefault(x => x.CategoryName == ctgNameTextBox.Text.Trim());
        if (chkCtgName==null)
        {
            EmployeeCategory empCtg = new EmployeeCategory();

            empCtg.CategoryName = ctgNameTextBox.Text;
            empCtg.uid = Session["uid"].ToString();
            empCtg.VarBranchId = Session["VarBranchId"].ToString();
            empCtg.VarShiftId = Session["VarShiftCode"].ToString();
            empCtg.InputDate = DateTime.Now;
            db.EmployeeCategories.InsertOnSubmit(empCtg);
            db.SubmitChanges();
            ctgNameTextBox.Text = String.Empty;
            successStatusLabel.InnerText = "Category Insert Successfully.";
            LoadCategoryGrid();
        }
        else
        {
            failStatusLabel.InnerText = "Category Name Already Exist!";
        }
       
    }
    protected void degSaveButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        EmployeeDesignation chkDegName = db.EmployeeDesignations.FirstOrDefault(x => x.VarDesignationName == degnationTextBox.Text.Trim());
        if (chkDegName == null)
        {
            EmployeeDesignation empDeg = new EmployeeDesignation();

            empDeg.VarDesignationName = degnationTextBox.Text;
            empDeg.uid = Session["uid"].ToString();
            empDeg.VarBranchId = Session["VarBranchId"].ToString();
            empDeg.VarShiftCode = Session["VarShiftCode"].ToString();
            empDeg.InputDate = DateTime.Now;
            db.EmployeeDesignations.InsertOnSubmit(empDeg);
            db.SubmitChanges();
            degnationTextBox.Text = String.Empty;
            successStatusLabel.InnerText = "Designation Insert Successfully.";
            LoadDesignationGrid();
        }
        else
        {
            failStatusLabel.InnerText = "Designation Name Already Exist!";
        }
    }
    protected void degreeSaveButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        tbl_EmployeeDegreeName chkDegree = db.tbl_EmployeeDegreeNames.FirstOrDefault(x => x.VarExamName == degreeTextBox.Text.Trim());
        if (chkDegree == null)
        {
            tbl_EmployeeDegreeName empDeg = new tbl_EmployeeDegreeName();

            empDeg.VarExamName = degreeTextBox.Text.Trim();
            db.tbl_EmployeeDegreeNames.InsertOnSubmit(empDeg);
            db.SubmitChanges();
            degreeTextBox.Text = String.Empty;
            successStatusLabel.InnerText = "Degree Insert Successfully.";
            LoadDegreeGrid();
        }
        else
        {
            failStatusLabel.InnerText = "Degree Name Already Exist!";
        }
    }
    protected void OnRowDeletingDesegnation(object sender, GridViewDeleteEventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        int index = Convert.ToInt32(e.RowIndex);
        //int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = designationGridView.Rows[index];
        string designation = ((Label)gvRow.FindControl("Label1")).Text;
        EmployeeDesignation chkDesignation =
            db.EmployeeDesignations.FirstOrDefault(x => x.VarDesignationName == designation);
        Employee chkEmployee =
            db.Employees.FirstOrDefault(x => x.EmployeeDesignation == chkDesignation.NumDesignationId);
        if (chkEmployee == null)
        {
            if (chkDesignation != null)
            {
                db.EmployeeDesignations.DeleteOnSubmit(chkDesignation);
                db.SubmitChanges();
            }
            successStatusLabel.InnerText = "Designation Delete Succussfully";
            LoadDesignationGrid();
        }
        else
        {
            failStatusLabel.InnerText = "Designation Name Already Used in Employee Information!";
        }
    }
    protected void OnRowDeletingCategory(object sender, GridViewDeleteEventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        int index = Convert.ToInt32(e.RowIndex);
        //int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = categoryGridView.Rows[index];
        string category = ((Label)gvRow.FindControl("Label1")).Text;
        EmployeeCategory chkCategory =
            db.EmployeeCategories.FirstOrDefault(x => x.CategoryName == category);
        Employee chkEmployee =
            db.Employees.FirstOrDefault(x => x.EmployeeCategory == chkCategory.CategoryId.ToString());
        if (chkEmployee == null)
        {
            if (chkCategory != null)
            {
                db.EmployeeCategories.DeleteOnSubmit(chkCategory);
                db.SubmitChanges();
            }
            successStatusLabel.InnerText = "Category Delete Succussfully";
            LoadCategoryGrid();
        }
        else
        {
            failStatusLabel.InnerText = "Category Name Already Used in Employee Information!";
        }
    }
    protected void OnRowDeletingDegree(object sender, GridViewDeleteEventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        int index = Convert.ToInt32(e.RowIndex);
        GridViewRow gvRow = degreeGridView.Rows[index];
        string degree = ((Label)gvRow.FindControl("Label1")).Text;
        tbl_EmployeeDegreeName chkDegreeName =
            db.tbl_EmployeeDegreeNames.FirstOrDefault(x => x.VarExamName == degree);
        EmployeeEducation chkEmployee =
            db.EmployeeEducations.FirstOrDefault(x => x.VarExamName == degree);
        if (chkEmployee == null)
        {
            if (chkDegreeName != null)
            {
                db.tbl_EmployeeDegreeNames.DeleteOnSubmit(chkDegreeName);
                db.SubmitChanges();
            }
            successStatusLabel.InnerText = "Degree Delete Succussfully";
            LoadDegreeGrid();
        }
        else
        {
            failStatusLabel.InnerText = "Degree Name Already Used in Employee Education!";
        }
    }

    
}