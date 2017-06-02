using RollerTest.Domain.Abstract;
using RollerTest.Domain.Concrete;
using RollerTest.Domain.Entities;
using RollerTest.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollerTest.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository projectrepository;
        private IBaseRepository baserepository;
        public ProjectController(IProjectRepository projectrepo,IBaseRepository baserepo)
        {
            projectrepository = projectrepo;
            baserepository = baserepo;
        }
        [HttpPost]
        public ActionResult EditProject(RollerProjectInfo rollerprojectinfo)
        {

            projectrepository.SaveRollerProjectInfo(rollerprojectinfo);
            return RedirectToAction("Index","Sample");
        }
        public ViewResult EditProject(int RollerProjectInfoID)
        {
            SettingViewModel settingviewModel = new SettingViewModel(baserepository);
            ViewData["StandardList"] = settingviewModel.GetStandardList();
            ViewData["LocationList"] = settingviewModel.GetLocationList();
            ViewData["ConditionList"] = settingviewModel.GetConditionList();
            ViewData["DeviceList"] = settingviewModel.GetDeviceList();

            RollerProjectInfo rollerprojectinfo = projectrepository.RollerProjectInfos.FirstOrDefault(p => p.RollerProjectInfoID == RollerProjectInfoID);
            return View(rollerprojectinfo);
        }
        [HttpPost]
        public ActionResult DeleteProject(int RollerProjectInfoID)
        {
            projectrepository.DeleteRollerProjectInfo(RollerProjectInfoID);
            return RedirectToAction("Index", "Sample");
        }
        public ViewResult CreateProject()
        {
            SettingViewModel settingviewModel = new SettingViewModel(baserepository);
            ViewData["StandardList"] = settingviewModel.GetStandardList();
            ViewData["LocationList"] = settingviewModel.GetLocationList();
            ViewData["ConditionList"] = settingviewModel.GetConditionList();
            ViewData["DeviceList"] = settingviewModel.GetDeviceList();
            return View("EditProject", new RollerProjectInfo());
        }
        public PartialViewResult ProjectMenu()
        {
            ProjectListViewModel projectlistviewModel = new ProjectListViewModel()
            {
                rollerprojectinfos = projectrepository.RollerProjectInfos
            };
            return PartialView(projectlistviewModel);
        }
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
    }
}