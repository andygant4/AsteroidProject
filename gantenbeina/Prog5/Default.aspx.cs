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
// Description: Code file for the Default.aspx web page in Prog5
//
//---------------------------------------------------------------------------------------------

public partial class Prog5_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.PageIndex = (int)Session["Prog5_PageIndex"];
        }
    }

    //Saves the current page the user is viewing.
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        Session["Prog5_PageIndex"] = GridView1.PageIndex;
    }
}