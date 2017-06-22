using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollerTest.WebUI.Models
{
    public class UserRolesViewModel
    {
        public IQueryable<IdentityUserRole> UserRoles { get; set; }
        public IQueryable<IdentityRole> Roles { get; set; }

    }
}