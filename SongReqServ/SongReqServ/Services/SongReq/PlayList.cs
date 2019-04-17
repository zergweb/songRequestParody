using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongReqServ.Services.SongReq
{ 
    public class PlayList
    {
        public Track CurrentSong { get; set; }
        public List<Track> Tracks { get; set; } = new List<Track>();
        public DateTime CurrentTime { get; set; }
    }
}
