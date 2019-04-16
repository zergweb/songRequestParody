using MediaToolkit;
using MediaToolkit.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using SongReqServ.Hubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary;

namespace SongReqServ.Services.SongReq
{
    public class SongReqManager
    {
        private readonly IHostingEnvironment hostEnvironment;
       // public RequestOptions Options { get; set; } = new RequestOptions { RateForSkip = 10 };
        public List<Track> SongList { get; set; } = new List<Track>();
        public SongReqManager(IHostingEnvironment _hostEnvironment)
        {
            hostEnvironment = _hostEnvironment;
        }
        public Task AddSong(String url, IClientProxy caller )
        {
            return new Task(()=> {
                var youTube = YouTube.Default;
                var vid = youTube.GetVideo(url);

              
                caller.SendAsync("onNotification", vid.FullName+" скачивается");

                if (vid != null)
                {
                    var path = hostEnvironment.WebRootPath + "/songrequests/video/" + vid.FullName;
                    File.WriteAllBytes(path, vid.GetBytes());
                    caller.SendAsync("onNotification", "step 3");
                    var inputFile = new MediaFile { Filename = hostEnvironment.WebRootPath + "/songrequests/video/" + vid.FullName };
                    caller.SendAsync("onNotification", "step 4");
                    var outputFile = new MediaFile { Filename = hostEnvironment.WebRootPath + "/songrequests/audio/" + vid.FullName.Replace("mp4", "mp3") };
                    using (var engine = new Engine())
                    {
                        engine.GetMetadata(inputFile);
                        engine.Convert(inputFile, outputFile);
                    }
                    caller.SendAsync("onNotification", "success");
                }
                else { caller.SendAsync("onNotification", "fail"); }
            });
            
        }

    }
}
