import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { toChildArray } from 'preact';
import { WorktimeService } from '../../_services/worktime.service';
import { formatDate, Time } from '@angular/common';
import { DatePipe } from '@angular/common';

interface CalendarItem {
  id: string;
  day: string;
  dayName: string;
  className: string;
  isWeekend: boolean;
  duration: Date;
  startHour: Date;
  endHour: Date;
  dayFromEndpoint: Date;
}

@Component({
  selector: 'app-worktime',
  templateUrl: './worktime.component.html',
  styleUrls: ['./worktime.component.scss'],
  providers: [DatePipe]
})

export class WorktimeComponent implements OnInit {
  date = moment().locale('pl');
  calendar: any[] = [];
  today;
  currentMonth = new Date().getMonth();
  all = true;
  weekdaysShort = [0, 1, 2, 3, 4, 5, 6].map(dow =>
    moment()
      .locale('pl')
      .weekday(dow)
      .format('ddd')
  );

  startOfMonth = this.date.startOf('month').format('ddd');
  endOfMonth = this.date.endOf('months').format('ddd');
  daysBefore = this.weekdaysShort.indexOf(this.startOfMonth);
  daysAfter = this.weekdaysShort.length - 1 - this.weekdaysShort.indexOf(this.endOfMonth);

  constructor(private workdayService: WorktimeService) { }

  month: [];

  ngOnInit(): void {
    this.today = moment().format('yyyy-MM-DD');
    this.fillCalendar();
    console.log(this.calendar);
  }

  fillCalendar() {
    this.calendar = [];
    this.startOfMonth = this.date.startOf('month').format('ddd');
    this.endOfMonth = this.date.endOf('months').format('ddd');
    this.daysBefore = this.weekdaysShort.indexOf(this.startOfMonth);
    this.daysAfter =
      this.weekdaysShort.length -
      1 -
      this.weekdaysShort.indexOf(this.endOfMonth);
    this.workdayService.getMonthEntry(this.currentMonth - 1).subscribe(res => {
      this.month = res;
      this.month.slice(-this.daysBefore).map(r => {
        this.calendar.push(this.createCalendarItem('previous-month', r));
      });
      this.workdayService.getMonthEntry(this.currentMonth).subscribe(res => {
        this.month = res;
        this.month.map(r => {
          this.calendar.push(this.createCalendarItem('in-month', r));
        });
        this.workdayService
          .getMonthEntry(this.currentMonth + 1)
          .subscribe(res => {
            this.month = res;
            this.month.slice(0, this.daysAfter).map(r => {
              this.calendar.push(this.createCalendarItem('next-month', r));
            });
          });
      });
    });
  }

  createCalendar(month: moment.Moment) {
    console.log(this.date);
    const clone = month.startOf('months').clone();

    if (this.daysBefore > 0) {
      clone.subtract(this.daysBefore, 'days');
    }

    return this.calendar.reduce(
      (pre: Array<CalendarItem[]>, curr: CalendarItem) => {
        if (pre[pre.length - 1].length < this.weekdaysShort.length) {
          pre[pre.length - 1].push(curr);
        } else {
          pre.push([curr]);
        }
        return pre;
      },
      [[]]
    );
  }

  createCalendarItem(className: string, value) {
    const dayName = formatDate(value.day, 'ddd', 'en-US');
    const test = new Date(value.day).getDay();
    let duration = value.workedTime.slice(0, -3);
    let startHour = value.startHour.slice(0, -3);
    let endHour = value.endHour.slice(0, -3);
    return {
      id: formatDate(value.day, 'yyyy-MM-dd', 'en-US'),
      dayName: formatDate(value.day, 'd', 'en-US'),
      className,
      isWeekend: test === 6 || test === 0,
      duration: duration,
      startHour: startHour,
      endHour: endHour,
      dayFromEndpoint: value.day
    };
  }

  public nextmonth() {
    this.date.add(1, 'months');
    this.currentMonth = this.currentMonth + 1;
    this.fillCalendar();
  }

  public previousmonth() {
    this.date.subtract(1, 'months');
    this.currentMonth = this.currentMonth - 1;
    this.fillCalendar();
  }

  setValueToChild(val, val2, val3) {
    this.workdayService.setDayDuration(val);
    let newVal = val2 + " - " + val3;
    this.workdayService.setDayTiming(newVal);
    localStorage.setItem('durationOfDay', val);
    localStorage.setItem('timingOfDay', newVal);
  }
}
