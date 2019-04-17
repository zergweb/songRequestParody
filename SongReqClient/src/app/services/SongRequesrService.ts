import { Injectable, Predicate } from '@angular/core';
import { SignalRService } from './SignalRService';
import { Track } from 'ngx-audio-player';
import { PlayList} from '../model/PlayList';
@Injectable({ providedIn: 'root' })
export class SongRequestService {
  public Tracks: Track[] = [
    {
      title: ' ',
      link: ' '
    } 
  ];
  constructor( private signalR: SignalRService) {
    signalR.connection.on("onUpdatePlayList", (playlist: PlayList) => {
      console.log(playlist);
      this.Tracks = [];
      for (let track of playlist.tracks) {   
        this.Tracks.push({ title: track.title, link: this.signalR.serv + track.link });
      }
           
    });
  }
  public SongRequest(url:String) {
    this.signalR.connection.send("SongRequest", url);
 
  }
}
