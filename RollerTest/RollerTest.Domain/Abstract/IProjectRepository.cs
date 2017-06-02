using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Abstract
{
    public interface IProjectRepository
    {
        IQueryable<RollerProjectInfo> RollerProjectInfos { get; }
        void SaveRollerProjectInfo(RollerProjectInfo rollerprojectinfo);
        RollerProjectInfo DeleteRollerProjectInfo(int rollerprojectinfoID);
    }
}
