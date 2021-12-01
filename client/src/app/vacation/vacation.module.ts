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
<<<<<<< HEAD
import { MatSelectModule } from '@angular/material/select';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
=======
>>>>>>> 5270fcd57c57f6d6b7f5c20cce7c2ddcb7cd9170

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
<<<<<<< HEAD
    MatNativeDateModule,
    MatSelectModule,
    MatProgressSpinnerModule
=======
    MatNativeDateModule
>>>>>>> 5270fcd57c57f6d6b7f5c20cce7c2ddcb7cd9170
  ],
  providers: []
})
export class VacationModule {}
