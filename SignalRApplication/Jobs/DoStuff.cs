using Microsoft.AspNetCore.SignalR;
using SignalRApplication.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Jobs
{
    public class DoStuff
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public DoStuff(IHubContext<ChatHub> hub)
        {
            _hubContext = hub;
        }

        public void SendInvoiceUpdate()
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", "Hangfire", $"Job has run @ {DateTime.Now.ToString()}");
            //_hubContext.Clients.All.SendAsync("NewTransactions", 5);
        }
    }
}
