using RollerTest.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RollerTest.Domain.Entities;

namespace RollerTest.Domain.Concrete
{
    public class EFRealtimeinfoRepository : IRealtimeinfoRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<RollerRealtimeInfo> RollerRealtimeInfos
        {
            get
            {
                return context.RollerRealtimeInfos;
            }
        }
    }
}
