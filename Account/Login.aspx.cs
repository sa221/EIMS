using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

public partial class Account_Login : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        //RegisterHyperLink.NavigateUrl = "~/Admin/Register.aspx";
        //?ReturnUrl=" +
        // HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    public void LoginButton_Click(object sender, EventArgs e)
    {
        tbl_user_info data = db.tbl_user_infos.Where(d => d.uid == UserName.Text).FirstOrDefault();

        //lbllogin.Text = data.uID.ToString();

        if (data != null)
        {
            if (data.upass == Password.Text)
            {
                Session["uid"] = data.uid;
                Session["VarBranchId"] = data.VarBranchId;
                Session["VarShiftCode"] = data.VarShiftCode;
                FormsAuthentication.RedirectFromLoginPage(data.urole, RememberMe.Checked);
            }
            else
            {
                FailureText.Text = "<script>alert('Password does not match !!!');</script>";
            }
        }
        else
        {
            FailureText.Text = "<script>alert('Invalid User !!!');</script>";
        }

        //if (Session["uid"]!=null)
        //       {
        //           Response.Redirect("~/About.aspx");


        //       }
    }
    protected void linkGoSomewhere_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Register.aspx");
    }
}