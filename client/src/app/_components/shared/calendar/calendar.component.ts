import { formatDate } from '@angular/common';
import { Component, Injectable, OnInit } from '@angular/core';
import { Output, Input, EventEmitter } from '@angular/core';
import * as moment from 'moment';
import {
  isHoliday,
  getHolidaysInYear,
  getHolidayOnDate
} from 'poland-public-holidays';

interface CalendarItem {
  id: string;
  day: string;
  dayName: string;
  className: string;
  isWeekend: boolean;
  leaveDay: string;
  leaveDayType: number;
}

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {
  date = moment().locale('pl');
  calendar: Array<CalendarItem[]> = [];
  holidays = getHolidaysInYear(new Date().getFullYear());
  @Output() changeMonthEmitter = new EventEmitter();

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

    let isHoliday = false;

    const test = formatDate(this.holidays[0].date, 'dd-MM-yyyy', 'en-US');
    const test2 = formatDate(data.toDate(), 'dd-MM-yyyy', 'en-US');

    console.log(test);
    console.log(test2);

    this.holidays.map(h => {
      if (
        formatDate(h.date, 'dd-MM-yyyy', 'en-US') ==
        formatDate(data.toDate(), 'dd-MM-yyyy', 'en-US')
      ) {
        console.log(data.toDate());
        isHoliday = true;
      }
    });

    return {
      id: data.format('DD') + data.format('MM') + data.format('YYYY'),
      day: data.format('D'),
      dayName,
      className,
      isWeekend: dayName === 'ndz' || dayName === 'sob',
      isHoliday: isHoliday,
      leaveDay: null,
      leaveDayType: null
    };
  }

  setLeaveDay(dayId, leaveStatus, leaveRegisterType) {
    let newArray = [];
    this.calendar.map(a => {
      newArray = newArray.concat(a);
    });
    const day = newArray.find(d => {
      return d.id === dayId;
    });
    if (leaveStatus === 'approved') {
      day.leaveDay = 'approved';
    } else if (leaveStatus === 'pending') {
      day.leaveDay = 'pending';
    } else if (leaveStatus === 'rejected') {
      day.leaveDay = 'rejected';
    }
    if (leaveRegisterType == 'sickleave') {
      day.leaveDayType = 'sickleave';
    } else if (leaveRegisterType == 'casualleave') {
      day.leaveDayType = 'casualleave';
    } else if (leaveRegisterType == 'caringleave') {
      day.leaveDayType = 'caringleave';
    } else if (leaveRegisterType == 'unpaidleave') {
      day.leaveDayType = 'unpaidleave';
    }
  }

  public nextmonth() {
    this.changeMonthEmitter.emit();
    this.date.add(1, 'months');
    this.calendar = this.createCalendar(this.date);
  }
  public previousmonth() {
    this.changeMonthEmitter.emit();
    this.date.subtract(1, 'months');
    this.calendar = this.createCalendar(this.date);
  }
}
