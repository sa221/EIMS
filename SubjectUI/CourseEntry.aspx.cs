using System;
using System.Linq;
using System.Web.UI;

public partial class SubjectUI_CourseEntry : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void courseSave_Click(object sender, EventArgs e)
    {
        //tbl_EdxelSubject subTbl = new tbl_EdxelSubject();

        var unitCode = new tbl_EdexelunitCode();

        var sub = new tbl_Subject();
        Literal1.Text = "";
        Literal2.Text = "";
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";

        Class classs = db.Classes.FirstOrDefault(u => u.VarClassID == dropDownClass.SelectedItem.Value);
        if (classs != null)
        {
            int classType = Convert.ToInt32(classs.ClassType);

            if (dropDownClass.SelectedItem.Value != "0")
            {
                if (txtSubTitle.Text != "")
                {
                    if (txtSpeId.Text != "")
                    {
                        if (classType == 1 || classType == 3)
                        {
                            IQueryable<string> checkExisting = from c in db.tbl_Subjects
                                where
                                    c.VarSubjectName.Equals(txtSubTitle.Text) &&
                                    c.ClassId.Equals(dropDownClass.SelectedItem.Value)
                                select c.VarSubjectName;
                            if (checkExisting.FirstOrDefault() != null)
                            {
                                failStatusLabel.InnerText = "Subject already exist...!";
                                return;
                            }
                            sub.VarClassName = dropDownClass.SelectedItem.Text;
                            sub.ClassId = dropDownClass.SelectedValue;
                            sub.VarSubjectName = txtSubTitle.Text;
                            sub.VarSubjectCode = txtSpeId.Text;
                            sub.Type = CheckBox1.Checked ? 1 : 2;
                            sub.ExamType = examTypeCheckBox.Checked ? "Oral" : "Written";
                            sub.IsLab = labCheckBox.Checked ? 1 : 0;
                            sub.uid = Session["uid"].ToString();
                            sub.VarBranchId = Session["VarBranchId"].ToString();
                            sub.VarShiftCode = Session["VarShiftCode"].ToString();
                            db.tbl_Subjects.InsertOnSubmit(sub);
                        }

                        else if (classType == 2)
                        {
                            IQueryable<string> checkExisting = from c in db.tbl_Subjects
                                where c.VarSubjectCode == txtSpeId.Text && c.ClassId == dropDownClass.SelectedValue
                                select c.VarSubjectName;
                            if (checkExisting.FirstOrDefault() != null)
                            {
                                Literal2.Text = "Subject exist";
                            }
                            else
                            {
                                sub.VarClassName = dropDownClass.SelectedItem.Text;
                                sub.ClassId = dropDownClass.SelectedValue;
                                sub.VarSubjectName = txtSubTitle.Text;
                                sub.VarSubjectCode = txtSpeId.Text;
                                //sub.VarASCode = asCodeTextBox.Text;
                                sub.uid = Session["uid"].ToString();
                                sub.VarBranchId = Session["VarBranchId"].ToString();
                                sub.VarShiftCode = Session["VarShiftCode"].ToString();
                                if (CheckBox1.Checked)
                                {
                                    sub.Type = 1;
                                }
                                else
                                {
                                    sub.Type = 2;
                                }
                                sub.IsLab = labCheckBox.Checked ? 1 : 0;
                                db.tbl_Subjects.InsertOnSubmit(sub);
                            }
                            unitCode.Class = dropDownClass.SelectedValue;
                            unitCode.UnitCode = txtUnitCode.Text;
                            unitCode.UnitCodeSpeCode = unitCodeSpeTextBox.Text;
                            unitCode.SpecificationCode = txtSpeId.Text;
                            unitCode.uid = Session["uid"].ToString();
                            unitCode.VarBranchId = Session["VarBranchId"].ToString();
                            unitCode.VarShiftCode = Session["VarShiftCode"].ToString();
                            if (CheckBox1.Checked)
                            {
                                unitCode.Type = 1;
                            }
                            else
                            {
                                unitCode.Type = 2;
                            }
                            db.tbl_EdexelunitCodes.InsertOnSubmit(unitCode);
                        }

                        db.SubmitChanges();
                        showSubjectGridView.DataBind();
                        successStatusLabel.InnerText = "Course entry successful";
                    }
                    else
                    {
                        failStatusLabel.InnerText = "Please insert Subject Specification Code!";
                    }
                }
                else
                {
                    failStatusLabel.InnerText = "Please insert Subject Name!";
                }
            }
            else
            {
                failStatusLabel.InnerText = "Please select a Class!";
                Literal1.Text = "<p style='color:Red;'>";
            }
        }
    }

    protected void dropDownClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        successStatusLabel.InnerText = "";
        failStatusLabel.InnerText = "";
        txtSpeId.Text = "";
        txtSubTitle.Text = "";
        Class classs = db.Classes.FirstOrDefault(u => u.VarClassID == dropDownClass.SelectedItem.Value);


        //showSubjectGridView.DefaultCellStyle.NullValue = "N/A";


        if (classs != null)
        {
            int classType = Convert.ToInt32(classs.ClassType);
            if (classType == 1 || classType == 3)
            {
                //asCodeTextBox.Visible = false;
                txtUnitCode.Visible = false;
                unitCodeSpeTextBox.Visible = false;
                //unitCodeLiteral.Text = "Not required for " + dropDownClass.SelectedItem.Text;
            }
            else
            {
                //asCodeTextBox.Visible = true;
                txtUnitCode.Visible = true;
                unitCodeSpeTextBox.Visible = true;
                //unitCodeLiteral.Text = "";
            }
        }
    }
}