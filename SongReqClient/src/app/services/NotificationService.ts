import { Injectable, Predicate } from '@angular/core';
import { ChatMessage } from '../model/ChatMessage';
import { SignalRService } from './SignalRService';
import { MatSnackBar } from '@angular/material';
@Injectable({ providedIn: 'root' })
export class NotificationService {
  constructor(private signalR: SignalRService, private snackBar: MatSnackBar) {
    signalR.connection.on("onNotification", (mess:string) => {
     // this.ShowNotification(mess);
      snackBar.open(mess," ", {
        duration: 3000
      });
    });
  }
  public ShowNotification(mess: String) {
    console.log(mess);   
  }
  //public UpdateState() {
  //  this.signalR.connection.send("UpdateState");
  //}
}
