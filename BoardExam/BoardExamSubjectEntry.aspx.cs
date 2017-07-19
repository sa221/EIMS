using System;
using System.Linq;

namespace BoardExam
{
    public partial class BoardExamBoardExamSubjectEntry : System.Web.UI.Page
    { 
        SWISDataContext db=new SWISDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        protected void courseSave_Click(object sender, EventArgs e)
        {
            successStatusLabel.InnerText = "";
            failStatusLabel.InnerText = "";
            tbl_BoardSubject subject=new tbl_BoardSubject();

            subject.Board = boardDropDownList.SelectedValue;
            subject.ClassLevel = classDropDownList.SelectedValue;
            subject.QualificationLevel = qLevelDropDownList.SelectedValue;
            subject.SubCode = subCodeTextBox.Text;
            subject.SubName = subNameTextBox.Text;
            subject.UnitCode = unitCodeSpeTextBox.Text;
            subject.UnitName = unitTextBox.Text;
            subject.UniqueId = subCodeTextBox.Text + unitCodeSpeTextBox.Text;
            if (theoryRadioButton.Checked)
            {
                subject.SubType = theoryRadioButton.Text;
            }
            else if (pactricalRadioButton.Checked)
            {
                subject.SubType = pactricalRadioButton.Text;
            }
            db.tbl_BoardSubjects.InsertOnSubmit(subject);
            db.SubmitChanges();
            LoadGrid();
            successStatusLabel.InnerText = "Subject Added Successfully.";
            ClearForm();
        }

        private void LoadGrid()
        {
            var getAllSubject = from x in db.tbl_BoardSubjects
                                orderby x.SubName
                select new {x.Board,x.ClassLevel,x.SubCode,x.SubName,x.UnitCode,x.UnitName,x.SubType,x.QualificationLevel};
            showSubjectGridView.DataSource = getAllSubject.AsEnumerable();
            showSubjectGridView.DataBind();
        }

        private void ClearForm()
        {
            subCodeTextBox.Text = String.Empty;
            subNameTextBox.Text = String.Empty;
            unitCodeSpeTextBox.Text = String.Empty;
            unitTextBox.Text = String.Empty;
        }
    }
}