using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Abstract
{
    public interface IRealtimeinfoRepository
    {
        IQueryable<RollerRealtimeInfo> RollerRealtimeInfos { get; }
        //void SaveRollerRealtimeInfo(RollerRealtimeInfo rollerrealtimeinfo);
        //RollerRealtimeInfo DeleteRollerRealtimeInfo(int rollerrealtimeinfoID);
    }
}
