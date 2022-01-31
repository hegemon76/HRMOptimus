import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { DashboardComponent } from './_components/dashboard/dashboard.component';
import { EmailChangeComponent } from './_components/account/email-change/email-change.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent
  },
  {
    path: 'worktime',
    loadChildren: () =>
      import('./_components/worktime/worktime.module').then(
        m => m.WorktimeModule
      )
  },
  {
    path: 'employees',
    loadChildren: () =>
      import('./_components/employees/employees.module').then(
        m => m.employeesModule
      )
  },
  {
    path: 'vacation/:id',
    loadChildren: () =>
      import('./_components/vacation/vacation.module').then(
        m => m.VacationModule
      )
  },
  {
    path: 'projects',
    loadChildren: () =>
      import('./_components/projects/projects.module').then(
        m => m.ProjectsModule
      )
  },
  { path: ':emailToken', component: EmailChangeComponent }
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
