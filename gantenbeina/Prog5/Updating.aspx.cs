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
// Description: Code file for the Updating.aspx web page in Prog5
//
//---------------------------------------------------------------------------------------------
public partial class Prog5_Updating : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int record = (int)Session["Prog4_RecordIndex"];
            DetailsView1.PageIndex = record;
        }

    }

    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            txtMessage.Value = e.Exception.Message;
        }
        else
        {
            txtMessage.Value = "Record Inserted.";
        }

    }

    protected void DetailsView1_PageIndexChanged(object sender, EventArgs e)
    {
        Session["Prog4_RecordIndex"] = DetailsView1.PageIndex;
    }

    protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            txtMessage.Value = e.Exception.Message;
        }
        else
        {
            txtMessage.Value = "Record Deleted.";
        }
    }

    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            txtMessage.Value = e.Exception.Message;
        }
        else
        {
            txtMessage.Value = "Record Updated.";
        }
    }
}