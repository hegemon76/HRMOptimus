import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent
  },
  {
    path: 'worktime',
    loadChildren: () =>
      import('./worktime/worktime.module').then(m => m.WorktimeModule)
  },
  {
    path: 'employees',
    loadChildren: () =>
      import('./employees/employees.module').then(m => m.employeesModule)
  },
  {
    path: 'vacation',
    loadChildren: () =>
      import('./vacation/vacation.module').then(m => m.VacationModule)
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      preloadingStrategy: PreloadAllModules,
      relativeLinkResolution: 'legacy'
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
