using RollerTest.Domain.Abstract;
using RollerTest.Domain.Entities;
using RollerTest.WebUI.IniFiles;
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
        private IBaseRepository baserepo;
        private IRealtimeinfoRepository realtimerepo;
        public TestBlockController(ISampleinfoRepository repo, IRealtimeinfoRepository rtrepo,IBaseRepository baserepo)
        {
            samplerepo = repo;
            realtimerepo = rtrepo;
            this.baserepo = baserepo;
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
        public void OpenTest(int StationId)
        {
            baserepo.ChangeStationState(StationId, true);
            IniFileControl.GetInstance().OpenRollerTimeSwitch(baserepo.RollerBaseStations.FirstOrDefault(x => x.RollerBaseStationID == StationId).Station);
            Response.Redirect("/TestBlock/Index");
        }
        public void CloseTest(int StationId)
        {
            baserepo.ChangeStationState(StationId, false);
            IniFileControl.GetInstance().CloseRollerTimeSwitch(baserepo.RollerBaseStations.FirstOrDefault(x => x.RollerBaseStationID == StationId).Station);
            Response.Redirect("/TestBlock/Index");
        }
        public void CleanTest(int StationId)
        {
            IniFileControl.GetInstance().CleanRollerTime(baserepo.RollerBaseStations.FirstOrDefault(x => x.RollerBaseStationID == StationId).Station);
            Response.Redirect("/TestBlock/Index");
        }


    }
}