import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectsListComponent } from './projects-list/projects-list.component';
import { ProjectDetailsComponent } from './project-details/project-details.component';
import { ProjectAddComponent } from './project-add/project-add.component';
import { ProjectEditComponent } from './project-edit/project-edit.component';

const routes: Routes = [
  {
    path: '',
    component: ProjectsListComponent
  },
  {
    path: 'details/:id',
    component: ProjectDetailsComponent
  },
  {
    path: 'edit/:id',
    component: ProjectEditComponent
  },
  {
    path: 'add',
    component: ProjectAddComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectsRoutingModule {}
