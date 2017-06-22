using RollerTest.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RollerTest.Domain.Entities;
using RollerTest.Domain.Context;

namespace RollerTest.Domain.Concrete
{
    public class EFProjectinfoRepository:IProjectRepository
    {
        //private EFDbContext context = ContextControl.GetInstance().getContext();
        private EFDbContext context = new EFDbContext();

        public IQueryable<RollerProjectInfo> RollerProjectInfos
        {
            get
            {
                return context.RollerProjectInfos;
            }
        }

        public RollerProjectInfo DeleteRollerProjectInfo(int rollerprojectinfoID)
        {
            RollerProjectInfo dbEntry = context.RollerProjectInfos.Find(rollerprojectinfoID);
            if (dbEntry != null)
            {
                context.RollerProjectInfos.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveRollerProjectInfo(RollerProjectInfo rollerprojectinfo)
        {
            if (rollerprojectinfo.RollerProjectInfoID == 0)
            {
                context.RollerProjectInfos.Add(rollerprojectinfo);
            }
            else
            {
                RollerProjectInfo dbEntry = context.RollerProjectInfos.Find(rollerprojectinfo.RollerProjectInfoID);
                if (dbEntry != null)
                {
                    dbEntry.Commission = rollerprojectinfo.Commission;
                    dbEntry.TestCondition = rollerprojectinfo.TestCondition;
                    dbEntry.TestDevice = rollerprojectinfo.TestDevice;
                    dbEntry.TestLocation = rollerprojectinfo.TestLocation;
                    dbEntry.TestName = rollerprojectinfo.TestName;
                    dbEntry.TestPerson = rollerprojectinfo.TestPerson;
                    dbEntry.TestStandard = rollerprojectinfo.TestStandard;
                }
            }
            context.SaveChanges();
        }
    }
}
