using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReportsUI_StudentLeft : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        failStatusLabel.InnerText = "";
        successStatusLabel.InnerText = "";
        if (studentIdTextBox.Text != "")
        {
            Student getStudent = db.Students.FirstOrDefault(x => x.VarStudentID == studentIdTextBox.Text);

            if (getStudent != null)
            {
                statusDropDownList.SelectedValue = getStudent.Status;
                remarksTextBox.Text = getStudent.Remarks;
                if (getStudent.SDate != null)
                {
                    leaveDateTextBox.Text = Convert.ToDateTime(getStudent.SDate.ToString())
                        .ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
            else
            {
                failStatusLabel.InnerText = "Please provide valid Student ID.!";
            }
        }
        else
        {
            failStatusLabel.InnerText = "Please provide Student ID.!";
        }
    }

    protected void tcButton_Click(object sender, EventArgs e)
    {
        Student getStudent = db.Students.FirstOrDefault(x => x.VarStudentID == studentIdTextBox.Text);
        tbl_Present_class pcl = db.tbl_Present_classes.FirstOrDefault(p => p.VarStudentID == studentIdTextBox.Text);

        if (getStudent != null)
        {
            getStudent.Status = statusDropDownList.SelectedValue;
            if (pcl != null) pcl.Status = statusDropDownList.SelectedValue;
            //getStudent.SDate = Convert.ToDateTime(leaveDateTextBox.Text);
            if (!String.IsNullOrWhiteSpace(leaveDateTextBox.Text))
            {
                DateTime date = DateTime.ParseExact(leaveDateTextBox.Text, "dd/MM/yyyy", null);
                getStudent.SDate = date;
            }
            getStudent.Remarks = remarksTextBox.Text;
            getStudent.TCComments = commentTextBox.Text;
            getStudent.LeftSession = sessionDropDownList.SelectedValue;
            db.SubmitChanges();
        }
        if (getStudent != null && getStudent.Status != "P")
        {
            int brachId = Convert.ToInt32(Session["VarBranchId"]);
            string status = "L";
            var report = new ReportDocument();
            report.Load(Server.MapPath("~/Reports/TransferCertificate.rpt"));
            TransferCertificate.ReportSource = report;
            TransferCertificate.SelectionFormula = "{Student.VarStudentID}='" + studentIdTextBox.Text +
                                                   "' and {Student.Status}='" + status +
                                                    "'and{Student.VarBranchID}=" + brachId;
            TransferCertificate.RefreshReport();
        }
        else
        {
            failStatusLabel.InnerText = "Could not possible Present Student Transfer Certificate genarate";
        }
    }
}