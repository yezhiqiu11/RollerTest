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
    public class EFTestreportinfoRepository : ITestreportinfoRepository
    {
        private EFDbContext context = ContextControl.GetInstance().getContext();
        public IQueryable<RollerTestreportInfo> RollerTestreportInfos
        {
            get
            {
                return context.RollerTestreportInfos;
            }
        }

        public RollerTestreportInfo DeleteRollerTestreportInfo(int rollertestreportinfoID)
        {
            RollerTestreportInfo dbEntry = context.RollerTestreportInfos.Find(rollertestreportinfoID);
            if (dbEntry != null)
            {
                context.RollerTestreportInfos.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveRollerTestreportInfo(RollerTestreportInfo rollertestreportinfo)
        {
            if (rollertestreportinfo.RollerTestReportInfoID == 0)
            {
                context.RollerTestreportInfos.Add(rollertestreportinfo);
            }
            else
            {
                RollerTestreportInfo dbEntry = context.RollerTestreportInfos.Find(rollertestreportinfo.RollerTestReportInfoID);
                if (dbEntry != null)
                {
                    dbEntry.StartStatus = rollertestreportinfo.StartStatus;
                    dbEntry.StartText = rollertestreportinfo.StartText;
                    dbEntry.EndStatus = rollertestreportinfo.EndStatus;
                    dbEntry.EndText = rollertestreportinfo.EndText;
                    dbEntry.FinalStatus = rollertestreportinfo.FinalStatus;
                    dbEntry.StartTime = rollertestreportinfo.StartTime;
                    dbEntry.EndTime = rollertestreportinfo.EndTime;
                    dbEntry.RollerSampleInfoID = rollertestreportinfo.RollerSampleInfoID;
                }
            }
            context.SaveChanges();
        }
    }
}
