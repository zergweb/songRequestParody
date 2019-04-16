import { Component } from '@angular/core';
import { NotificationService} from './services/NotificationService';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SongReqClient';
  constructor(public notifications: NotificationService) {
  }
}
