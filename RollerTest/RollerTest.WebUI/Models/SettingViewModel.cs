using RollerTest.Domain.Abstract;
using RollerTest.Domain.Concrete;
using RollerTest.Domain.Entities;
using RollerTest.WebUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollerTest.WebUI.Models
{
    public class SettingViewModel
    {
        private IBaseRepository baserepo;
        public SettingViewModel(IBaseRepository baserepo)
        {
            this.baserepo = baserepo;            
        }
        public IEnumerable<SelectListItem> GetStandardList()
        {
            var selectList = baserepo.RollerBaseStandards.Select(a => new SelectListItem
            {
                Text=a.Standard,
                Value=a.Standard.ToString()
            });
            return selectList;
        }
        public IEnumerable<SelectListItem> GetConditionList()
        {
            var selectList = baserepo.RollerBaseConditions.Select(a => new SelectListItem
            {
                Text = a.Condition,
                Value = a.Condition.ToString()
            });
            return selectList;
        }
        public IEnumerable<SelectListItem> GetLocationList()
        {
            var selectList = baserepo.RollerBaseLocations.Select(a => new SelectListItem
            {
                Text = a.Location,
                Value = a.Location.ToString()
            });
            return selectList;
        }
        public IEnumerable<SelectListItem> GetDeviceList()
        {
            var selectList = baserepo.RollerBaseStations.Distinct(a=>a.Device).Select(a => new SelectListItem
            {
                Text = a.Device,
                Value = a.Device.ToString()
            }) ;

            return selectList;
        }
        public IEnumerable<SelectListItem> GetStationList(string device)
        {
            var selectList = baserepo.RollerBaseStations.Where(a=>a.Device==device).Select(a => new SelectListItem
            {
                Text = a.Station,
                Value = a.Station.ToString()
            });

            return selectList;
        }


    }
}