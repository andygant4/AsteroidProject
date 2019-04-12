using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prog3_Updating : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            DisplayRow((int)Session["Prog3_Index"]);
    }

    private void DisplayRow(int index)
    {
        System.Data.DataRow row
                          = SQLDataClass.tblProduct.Rows[index];

        txtID.Text = row[0].ToString();
        txtName.Text = row[1].ToString();
        txtPrice.Text = string.Format("{0:C}", row[2]);
        txtDescription.Text = row[3].ToString();
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        int index = 0;
        Session["Prog3_Index"] = index;
        DisplayRow(index);
    }

    protected void btnPrevious_Click1(object sender, EventArgs e)
    {
        int index = (int)Session["Prog3_Index"] - 1;
        if (index < 0)
            index = 0;
        Session["Prog3_Index"] = index;
        DisplayRow(index);
    }

    protected void btnNext_Click1(object sender, EventArgs e)
    {
        int index = (int)Session["Prog3_Index"] + 1;
        if (index > SQLDataClass.tblProduct.Rows.Count - 1)
            index = SQLDataClass.tblProduct.Rows.Count - 1;
        Session["Prog3_Index"] = index;
        DisplayRow(index);
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        int index = SQLDataClass.tblProduct.Rows.Count - 1;
        Session["Prog3_Index"] = index;
        DisplayRow(index);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string theID = txtID.Text;
            string newName = txtName.Text;
            double newPrice = double.Parse(txtPrice.Text.Replace("$", ""));
            string newDesc = txtDescription.Text;
            SQLDataClass.UpdateProduct(theID, newName, newPrice, newDesc);
            txtMessage.Text = "Record updated.";
            SQLDataClass.getAllProducts();
        }
        catch (Exception ex)
        {
            txtMessage.Text = "Product Not Updated: " + ex.Message;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (btnNew.Text.Equals("Save New"))
        {
            try
            {
                string theID = txtID.Text;
                string newName = txtName.Text;
                double newPrice = double.Parse(txtPrice.Text.Replace("$", ""));
                string newDesc = txtDescription.Text;
                SQLDataClass.InsertProduct(theID, newName, newPrice, newDesc);
                txtMessage.Text = "Record updated.";
                SQLDataClass.getAllProducts();
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Product Not Inserted: " + ex.Message;
            }
        }
        else if (btnNew.Text.Equals("New"))
        {
            txtDescription.Text = "";
            txtID.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";

            btnUpdate.Enabled = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
        }


    }
} 