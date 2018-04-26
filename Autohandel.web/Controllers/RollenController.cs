using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autohandel.Domain.Data;
using Autohandel.web.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Autohandel.web.Controllers
{
    public class RollenController : Controller
    {
        private readonly AutohandelContext _context;

        public RollenController(AutohandelContext context)  
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<UserViewModel> modelLst = new List<UserViewModel>();
            var role = _context.UserRoles;

            foreach (var r in role)
            {

                var usr = _context.Users.Find(r.UserId);
                var rol = _context.Roles.Find(r.RoleId);
                var vm = new UserViewModel
                {
                    Username = usr.UserName,
                    Email = usr.Email,
                    RoleName = rol.Name
                };
                modelLst.Add(vm);


            }
            return View(modelLst);
        }

        public IActionResult Users()
        {
            List<UserViewModel> userLst = new List<UserViewModel>();
            var users = _context.Users;

            foreach (var g in users)
            {
                var vm = new UserViewModel
                {
                    Username = g.UserName,
                    Email = g.Email,
                    MislukteLogin = g.AccessFailedCount,
                    PaswoordHash = g.PasswordHash
                };
                userLst.Add(vm);


            }
            return View(userLst);
        }
    }
}