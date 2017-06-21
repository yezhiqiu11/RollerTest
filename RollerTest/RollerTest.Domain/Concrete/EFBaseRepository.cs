using RollerTest.Domain.Abstract;
using RollerTest.Domain.Context;
using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RollerTest.Domain.Concrete
{
    public class EFBaseRepository:IBaseRepository
    {
        //private EFDbContext context = ContextControl.GetInstance().getContext();
        private EFDbContext context = new EFDbContext();
        public IQueryable<RollerBaseLocation> RollerBaseLocations
        {
            get
            {
                return context.RollerBaseLocations;
            }
        }
        public IQueryable<RollerBaseCondition> RollerBaseConditions
        {
            get
            {
                return context.RollerBaseCoditions;
            }
        }
        public IQueryable<RollerBaseStandard> RollerBaseStandards
        {
            get
            {
                return context.RollerBaseStandards;
            }
        }
        public IQueryable<RollerBaseStation> RollerBaseStations
        {
            get
            {
                return context.RollerBaseStations;
            }
        }
        public void ChangeStationState(int StationId,bool state)
        {
            RollerBaseStation dbEntry = context.RollerBaseStations.Find(StationId);
                if (dbEntry != null)
                {
                dbEntry.State = state;
                }
            context.SaveChanges();
        }

    }
}
