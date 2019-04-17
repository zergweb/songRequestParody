using MediaToolkit;
using MediaToolkit.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using SongReqServ.Hubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VideoLibrary;

namespace SongReqServ.Services.SongReq
{
    public class SongReqManager
    {
        private readonly String folder= "/songrequests/audio/";
        private readonly IHostingEnvironment hostEnvironment;
        // public RequestOptions Options { get; set; } = new RequestOptions { RateForSkip = 10 };
        public PlayList PlayList { get; set; } = new PlayList();
        public SongReqManager(IHostingEnvironment _hostEnvironment)
        {
            hostEnvironment = _hostEnvironment;
        }
        public Task AddSong(String url, IHubCallerClients callers )
        {
            return new Task(()=> {
                var youTube = YouTube.Default;
                var vid = youTube.GetVideo(url);        

                callers.Caller.SendAsync("onNotification", vid.FullName+" скачивается");
                if (vid != null)
                {
                    var path = hostEnvironment.WebRootPath + "/songrequests/video/" + vid.FullName;
                    callers.Caller.SendAsync("onNotification", "загрузка видео");
                    File.WriteAllBytes(path, vid.GetBytes());     
                    var inputFile = new MediaFile { Filename = hostEnvironment.WebRootPath + "/songrequests/video/" + vid.FullName };
                    callers.Caller.SendAsync("onNotification", "преобразование в mp3");
                    var name = vid.FullName.Replace("mp4", "mp3");
                    var outputFile = new MediaFile { Filename = hostEnvironment.WebRootPath + folder + name };
                    
                   
                    using (var engine = new Engine())
                    {
                        engine.GetMetadata(inputFile);
                        engine.Convert(inputFile, outputFile);
                    }
                    callers.Caller.SendAsync("onNotification", "success");
                    UpdatePlayList(callers);
                }
                else { callers.Caller.SendAsync("onNotification", "fail"); }
            });            
        }
        public Task UpdatePlayList(IHubCallerClients callers)
        {
            return callers.All.SendAsync("onUpdatePlayList", CreatePlaylist());
        }
        private PlayList CreatePlaylist()
        {
            
            var pl = new PlayList();
            var songs = Directory.GetFiles(hostEnvironment.WebRootPath + folder);
            foreach(var song in songs)
            {
                var name = song.Substring(song.IndexOf(folder)+folder.Length);
                pl.Tracks.Add(new Track { link = folder+name,title = name });
            }
            return pl;
        }

        
    }
}
