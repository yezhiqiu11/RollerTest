using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace RollerTest.WebUI.SignalR
{
    [HubName("dataHub")]
    public class DataHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}