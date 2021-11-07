import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

const routes: Routes = [
  {
    path: 'worktime',
    loadChildren: () =>
      import('./worktime/worktime.module').then(m => m.WorktimeModule)
  },
  {
    path: 'workers',
    loadChildren: () =>
      import('./workers/workers.module').then(m => m.WorkersModule)
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
