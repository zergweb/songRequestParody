using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SongReqServ.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongReqServ.Logger
{
    public class WSLoggerProvider : ILoggerProvider
    {
        private readonly IHubContext<MainHub> ws;
        public WSLoggerProvider(IHubContext<MainHub> wsHandler)
        {
            ws = wsHandler;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new WSLogger(ws);
        }

        public void Dispose()
        {
        }
    }
}
