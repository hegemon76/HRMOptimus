import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorktimeComponent } from './worktime.component';
import { WorktimeRoutingModule } from './worktime-routing.module';
import { WorkdayComponent } from './workday/workday.component';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [WorktimeComponent, WorkdayComponent],
  imports: [CommonModule, WorktimeRoutingModule, MatSelectModule, MatInputModule, MatIconModule, MatExpansionModule, FormsModule, ReactiveFormsModule]
})
export class WorktimeModule { }
