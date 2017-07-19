using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_EmployeeDetailsReport : System.Web.UI.Page
{
    SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategory();
            LoadDesignation();
            LoadEmployeeReport();
        }
    }

    private void LoadCategory()
    {
        var getAllCategory = from c in db.EmployeeCategories
                             select new { c.CategoryId, c.CategoryName };
        ctgDropDownList.DataSource = getAllCategory;
        ctgDropDownList.DataValueField = "CategoryId";
        ctgDropDownList.DataTextField = "CategoryName";
        ctgDropDownList.DataBind();
        ctgDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    private void LoadDesignation()
    {
        var getAllDesignation = from c in db.EmployeeDesignations
                             select new { c.NumDesignationId, c.VarDesignationName };
        designationDropDownList.DataSource = getAllDesignation;
        designationDropDownList.DataValueField = "NumDesignationId";
        designationDropDownList.DataTextField = "VarDesignationName";
        designationDropDownList.DataBind();
        designationDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void showReportButton_Click(object sender, EventArgs e)
    {
        failStatusLabel.InnerText = "";
        successStatusLabel.InnerText = "";
        LoadEmployeeReport();
    }
    private void LoadEmployeeReport()
    {
        var report = new ReportDocument();

        int brachId = Convert.ToInt32(Session["VarBranchId"]);

        if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                     "'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                                                    "and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                     "'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                                                    "and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                     "'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                //"and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                //"'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                                                    "'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = //"{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                     "{Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                                                    "and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        //--00--
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                     "'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                //"and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                //"'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                                                    "'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = //"{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                     "{Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                                                    "and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                // "'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                //"and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = //"{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                     "{Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                //"and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = //"{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                //"'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                                                    "{Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        //--000--
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                //"'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                //"and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = //"{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                     "{Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                //"and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = //"{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                //"'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                                                    "{Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue == "0" &&
                 currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = //"{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                //"'and {Employee.EmployeeDesignation}=" + Convert.ToInt32(designationDropDownList.SelectedValue) +
                //"and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "{Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
        else
        {
            report.Load(Server.MapPath("~/Reports/EmployeeInfoReport.rpt"));
            employeeDetailsReport.ReportSource = report;
            employeeDetailsReport.SelectionFormula = "{Employee.VarBranchId}=" + brachId;
            employeeDetailsReport.RefreshReport();
        }
    }
}