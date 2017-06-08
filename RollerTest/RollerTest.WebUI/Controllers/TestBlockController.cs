using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RollerTest.Domain.Abstract;
using RollerTest.WebUI.Models;
using RollerTest.Domain.Entities;

namespace RollerTest.WebUI.Controllers
{
    public class TestBlockController : Controller
    {
        private ISampleinfoRepository sampleinforepository;
        public TestBlockController(ISampleinfoRepository samplerepo, IBaseRepository baserepo)
        {
            sampleinforepository = samplerepo;
        }
        // GET: TestBlock
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BeforeTestInfo()
        {

            return View();
        }

        public ActionResult TestingInfo()
        {       
            ViewData["RollerSampleInfoID"] = sampleinforepository.RollerSampleInfos.Where(a => a.State == true).Select(a => new SelectListItem
            {
                Text = a.SampleID,
                Value = a.SampleID.ToString()
            });

            return View("TestingInfoView", new RollerRecordInfo());
        }

        public ActionResult AfterTestingInfo()
        {
            return View();
        }

    }
}