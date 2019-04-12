using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Project_Quiz : System.Web.UI.Page
{
    [WebMethod()]
    public static string getQuiz(string name)
    {
        return File.ReadAllText(HttpContext.Current.Server.MapPath("./assets/" + name + ".json"));
    }
}