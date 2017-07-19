using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_StudentProfile : System.Web.UI.Page
{
    private string studentId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        studentId = Request.QueryString["VarStudentID"];
        if (studentId != null)
        {
            studentIdTextBox.Text = studentId;
        }
        if (!IsPostBack)
        {
            LoadStudentProfile(studentId);
        }
        else
        {
            if (studentIdTextBox.Text!="")
            {
                LoadStudentProfile(studentIdTextBox.Text);   
            }
            else
            {
                LoadAllReport();
            }
        }

    }
    protected void viewButton_Click(object sender, EventArgs e)
    {
        LoadStudentProfile(studentIdTextBox.Text);
    }


    public void LoadStudentProfile(string studentId)
    {
        var report = new ReportDocument();
        report.Load(Server.MapPath("~/Reports/StudentProfile.rpt"));
        profileViewer.ReportSource = report;
        profileViewer.SelectionFormula = "{Student.VarStudentID}='" + studentId + "'";
        profileViewer.RefreshReport();

    }
    protected void refreshButton_Click(object sender, EventArgs e)
    {
        var nvc = HttpUtility.ParseQueryString(Request.Url.Query);
        nvc.Remove("VarStudentID");
        string url = Request.Url.AbsolutePath + "?" + nvc.ToString();
        Response.Redirect("~/ReportsUI/StudentProfile.aspx");

    }
    //public static string GetPublicIP()
    //{
    //    string url = "http://checkip.dyndns.org";
    //    System.Net.WebRequest req = System.Net.WebRequest.Create(url);
    //    System.Net.WebResponse resp = req.GetResponse();
    //    System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
    //    string response = sr.ReadToEnd().Trim();
    //    string[] a = response.Split(':');
    //    string a2 = a[1].Substring(1);
    //    string[] a3 = a2.Split('<');
    //    string a4 = a3[0];
    //    return a4;
    //}
    protected void createButton_Click(object sender, EventArgs e)
    {
        LoadAllReport();

        //"{tbl_Present_class.VarClassID} ='" +PClassID

    }

    private void LoadAllReport()
    {
        var report = new ReportDocument();
        report.Load(Server.MapPath("~/Reports/StudentProfile.rpt"));
        profileViewer.ReportSource = report;
        if (classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue != "0")
        {
            profileViewer.SelectionFormula = "{Student.PClassID}='" + classDropDownList.SelectedValue +
                "' and {Student.VarSessionName}='" + sessionDropDownList.SelectedValue +
                 "'and {Student.RecommendAdmissionSection}='" + sectionDropDownList.SelectedValue +
                 "'and {Student.Status}='" + "P" + "'";
            profileViewer.RefreshReport();
        }
        else if (classDropDownList.SelectedValue != "0" && sectionDropDownList.SelectedValue == "0")
        {
            profileViewer.SelectionFormula = "{Student.PClassID}='" + classDropDownList.SelectedValue +
                "' and {Student.VarSessionName}='" + sessionDropDownList.SelectedValue +
                 "'and {Student.Status}='" + "P" + "'";
            profileViewer.RefreshReport();
        }
    }
    protected void classDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        sectionDropDownList.Items.Clear();
        sectionDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    
}