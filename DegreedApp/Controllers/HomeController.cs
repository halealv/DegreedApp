using APIClient;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DegreedApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRandom()
        {
            List<JokeClass> list = new List<JokeClass>();

            var joke = APIClientService.GetRandomJoke();

            list.Add(joke);

            return PartialView("JokeList", list);
        }

        public ActionResult GetFiltered(FilterClass filter)
        {
            var jokes = APIClientService.GetListJoke(filter);

            return PartialView("JokeList", jokes.Results);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}