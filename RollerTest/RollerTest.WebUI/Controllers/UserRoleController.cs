using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RollerTest.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollerTest.WebUI.Controllers
{
    public class UserRoleController : Controller
    {
        // GET: UserRole
        public ActionResult Index()
        {
            return View();
        }
        //
        //Role
        public ActionResult RoleIndex()
        {
            var rm = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(new ApplicationDbContext()));
            RoleViewModel rvm = new RoleViewModel()
            {
                Roles = rm.Roles
            };
            return View(rvm);
        }
        public ActionResult CreateRoles()
        {
            var rolename = Request["rolename"];
            IdentityManager idm = new IdentityManager();
            idm.CreateRole(rolename);
            return RedirectToAction("RoleIndex", "UserRole");
        }
        public ActionResult DeleteRoles(string roleid)
        {
            IdentityManager idm = new IdentityManager();
            idm.DeleteRole(roleid);
            return RedirectToAction("RoleIndex", "UserRole");
        }

        //
        //User
        public ActionResult UserIndex()
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            UserViewModel uvm = new UserViewModel()
            {
                Users = um.Users.Include(x => x.Roles)
            };
            return View(uvm);
        }
        public ActionResult DeleteUsers(string userid)
        {
            IdentityManager idm = new IdentityManager();
            idm.DeleteUser(userid);
            return RedirectToAction("UserIndex", "UserRole");
        }
        public ActionResult UserRolesIndex(string userId)
        {
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var rm = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(new ApplicationDbContext()));
            ViewData["userId"] = userId;
            ViewData["RoleList"] = rm.Roles.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Name
            });
            UserRolesViewModel urvm = new UserRolesViewModel()
            {
                UserRoles = um.FindById(userId).Roles.AsQueryable(),
                Roles = rm.Roles
            };
            return View(urvm);
        }
        public ActionResult CreateUserRole()
        {
            var rolename = Request["rolename"];
            var userid = Request["userid"];
            IdentityManager idm = new IdentityManager();
            idm.AddUserToRole(userid, rolename);
            return RedirectToAction("UserRolesIndex", "UserRole", new { userId = userid });

        }
        public ActionResult DeleteUserRoles(string userId, string roleName)
        {
            IdentityManager idm = new IdentityManager();
            idm.DeleteUserRole(userId, roleName);
            return RedirectToAction("UserRolesIndex", "UserRole", new { userId = userId });
        }
        public ActionResult ClearUserRoles(string userId)
        {
            IdentityManager idm = new IdentityManager();
            idm.ClearUserRoles(userId);
            return RedirectToAction("UserRolesIndex", "UserRole", new { userId = userId });
        }
        public PartialViewResult LoginName()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            return PartialView(user);
        }

    }
}