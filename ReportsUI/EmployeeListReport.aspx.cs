using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_EmployeeListReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEmployeeReport();
        }
    }
    protected void searchButton_Click(object sender, EventArgs e)
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
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                    "' and {Employee.EmployeeDesignation}='" + designationDropDownList.SelectedValue +
                                                    "'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeCategory} ='" +
                                                    ctgDropDownList.SelectedValue +
                                                    "' and {Employee.EmployeeDesignation}='" +
                                                    designationDropDownList.SelectedValue +
                                                    "'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeCategory} ='" +
                                                    ctgDropDownList.SelectedValue +
                                                    "' and {Employee.EmployeeDesignation}='" +
                                                    designationDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                    "'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeDesignation}='" +
                                                    designationDropDownList.SelectedValue +
                                                    "'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        //--00--
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                    "' and {Employee.EmployeeDesignation}='" + designationDropDownList.SelectedValue +
                //"'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                //"' and {Employee.EmployeeDesignation}='" + designationDropDownList.SelectedValue +
                                                    "'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeDesignation}='" + designationDropDownList.SelectedValue +
                                                    "'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                //"'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                //"' and {Employee.EmployeeDesignation}='" + designationDropDownList.SelectedValue +
                //"'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeDesignation}='" + designationDropDownList.SelectedValue +
                //"'and {Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and {Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        //--000--
        else if (ctgDropDownList.SelectedValue != "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeCategory} ='" + ctgDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue != "0" && currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.EmployeeDesignation}='" + designationDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue == "0" && currentStatusDropDownList.SelectedValue != "0" && campusDropDownList.SelectedValue == "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.VarCurrentStatus}='" + currentStatusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else if (ctgDropDownList.SelectedValue == "0" && designationDropDownList.SelectedValue == "0" &&
                 currentStatusDropDownList.SelectedValue == "0" && campusDropDownList.SelectedValue != "0")
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.VarCampusId}='" + campusDropDownList.SelectedValue +
                                                    "'and{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
        else
        {
            report.Load(Server.MapPath("~/Reports/EmployeeList.rpt"));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.SelectionFormula = "{Employee.VarBranchId}=" + brachId;
            CrystalReportViewer1.RefreshReport();
        }
    }
}
