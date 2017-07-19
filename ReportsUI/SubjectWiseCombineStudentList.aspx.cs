using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_SubjectWiseCombineStudentList : System.Web.UI.Page
{
    SWISDataContext db=new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void showButton_Click(object sender, EventArgs e)
    {
        var report = new ReportDocument();

        //Class cls = db.Classes.FirstOrDefault(x => x.VarClassID == classDropDownList.SelectedValue);
        if (subjectDropDownList.SelectedValue != "0" && unitcodeDropDownList.SelectedValue!="0")
        {
            if (XIClassCheckBox.Checked)
            {
                report.Load(Server.MapPath("~/Reports/CombineClassSubReport.rpt"));
                SubjectWiseStudentList.ReportSource = report;
                SubjectWiseStudentList.SelectionFormula = "{tbl_EdexcelSubjectAssign.Session} ='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and ({tbl_EdexcelSubjectAssign.ClassId} ='" +"126"+
                                                            "' or {tbl_EdexcelSubjectAssign.ClassId} ='" + "127" +
                                                            "') and {tbl_EdexcelSubjectAssign.SubjectId} ='" +
                                                            subjectDropDownList.SelectedValue +
                                                            "' and{tbl_EdexcelSubjectAssign.UnitCode} ='" +
                                                            unitcodeDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" + "'";

                SubjectWiseStudentList.RefreshReport();
            }
            else if (XIIClassCheckBox.Checked)
            {
                report.Load(Server.MapPath("~/Reports/CombineClassSubReport.rpt"));
                SubjectWiseStudentList.ReportSource = report;
                SubjectWiseStudentList.SelectionFormula = "{tbl_EdexcelSubjectAssign.Session} ='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and ({tbl_EdexcelSubjectAssign.ClassId} ='" + "128" +
                                                            "' or {tbl_EdexcelSubjectAssign.ClassId} ='" + "129" +
                                                            "') and {tbl_EdexcelSubjectAssign.SubjectId} ='" +
                                                            subjectDropDownList.SelectedValue +
                                                            "' and{tbl_EdexcelSubjectAssign.UnitCode} ='" +
                                                            unitcodeDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" + "'";
                SubjectWiseStudentList.RefreshReport();
            }
            
        }
        else if (subjectDropDownList.SelectedValue != "0" && unitcodeDropDownList.SelectedValue == "0")
        {
            if (XIClassCheckBox.Checked)
            {
                report.Load(Server.MapPath("~/Reports/CombineClassSubReport.rpt"));
                SubjectWiseStudentList.ReportSource = report;
                SubjectWiseStudentList.SelectionFormula = "{tbl_EdexcelSubjectAssign.Session} ='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and ({tbl_EdexcelSubjectAssign.ClassId} ='" + "126" +
                                                            "' or {tbl_EdexcelSubjectAssign.ClassId} ='" + "127" +
                                                            "') and {tbl_EdexcelSubjectAssign.SubjectId} ='" +
                                                            subjectDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" + "'";

                SubjectWiseStudentList.RefreshReport();
            }
            else if (XIIClassCheckBox.Checked)
            {
                report.Load(Server.MapPath("~/Reports/CombineClassSubReport.rpt"));
                SubjectWiseStudentList.ReportSource = report;
                SubjectWiseStudentList.SelectionFormula = "{tbl_EdexcelSubjectAssign.Session} ='" +
                                                            sessionDropDownList.SelectedValue +
                                                            "' and ({tbl_EdexcelSubjectAssign.ClassId} ='" + "128" +
                                                            "' or {tbl_EdexcelSubjectAssign.ClassId} ='" + "129" +
                                                            "') and {tbl_EdexcelSubjectAssign.SubjectId} ='" +
                                                            subjectDropDownList.SelectedValue +
                                                            "'and {tbl_Present_class.Status}='" + "P" + "'";
                SubjectWiseStudentList.RefreshReport();
            }

        }
        
    }
    
    protected void XIClassCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (XIClassCheckBox.Checked)
        {
            var getAllSubject = (from x in db.tbl_Subjects
                                 where x.ClassId == "126" || x.ClassId == "127"
                                 select new { x.VarSubjectCode, x.VarSubjectName }).Distinct();

            
            subjectDropDownList.DataSource = getAllSubject.AsEnumerable();
            subjectDropDownList.DataValueField = "VarSubjectCode";
            subjectDropDownList.DataTextField = "VarSubjectName";
            subjectDropDownList.DataBind();
            subjectDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            subjectDropDownList.Items.Clear();
            unitcodeDropDownList.Items.Clear();
        }
       
    }
    protected void XIIClassCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (XIIClassCheckBox.Checked)
        {
            var getAllSubject = (from x in db.tbl_Subjects
                where x.ClassId == "128" || x.ClassId == "129"
                select new {x.VarSubjectCode, x.VarSubjectName}).Distinct();

            
            subjectDropDownList.DataSource = getAllSubject.AsEnumerable();
            subjectDropDownList.DataValueField = "VarSubjectCode";
            subjectDropDownList.DataTextField = "VarSubjectName";
            subjectDropDownList.DataBind();
            subjectDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            subjectDropDownList.Items.Clear();
            unitcodeDropDownList.Items.Clear();
        }
        
    }
    protected void subjectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (XIClassCheckBox.Checked)
        {
            var getUnit = from x in db.tbl_EdexelunitCodes
                          where x.SpecificationCode == subjectDropDownList.SelectedValue && (x.Class == "126" || x.Class == "127")
                          select new { x.UnitCode, x.UnitCodeSpeCode };
            unitcodeDropDownList.DataSource = getUnit.AsEnumerable();
            unitcodeDropDownList.DataValueField = "UnitCodeSpeCode";
            unitcodeDropDownList.DataTextField = "UnitCode";
            unitcodeDropDownList.DataBind();
            unitcodeDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else if (XIIClassCheckBox.Checked)
        {
            var getUnit = from x in db.tbl_EdexelunitCodes
                          where x.SpecificationCode == subjectDropDownList.SelectedValue && (x.Class == "128" || x.Class == "129")
                          select new { x.UnitCode, x.UnitCodeSpeCode };
            unitcodeDropDownList.DataSource = getUnit.AsEnumerable();
            unitcodeDropDownList.DataValueField = "UnitCodeSpeCode";
            unitcodeDropDownList.DataTextField = "UnitCode";
            unitcodeDropDownList.DataBind();
            unitcodeDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        
        
    }
}