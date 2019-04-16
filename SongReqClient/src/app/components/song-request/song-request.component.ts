import { Component, OnInit } from '@angular/core';
import { SongRequestService} from '../../services/SongRequesrService';


@Component({
  selector: 'song-request',
  templateUrl: './song-request.component.html',
  styleUrls: ['./song-request.component.css']
})
export class SongRequestComponent implements OnInit {
  public Url: string = "";
  constructor(
    public rs:SongRequestService
  ) { }

  ngOnInit() {

  }
  public InvokeSongRequest() {
    this.rs.SongRequest(this.Url);
    this.Url = "";
  }
}
