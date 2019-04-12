//---------------------------------------------------------------------------------------------
// Class : CS 3870
//
// Name : Andrew Gantenbein
//
// UserName : gantenbeina
//
// Description: Code file for the OrderingProduct.aspx page
//
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prog2_OrderingProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && (bool)Session["Prog2_Computed"])
        {

            txtQuantity.Text = (string)Session["Prog2_ProductQuantity"];
            txtPrice.Text = (string)Session["Prog2_ProductPrice"];
            txtID.Text = (string)Session["Prog2_ProductID"];
            CalculateTotals();
        }
        else
        {
            txtID.Focus();
        }
    }

    protected void btnCompute_Click(object sender, EventArgs e)
    {

        CalculateTotals();

        Session["Prog2_ProductPrice"] = txtPrice.Text;
        Session["Prog2_ProductQuantity"] = txtQuantity.Text;
        Session["Prog2_ProductID"] = txtID.Text;
        Session["Prog2_Computed"] = true;

        txtQuantity.ReadOnly = true;
        txtID.ReadOnly = true;
        txtPrice.ReadOnly = true;
        btnReset.Focus();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtPrice.Text = "";
        txtQuantity.Text = "";
        txtID.Text = "";
        txtGrandTotal.Text = "";
        txtSubTotal.Text = "";
        txtTax.Text = "";

        txtPrice.ReadOnly = false;
        txtQuantity.ReadOnly = false;
        txtID.ReadOnly = false;
        txtID.Focus();
    }

    private void CalculateTotals()
    {
        float price = float.Parse(txtPrice.Text);
        int quantity = int.Parse(txtQuantity.Text);


        float subtotal = price * quantity;
        float tax = subtotal * .055f;
        float total = tax + subtotal;

        txtSubTotal.Text = subtotal.ToString();
        txtSubTotal.Text = string.Format("{0:c}", subtotal);

        txtTax.Text = tax.ToString();
        txtTax.Text = string.Format("{0:c}", tax);

        txtGrandTotal.Text = total.ToString();
        txtGrandTotal.Text = string.Format("{0:c}", total);

        txtPrice.ReadOnly = true;
        txtQuantity.ReadOnly = true;
    }
}