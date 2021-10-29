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
    initialView: 'listMonth',
    height: '100%',
    selectable: true,
    slotMinTime: '7:00:00',
    slotMaxTime: '20:00:00',
    events: [
      {
        title: 'event 1',
        start: '2021-10-28T07:30:00',
        end: '2021-10-28T11:30:00'
      },
      {
        title: 'event 2',
        start: '2021-10-28T11:30:00',
        end: '2021-10-28T12:00:00'
      },
      {
        title: 'event 3',
        start: '2021-10-28T12:00:00',
        end: '2021-10-28T13:30:00'
      },
      {
        title: 'event 4',
        start: '2021-10-28T13:30:00',
        end: '2021-10-28T14:30:00'
      },
      {
        title: 'event 5',
        start: '2021-10-28T14:30:00',
        end: '2021-10-28T16:00:00'
      },
      {
        title: 'event 1',
        start: '2021-10-29T07:30:00',
        end: '2021-10-29T11:30:00'
      },
      {
        title: 'event 2',
        start: '2021-10-29T11:30:00',
        end: '2021-10-29T12:00:00'
      },
      {
        title: 'event 3',
        start: '2021-10-29T12:00:00',
        end: '2021-10-29T13:30:00'
      },
      {
        title: 'event 4',
        start: '2021-10-29T13:30:00',
        end: '2021-10-29T14:30:00'
      },
      {
        title: 'event 5',
        start: '2021-10-29T14:30:00',
        end: '2021-10-29T16:00:00'
      },
      {
        title: 'event 1',
        start: '2021-10-30T07:30:00',
        end: '2021-10-30T11:30:00'
      },
      {
        title: 'event 2',
        start: '2021-10-30T11:30:00',
        end: '2021-10-30T12:00:00'
      },
      {
        title: 'event 3',
        start: '2021-10-30T12:00:00',
        end: '2021-10-30T13:30:00'
      },
      {
        title: 'event 4',
        start: '2021-10-30T13:30:00',
        end: '2021-10-30T14:30:00'
      },
      {
        title: 'event 5',
        start: '2021-10-30T14:30:00',
        end: '2021-10-30T16:00:00'
      },
      {
        title: 'event 1',
        start: '2021-10-31T07:30:00',
        end: '2021-10-31T11:30:00'
      },
      {
        title: 'event 2',
        start: '2021-10-31T11:30:00',
        end: '2021-10-31T12:00:00'
      },
      {
        title: 'event 3',
        start: '2021-10-31T12:00:00',
        end: '2021-10-31T13:30:00'
      },
      {
        title: 'event 4',
        start: '2021-10-31T13:30:00',
        end: '2021-10-31T14:30:00'
      },
      {
        title: 'event 5',
        start: '2021-10-31T14:30:00',
        end: '2021-10-31T16:00:00'
      }
    ]
  };
  ngAfterViewInit() {
    const dots = document.querySelectorAll<HTMLElement>('.fc-list-event-dot');
    dots.forEach(dot => {
      dot.style.borderColor = `rgba(${Math.floor(
        Math.random() * 255
      )},${Math.floor(Math.random() * 255)},${Math.floor(
        Math.random() * 255
      )},1)`;
    });
  }
}
