using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Abstract
{
    public interface IBaseRepository
    {
        IQueryable<RollerBaseLocation> RollerBaseLocations { get; }
        IQueryable<RollerBaseCondition> RollerBaseConditions { get; }
        IQueryable<RollerBaseStandard> RollerBaseStandards { get; }
        IQueryable<RollerBaseStation> RollerBaseStations { get; }

        void ChangeStationState(int StationId, bool state);

    }
}
