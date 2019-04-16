import { Component, OnInit } from '@angular/core';
import { ChatService } from '../../services/ChatService';
import { ChatMessage } from '../../model/ChatMessage';

@Component({
  selector: 'chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  public CurrentMessage: string = "";
  constructor(
    private chat: ChatService
  ) { }

  ngOnInit() {

  }
  public SendMessage() {
    this.chat.SendMessage({ Message: this.CurrentMessage, Author: "author" });
    this.CurrentMessage = "";
  }
}
