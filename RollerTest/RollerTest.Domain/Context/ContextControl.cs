using RollerTest.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Context
{
    public class ContextControl
    {
        private static ContextControl instance;
        private static readonly object locker = new object();
        private EFDbContext context = new EFDbContext();
        private ContextControl()
        {

        }
        public static ContextControl GetInstance()
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new ContextControl();
                }
            }
            return instance;
        }
        public EFDbContext getContext()
        {
            context.Configuration.LazyLoadingEnabled = true;
            context.Configuration.ProxyCreationEnabled = true;
            return context;
        }
        public void disposeContext()
        {
            context.Dispose();
        }
    }
}
