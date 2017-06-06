﻿using Microsoft.Owin;
using Owin;
using Hangfire;
using System.Web.Services.Description;
using RollerTest.Domain.Concrete;

[assembly: OwinStartupAttribute(typeof(RollerTest.WebUI.Startup))]
namespace RollerTest.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=EIS-1127;Initial Catalog=HangfireDemo;User ID=sa;Password=sanling");
            //app.UseHangfireDashboard();
            //app.UseHangfireServer();
            EFDbContext context = new EFDbContext();
            context.Database.CreateIfNotExists();
        }
    }
}
