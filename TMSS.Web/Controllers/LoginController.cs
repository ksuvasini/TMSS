using AutoMapper;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TMSS.Domain.DTO;
using TMSS.Infrastructure.Enum;
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
        public IActionResult SomeAction()
        {
            // Custom error message
            ModelState.AddModelError("CustomError", "Invalid Credentials");

            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] LoginViewModel loginViewModel)
        {
            LoginViewModel userDetails = _mapper.Map<LoginViewModel>(_loginService.IsAuthenticated(_mapper.Map<UserDto>(loginViewModel)));
            if (userDetails == null)
            {
                ModelState.AddModelError("", "Invalid credentials. Please try again.");

                // SomeAction();
                //throw new Exception("Invalid Credentials");

            }
            else if (userDetails.IsAuthenticated)
            {
                //if (!userDetails.UserRoles.Any())
                //    throw new Exception("Roles are not assigned to User");
                //if (userDetails.UserRoles.Any(jj =>
                //{
                //    return jj.RoleName == RoleTypeCode.User.ToString();
                //}))
                //{
                //    return RedirectToAction("Index", "User");
                //}
                //else if (userDetails.UserRoles.Any(jj => jj.RoleName == RoleTypeCode.User.ToString()))
                //{
                //    return RedirectToAction("Index", "User");
                //}
                if (userDetails.UserName == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "User");

                }
            }
            //if (!userDetails.Any())
            //    throw new Exception("Invalid Credentials"); 
            //if (userDetails.FirstOrDefault().IsAuthenticated)
            //{
            //    if (userDetails.FirstOrDefault().RoleName == "User")
            //    {
            //        return RedirectToAction("Index", "User");
            //    }
            //    else if (userDetails.FirstOrDefault().RoleName == "Admin")
            //    {
            //        return RedirectToAction("Index", "User");
            //    }
            //}
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