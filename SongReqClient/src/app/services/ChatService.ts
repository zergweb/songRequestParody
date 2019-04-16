import { Injectable, Predicate } from '@angular/core';
import { ChatMessage} from '../model/ChatMessage';
//import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SignalRService} from './SignalRService';
@Injectable({ providedIn: 'root' })
export class ChatService {
  public Count: number = 300;
  private serv = "https://localhost:44305/";
  constructor(/*private http: HttpClient*/ private signalR: SignalRService) {
    signalR.connection.on("messageReceived", (username: string, message: string) => {
      this.AddMessage({ Author: username, Message: message });
      console.log("recieved" + message);
    });
  }
  public SendMessage(mess:ChatMessage ) {
    this.signalR.connection.send("newMessage", mess.Author, mess.Message);
     //.then(() = > );
  }
  //public getTest() {
  //  return this.http.post(this.serv, { action:"getalldata"});
  //}
  //public getTest2() {
  //  return this.http.get(this.serv+'/test');
  //}

  public MessageList: ChatMessage[] = [
   
   
  ];
  public AddMessage(mess: ChatMessage) {
    //if (this.MessageList.length == this.Count) {
      this.MessageList.push(mess);
   // }   
  }
}
