import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VacationRoutingModule } from './vacation-routing.module';
import { VacationComponent } from './vacation.component';
import { MatCardModule } from '@angular/material/card';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [VacationComponent],
  imports: [CommonModule, SharedModule, VacationRoutingModule, MatCardModule]
})
export class VacationModule {}
