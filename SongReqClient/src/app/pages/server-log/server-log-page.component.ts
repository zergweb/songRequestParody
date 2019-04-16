import { Component, OnInit } from '@angular/core';
import { LogService} from '../../services/LogService';
@Component({
  selector: 'server-log-page',
  templateUrl: './server-log-page.component.html',
  styleUrls: ['./server-log-page.component.css']
})
export class ServerLogPageComponent implements OnInit {
  public Log: String[] = [];
  constructor(
    public log:LogService
  ) {
    this.Log = log.Log;
  }

  ngOnInit() {
 
  }
  public ClearLog() {
    this.log.ClearLog();
  }
}
