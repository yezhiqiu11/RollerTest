using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public EFDbContext() :base("EFConnection"){ }
        public DbSet<RollerBaseCondition> RollerBaseCoditions { get; set; }
        public DbSet<RollerBaseLocation> RollerBaseLocations { get; set; }
        public DbSet<RollerBaseStation> RollerBaseStations { get; set; }
        public DbSet<RollerBaseStandard> RollerBaseStandards { get; set; }
        public DbSet<RollerRealtimeInfo> RollerRealtimeInfos { get; set; }
        public DbSet<RollerRecordInfo> RollerRecordInfos { get; set; }
        public DbSet<RollerSampleInfo> RollerSampleInfos { get; set; }
        public DbSet<RollerTestreportInfo> RollerTestreportInfos { get; set; }
        public DbSet<RollerProjectInfo> RollerProjectInfos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer<EFDbContext>(new DropCreateDatabaseIfModelChanges<EFDbContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
