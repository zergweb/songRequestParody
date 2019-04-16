import { Injectable, Predicate } from '@angular/core';
import { SignalRService } from './SignalRService';
@Injectable({ providedIn: 'root' })
export class LogService {
  public Log: String[] = [];
  constructor(private signalR: SignalRService) {
    signalR.connection.on("onLogMessage", (mess: string) => {
      this.Log.push(mess);
      //this.ShowNotification(mess);  
    });
  }
  public ShowNotification(mess: String) {
    if (this.Log.length = 300) {

    } 
    console.log(mess);
  }
  public ClearLog() {
    this.Log = [];
  }
}
