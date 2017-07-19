using System;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.Script.Serialization;

public partial class All_Set_Up_House : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (IsPostBack != null)
        //{


        //    if (Session["uid"] != null)
        //        Textuid.Text = Session["uid"].ToString();

        //    if (Session["VarBranchId"] != null)
        //        DropDownBranch.SelectedValue = Session["VarBranchId"].ToString();
        //    if (Session["VarShiftCode"] != null)
        //        drpshift.SelectedValue = Session["VarShiftCode"].ToString();

        //}
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        IQueryable<string> checkExistinghouseId = from c in db.tblhouses
            where c.house_Code.Contains(txthousecode.Text)
            select c.house_Code;

        if (checkExistinghouseId.FirstOrDefault() == null)
        {
            var th = new tblhouse();
            th.uid = Session["uid"].ToString();
            th.VarBranchId = Session["VarBranchId"].ToString();
            th.VarShiftCode = Session["VarShiftCode"].ToString();
            th.house_Code = txthousecode.Text;
            th.house_name = txthouse.Text;
            th.address = txtaddress.Text;
            th.remarks = txtremarks.Text;
            ////-------------------API TEST----------------
            //    var data = new
            //    {
            //        value = new
            //        {
            //            SenderNo = th.house_Code,
            //            ReceiverNo = th.house_name,
            //            MessageText= th.address
            //        },
            //        user = "walif",
            //        pass = "356"
            //    };
            //    //string jData = new JavaScriptSerializer().Serialize(data);
            //    using (var client = new WebClient())
            //    {
            //        var dataString = new JavaScriptSerializer().Serialize(data);;
            //        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            //        client.UploadString(new Uri("http://192.168.0.109/Test/api/SMS/SendSms"), "POST", dataString);
            //    }    
            ////--------Finish Test------------------------------
            db.tblhouses.InsertOnSubmit(th);
            db.SubmitChanges();
            Literal1.Text = "Data saved successfully";


            txthouse.Text = "";
            txtaddress.Text = "";
            txtremarks.Text = "";
            Response.Redirect("~/All Set Up/House.aspx");
        }
        else
        {
            Literal1.Text = "House Code Already Exists";
        }
    }
}