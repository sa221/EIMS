using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResultProcessing_TabulationTest : System.Web.UI.Page
{
    static DataTable dt = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            CreateDataTable();
    }

    private void CreateDataTable()
    {

        if (dt == null)
        {
            string[] cols = { "Age Group", "Admin", "Systems", "HR", "IT" };
            string[,] data = { { "18-25", "25", "20", "35", "40" }, { "25-35", "25", "75", "65", "45" }, { "35-45", "25", "35", "20", "16" } };
            dt = new DataTable();
            foreach (string str in cols)
                dt.Columns.Add(str);
            for (int i = 0; i < 3; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < 5; j++)
                {
                    dr[j] = data[i, j];
                }
                dt.Rows.Add(dr);
            }
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            if (gvRow.Cells[0].Text == "Age Group")
            {
                gvRow.Cells.Remove(gvRow.Cells[0]);
                GridViewRow gvHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell headerCell0 = new TableCell()
                {
                    Text = "Age Group",
                    HorizontalAlign = HorizontalAlign.Center,
                    RowSpan = 2
                };
                TableCell headerCell1 = new TableCell()
                {
                    Text = "No. Of Employees",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 4
                };
                gvHeader.Cells.Add(headerCell0);
                gvHeader.Cells.Add(headerCell1);
                GridView1.Controls[0].Controls.AddAt(0, gvHeader);
            }
        }
    }
}