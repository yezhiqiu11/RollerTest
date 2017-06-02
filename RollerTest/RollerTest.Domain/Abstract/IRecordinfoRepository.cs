using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Abstract
{
    public interface IRecordinfoRepository
    {
        IQueryable<RollerRecordInfo> RollerRecordInfos { get; }
        //void SaveRollerRecordInfo(RollerRecordInfo rollerrecordinfo);
        //RollerRecordInfo DeleteRollerRecordInfo(int rollerrecordinfoID);
    }
}
