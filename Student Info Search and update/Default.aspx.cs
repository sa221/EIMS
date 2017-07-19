using System;
using System.Web.UI;

public partial class Student_Attendence_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Label1.Text = "UpdatePanel1 refreshed at: " +
                      DateTime.Now.ToLongTimeString();
        Label2.Text = "UpdatePanel2 refreshed at: " +
                      DateTime.Now.ToLongTimeString();
    }
}