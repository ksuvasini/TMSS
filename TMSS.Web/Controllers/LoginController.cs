using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TMSS.Domain.DTO;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        public ILoginService _loginService { get; set; }
        private readonly IMapper _mapper;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger, IMapper mapper)
        {
            _logger = logger;
            _loginService = loginService;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] LoginViewModel loginViewModel)
        {


            var userDetails = _loginService.IsAuthenticated(_mapper.Map<UserDto>(loginViewModel));

            if (userDetails.FirstOrDefault().IsAuthenticated)
            {
                if (userDetails.FirstOrDefault().RoleName == "User")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (userDetails.FirstOrDefault().RoleName == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            //if (ad.UserName == "user" && ad.Password == "test")
            //{
            //    // return View("Home/AdminHome");
            //    return RedirectToAction("Index", "User");

            //}

            //else if (ad.UserName == "admin" && ad.Password == "test")
            //{

            //    //  return Redirect("~/Admin");
            //    return RedirectToAction("Index", "Admin");

            //}

            //}

            return View();
        }



        public IActionResult Privacy()
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