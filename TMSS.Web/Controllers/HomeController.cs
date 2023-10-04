using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
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
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] LoginViewModel ad)
        {
            // Db dbcontext = new Db();
            // dbcontext.LoginCheck(ad);
            //int res = dbcontext.LoginCheck(ad);
            //if (res == 1 )
            //{
            if (ad.UserName == "user" && ad.Password == "test")
            {
                // return View("Home/AdminHome");
                return RedirectToAction("Index", "User");

            }

            else if (ad.UserName == "admin" && ad.Password == "test")
            {

                //  return Redirect("~/Admin");
                return RedirectToAction("Index", "Admin");

            }

            //}

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminHome()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}