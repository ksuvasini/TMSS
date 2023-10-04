using Microsoft.AspNetCore.Mvc;

namespace TMSSDemo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
