using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccountsUI_FeesCollection : Page
{
    private readonly SWISDataContext db = new SWISDataContext();
    private DataTable _dataTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dateTextBox.Text = DateTime.Now.ToString();
            Session["feesAddGridViewData"] = null;
        }
        //feesHistoryGridView.DataBind();
    }

    public void PopulateGridView()
    {
        // _dataTable.Columns.Add("SiNo", typeof(int));
        _dataTable.Columns.Add("FeesName", typeof (string));
        _dataTable.Columns.Add("MonthFrom", typeof (string));
        _dataTable.Columns.Add("MonthTo", typeof (string));
        _dataTable.Columns.Add("Session", typeof (string));
        _dataTable.Columns.Add("Amount", typeof (string));
        _dataTable.Columns.Add("Vat", typeof (string));
        _dataTable.Columns.Add("NetAmount", typeof (string));

        _dataTable.AcceptChanges();
        Session["feesAddGridViewData"] = _dataTable;
    }

    private bool InsertDataIntoGridView()
    {
        _dataTable.Clear();

        _dataTable = (DataTable) Session["feesAddGridViewData"];

        tbl_feesInfo feesInfo =
            db.tbl_feesInfos.FirstOrDefault(u => u.FeesId == Convert.ToInt32(feesTypeDropDownList.SelectedItem.Value));
        int feesTypeId = Convert.ToInt32(feesInfo.FeesType);
        if (feesTypeId == 1)
        {
            _dataTable.Rows.Add(feesTypeDropDownList.SelectedItem.Text, "N/A",
                "N/A", sessionDropDownList.SelectedItem.Text, amountTextBox.Text, vatTextBox.Text, netAmountTextBox.Text);
        }
        else
        {
            decimal othersFees = GetFeesAmount("Other Fees");
            decimal tutionFee = GetFeesAmount(feesTypeDropDownList.SelectedItem.Text);
            int month = GetCountedMonth();

            if (feesInfo.FeesId.Equals(2))
            {
                _dataTable.Rows.Add(feesTypeDropDownList.SelectedItem.Text, monthFromDropDownList.SelectedItem.Text,
                    monthToDropDownList.SelectedItem.Text, sessionDropDownList.SelectedItem.Text, tutionFee*month,
                    GetVat(tutionFee*month), GetNetAmount(tutionFee*month, GetVat(tutionFee*month)));
                _dataTable.Rows.Add("Other Fees", monthFromDropDownList.SelectedItem.Text,
                    monthToDropDownList.SelectedItem.Text, sessionDropDownList.SelectedItem.Text, othersFees*month,
                    GetVat(othersFees*month), GetNetAmount(othersFees*month, GetVat(othersFees*month)));
            }
            else
            {
                _dataTable.Rows.Add(feesTypeDropDownList.SelectedItem.Text, monthFromDropDownList.SelectedItem.Text,
                    monthToDropDownList.SelectedItem.Text, sessionDropDownList.SelectedItem.Text, amountTextBox.Text,
                    vatTextBox.Text, netAmountTextBox.Text);
            }
        }


        _dataTable.AcceptChanges();

        Session["feesAddGridViewData"] = _dataTable;
        addFeesGridView.DataSource = _dataTable;
        addFeesGridView.DataBind();

        return true;
    }

    //Delete row of SubjectAddGridView
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        _dataTable = Session["feesAddGridViewData"] as DataTable;
        _dataTable.Rows[index].Delete();
        Session["feesAddGridViewData"] = _dataTable;
        addFeesGridView.DataSource = _dataTable;
        addFeesGridView.DataBind();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[1].Text;
            foreach (Button button in e.Row.Cells[7].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item +
                                                   "?')){ return false; };";
                }
            }
        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string studentId = branchDropDownList.SelectedItem.Text + txtStudentId.Text;


        if (txtStudentId.Text != "")
        {
            var feesId = (from u in db.tbl_Students_Accounts
                join c in db.tbl_feesTypes on u.PayableFeesId equals c.Id
                where
                    u.VarStudentId == studentId && u.VarSessionId == sessionDropDownList.SelectedItem.Value && c.Id != 4
                select new {c.FeesType, c.Id}).Distinct().ToList();
            feesTypeDropDownList.DataSource = feesId;
            feesTypeDropDownList.DataTextField = "FeesType";
            feesTypeDropDownList.DataValueField = "Id";

            feesTypeDropDownList.DataBind();


            IQueryable<tbl_feesCollectionSub> feesmonthCheck = from f in db.tbl_feesCollectionSubs
                where
                    f.VarStudentId == studentId && f.VarSession == sessionDropDownList.SelectedValue &&
                    f.VarFeesName == 2
                select f;
            if (feesmonthCheck.Count() == 12)
            {
                feesTypeDropDownList.Items.Remove(feesTypeDropDownList.Items.FindByValue("2"));
            }
            if (feesmonthCheck.FirstOrDefault() != null)
            {
                foreach (tbl_feesCollectionSub reduceMonth in feesmonthCheck)
                {
                    monthFromDropDownList.Items.Remove(monthFromDropDownList.Items.FindByValue(reduceMonth.VarMonth));
                    monthToDropDownList.Items.Remove(monthToDropDownList.Items.FindByValue(reduceMonth.VarMonth));
                }
            }

            //tbl_feesCollection history = db.tbl_feesCollections.FirstOrDefault(h => h.StudentId == studentId);
            IQueryable<tbl_feesCollection> his = from u in db.tbl_feesCollections
                where u.StudentId == studentId
                select u;
            //return his.ToArray();

            ////var list = new List<object> { history };
            feesHistoryGridView.DataSource = his.AsEnumerable();
            feesHistoryGridView.DataBind();

            //string studentId = branchDropDownList.SelectedItem.Text + txtStudentId.Text;

            IQueryable<string> checkExistingStudentId = from c in db.Students
                where c.VarStudentID == studentId && c.VarSessionName == sessionDropDownList.SelectedValue
                select c.VarStudentID;

            if (checkExistingStudentId.FirstOrDefault() != null)
            {
                Student std = db.Students.FirstOrDefault(u => u.VarStudentID == studentId);
                //int clsid = Convert.ToInt32(std.RecommendAdmissionClass);
                if (std != null)
                {
                    string clsid = std.PClassID;
                    Class cls = db.Classes.FirstOrDefault(c => c.VarClassID == clsid);
                    studentNameTextBox.Text = std.VarStudentFirstName + " " + std.VarStudentMeddleName + " " +
                                              std.VarStudentLastName;
                    fatherNameTextBox.Text = std.VarFatherName;
                    if (cls != null)
                    {
                        classTextBox.Text = cls.VarClassName;
                        classIdTextBox.Text = cls.VarClassID;
                    }
                }

                msgLabel.Text = "<p style='color:Green;'>Student Exist";
            }
            else
            {
                msgLabel.Text = "<p style='color:Red;'>Student ID not found!";
            }
        }
        else
        {
            msgLabel.Text = "<p style='color:Red;'>Please Insert a valid Student ID!";
        }
    }

    protected void monthToDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int countMonth = GetCountedMonth();

        decimal amount = GetFeesAmount(feesTypeDropDownList.SelectedItem.Text);

        decimal feesAmount = GetCalculatedAmount(countMonth, amount);
        amountTextBox.Text = feesAmount.ToString();
        decimal vatAmount = GetVat(feesAmount);
        vatTextBox.Text = vatAmount.ToString();
        decimal netAmount = GetNetAmount(feesAmount, vatAmount);
        netAmountTextBox.Text = netAmount.ToString();
    }

    private int GetCountedMonth()
    {
        tbl_Month monthFrom =
            db.tbl_Months.FirstOrDefault(m => m.MonthId == Convert.ToInt32(monthFromDropDownList.SelectedItem.Value));
        tbl_Month monthTo =
            db.tbl_Months.FirstOrDefault(m => m.MonthId == Convert.ToInt32(monthToDropDownList.SelectedItem.Value));
        int countMonth = (monthTo.MonthId - monthFrom.MonthId) + 1;
        return countMonth;
    }

    private decimal GetFeesAmount(string feesType)
    {
        IQueryable<tbl_feesInfo> query = (from a in db.GetTable<tbl_feesInfo>()
            select a);
        decimal matches = (from c in query
            where c.VarClassId == classIdTextBox.Text && c.VarFeesName == feesType
            select
                c.Fees).SingleOrDefault();

        return matches;
    }

    public decimal GetCalculatedAmount(int countMonth, decimal matches)
    {
        return countMonth*matches;
    }

    public decimal GetVat(decimal amount)
    {
        return (decimal) (.075*(double) amount);
    }

    public decimal GetNetAmount(decimal calaculatedAmount, decimal vatAmount)
    {
        return calaculatedAmount + vatAmount;
    }

    protected void addButton_Click(object sender, EventArgs e)
    {
        if (receiptTextBox.Text != "")
        {
            if (feesTypeDropDownList.SelectedItem.Value != "0")
            {
                if (sessionDropDownList.SelectedItem.Value != "0")
                {
                    if (amountTextBox.Text != "")
                    {
                        if (Session["feesAddGridViewData"] == null)
                        {
                            PopulateGridView();

                            feesMsgLabel.Text = "";
                        }
                        if (!InsertDataIntoGridView())
                        {
                            feesMsgLabel.Text = "Error Message";
                        }
                    }
                    else
                    {
                        feesMsgLabel.Text = "<p style='color:Red;'>Amount cannot be Empty!";
                    }
                }
                else
                {
                    feesMsgLabel.Text = "<p style='color:Red;'>Please select a Session!";
                }
            }
            else
            {
                feesMsgLabel.Text = "<p style='color:Red;'>Please select a Fees Type!";
            }
        }
        else
        {
            feesMsgLabel.Text = "<p style='color:Red;'>Please insert Receipt No.!";
        }
    }

    protected void feesTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (feesTypeDropDownList.SelectedItem.Value != "0")
        {
            tbl_feesInfo feesInfo =
                db.tbl_feesInfos.FirstOrDefault(
                    u => u.FeesId == Convert.ToInt32(feesTypeDropDownList.SelectedItem.Value));
            int feesTypeId = Convert.ToInt32(feesInfo.FeesType);


            IQueryable<tbl_feesInfo> query = (from a in db.GetTable<tbl_feesInfo>()
                select a);

            decimal matches = (from c in query
                where c.VarClassId == classIdTextBox.Text && c.VarFeesName == feesTypeDropDownList.SelectedItem.Text
                select
                    c.Fees).SingleOrDefault();
            if (feesTypeId == 1)
            {
                monthFromDropDownList.Visible = false;
                monthToDropDownList.Visible = false;
                //monthFromDropDownList.SelectedItem.Text ="N/A";
                //monthToDropDownList.SelectedItem.Text = "N/A";
                decimal feesAmount = matches;
                amountTextBox.Text = feesAmount.ToString();

                var vatAmount = (decimal) (.075*(double) feesAmount);
                vatTextBox.Text = vatAmount.ToString();
                decimal netAmount = feesAmount + vatAmount;
                netAmountTextBox.Text = netAmount.ToString();
            }
            else
            {
                monthFromDropDownList.Visible = true;
                monthToDropDownList.Visible = true;

                amountTextBox.Text = string.Empty;
                vatTextBox.Text = string.Empty;
                netAmountTextBox.Text = string.Empty;
            }
        }
        else
        {
            feesMsgLabel.Text = "<p style='color:Red;'>Select a fees type";
            monthFromDropDownList.Visible = true;
            monthToDropDownList.Visible = true;
            amountTextBox.Text = string.Empty;
            vatTextBox.Text = string.Empty;
            netAmountTextBox.Text = string.Empty;
        }
        string studentId = branchDropDownList.SelectedItem.Text + txtStudentId.Text;
        IQueryable<tbl_feesCollection> his = from u in db.tbl_feesCollections
            where
                u.StudentId == studentId && u.Session == sessionDropDownList.SelectedItem.Text &&
                u.FeesId == Convert.ToInt32(feesTypeDropDownList.SelectedItem.Value)
            select u;
        if (sessionDropDownList.SelectedItem.Value != "0")
        {
            feesHistoryGridView.DataSource = his.AsEnumerable();
            feesHistoryGridView.DataBind();
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        int seedNums = 1;
        char pads = '0';
        string invo = null;

        string result = db.tbl_feesCollections.Max(element => element.VarInvoiceNo);
        if (result != null)
        {
            string subs = result.Substring(8);
            seedNums = Convert.ToInt32(subs);
            seedNums = seedNums + 1;
            string sub = sessionDropDownList.SelectedItem.Text.Substring(2, 2) +
                         sessionDropDownList.SelectedItem.Text.Substring(7, 2);
            invo = ("CL" + "-" + sub + "-" + seedNums.ToString().PadLeft(6, pads));
        }
        else
        {
            string sub = sessionDropDownList.SelectedItem.Text.Substring(2, 2) +
                         sessionDropDownList.SelectedItem.Text.Substring(7, 2);
            invo = ("CL" + "-" + sub + "-" + seedNums.ToString().PadLeft(6, pads));
        }


        IQueryable<tbl_feesInfo> query = (from a in db.GetTable<tbl_feesInfo>()
            select a);

        decimal matches = (from c in query
            where c.VarClassId == classIdTextBox.Text && c.VarFeesName == feesTypeDropDownList.SelectedItem.Text
            select
                c.Fees).SingleOrDefault();
        var vatAmount = (decimal) (.075*(double) matches);
        decimal netAmount = matches + vatAmount;

        foreach (GridViewRow gvrow in addFeesGridView.Rows)
        {
            var feesCollection = new tbl_feesCollection();
            var stdAccount = new tbl_Students_Account();
            //var fType = from c in db.tbl_feesInfos
            //    where c.VarFeesName == gvrow.Cells[1].Text
            //    select c;


            tbl_feesInfo type = db.tbl_feesInfos.FirstOrDefault(u => u.VarFeesName == gvrow.Cells[1].Text);
            tbl_feesInfo fi = db.tbl_feesInfos.FirstOrDefault(f => f.VarFeesName == gvrow.Cells[1].Text);
            if (type != null && type.FeesType == 2)
            {
                string feestype = type.VarFeesName;


                if (gvrow.Cells[1].Text == feestype)
                {
                    tbl_Month fMonth = db.tbl_Months.FirstOrDefault(u => u.MonthName == gvrow.Cells[2].Text);
                    //if (fMonth != null)
                    //{
                    int fmId = fMonth.MonthId;
                    //}
                    tbl_Month tMonth = db.tbl_Months.FirstOrDefault(u => u.MonthName == gvrow.Cells[3].Text);

                    int tmId = tMonth.MonthId;


                    for (int i = fmId; i <= tmId; i++)
                    {
                        var feesSub = new tbl_feesCollectionSub();
                        feesSub.VarStudentId = branchDropDownList.SelectedItem.Text + txtStudentId.Text;

                        feesSub.ReceiptNo = Convert.ToInt32(receiptTextBox.Text);
                        feesSub.VarFeesName = fi.FeesId;
                        feesSub.VarMonth = i.ToString();
                        feesSub.Amount = Math.Round((Convert.ToDecimal(gvrow.Cells[5].Text))/((tmId - fmId) + 1), 2);
                        feesSub.Vat = Math.Round((Convert.ToDecimal(gvrow.Cells[6].Text))/((tmId - fmId) + 1), 2);
                        feesSub.NetAmount = feesSub.Amount + feesSub.Vat;
                        feesSub.VarInvoiceNo = invo;
                        feesSub.Date = Convert.ToDateTime(dateTextBox.Text);
                        feesSub.VarSession = sessionDropDownList.SelectedValue;
                        db.tbl_feesCollectionSubs.InsertOnSubmit(feesSub);
                        db.SubmitChanges();
                    }
                }
            }

            stdAccount.ReceiptNo = Convert.ToInt32(receiptTextBox.Text);
            stdAccount.InvoNo = invo;
            stdAccount.VarSessionId = sessionDropDownList.SelectedValue;
            stdAccount.VarStudentId = branchDropDownList.SelectedItem.Text + txtStudentId.Text;
            stdAccount.PayableFeesId = fi.FeesId;
            stdAccount.PaidAmount = Convert.ToDecimal(gvrow.Cells[5].Text);
            stdAccount.PaidVat = Convert.ToDecimal(gvrow.Cells[6].Text);
            stdAccount.NetPaid = stdAccount.PaidAmount + stdAccount.PaidVat;
            stdAccount.FeesAssignDate = DateTime.Now;
            stdAccount.uid = Session["uid"].ToString();

            //feesCollection.VarInvoiceNo = "CL" + "-" + sessionDropDownList.Text + "-" + result;
            feesCollection.VarInvoiceNo = invo;
            feesCollection.Date = Convert.ToDateTime(dateTextBox.Text);
            feesCollection.ReceiptNo = Convert.ToInt32(receiptTextBox.Text);
            feesCollection.StudentId = branchDropDownList.SelectedItem.Text + txtStudentId.Text;
            feesCollection.ClassName = classTextBox.Text;
            feesCollection.FeesId = fi.FeesId;
            feesCollection.FeesName = gvrow.Cells[1].Text;
            feesCollection.MonthFrom = gvrow.Cells[2].Text;
            feesCollection.MonthTo = gvrow.Cells[3].Text;
            feesCollection.Session = gvrow.Cells[4].Text;
            feesCollection.Amount = Convert.ToDecimal(gvrow.Cells[5].Text);
            feesCollection.Vat = Convert.ToDecimal(gvrow.Cells[6].Text);
            feesCollection.NetAmount = Convert.ToDecimal(gvrow.Cells[7].Text);

            db.tbl_Students_Accounts.InsertOnSubmit(stdAccount);
            db.tbl_feesCollections.InsertOnSubmit(feesCollection);
            db.SubmitChanges();
        }
        saveMsgLiteral.Text = "<p style='color:Green;'>Fees successfully save ";
        addFeesGridView.Visible = false;
        addFeesGridView.DataSource = null;
        addFeesGridView.DataBind();
    }


    protected void sessionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string studentId = branchDropDownList.SelectedItem.Text + txtStudentId.Text;
        //tbl_feesCollectionSub feesSub = db.tbl_feesCollectionSubs.FirstOrDefault(u => u.VarStudentId ==studentId)&& (u=>u.);
        IQueryable<string> chkMonth = from u in db.tbl_feesCollectionSubs
            where u.VarStudentId == studentId && u.VarSession == sessionDropDownList.SelectedItem.Text
            select u.VarMonth;
        var array = new ArrayList();

        //var list = new List<object> { chkMonth.AsEnumerable() };


        IQueryable<tbl_feesCollection> query = (from a in db.GetTable<tbl_feesCollection>()
            select a);
        int? matches = (from c in query
            where
                c.StudentId == branchDropDownList.SelectedItem.Text + txtStudentId.Text &&
                c.Session == sessionDropDownList.SelectedItem.Text
            select
                c.FeesId).FirstOrDefault();
        if (matches != null)
        {
            var feesId = (int) matches;
            ListItem itm = feesTypeDropDownList.Items.FindByValue(feesId.ToString());
            feesTypeDropDownList.Items.Remove(itm);
        }

        if (sessionDropDownList.SelectedItem.Value != "0")
        {
            IQueryable<tbl_feesCollection> his = from u in db.tbl_feesCollections
                where u.StudentId == studentId && u.Session == sessionDropDownList.SelectedItem.Text
                select u;
            feesHistoryGridView.DataSource = his.AsEnumerable();
            feesHistoryGridView.DataBind();
        }
        else
        {
            IQueryable<tbl_feesCollection> his = from u in db.tbl_feesCollections
                where u.StudentId == studentId
                select u;
            feesHistoryGridView.DataSource = his.AsEnumerable();
            feesHistoryGridView.DataBind();
        }
    }

    protected void monthFromDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}