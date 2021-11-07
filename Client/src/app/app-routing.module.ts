import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorktimeComponent } from './main/content/worktime/worktime.component';
import { VacationComponent } from './main/content/vacation/vacation.component';
import { WorkersComponent } from './main/content/workers/workers.component';
import { WorkdayComponent } from './main/content/worktime/workday.component';

const routes: Routes = [
  { path: 'worktime', component: WorktimeComponent },
  { path: 'vacation', component: VacationComponent },
  { path: 'workers', component: WorkersComponent },
  { path: 'workday', component: WorkdayComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
