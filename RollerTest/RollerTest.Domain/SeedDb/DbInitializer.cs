using RollerTest.Domain.Concrete;
using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.SeedDb
{

    public class DbInitializer : System.Data.Entity.DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID=1, Device = "1#滚轮试验机", Station = "1#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 2, Device = "2#滚轮试验机", Station = "2#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 3, Device = "3#滚轮试验机", Station = "3#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 4, Device = "4#滚轮试验机", Station = "4#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 5, Device = "5#滚轮试验机", Station = "5#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 6, Device = "6#滚轮试验机", Station = "6#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 7, Device = "7#滚轮试验机", Station = "7#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 8, Device = "8#滚轮试验机", Station = "8#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 9, Device = "9#滚轮试验机", Station = "9#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 10, Device = "10#滚轮试验机", Station = "10#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 11, Device = "11#滚轮试验机", Station = "11#", State = false });
            context.RollerBaseStations.Add(new RollerBaseStation { RollerBaseStationID = 12, Device = "12#滚轮试验机", Station = "12#", State = false });
            context.RollerBaseStandards.Add(new RollerBaseStandard { RollerBaseStandardID=1, Standard = "GB/T 10000" });
            context.RollerBaseLocations.Add(new RollerBaseLocation {  RollerBaseLocationID=1,Location = "试验塔21楼" });
            context.RollerBaseCoditions.Add(new RollerBaseCondition {  RollerBaseConditonID=1,Condition = "常温条件100h" });

            base.Seed(context);
        }

    }

}
