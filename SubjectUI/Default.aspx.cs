using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubjectUI_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
  
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        if (DropDownList1.SelectedItem.Text == "B")
        {
            ModalPopupExtender2.Enabled = true;
            ModalPopupExtender2.Show();//popup show
        }
        else
        {
            ModalPopupExtender2.Enabled = false;
            ModalPopupExtender2.Hide();
        }
    }

    protected void btnClose_OnClick_(object sender, EventArgs e)
    {
        ModalPopupExtender2.Enabled = false;
    }

    protected void saveButton_OnClick_OnClick_(object sender, EventArgs e)
    {
        string v = DropDownList1.Items.Cast<ListItem>().Max(j => j.Value);
        DropDownList1.Items.Insert(0, new ListItem(TextBox1.Text, v+"1"));
    }
}