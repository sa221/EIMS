using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class All_Set_Up_InterviewTimeAndSlotSetup : System.Web.UI.Page
{
    private SWISDataContext db = new SWISDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSlotGrid();
            LoadTimeGrid();
        }
        
    }
    protected void LoadSlotGrid()
    {
        var getSlot = from x in db.tbl_InterviewSlots
                          select new { x.InterviewSlot };
        slotGridView.DataSource = getSlot.AsEnumerable();
        slotGridView.DataBind();

    }
    protected void LoadTimeGrid()
    {
        var getTime = from x in db.tbl_InterViewTimes
                      orderby x.InterViewTime ascending
                      select new { x.InterViewTime };
        timeGridView.DataSource = getTime.AsEnumerable();
        timeGridView.DataBind();

    }
    protected void slotSaveButton_Click1(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        tbl_InterviewSlot chkSlotName = db.tbl_InterviewSlots.FirstOrDefault(x => x.InterviewSlot == slotNameTextBox.Text.Trim());
        if (chkSlotName == null)
        {
            tbl_InterviewSlot empSlot = new tbl_InterviewSlot();

            empSlot.InterviewSlot = slotNameTextBox.Text;

            db.tbl_InterviewSlots.InsertOnSubmit(empSlot);
            db.SubmitChanges();
            slotNameTextBox.Text = String.Empty;
            successStatusLabel.InnerText = "Interview Slot Insert Successfully.";
            LoadSlotGrid();
        }
        else
        {
            failStatusLabel.InnerText = "Interview Slot Name Already Exist!";
        }

    }
    protected void timeSaveButton_Click(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        tbl_InterViewTime chkTimeName = db.tbl_InterViewTimes.FirstOrDefault(x => x.InterViewTime == timeTextBox.Text.Trim());
        if (chkTimeName == null)
        {
            tbl_InterViewTime empTime = new tbl_InterViewTime();

            empTime.InterViewTime = timeTextBox.Text;

            db.tbl_InterViewTimes.InsertOnSubmit(empTime);
            db.SubmitChanges();
            slotNameTextBox.Text = String.Empty;
            successStatusLabel.InnerText = "Interview Time Insert Successfully.";
            LoadTimeGrid();
        }
        else
        {
            failStatusLabel.InnerText = "Interview Time Already Exist!";
        }

    }
}