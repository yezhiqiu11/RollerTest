using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollerTest.WebUI.Models
{
    public class UserViewModel
    {
        public IQueryable<ApplicationUser> Users { get; set; }
    }
}