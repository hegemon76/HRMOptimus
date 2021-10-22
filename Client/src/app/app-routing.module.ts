import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorktimeComponent } from './main/content/worktime/worktime.component';
import { VacationComponent } from './main/content/vacation/vacation.component';

const routes: Routes = [
  { path: 'worktime', component: WorktimeComponent },
  { path: 'vacation', component: VacationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
