import { Injectable, Predicate } from '@angular/core';
import { ChatMessage } from '../model/ChatMessage';
import * as signalR from "@aspnet/signalr";
@Injectable({ providedIn: 'root' })
export class SignalRService {
  public serv = "https://localhost:44305/";
  public connection = new signalR.HubConnectionBuilder()
    .withUrl(this.serv+"hub")
    .build();
  constructor() {
    this.connection.start().then(() => {
      console.log("asdfsdfc");
      this.connection.send("UpdateState");
    }).catch(err => console.log(err));
  }
}
