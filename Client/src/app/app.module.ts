import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { MainComponent } from './main/main.component';
import { TopbarComponent } from './main/topbar/topbar.component';
import { ContentComponent } from './main/content/content.component';
import { WorktimeComponent } from './main/content/worktime/worktime.component';
import { VacationComponent } from './main/content/vacation/vacation.component';
import { VariablesService } from './variables.service';
import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';
import { DashboardComponent } from './main/content/dashboard/dashboard.component';

FullCalendarModule.registerPlugins([
  // register FullCalendar plugins
  dayGridPlugin,
  timeGridPlugin,
  interactionPlugin
]);

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    MainComponent,
    TopbarComponent,
    ContentComponent,
    WorktimeComponent,
    VacationComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: '', component: DashboardComponent },
      { path: 'worktime', component: WorktimeComponent },
      { path: 'vacation', component: VacationComponent }
    ]),
    FullCalendarModule
  ],
  providers: [VariablesService],
  bootstrap: [AppComponent]
})
export class AppModule {}
