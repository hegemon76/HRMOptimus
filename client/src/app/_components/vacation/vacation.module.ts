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
import { MatSelectModule } from '@angular/material/select';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDialogModule } from '@angular/material/dialog';
import { DateUnavailableDialog } from './vacation.component';
import { DatesOverflowedDialog } from './vacation.component';
import { DateRangeIncorrectDialog } from './vacation.component';

@NgModule({
  declarations: [
    VacationComponent,
    DateUnavailableDialog,
    DatesOverflowedDialog,
    DateRangeIncorrectDialog
  ],
  imports: [
    CommonModule,
    SharedModule,
    VacationRoutingModule,
    MatCardModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatAutocompleteModule,
    MatDialogModule
  ],
  providers: []
})
export class VacationModule {}
