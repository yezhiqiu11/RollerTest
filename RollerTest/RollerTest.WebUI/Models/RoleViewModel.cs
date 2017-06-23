using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollerTest.WebUI.Models
{
    public class RoleViewModel
    {
        public IQueryable<IdentityRole> Roles { get; set; }
    }
}