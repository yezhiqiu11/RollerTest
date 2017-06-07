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
    }
}
