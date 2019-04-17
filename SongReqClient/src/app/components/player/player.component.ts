import { Component, OnInit } from '@angular/core';
import { SongRequestService} from '../../services/SongRequesrService';
import { Track } from 'ngx-audio-player';  

@Component({
  selector: 'player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
 public msaapDisplayTitle = true;
 public msaapDisplayPlayList = true;
 public msaapPageSizeOptions = [6,10];
 
  constructor(
    public rs:SongRequestService
  ) { }

  ngOnInit() {

  }
  public InvokeSongRequest() {
   
  }
}
