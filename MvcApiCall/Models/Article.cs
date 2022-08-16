using System.Collections.Generic;
using Newtonsoft.Json;//The type JObject comes from the Newtonsoft.Json.Linq library and is a .NET object we can treat as JSON.
using Newtonsoft.Json.Linq;

namespace MvcApiCall.Models
{
  public class Article
  {
    public string Section { get; set; }
    public string Title { get; set; }
    public string Abstract { get; set; }
    public string Url { get; set; }
    public string Byline { get; set; }

    public static List<Article> GetArticles(string apiKey)
    {
      var apiCallTask = ApiHelper.ApiCall(apiKey);// create a variable to store the returned Task from apiHelper's static async method apiCall(see below in the ApiHelper class)

      var result = apiCallTask.Result;//stored result from action above. In this case: a string representation of API call's response content

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);//converts the JSON-formatted string result into a JObject.

      List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());//DeserializedObject() will auto grab any JSON keys in our response that match the names of the properties in our class. Prop names in class MUST match JSON keys.

      return articleList;
    }
  }
}