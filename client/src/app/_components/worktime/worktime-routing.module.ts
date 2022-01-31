import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorktimeComponent } from './worktime.component';
import { WorkdayComponent } from './workday/workday.component';

const routes: Routes = [
  {
    path: '',
    component: WorktimeComponent
  },
  {
    path: ':employeeId',
    component: WorktimeComponent
  },
  {
    path: 'day/:id',
    component: WorkdayComponent
  },
  {
    path: ':employeeId/day/:id',
    component: WorkdayComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorktimeRoutingModule {}
