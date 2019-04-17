import { Component, OnInit } from '@angular/core';
import { NotificationService} from './services/NotificationService';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {
    
  title = 'SongReqClient';
  constructor(public notifications: NotificationService) {
    
  }
  ngOnInit(): void {
   // this.notifications.UpdateState();
  }
}
