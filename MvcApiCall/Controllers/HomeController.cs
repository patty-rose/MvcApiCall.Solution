using Microsoft.AspNetCore.Mvc;
using MvcApiCall.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using RestSharp;

namespace MvcApiCall.Controllers
{
  public class HomeController : Controller
    {

      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
          _logger.LogInformation("woohoo");
          var apiCallTask = ApiHelper.ApiCall("goJIpDLVGSytpsALpO3B0YsAwwAj0CLo");
          var result = apiCallTask.Result;
          _logger.LogInformation(result);//log api call result

            var allArticles = Article.GetArticles(EnvironmentVariables.ApiKey);//because GetArticles() is a static method, it's called on the Article class itself.

            return View(allArticles);
        }
    }
}