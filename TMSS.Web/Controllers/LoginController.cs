using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System.Diagnostics;
using System.Security.Claims;
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
        [HttpPost]
        public IActionResult Index([Bind] LoginViewModel loginViewModel)
        {
            LoginViewModel userDetails = _mapper.Map<LoginViewModel>(_loginService.IsAuthenticated(_mapper.Map<UserDto>(loginViewModel)));
            if (userDetails == null) throw new Exception("Invalid Credentials");
            if (!userDetails.IsAuthenticated)
            {
                var userClaims = new List<Claim>()
                {
                     new Claim("UserName",userDetails.UserName)
                 //   new Claim(ClaimTypes.Name,userDetails.UserName)
                };
                foreach (var role in userDetails.UserRoles)
                {
                    Claim roleClaim = new Claim(ClaimTypes.Role, role.RoleName);
                    userClaims.Add(roleClaim);
                }
                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);
                if (!userDetails.UserRoles.Any())
                    throw new Exception("Roles are not assigned to User");
                if (userDetails.UserRoles.Any(jj =>
                {
                    return jj.RoleName == RoleTypeCode.User.ToString();
                }))
                {
                    return RedirectToAction("Privacy", "Login");
                }
                else if (userDetails.UserRoles.Any(jj => jj.RoleName == RoleTypeCode.User.ToString()))
                {
                    return RedirectToAction("Privacy", "Login");
                }
                else
                {
                    return View();
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

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "UserAdmin")]
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult UserAccessDenied()
        {
            return View();
        }
    }
}