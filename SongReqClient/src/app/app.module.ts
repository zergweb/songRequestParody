import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {MaterialModule } from './material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MainPageComponent } from './pages/main-page/main-page.component';
import { ServerLogPageComponent } from './pages/server-log/server-log-page.component';
import { ChatComponent } from './components/chat/chat.component';
import { SongRequestComponent} from './components/song-request/song-request.component';
import { ChatService } from './services/ChatService';
import { SignalRService } from './services/SignalRService';
import { NotificationService } from './services/NotificationService';
import { SongRequestService } from './services/SongRequesrService';
import {LogService } from './services/LogService';
@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    ServerLogPageComponent,
    ChatComponent,
    SongRequestComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    FormsModule 
  ],
  providers: [ChatService,
    SignalRService,
    NotificationService,
    SongRequestService,
    LogService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
