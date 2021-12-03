import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';
import { EmployeeAddComponent } from './employee-add/employee-add.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeesListComponent
  },
  {
    path: 'edit/:id',
    component: EmployeeEditComponent
  },
  {
    path: 'add',
    component: EmployeeAddComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeesRoutingModule {}
