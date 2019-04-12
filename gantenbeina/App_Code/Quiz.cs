using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Quiz
/// </summary>
public class Quiz
{
    [JsonProperty]
    public List<Question> questions;

    [JsonProperty]
    public string name;

    [JsonProperty]
    public string description;

    public Quiz()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}