import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkersComponent } from './workers.component';
import { WorkersRoutingModule } from '../workers/workers-routing.module';

@NgModule({
  declarations: [WorkersComponent],
  imports: [CommonModule, WorkersRoutingModule]
})
export class WorkersModule {}
