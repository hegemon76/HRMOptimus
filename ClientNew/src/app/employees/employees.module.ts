import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DeleteEmployeeDialog,
  EmployeesComponent
} from './employees.component';
import { EmployeesRoutingModule } from '../employees/employees-routing.module';
import { FilterPipe } from './employeesFilter.pipe';
import { FormsModule } from '@angular/forms';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    EmployeesComponent,
    FilterPipe,
    EmployeeEditComponent,
    DeleteEmployeeDialog
  ],
  imports: [
    CommonModule,
    EmployeesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatAutocompleteModule,
    MatDialogModule
  ]
})
export class employeesModule {}
