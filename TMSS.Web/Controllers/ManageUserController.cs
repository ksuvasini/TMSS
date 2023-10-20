using AutoMapper;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Infrastructure.Enum;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

namespace TMSS.Web.Controllers
{
    public class ManageUserController : Controller
    {
        private readonly ILogger<ManageUserController> _logger;
        public IManageUserService _Service { get; set; }
        private readonly IMapper _mapper;
        public TMSSDbContext? _dbcontext;

        public ManageUserController(IManageUserService Service, ILogger<ManageUserController> logger, IMapper mapper, TMSSDbContext context)
        {
            _logger = logger;
            _Service = Service;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbcontext = context;
        }

        public async Task<IActionResult> Index(string searchstring)
        {
            try
            {
                if (!String.IsNullOrEmpty(searchstring))
                {
                    IEnumerable<User> users = await _Service.GetManageUsers();
                    searchstring = searchstring.ToLower(); // Convert the search keyword to lowercase
                    users = users
               .Where(s => s.UserName.ToLower().Contains(searchstring) || s.Password.ToLower().Contains(searchstring) || s.EmailID.ToLower().Contains(searchstring)).ToList();
                    return View(users.ToList());
                }
                else
                {
                    IEnumerable<User> users = await _Service.GetManageUsers();
                    return View(users);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return StatusCode(500, "An error occurred while fetching users.");
            }
        }
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            //if (ModelState.IsValid)
            //{
            user.CreatedDate = DateTime.Now;
            user.CreatedBy = "admin";
            var _user = _Service.CreateUsers(user);
            if (_user.UserId > 0)
                return RedirectToAction("Index"); // Redirect to a success page or wherever you need.
            else
                return View();
            // }
            // return Ok(user);
        }
        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<User> users = await _Service.GetManageUsers();

            var clinics = users.Where(c => c.UserId == id).FirstOrDefault();
            return View(clinics);

        }
        [HttpPost]
        public IActionResult Edit(User edituser)
        {

            var _user = _Service.ModifyUsers(edituser);
            return RedirectToAction("Index");


        }
    }
}
