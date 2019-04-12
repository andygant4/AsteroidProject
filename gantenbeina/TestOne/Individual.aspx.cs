using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestOne_Individual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            DisplayRow((int)Session["Test1_Index"]);
    }

    private void DisplayRow(int index)
    {
        System.Data.DataRow row
                          = TestOne_SQLDataClass.tblEmployee.Rows[index];

        txtID.Text = row[0].ToString();
        txtFirst.Text = row[1].ToString();
        txtLast.Text = row[2].ToString();
        txtHireDate.Text = string.Format("{0:d}", row[3]);
        txtPosition.Text = row[4].ToString();
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        int index = (int)Session["Test1_Index"] - 1;
        if (index < 0)
            index = 0;
        Session["Test1_Index"] = index;
        DisplayRow(index);
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        int index = (int)Session["Test1_Index"] + 1;
        if (index > TestOne_SQLDataClass.tblEmployee.Rows.Count - 1)
            index = TestOne_SQLDataClass.tblEmployee.Rows.Count - 1;
        Session["Test1_Index"] = index;
        DisplayRow(index);
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        txtID.Text = "";
        txtFirst.Text = "";
        txtLast.Text = "";
        txtPosition.Text = "";
        txtHireDate.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string theID = txtID.Text;
            string firstName = txtFirst.Text;
            string lastName = txtLast.Text;
            string hireDate = txtHireDate.Text;
            string pos = txtPosition.Text;
            TestOne_SQLDataClass.InsertEmployee(theID, firstName, lastName, hireDate, pos);
            txtMessage.Value = "New Record Saved.";
            TestOne_SQLDataClass.getAllEmployees();
        }
        catch (Exception ex)
        {

            txtMessage.Value = "Employee Not Inserted: " + ex.Message;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string theID = txtID.Text;
            TestOne_SQLDataClass.DeleteEmployee(theID);
            txtMessage.Value = "Record Deleted.";
            TestOne_SQLDataClass.getAllEmployees();

            int index = (int)Session["Test1_Index"] + 1;
            DisplayRow(index);
            Session["Test1_Index"] = index;
        }
        catch (Exception ex)
        {
            txtMessage.Value = "Employee Not Deleted: " + ex.Message;
        }
    }

}