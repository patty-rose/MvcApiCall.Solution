using Microsoft.AspNetCore.Mvc;
using MvcApiCall.Models;

namespace MvcApiCall.Controllers
{
  public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allArticles = Article.GetArticles(EnvironmentVariables.ApiKey);//because GetArticles() is a static method, it's called on the Article class itself.

            return View(allArticles);
        }
    }
}