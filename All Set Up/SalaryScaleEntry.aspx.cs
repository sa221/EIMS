using System;
using System.Web.UI;

public partial class Employee_SalaryScaleEntry : Page
{
    private readonly SWISDataContext db = new SWISDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void scaleSave_Click(object sender, EventArgs e)
    {
        var saScale = new SalaryScale();
        saScale.VarScaleid = Convert.ToInt32(txtScaleId.Text);
        saScale.VarScaleName = txtScaleName.Text;
        saScale.FltBasic = Convert.ToDouble(txtBasic.Text);

        saScale.FltHouseRent = Convert.ToDouble(txtHouseRent.Text);
        saScale.FltMedical = Convert.ToDouble(txtMedical.Text);
        saScale.FltTransport = Convert.ToDouble(txtTransport.Text);
        saScale.FltIncrement = Convert.ToDouble(txtIncrement.Text);
        saScale.FltPF = Convert.ToDouble(txtPf.Text);
        saScale.FltOther = Convert.ToDouble(txtOthers.Text);
        db.SalaryScales.InsertOnSubmit(saScale);
        db.SubmitChanges();
        Literal1.Text = "Salary scale inserted Successfuly";
    }

    //public double sallaryCalculate()
    //{
    //    SalaryScale saScale = new SalaryScale();
    //    double houseRent = saScale.FltHouseRent/100*saScale.FltBasic;
    //    double medical = saScale.FltMedical/100*saScale.FltBasic;
    //    double transport = saScale.FltTransport/100*saScale.FltBasic;
    //    double pf = saScale.FltPF/100*saScale.FltBasic;
    //    double other = saScale.FltOther/100*saScale.FltBasic;
    //    double total = houseRent + medical + transport + pf + other;
    //    return sallaryCalculate(total);
    //}
}