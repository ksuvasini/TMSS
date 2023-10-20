using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TMSS.Services.Interfaces;
using TMSS.Services.Services;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class AdminController : Controller
    {
        public IRoleManagementService _roleManagementService { get; set; }

        private readonly ILogger<LoginController> _logger;
        public ILoginService _loginService { get; set; }
        private readonly IMapper _mapper;

        public AdminController(IRoleManagementService roleManagementService, ILogger<LoginController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _roleManagementService = roleManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole([Bind] RoleViewModel roleViewModel)
        {
            var result = _roleManagementService.AddRole(new TMSS.Domain.DTO.RoleDto());
            var userRoles = _roleManagementService.GetRoles();
            return View(userRoles);
        }

        public IActionResult AssignUserRole()
        {
            UserRoleViewModel userRoles = new UserRoleViewModel();
            // userRoles.Roles.AddRange(_mapper.Map<List<RoleViewModel>>(_roleManagementService.GetUserRoles()));
            userRoles.Roles = new List<SelectListItem>();
            userRoles.Roles.Add(new SelectListItem() { Text = "Email", Value = "1", Selected = false });
            userRoles.Users = new List<SelectListItem>();
            userRoles.Users.Add(new SelectListItem() { Text = "UserEmail", Value = "1", Selected = false });

            return View(userRoles);
        }

        [HttpPost]
        public IActionResult AssignUserRole([Bind] UserRoleViewModel roleViewModel)
        {
            var result = _roleManagementService.AssignRoles(new TMSS.Domain.DTO.RoleDto());
            var userRoles = _roleManagementService.GetUserRoles();
            return View(userRoles);
        }

    }
}
