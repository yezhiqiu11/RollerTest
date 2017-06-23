using RollerTest.Domain.Abstract;
using RollerTest.Domain.Entities;
using RollerTest.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollerTest.WebUI.Controllers
{
    public class SampleDecideController : Controller
    {
        private ITestreportinfoRepository testreportinfoRepo;
        public SampleDecideController(ITestreportinfoRepository repo)
        {
            testreportinfoRepo = repo;
        }

        //public ActionResult Index()
        //{

        //    return View();
        //}

        //public ActionResult SampleDecide(int RollerSampleInfoId)
        //{
        //    SampleDecideViewModel sampledecideviewModel = new SampleDecideViewModel()
        //    {
        //        rollertestreportinfos = testreportinfoRepo.RollerTestreportInfos.Where(x => x.RollerSampleInfoID == RollerSampleInfoId)
        //    };
        //    return View(sampledecideviewModel);
        //}
        [HttpPost]
        public ActionResult SampleDecide(RollerTestreportInfo rollertestreportinfo)
        {
            testreportinfoRepo.SaveRollerTestreportInfo(rollertestreportinfo);
            //return RedirectToAction("SampleDecide", new { RollerSampleInfoID = rollertestreportinfo.RollerSampleInfoID });
            //return RedirectToAction("../TestBlock/Index", new { RollerSampleInfoID = rollertestreportinfo.RollerSampleInfoID });
            return RedirectToAction("../TestBlock/Index");
        }
        [HttpGet]
        public ViewResult SampleDecide(int RollerSampleInfoID)
        {
            //SampleDecideViewModel sampledecideviewModel = new SampleDecideViewModel()
            //{
            //    rollertestreportinfos = testreportinfoRepo.RollerTestreportInfos.Where(x => x.RollerSampleInfoID == RollerSampleInfoID)
            //};
            RollerTestreportInfo rollertestreportinfo = testreportinfoRepo.RollerTestreportInfos.FirstOrDefault(x => x.RollerSampleInfoID == RollerSampleInfoID);
            return View(rollertestreportinfo);
        }
       
    }
}