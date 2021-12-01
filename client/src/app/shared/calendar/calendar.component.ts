import { Component, OnInit } from '@angular/core';
import { Output, Input } from '@angular/core';
import * as moment from 'moment';

interface CalendarItem {
  id: string;
  day: string;
  dayName: string;
  className: string;
  isWeekend: boolean;
}

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {
  date = moment().locale('pl');
  calendar: Array<CalendarItem[]> = [];

  constructor() {}

  ngOnInit(): void {
    this.calendar = this.createCalendar(this.date);
  }
  createCalendar(month: moment.Moment) {
    const daysInMonth = month.daysInMonth();
    const startOfMonth = month.startOf('month').format('ddd');
    const endOfMonth = month.endOf('months').format('ddd');
    const weekdaysShort = [0, 1, 2, 3, 4, 5, 6].map(dow =>
      moment()
        .locale('pl')
        .weekday(dow)
        .format('ddd')
    );
    const calendar: CalendarItem[] = [];
    const daysBefore = weekdaysShort.indexOf(startOfMonth);
    const daysAfter =
      weekdaysShort.length - 1 - weekdaysShort.indexOf(endOfMonth);
    const clone = month.startOf('months').clone();
    if (daysBefore > 0) {
      clone.subtract(daysBefore, 'days');
    }
    for (let i = 0; i < daysBefore; i++) {
      calendar.push(this.createCalendarItem(clone, 'previous-month'));
      clone.add(1, 'days');
    }
    for (let i = 0; i < daysInMonth; i++) {
      calendar.push(this.createCalendarItem(clone, 'in-month'));
      clone.add(1, 'days');
    }
    for (let i = 0; i < daysAfter; i++) {
      calendar.push(this.createCalendarItem(clone, 'next-month'));
      clone.add(1, 'days');
    }
    return calendar.reduce(
      (pre: Array<CalendarItem[]>, curr: CalendarItem) => {
        if (pre[pre.length - 1].length < weekdaysShort.length) {
          pre[pre.length - 1].push(curr);
        } else {
          pre.push([curr]);
        }
        return pre;
      },
      [[]]
    );
  }
  createCalendarItem(data: moment.Moment, className: string) {
    const dayName = data.format('ddd');
    return {
      id: data.format('DD') + data.format('MM') + data.format('YYYY'),
      day: data.format('D'),
      dayName,
      className,
      isWeekend: dayName === 'ndz' || dayName === 'sob'
    };
  }
  public nextmonth() {
    this.date.add(1, 'months');
    this.calendar = this.createCalendar(this.date);
  }
  public previousmonth() {
    this.date.subtract(1, 'months');
    this.calendar = this.createCalendar(this.date);
  }
}
