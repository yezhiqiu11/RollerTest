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
        private IBaseRepository baserepository;
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
            SettingViewModel settingviewModel = new SettingViewModel(baserepository);
            //ViewData["StandardList"] = settingviewModel.GetStandardList();
            //ViewData["LocationList"] = settingviewModel.GetLocationList();
            //ViewData["ConditionList"] = settingviewModel.GetConditionList();
            //ViewData["DeviceList"] = settingviewModel.GetDeviceList();
            ViewData["RollerSampleInfoID"] = settingviewModel.GetDeviceList();
            return View("TestingInfoView", new RollerSampleInfo());
        }

        public ActionResult AfterTestingInfo()
        {
            return View();
        }

    }
}