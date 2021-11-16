import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

const routes: Routes = [
  {
    path: 'worktime',
    loadChildren: () =>
      import('./worktime/worktime.module').then(m => m.WorktimeModule)
  },
  {
    path: 'employees',
    loadChildren: () =>
      import('./employees/employees.module').then(m => m.employeesModule)
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
