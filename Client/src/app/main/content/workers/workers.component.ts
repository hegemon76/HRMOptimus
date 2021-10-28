import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';

@Component({
  selector: 'app-workers',
  templateUrl: './workers.component.html',
  styleUrls: ['./workers.component.scss']
})
export class WorkersComponent implements OnInit {
  constructor() {}
  ngOnInit(): void {}
  calendarOptions: CalendarOptions = {
    initialView: 'timeGridWeek',
    height: '100%',
    selectable: true
  };
}
