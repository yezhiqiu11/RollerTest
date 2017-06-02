using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollerTest.WebUI.Models
{
    public class ProjectListViewModel
    {
        public IEnumerable<RollerProjectInfo> rollerprojectinfos  { get; set; }

    }
}