using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SongReqServ.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongReqServ.Logger
{
    public class WSLogger : ILogger
    {
        private readonly IHubContext<MainHub> hub;
        public WSLogger(IHubContext<MainHub> _hub)
        {
            hub = _hub;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
              
               await hub.Clients.All.SendAsync("onLogMessage",formatter(state, exception));
            }
        }
    }
}
