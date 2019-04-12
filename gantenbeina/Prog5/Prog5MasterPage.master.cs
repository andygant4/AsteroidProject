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
// Description: Code file for the master web page in Prog5. Returns the data source for other
//              web forms
//
//---------------------------------------------------------------------------------------------

public partial class Prog5_Prog5MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public SqlDataSource MyDataSource()
    {
        return SqlDataSource1;
    }
    protected void LoginStatus1_LoggingOut(object sender, EventArgs e)
    {
        Session.Abandon();

        FormsAuthentication.SignOut();

        Response.Redirect("~/Login.aspx");
    }

}
