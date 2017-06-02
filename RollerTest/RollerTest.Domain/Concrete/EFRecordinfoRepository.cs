using RollerTest.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RollerTest.Domain.Entities;

namespace RollerTest.Domain.Concrete
{
    public class EFRecordinfoRepository : IRecordinfoRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<RollerRecordInfo> RollerRecordInfos
        {
            get
            {
                return context.RollerRecordInfos;
            }
        }
    }
}
