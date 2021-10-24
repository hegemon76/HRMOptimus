import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';

@Component({
  selector: 'app-worktime',
  templateUrl: './worktime.component.html',
  styleUrls: ['./worktime.component.scss']
})
export class WorktimeComponent implements OnInit {
  constructor() {}
  ngOnInit(): void {}
  calendarOptions: CalendarOptions = {
    initialView: 'timeGridWeek',
    height: '100%',
    selectable: true
  };
}
