﻿using RollerTest.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RollerTest.Domain.Entities;

namespace RollerTest.Domain.Concrete
{
    public class EFSampleinfoRepository : ISampleinfoRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<RollerSampleInfo> RollerSampleInfos
        {
            get
            {
                return context.RollerSampleInfos;
            }
        }

        public RollerSampleInfo DeleteRollerSampleInfo(int rollersampleinfoID)
        {
            RollerSampleInfo dbEntry = context.RollerSampleInfos.Find(rollersampleinfoID);
            if (dbEntry != null)
            {
                context.RollerSampleInfos.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveRollerSampleInfo(RollerSampleInfo rollersampleinfo)
        {
            if (rollersampleinfo.RollerSampleInfoID == 0)
            {
                context.RollerSampleInfos.Add(rollersampleinfo);
            }
            else
            {
                RollerSampleInfo dbEntry = context.RollerSampleInfos.Find(rollersampleinfo.RollerSampleInfoID);
                if (dbEntry != null)
                {
                    dbEntry.RollerProjectInfo = rollersampleinfo.RollerProjectInfo;
                    dbEntry.SampleID = rollersampleinfo.SampleID;
                    dbEntry.SampleName = rollersampleinfo.SampleName;
                    dbEntry.SetValue = rollersampleinfo.SetValue;
                    dbEntry.TestStation = rollersampleinfo.TestStation;
                    dbEntry.UpLimit = rollersampleinfo.UpLimit;
                    dbEntry.DnLimit = rollersampleinfo.DnLimit;
                }
            }
            context.SaveChanges();
        }
    }
}
