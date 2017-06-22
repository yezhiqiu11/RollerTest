using RollerTest.Domain.Abstract;
using RollerTest.Domain.Entities;
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
        private IRealtimeinfoRepository realtimerepo;
        private IRecordinfoRepository recordinforepo;
        public TestBlockController(ISampleinfoRepository repo, IRealtimeinfoRepository rtrepo,IRecordinfoRepository rirepo)
        {
            samplerepo = repo;
            realtimerepo = rtrepo;
            recordinforepo = rirepo;
        }
        // GET: TestBlock
        public ActionResult Index()
        {
            TestListViewModel testlistviewModel = new TestListViewModel()
            {
                rollersampleinfos = samplerepo.RollerSampleInfos.Where(x => x.State == true).Include(x => x.RollerBaseStation).Include(x => x.RollerProjectInfo)
            };
            return View(testlistviewModel);
        }
        public PartialViewResult RealtimeAction(int RollerSampleInfoId)
        {
            RollerRealtimeInfo rollerrealtimeInfo = realtimerepo.RollerRealtimeInfos.FirstOrDefault(x => x.RollerSampleInfoID == RollerSampleInfoId);
            return PartialView(rollerrealtimeInfo);
        }
     
    }
}