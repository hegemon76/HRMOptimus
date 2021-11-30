import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorktimeComponent } from './worktime.component';
import { WorktimeRoutingModule } from './worktime-routing.module';
import { WorkdayComponent } from './workday.component';

@NgModule({
  declarations: [WorktimeComponent, WorkdayComponent],
  imports: [CommonModule, WorktimeRoutingModule]
})
export class WorktimeModule {}
