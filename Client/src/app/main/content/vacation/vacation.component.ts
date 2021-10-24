import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';

@Component({
  selector: 'app-vacation',
  templateUrl: './vacation.component.html',
  styleUrls: ['./vacation.component.scss']
})
export class VacationComponent implements OnInit {
  constructor() {}
  ngOnInit(): void {}
  calendarOptions: CalendarOptions = {
    initialView: 'dayGridWeek',
    height: '100%',
    selectable: true
  };
}
