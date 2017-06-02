using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using RollerTest.Domain.Abstract;
using RollerTest.Domain.Concrete;

namespace RollerTest.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBinding()
        {
            //添加绑定

            ninjectKernel.Bind<IRealtimeinfoRepository>().To<EFRealtimeinfoRepository>();
            ninjectKernel.Bind<IRecordinfoRepository>().To<EFRecordinfoRepository>();
            ninjectKernel.Bind<ISampleinfoRepository>().To<EFSampleinfoRepository>();
            ninjectKernel.Bind<ITestreportinfoRepository>().To<EFTestreportinfoRepository>();
            ninjectKernel.Bind<IProjectRepository>().To<EFProjectinfoRepository>();
            ninjectKernel.Bind<IBaseRepository>().To<EFBaseRepository>();

        }
    }
}