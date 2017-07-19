using System;
using System.Linq;
using System.Web.UI;

public partial class AccountsUI_FeesSetup : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            feesAmountTextBox.Text = string.Empty;
            classDropDownList.SelectedValue = "0";
            feesNameDropDownList.SelectedValue = "0";
            typeCheckBox.Checked = false;
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        var feesInfo = new tbl_feesInfo();

        tbl_feesInfo check =
            (from d in db.tbl_feesInfos
                where d.VarFeesName == feesNameDropDownList.SelectedItem.Text && d.VarClassId == classDropDownList.Text
                select d).SingleOrDefault();

        if (check == null)
        {
            if (!classDropDownList.SelectedValue.Equals("0"))
            {
                if (!feesNameDropDownList.SelectedValue.Equals("0"))
                {
                    if (feesAmountTextBox.Text != "")
                    {
                        feesInfo.VarClassId = classDropDownList.Text;
                        feesInfo.FeesId = Convert.ToInt32(feesNameDropDownList.SelectedItem.Value);
                        feesInfo.VarFeesName = feesNameDropDownList.SelectedItem.Text;
                        feesInfo.Fees = Convert.ToDecimal(feesAmountTextBox.Text);
                        if (feesNameDropDownList.SelectedValue == "5")
                        {
                            feesInfo.FeesType = 3; //type 3 for lab fee,cz in lab fee vat not added
                        }
                        else
                        {
                            feesInfo.FeesType = typeCheckBox.Checked ? 1 : 2;
                                //type 1 for admission fees which is yearly fees;2 for tution  which is monthly type fees
                        }


                        db.tbl_feesInfos.InsertOnSubmit(feesInfo);
                        classAllFeesGridView.DataBind();
                        msgLiteral.Text = "Fees Info saved successfuly";
                        feesAmountTextBox.Text = string.Empty;
                        //classDropDownList.SelectedValue = "0";
                        feesNameDropDownList.SelectedValue = "0";
                        typeCheckBox.Checked = false;
                    }
                    else
                    {
                        msgLiteral.Text = "<p style='color:Red;'>Please Input Fees Amount!";
                    }
                }
                else
                {
                    msgLiteral.Text = "<p style='color:Red;'>Please Select Fees Name!";
                }
            }
            else
            {
                msgLiteral.Text = "<p style='color:Red;'>Please Select Class Name!";
            }
        }

        else if (check.Fees != null)
        {
            if (feesAmountTextBox.Text != "")
            {
                check.Fees = Convert.ToDecimal(feesAmountTextBox.Text);
                msgLiteral.Text = "Fees Info update successfully";
            }
            else
            {
                msgLiteral.Text = "<p style='color:Red;'>Please Input Fees Amount!";
            }
        }

        db.SubmitChanges();
        classAllFeesGridView.DataBind();
    }
}