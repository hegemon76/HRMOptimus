import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VacationRoutingModule } from './vacation-routing.module';
import { VacationComponent } from './vacation.component';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [VacationComponent],
  imports: [
    CommonModule,
    SharedModule,
    VacationRoutingModule,
    MatCardModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: []
})
export class VacationModule {}
