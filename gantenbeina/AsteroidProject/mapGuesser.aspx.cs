using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Project_mapGuesser : System.Web.UI.Page
{
    private static string ws_string
    {
        get { return ((ServiceReference1.UWPCSSEWebService2018SoapClient)servRef).getGPSData(); }
    }

    private static object servRef;

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        servRef = new ServiceReference1.UWPCSSEWebService2018SoapClient();
    }

    [WebMethod()]
    public static string GetGPSData()
    {
        return ws_string;
    }
}