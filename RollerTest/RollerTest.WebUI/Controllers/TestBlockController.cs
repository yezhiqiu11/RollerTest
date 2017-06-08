using RollerTest.Domain.Abstract;
using RollerTest.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollerTest.WebUI.Controllers
{
    public class TestBlockController : Controller
    {
        private ISampleinfoRepository samplerepo;
        public TestBlockController(ISampleinfoRepository repo)
        {
            samplerepo = repo;
        }
        // GET: TestBlock
        public ActionResult Index()
        {
            TestListViewModel testlistviewModel = new TestListViewModel()
            {
                rollersampleinfos = samplerepo.RollerSampleInfos.Where(x => x.State == true).Include(x=>x.RollerBaseStation).Include(x=>x.RollerProjectInfo)
            };
            return View(testlistviewModel);
        }
    }
}