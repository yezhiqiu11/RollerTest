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
                Value=a.RollerBaseStandardID.ToString()
            });
            return selectList;
        }
        public IEnumerable<SelectListItem> GetConditionList()
        {
            var selectList = baserepo.RollerBaseConditions.Select(a => new SelectListItem
            {
                Text = a.Condition,
                Value = a.RollerBaseConditonID.ToString()
            });
            return selectList;
        }
        public IEnumerable<SelectListItem> GetLocationList()
        {
            var selectList = baserepo.RollerBaseLocations.Select(a => new SelectListItem
            {
                Text = a.Location,
                Value = a.RollerBaseLocationID.ToString()
            });
            return selectList;
        }
        public IEnumerable<SelectListItem> GetDeviceList()
        {
            var selectList = baserepo.RollerBaseStations.Distinct(a=>a.Device).Select(a => new SelectListItem
            {
                Text = a.Device,
                Value = a.RollerBaseStationID.ToString()
            }) ;

            return selectList;
        }


    }
}