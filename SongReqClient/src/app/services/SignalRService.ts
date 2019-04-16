import { Injectable, Predicate } from '@angular/core';
import { ChatMessage } from '../model/ChatMessage';
import * as signalR from "@aspnet/signalr";
//import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({ providedIn: 'root' })
export class SignalRService {
  private serv = "https://localhost:44305/";
  public connection = new signalR.HubConnectionBuilder()
    .withUrl(this.serv+"hub")
    .build();
  constructor() {
    this.connection.start().catch(err => console.log(err));
  }
}
