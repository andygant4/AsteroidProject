<%@ Application Language="C#" %>

<script runat="server">
//---------------------------------------------------------------------------------------------
// Class : CS 3870
//
// Name : Andrew Gantenbein
//
// UserName : gantenbeina
//
// Description: Global file Global.asax of Prog2 and future programs
//
//---------------------------------------------------------------------------------------------
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        //SQLDataClass.setupProdAdapter();

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Session["Prog2_ProductID"] = "";
        Session["Prog2_ProductPrice"] = "20";
        Session["Prog2_ProductQuantity"] = "5";
        Session["Prog2_Computed"] = false;

        //Program 3
        Session["Prog3_Index"] = 0;
        Session["Prog3_ID"] = "";
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
