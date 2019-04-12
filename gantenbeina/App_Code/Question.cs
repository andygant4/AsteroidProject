using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for Question
/// </summary>
public class Question
{
    [JsonProperty]
    public string image;

    [JsonProperty]
    public string[] choices;

    [JsonProperty]
    public string answer;

    [JsonProperty]
    public string text;

    [JsonProperty]
    public string message;


    public Question()
    {
      
    }
    
}