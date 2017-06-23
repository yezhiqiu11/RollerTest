using RollerTest.Domain.Abstract;
using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollerTest.WebUI.Models
{
    public class SampleDecideViewModel
    {
        private ITestreportinfoRepository testreportinfoRepo;

        //public IEnumerable<RollerSampleInfo> rollersampleinfos { get; set; }
        public IEnumerable<RollerTestreportInfo> rollertestreportinfos { get; set; }

    }
}