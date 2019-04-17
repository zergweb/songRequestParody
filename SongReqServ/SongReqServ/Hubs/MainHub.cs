using Microsoft.AspNetCore.SignalR;
using SongReqServ.Services.SongReq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongReqServ.Hubs
{
    public class MainHub:Hub
    {
        private readonly SongReqManager songManager;
        public MainHub(SongReqManager sm)
        {
            songManager = sm;
        }
        public async Task NewMessage(string username, string message)
        {   
           await Clients.All.SendAsync("messageReceived", username, message);
        }
        public async Task SongRequest(string url)
        {           
            songManager.AddSong(url,Clients).Start();
            await SendNotification("Запрос в обработке");
        }
        public async Task UpdateState()
        {
           await songManager.UpdatePlayList(Clients);
        }
        private Task SendNotification(String mess)
        {          
             return Clients.Caller.SendAsync("onNotification", mess);         
        }
        public Task LogMessageMailing(String mess)
        {           
            return Clients.All.SendAsync("onLogMessage", mess);
        }
    }
}
