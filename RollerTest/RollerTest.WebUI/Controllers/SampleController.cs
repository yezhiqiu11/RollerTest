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
    public class SampleController : Controller
    {
        private ISampleinfoRepository repository;
        public SampleController(ISampleinfoRepository repo)
        {
            repository = repo;
        }
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateOrEditSample(int RollerProjectInfoID)
        {
            RollerSampleInfo rollersampleInfo = repository.RollerSampleInfos.FirstOrDefault(p => p.RollerProjectInfoId == RollerProjectInfoID);
            if (rollersampleInfo != null)
            {
                return RedirectToAction("EditSample",new { rollersampleinfo= rollersampleInfo });
            }
            else
            {
                return View("EditSample", new RollerSampleInfo());
            }
        }
        public ViewResult EditSample(RollerSampleInfo rollersampleinfo)
        {
            return View(rollersampleinfo);
        }

    }
}