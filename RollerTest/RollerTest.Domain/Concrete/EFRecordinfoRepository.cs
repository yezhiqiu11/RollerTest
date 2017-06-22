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
    public class EFRecordinfoRepository : IRecordinfoRepository
    {
        private EFDbContext context = ContextControl.GetInstance().getContext();
        public IQueryable<RollerRecordInfo> RollerRecordInfos
        {
            get
            {
                return context.RollerRecordInfos;
            }
        }
        public void SaveRollerRecordInfo(RollerRecordInfo rollerrecordinfo)
        {
            if (rollerrecordinfo.RollerRecordInfoID == 0)
            {
                context.RollerRecordInfos.Add(rollerrecordinfo);
            }
            else
            {
                RollerRecordInfo dbEntry = context.RollerRecordInfos.Find(rollerrecordinfo.RollerRecordInfoID);
                if (dbEntry != null)
                {
                    dbEntry.RollerRecordInfoID = rollerrecordinfo.RollerRecordInfoID;
                    dbEntry.RollerSampleInfoID = rollerrecordinfo.RollerSampleInfoID;
                    dbEntry.SampleStatus = rollerrecordinfo.SampleStatus;
                    dbEntry.CurrentTime = rollerrecordinfo.CurrentTime;
                    dbEntry.TotalTime = rollerrecordinfo.TotalTime;
                    dbEntry.RecordInfo = rollerrecordinfo.RecordInfo;
                }
            }
            context.SaveChanges();
        }
        public RollerRecordInfo DeleteRollerRecordInfo(int rollerrecordinfoID)
        {
            RollerRecordInfo dbEntry = context.RollerRecordInfos.Find(rollerrecordinfoID);
            if (dbEntry != null)
            {
                context.RollerRecordInfos.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
    

