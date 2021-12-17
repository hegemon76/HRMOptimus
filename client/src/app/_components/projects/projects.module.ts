import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ProjectsListComponent,
  DeleteProjectDialog
} from './projects-list/projects-list.component';
import { ProjectDetailsComponent } from './project-details/project-details.component';
import {
  ProjectAddComponent,
  FillProjectsFormDialog
} from './project-add/project-add.component';
import { ProjectAddSingleFormComponent } from './project-add/project-add-single-form/project-add-single-form.component';
import { ProjectsRoutingModule } from './projects-routing.module';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FilterPipe } from './projectsFilter.pipe';
import { FormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    ProjectsListComponent,
    ProjectDetailsComponent,
    ProjectAddComponent,
    ProjectAddSingleFormComponent,
    FilterPipe,
    FillProjectsFormDialog,
    DeleteProjectDialog
  ],
  imports: [
    CommonModule,
    ProjectsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatDialogModule
  ]
})
export class ProjectsModule {}
