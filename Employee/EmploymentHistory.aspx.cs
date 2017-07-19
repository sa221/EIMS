using System;
using System.Linq;
using System.Web.UI;

public partial class Employee_EmploymentHistory : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void empEmploymentHistorySave_Click(object sender, EventArgs e)
    {
        IQueryable<string> checkExistingempId = from c in db.Employees
            where c.VarEmployeeid.Contains(txtEmpId.Text)
            select c.VarEmployeeid;

        if (checkExistingempId.FirstOrDefault() == null)
        {
            var empHistory = new EmployeeEmploymentHistory();
            empHistory.NumEmployeeid = Convert.ToInt32(txtEmpId.Text);
            empHistory.NumSlNo = Convert.ToInt32(txtEmpSlNo.Text);
            empHistory.VarOrganizationName = txtOrgName.Text;
            empHistory.VarOrganizationAdd = txtOrgAdd.Text;
            empHistory.VarOrganizationContact = txtOrgContact.Text;
            empHistory.NumDesignationID = dropDownDegId.SelectedIndex;
            empHistory.VarDutyResponsibility = txtDutyResp.Text;
            empHistory.VarJobDuration = txtJobDur.Text;
            empHistory.DatJobStart = Convert.ToDateTime(txtJobStart.Text);
            empHistory.DatJobEnd = Convert.ToDateTime(txtJobEnd.Text);
            empHistory.VarLeaveNote = txtLeaveNote.Text;
            db.EmployeeEmploymentHistories.InsertOnSubmit(empHistory);
            db.SubmitChanges();
            Literal1.Text = "Employee History Save Successfully";
        }
    }
}