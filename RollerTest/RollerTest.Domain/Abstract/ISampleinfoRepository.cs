using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RollerTest.Domain.Abstract
{
    public interface ISampleinfoRepository
    {
        IQueryable<RollerSampleInfo> RollerSampleInfos { get; }
        void SaveRollerSampleInfo(RollerSampleInfo rollersampleinfo);

        RollerSampleInfo DeleteRollerSampleInfo(int rollersampleinfoID);

        IEnumerable<SelectListItem> GetSampleTestingList()
    }
}
