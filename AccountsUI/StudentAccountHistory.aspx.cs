using System;
using System.Linq;
using System.Web.UI;

public partial class AccountsUI_StudentAccountHistory : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Session["VarBranchId"] != null)
        //    {
        //        int branchId = Convert.ToInt32(Session["VarBranchId"]);
        //        Branch branchInitial = db.Branches.FirstOrDefault(c => c.VarBranchID == branchId);
        //        if (branchInitial != null)
        //        {
        //            branchinitialTextBox.Text = branchInitial.VarBranchInitial;
        //        }
        //        else
        //        {
        //            Response.Redirect("~/Account/Login.aspx");
        //        }
        //    }
        //}
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        receivaleLabel.Text = string.Empty;
        paidLabel.Text = string.Empty;
        dueLabel.Text = string.Empty;


        //string studentId = branchinitialTextBox + "" + studentIdTexBox.Text;
        if (sessionDropdownlist.SelectedValue == "0" && studentIdTexBox.Text != "")
        {
            var his = from u in db.tbl_Students_Accounts
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId
                join f in db.tbl_feesTypes on u.PayableFeesId equals f.Id
                where u.VarStudentId == studentIdTexBox.Text
                select new {u.FeesAssignDate, s.VarSessionName, u.ReceiptNo, f.FeesType, u.NetPayable, u.NetPaid};

            feesHistoryGridView.DataSource = his.AsEnumerable();
            feesHistoryGridView.DataBind();


            var totalReceivale = (from sa in db.tbl_Students_Accounts
                where sa.VarStudentId == studentIdTexBox.Text
                select new {sa.NetPayable}).ToList();
            decimal? sumReceivale = totalReceivale.Select(sa => sa.NetPayable).Sum();

            var totalPaid = (from sa in db.tbl_Students_Accounts
                where sa.VarStudentId == studentIdTexBox.Text
                select new {sa.NetPaid}).ToList();
            decimal? sumPid = totalPaid.Select(sa => sa.NetPaid).Sum();


            receivaleLabel.Text = sumReceivale.ToString();
            paidLabel.Text = sumPid.ToString();
            dueLabel.Text = (sumReceivale - sumPid).ToString();
        }
        else if (sessionDropdownlist.SelectedValue != "0" && studentIdTexBox.Text != "")
        {
            var his = from u in db.tbl_Students_Accounts
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId
                join f in db.tbl_feesTypes on u.PayableFeesId equals f.Id
                where u.VarStudentId == studentIdTexBox.Text && u.VarSessionId == sessionDropdownlist.SelectedValue
                select new {u.FeesAssignDate, s.VarSessionName, u.ReceiptNo, f.FeesType, u.NetPayable, u.NetPaid};

            feesHistoryGridView.DataSource = his.AsEnumerable();
            feesHistoryGridView.DataBind();

            var totalReceivale = (from sa in db.tbl_Students_Accounts
                where sa.VarStudentId == studentIdTexBox.Text
                select new {sa.NetPayable}).ToList();
            decimal? sumReceivale = totalReceivale.Select(sa => sa.NetPayable).Sum();

            var totalPaid = (from sa in db.tbl_Students_Accounts
                where sa.VarStudentId == studentIdTexBox.Text
                select new {sa.NetPaid}).ToList();
            decimal? sumPid = totalPaid.Select(sa => sa.NetPaid).Sum();


            receivaleLabel.Text = sumReceivale.ToString();
            paidLabel.Text = sumPid.ToString();
            dueLabel.Text = (sumReceivale - sumPid).ToString();
        }
    }
}