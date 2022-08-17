using System.Threading.Tasks;
using RestSharp;

namespace MvcApiCall.Models
{
  class ApiHelper//contains a static method ApiCall which takes an apiKey parameter.
  {
    public static async Task<string> ApiCall(string apiKey)//a generic Task can also be returned
    {
      RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");//We instantiate a RestSharp RestClient object and store the connection in a variable called client.

      RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);//Next, we create a RestRequest object. This is our actual request. We include the path to the endpoint we are looking for (home.json) along with our API key. We also specify that we will be using a GET Http method.
      var response = await client.ExecuteTaskAsync(request);//Then we use the await keyword to specify that we need to receive a result before we attempt to define response. We call the RestClient's ExecuteTaskAsync method and pass in our request object.

      
      return response.Content;//Finally, we return the Content property of the response variable, which is a string representation of the response content.
    }
  }
}