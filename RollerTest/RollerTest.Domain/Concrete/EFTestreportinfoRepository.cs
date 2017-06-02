using RollerTest.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RollerTest.Domain.Entities;

namespace RollerTest.Domain.Concrete
{
    public class EFTestreportinfoRepository : ITestreportinfoRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<RollerTestreportInfo> RollerTestreportInfos
        {
            get
            {
                return context.RollerTestreportInfos;
            }
        }
    }
}
