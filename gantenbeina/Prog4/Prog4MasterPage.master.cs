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
// Description: Code file for the master web page in Prog3. Returns the data source for other
//              web forms
//
//---------------------------------------------------------------------------------------------
public partial class Prog4_Prog4MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public SqlDataSource MyDataSource()
    {
        return SqlDataSource1;
    }

}
