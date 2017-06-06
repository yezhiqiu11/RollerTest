using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollerTest.WebUI.Models
{
    public class SampleViewModel
    {
        public RollerProjectInfo rollerprojectinfo { get; set; }
        public IEnumerable<RollerSampleInfo> rollersampleinfos {get;set;}
    }
}