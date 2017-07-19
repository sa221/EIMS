using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccountsUI_FeesEntryManuly : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        //tbl_Present_class pcl =
        //    db.tbl_Present_classes.FirstOrDefault(
        //        p => p.VarStudentID == studentIdTextBox.Text && p.VarSessionId == sessionDropDownList.SelectedValue);

        var pcl = (from p in db.tbl_Present_classes
            join c in db.Classes on p.VarClassID equals c.VarClassID
            where p.VarStudentID == studentIdTextBox.Text && p.VarSessionId == sessionDropDownList.SelectedValue
            select new {c.VarClassName, c.VarClassID}).Distinct().ToList();
        if (pcl.FirstOrDefault() != null)
        {
            classDropDownList.DataSource = pcl;
            classDropDownList.DataTextField = "VarClassName";
            classDropDownList.DataValueField = "VarClassID";
            classDropDownList.DataBind();

            var feesId = (from u in db.tbl_feesInfos
                join c in db.tbl_feesTypes on u.FeesId equals c.Id
                where u.VarClassId == classDropDownList.SelectedValue
                select new {c.FeesType, c.Id}).Distinct().ToList();
            feesNameDropDownList.DataSource = feesId;
            feesNameDropDownList.DataTextField = "FeesType";
            feesNameDropDownList.DataValueField = "Id";

            feesNameDropDownList.DataBind();
            feesNameDropDownList.Items.Insert(0, new ListItem("Previous Dues", "7"));

            if (sessionDropDownList.SelectedValue == "0" && studentIdTextBox.Text != "")
            {
                var his = from u in db.tbl_Students_Accounts
                    join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId
                    join f in db.tbl_feesTypes on u.PayableFeesId equals f.Id
                    where u.VarStudentId == studentIdTextBox.Text
                    select new {u.FeesAssignDate, s.VarSessionName, u.ReceiptNo, f.FeesType, u.NetPayable, u.NetPaid};

                feesHistoryGridView.DataSource = his.AsEnumerable();
                feesHistoryGridView.DataBind();
            }
            else if (sessionDropDownList.SelectedValue != "0" && studentIdTextBox.Text != "")
            {
                var his = from u in db.tbl_Students_Accounts
                    join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId
                    join f in db.tbl_feesTypes on u.PayableFeesId equals f.Id
                    where u.VarStudentId == studentIdTextBox.Text && u.VarSessionId == sessionDropDownList.SelectedValue
                    select new {u.FeesAssignDate, s.VarSessionName, u.ReceiptNo, f.FeesType, u.NetPayable, u.NetPaid};

                feesHistoryGridView.DataSource = his.AsEnumerable();
                feesHistoryGridView.DataBind();
            }
            //if (feesId != null) feesNameDropDownList.SelectedValue = feesId.FeesId.ToString();
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        if (studentIdTextBox.Text != "" && netAmountTextBox.Text != "")
        {
            var stdAccount = new tbl_Students_Account();

            stdAccount.VarSessionId = sessionDropDownList.SelectedValue;
            stdAccount.VarStudentId = studentIdTextBox.Text;
            stdAccount.PayableFeesId = Convert.ToInt32(feesNameDropDownList.SelectedValue);
            stdAccount.PayableVat = Convert.ToDecimal(VatTextBox.Text);
            stdAccount.PayableAmount = Convert.ToDecimal(feesAmountTextBox.Text);
            stdAccount.NetPayable = Convert.ToDecimal(netAmountTextBox.Text);
            stdAccount.FeesAssignDate = DateTime.Now;
            stdAccount.uid = Session["uid"].ToString();

            db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
            db.SubmitChanges();

            var his = from u in db.tbl_Students_Accounts
                join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId
                join f in db.tbl_feesTypes on u.PayableFeesId equals f.Id
                where u.VarStudentId == studentIdTextBox.Text && u.VarSessionId == sessionDropDownList.SelectedValue
                select new {u.FeesAssignDate, s.VarSessionName, u.ReceiptNo, f.FeesType, u.NetPayable, u.NetPaid};

            feesHistoryGridView.DataSource = his.AsEnumerable();
            feesHistoryGridView.DataBind();
            feesAmountTextBox.Text = string.Empty;
            VatTextBox.Text = string.Empty;
            netAmountTextBox.Text = string.Empty;
        }
        else
        {
            msgLiteral.Text = "Please insert Student ID and Fees Amount";
        }
    }

    protected void feesNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        feesAmountTextBox.Text = string.Empty;
        VatTextBox.Text = string.Empty;
        netAmountTextBox.Text = string.Empty;
        var getFees = from f in db.tbl_feesInfos
            where
                f.FeesId == Convert.ToInt32(feesNameDropDownList.SelectedValue) &&
                f.VarClassId == classDropDownList.SelectedValue
            select new {f.Fees, f.FeesType};

        foreach (var feesAmount in getFees)
        {
            if (feesAmount.FeesType == 1)
            {
                decimal amount = feesAmount.Fees;
                decimal vat = amount*(decimal) (.075);
                decimal netAmount = amount + vat;
                feesAmountTextBox.Text = amount.ToString();
                VatTextBox.Text = vat.ToString();
                netAmountTextBox.Text = netAmount.ToString();
            }
            else if (feesAmount.FeesType == 2)
            {
                decimal amount = feesAmount.Fees*12;
                decimal vat = amount*Convert.ToDecimal(.075);
                decimal netAmount = amount + vat;
                feesAmountTextBox.Text = amount.ToString();
                VatTextBox.Text = vat.ToString();
                netAmountTextBox.Text = netAmount.ToString();
            }
            else if (feesAmount.FeesType == 3)
            {
                decimal amount = feesAmount.Fees*12;
                //decimal vat = amount * Convert.ToDecimal(.075);
                decimal netAmount = amount;
                feesAmountTextBox.Text = amount.ToString();
                //VatTextBox.Text = "0";
                netAmountTextBox.Text = netAmount.ToString();
            }
        }
    }

    protected void feesHistoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = feesHistoryGridView.Rows[index];
            string session = ((Label) gvRow.FindControl("Label4")).Text;
            string feesName = ((Label) gvRow.FindControl("Label3")).Text;
            //DateTime date = Convert.ToDateTime(((Label)gvRow.FindControl("Label10")).Text);

            tbl_feesType getFeesId = db.tbl_feesTypes.FirstOrDefault(x => x.FeesType == feesName);
            SessionInfo getSessionId = db.SessionInfos.FirstOrDefault(x => x.VarSessionName == session);
            tbl_Students_Account getFeesRecord =
                db.tbl_Students_Accounts.FirstOrDefault(
                    x =>
                        getSessionId != null &&
                        (x.PayableFeesId == getFeesId.Id && x.VarSessionId == getSessionId.VarSessionId &&
                         x.VarStudentId == studentIdTextBox.Text));
            //var feesId = (from c in db.tbl_Students_Accounts
            //    where c.PayableFeesId == getFeesId.Id && c.VarSessionId==getSessionId.VarSessionId
            //    select new{c.Id}).ToList();
            if (getFeesRecord != null)
            {
                db.tbl_Students_Accounts.DeleteOnSubmit(getFeesRecord);
                db.SubmitChanges();
            }
            if (sessionDropDownList.SelectedValue == "0" && studentIdTextBox.Text != "")
            {
                var his = from u in db.tbl_Students_Accounts
                    join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId
                    join f in db.tbl_feesTypes on u.PayableFeesId equals f.Id
                    where u.VarStudentId == studentIdTextBox.Text
                    select new {u.FeesAssignDate, s.VarSessionName, u.ReceiptNo, f.FeesType, u.NetPayable, u.NetPaid};

                feesHistoryGridView.DataSource = his.AsEnumerable();
                feesHistoryGridView.DataBind();
            }
            else if (sessionDropDownList.SelectedValue != "0" && studentIdTextBox.Text != "")
            {
                var his = from u in db.tbl_Students_Accounts
                    join s in db.SessionInfos on u.VarSessionId equals s.VarSessionId
                    join f in db.tbl_feesTypes on u.PayableFeesId equals f.Id
                    where u.VarStudentId == studentIdTextBox.Text && u.VarSessionId == sessionDropDownList.SelectedValue
                    select new {u.FeesAssignDate, s.VarSessionName, u.ReceiptNo, f.FeesType, u.NetPayable, u.NetPaid};

                feesHistoryGridView.DataSource = his.AsEnumerable();
                feesHistoryGridView.DataBind();
            }
        }
    }
}