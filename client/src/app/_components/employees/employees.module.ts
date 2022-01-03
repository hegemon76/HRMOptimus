import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DeleteEmployeeDialog,
  EmployeesListComponent
} from './employees-list/employees-list.component';
import { EmployeesRoutingModule } from './employees-routing.module';
import { FilterPipe } from './employeesFilter.pipe';
import { FormsModule } from '@angular/forms';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {
  EmployeeAddComponent,
  FillFormDialog
} from './employee-add/employee-add.component';
import { EmployeeAddSingleFormComponent } from './employee-add/employee-add-single-form/employee-add-single-form.component';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatChipsModule } from '@angular/material/chips';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    EmployeesListComponent,
    FilterPipe,
    EmployeeEditComponent,
    DeleteEmployeeDialog,
    EmployeeAddComponent,
    EmployeeAddSingleFormComponent,
    FillFormDialog,
    EmployeeDetailsComponent
  ],
  imports: [
    CommonModule,
    EmployeesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatAutocompleteModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatChipsModule,
    MatIconModule
  ]
})
export class employeesModule {}
