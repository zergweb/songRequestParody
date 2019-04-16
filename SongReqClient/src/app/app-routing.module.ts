import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { ServerLogPageComponent } from './pages/server-log/server-log-page.component';
const routes: Routes = [
  {
    path: '',
    component: MainPageComponent
  },
  {
    path: 'song-room',
    component: MainPageComponent
  },
  {
    path: 'server-log',
    component: ServerLogPageComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
