using System;
using System.Linq;
using System.Web.UI;

public partial class AccountsUI_WaiverAssign : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        if (studentIdTextBox.Text != "")
        {
            Student std = db.Students.FirstOrDefault(x => x.VarStudentID == studentIdTextBox.Text);


            var pcl = (from p in db.tbl_Present_classes
                join c in db.Classes on p.VarClassID equals c.VarClassID
                where p.VarStudentID == studentIdTextBox.Text && p.VarSessionId == sessionDropDownList.SelectedValue
                select new {c.VarClassName, c.VarClassID}).Distinct().ToList();
            if (pcl.FirstOrDefault() != null)
            {
                if (std != null) nameLabel.Text = std.VarStudentFirstName + " " + std.VarStudentLastName;
                classDropDownList.DataSource = pcl;
                classDropDownList.DataTextField = "VarClassName";
                classDropDownList.DataValueField = "VarClassID";
                classDropDownList.DataBind();

                IQueryable<tbl_WaiverHistory> waiverHistory = from w in db.tbl_WaiverHistories
                    where w.VarStudentId == studentIdTextBox.Text && w.VarSessiuon == sessionDropDownList.SelectedValue
                    select w;
                waiverHistoryGridView.DataSource = waiverHistory.AsEnumerable();
                waiverHistoryGridView.DataBind();
            }
            else
            {
                failStatusLabel.InnerText = "Student not found in Present Class";
            }
        }
        else
        {
            failStatusLabel.InnerText = "Please Insert Student ID";
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        int countMonth = Convert.ToInt32(toMonthDropDownList.SelectedValue) -
                         Convert.ToInt32(fromMonthDropDownList.SelectedValue) + 1;

        IQueryable<tbl_feesInfo> feesAmount = (from f in db.tbl_feesInfos
            where f.VarClassId == classDropDownList.SelectedValue && f.FeesId == 2
            select f);
        foreach (tbl_feesInfo fees in feesAmount)
        {
            decimal waiverAmount = fees.Fees*countMonth;
            decimal vat = waiverAmount*(decimal) (.075);
            decimal netAmount = waiverAmount + vat;

            IQueryable<tbl_Students_Account> getFeesId = (from s in db.tbl_Students_Accounts
                where
                    s.VarStudentId == studentIdTextBox.Text && s.PayableFeesId == fees.FeesId &&
                    s.VarSessionId == sessionDropDownList.SelectedValue
                select s);
            if (getFeesId.FirstOrDefault() != null)
            {
                foreach (tbl_Students_Account account in getFeesId)
                {
                    var studentsAccount = new tbl_Students_Account();

                    account.PayableAmount = account.PayableAmount - waiverAmount;
                    account.PayableVat = account.PayableVat - vat;
                    account.NetPayable = account.NetPayable - netAmount;
                }
            }


            var waiver = new tbl_WaiverHistory();
            waiver.VarStudentId = studentIdTextBox.Text;
            waiver.VarClassId = classDropDownList.SelectedValue;
            waiver.VarSessiuon = sessionDropDownList.SelectedValue;
            waiver.FromMonthId = Convert.ToInt32(fromMonthDropDownList.SelectedValue);
            waiver.FromMonth = fromMonthDropDownList.SelectedItem.Text;
            waiver.ToMonthId = Convert.ToInt32(toMonthDropDownList.SelectedValue);
            waiver.ToMonth = toMonthDropDownList.SelectedItem.Text;
            waiver.Amount = waiverAmount;
            waiver.uid = Session["uid"].ToString();
            waiver.InputDate = DateTime.Now;
            waiver.VarBranchId = Session["VarBranchId"].ToString();
            waiver.VarShiftId = Session["VarShiftCode"].ToString();

            db.tbl_WaiverHistories.InsertOnSubmit(waiver);
        }
        db.SubmitChanges();
        IQueryable<tbl_WaiverHistory> waiverHistory = from w in db.tbl_WaiverHistories
            where w.VarStudentId == studentIdTextBox.Text && w.VarSessiuon == sessionDropDownList.SelectedValue
            select w;
        waiverHistoryGridView.DataSource = waiverHistory.AsEnumerable();
        waiverHistoryGridView.DataBind();
    }
}