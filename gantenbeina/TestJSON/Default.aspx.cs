using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Web.Services;

public partial class TestJSON_Default : System.Web.UI.Page
{
    private string jsonPath = "K:/Courses/CSSE/yangq/cs3870/gantenbeina/TestJSON/info.json";
    private static Quiz quiz;
    private int index;

    protected void Page_Load(object sender, EventArgs e)
    {
        quiz = JsonConvert.DeserializeObject<Quiz>(File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/info.json")));
        Image1.ImageUrl = quiz.questions[index].image;
        foreach(string s in quiz.questions[index].choices)
        {
            ddAnswers.Items.Add(s);
        }
    }

    //[JsonProperty]
    //private List<string> questions;

    //[JsonProperty]
    //private List<string> answers;

    //[JsonProperty]
    //private List<string> imgTextures;
    //private int count;
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    JObject j = JObject.Parse(File.ReadAllText("K:/Courses/CSSE/yangq/cs3870/gantenbeina/TestJSON/questions.json"));

    //    JToken q = j[0];

    //    count = 0;
    //    questions = new List<string>();
    //    answers = new List<string>();
    //    imgTextures = new List<string>();
    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    TextBox1.Text = questions[count % 3];
    //    TextBox2.Text = answers[count % 3];
    //    Image1.ImageUrl = imgTextures[count % 3];
    //    count++;
    //}

    [WebMethod()]
    public static string getQuiz(int ID)
    {
        return File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/"+ ID + ".json"));

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ddAnswers.Items.Clear();
        if (quiz.questions[index].answer == ddAnswers.SelectedValue)
            lblAnswer.Text = "Correct!";
        else
            lblAnswer.Text = "Wrong!";
        index++;
        Image1.ImageUrl = quiz.questions[index % 3].image;
        foreach (string s in quiz.questions[index % 3].choices)
        {
            ddAnswers.Items.Add(s);
        }

    }
}

