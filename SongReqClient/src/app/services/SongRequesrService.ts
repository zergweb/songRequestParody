import { Injectable, Predicate } from '@angular/core';
import { ChatMessage } from '../model/ChatMessage';
import { SignalRService } from './SignalRService';
@Injectable({ providedIn: 'root' })
export class SongRequestService {
  constructor( private signalR: SignalRService) {

   
  }
  public SongRequest(url:String) {
    this.signalR.connection.send("SongRequest", url);
 
  }
}
