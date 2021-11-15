import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { employeesComponent } from './employees.component';
import { employeesRoutingModule } from '../employees/employees-routing.module';

@NgModule({
  declarations: [employeesComponent],
  imports: [CommonModule, employeesRoutingModule]
})
export class employeesModule {}
