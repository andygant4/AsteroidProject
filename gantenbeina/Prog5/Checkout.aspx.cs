using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
//---------------------------------------------------------------------------------------------
// Class : CS 3870
//
// Name : Andrew Gantenbein
//
// UserName : gantenbeina
//
// Description: Code file for the Checkout.aspx web page in Prog5
//
//---------------------------------------------------------------------------------------------
public partial class Prog5_Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = (System.Data.DataTable)Session["Prog5_Bag"];

        GridView1.DataBind();

    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        // End the current session
        // will clear all session variables          
        Session.Abandon();

        // Logout of Membership 
        FormsAuthentication.SignOut();

       // Go to Login.aspx     
       // Response.Redirect("~/Login.aspx");
        Response.Redirect(FormsAuthentication.LoginUrl);

    }
}