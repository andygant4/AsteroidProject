using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//---------------------------------------------------------------------------------------------
// Class : CS 3870
//
// Name : Andrew Gantenbein
//
// UserName : gantenbeina
//
// Description: Code file for the Shopping.aspx web page in Prog4
//
//---------------------------------------------------------------------------------------------
public partial class Prog4_Shopping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtID.Focus();
            Session["Prog4_ID"] = "";
        }
    }


    protected void txtID_TextChanged(object sender, EventArgs e)
    {
        string id = txtID.Text.Trim();
        var ds = Master.MyDataSource();
        var dv = (System.Data.DataView)ds.Select(DataSourceSelectArguments.Empty);

        dv.RowFilter = "ProductID = '" + id + "'";

        if (dv.Count == 1)
        {
            Session["Prog4_ID"] = id;
            Session["Prog4_UnitPrice"] = txtPrice.Text.Replace("$", "");
            System.Data.DataRow row = dv.ToTable().Rows[0];

            txtName.Text = row[1].ToString();
            txtPrice.Text = string.Format("{0:C}", row[2]);

            txtQuantity.Focus();

        }
        else
        {
            Session["Prog4_ID"] = "";
            txtID.Focus();
        }

    }


    //Calculates the totals based on the ID and quantity.
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        int quantity;
        if ((string)Session["Prog4_ID"] == "")
        {
            txtID.Text = txtName.Text = txtPrice.Text = txtQuantity.Text = txtSub.Text = txtTax.Text = txtTotal.Text = "";
            txtID.Focus();
        }
        else if (!int.TryParse(txtQuantity.Text, out quantity) || quantity < 0)
        {
            txtID.Text = txtName.Text = txtPrice.Text = txtQuantity.Text = txtSub.Text = txtTax.Text = txtTotal.Text = "";
            txtQuantity.Focus();
        }
        else
        {
            float price = 0.0f;
            if (txtPrice.Text != "")
            {
                price = float.Parse(txtPrice.Text.Replace("$", ""));
            }
            //float price = float.Parse(txtPrice.Text.Replace("$", ""));
            int quan = int.Parse(txtQuantity.Text);

            float subtotal = price * quan;
            float tax = subtotal * .055f;
            float total = tax + subtotal;

            txtSub.Text = subtotal.ToString();
            txtSub.Text = string.Format("{0:c}", subtotal);

            txtTax.Text = tax.ToString();
            txtTax.Text = string.Format("{0:c}", tax);

            txtTotal.Text = total.ToString();
            txtTotal.Text = string.Format("{0:c}", total);
        }
    }

}