import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { employeesComponent } from './employees.component';
import { employeesRoutingModule } from '../employees/employees-routing.module';
import { FilterPipe } from './employeesFilter.pipe';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [employeesComponent, FilterPipe],
  imports: [CommonModule, employeesRoutingModule, FormsModule]
})
export class employeesModule {}
