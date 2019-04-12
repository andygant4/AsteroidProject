﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Web.Script.Services;
/// <summary>
/// Summary description for UWPCSSEWebService2018
/// </summary>
[WebService(Namespace = "https://alpha.ion.uwplatt.edu/gantenbeina")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class UWPCSSEWebService2018 : System.Web.Services.WebService
{

    public UWPCSSEWebService2018()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getTFQuiz()
    {
        return File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/truefalse.json"));
    }
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

}
