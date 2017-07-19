using System;
using System.Linq;
using System.Web.UI;

public partial class Account_Register : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void CreateUserButton_Click(object sender, EventArgs e)
    {
        String uID = UserName.Text;

        tbl_user_info data = db.tbl_user_infos.Where(d => d.uid == uID).FirstOrDefault();


        if (data == null)
        {
            var ur = new tbl_user_info();

            ur.uid = UserName.Text;
            ur.user_full_name = txtUserFull.Text;
            //ur.email = Email.Text;
            ur.upass = Password.Text;
            //ur.c_password = ConfirmPassword.Text;

            ur.VarBranchId = DropDownList1.Text;
            ur.VarShiftCode = DropDownList2.Text;
            ur.urole = DropDownList3.Text;
            ur.isactive = "True";
            ur.activationDate = Convert.ToDateTime(DateTime.Now);


            db.tbl_user_infos.InsertOnSubmit(ur);
            db.SubmitChanges();

            Literal1.Text = "Registration successfull";


            //UserInfo ui = new UserInfo();

            //ui.uID = data.uID;
            //ui.uPass = data.password;
            //ui.uRole = "Student";


            //Response.Redirect("~/Account/Login.aspx");
            UserName.Text = "";
            txtUserFull.Text = "";
            DropDownList1.SelectedValue = "0";
            DropDownList1.SelectedValue = "0";
            DropDownList1.SelectedValue = "0";
        }

        else
        {
            Literal1.Text = "user ID already exists";
        }
    }
}