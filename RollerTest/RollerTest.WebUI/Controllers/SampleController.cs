using RollerTest.Domain.Abstract;
using RollerTest.Domain.Context;
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
    public class SampleController : Controller
    {
        private ISampleinfoRepository repository;
        private IProjectRepository projectrepo;
        private IBaseRepository baserepository;
 
        public SampleController(ISampleinfoRepository repo,IProjectRepository prepo,IBaseRepository baserepo)
        {
            repository = repo;
            projectrepo = prepo;
            baserepository = baserepo;
        }
        // GET: Project
        public ActionResult Index()
        {
            ProjectListViewModel projectlistviewModel = new ProjectListViewModel()
            {
                rollerprojectinfos = projectrepo.RollerProjectInfos
            };
            
            return View(projectlistviewModel);
        }
        public ActionResult ViewInfo(int RollerProjectInfoID)
        {
            SampleViewModel sampleviewmodel = new SampleViewModel()
            {
                rollerprojectinfo = projectrepo.RollerProjectInfos.FirstOrDefault(a => a.RollerProjectInfoID == RollerProjectInfoID),
                rollersampleinfos = repository.RollerSampleInfos.Where(a => a.RollerProjectInfo.RollerProjectInfoID == RollerProjectInfoID).Include(x => x.RollerBaseStation),
                 projectlistviewmodel = new ProjectListViewModel() { rollerprojectinfos = projectrepo.RollerProjectInfos }
            };
            return View(sampleviewmodel);
        }
        public ViewResult CreateSample(int RollerProjectInfoID)
        {
            SettingViewModel settingviewModel = new SettingViewModel(baserepository);
            ViewData["StationList"] = settingviewModel.GetStationList(projectrepo.RollerProjectInfos.FirstOrDefault(a=>a.RollerProjectInfoID== RollerProjectInfoID).TestDevice);
            return View("EditSample", new RollerSampleInfo() { RollerProjectInfoID = RollerProjectInfoID, State = true });
        }
        [HttpPost]
        public ActionResult EditSample(RollerSampleInfo rollersampleinfo)
        {
            if (ModelState.IsValid) {
                repository.SaveRollerSampleInfo(rollersampleinfo);
                return RedirectToAction("ViewInfo", new { RollerProjectInfoID = rollersampleinfo.RollerProjectInfoID });
            }
            else
            {
                SettingViewModel settingviewModel = new SettingViewModel(baserepository);
                ViewData["StationList"] = settingviewModel.GetStationList(projectrepo.RollerProjectInfos.FirstOrDefault(a => a.RollerProjectInfoID == rollersampleinfo.RollerProjectInfoID).TestDevice);
                return View(rollersampleinfo);
            }
        }
        [HttpGet]
        public  ViewResult EditSample(int RollerSampleInfoID)
        {
            SettingViewModel settingviewModel = new SettingViewModel(baserepository);
            RollerSampleInfo rollersampleinfo = repository.RollerSampleInfos.FirstOrDefault(p => p.RollerSampleInfoID == RollerSampleInfoID);
            ViewData["StationList"] = settingviewModel.GetStationList(projectrepo.RollerProjectInfos.FirstOrDefault(a => a.RollerProjectInfoID == rollersampleinfo.RollerProjectInfo.RollerProjectInfoID).TestDevice);
            
            return View(rollersampleinfo);
        }

        [HttpPost]
        public ActionResult DeleteSample(int RollerSampleInfoID,int RollerProjectInfoId)
        {          
            repository.DeleteRollerSampleInfo(RollerSampleInfoID);
            return RedirectToAction("ViewInfo", new { RollerProjectInfoID = RollerProjectInfoId });
        }


    }
}