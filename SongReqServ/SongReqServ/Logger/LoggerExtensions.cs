using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SongReqServ.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongReqServ.Logger
{
    public static class LoggerExtensions
    {
        public static ILoggerFactory WSLogger(this ILoggerFactory factory, IHubContext<MainHub> wsHandler
                                        )
        {
            factory.AddProvider(new WSLoggerProvider(wsHandler));
            return factory;
        }
    }
}
