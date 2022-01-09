import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { toChildArray } from 'preact';
import { WorktimeService } from '../worktime/worktime.service';
import { formatDate, Time } from '@angular/common';

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
  styleUrls: ['./worktime.component.scss']
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
  daysAfter =
    this.weekdaysShort.length - 1 - this.weekdaysShort.indexOf(this.endOfMonth);

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

    return {
      id: formatDate(value.day, 'yyyy-MM-dd', 'en-US'),
      dayName: formatDate(value.day, 'd', 'en-US'),
      className,
      isWeekend: test === 6 || test === 0,
      duration: value.workedTime,
      startHour: value.startHour,
      endHour: value.endHour,
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
}

// import { Component, OnInit } from '@angular/core';
// import * as moment from 'moment';
// import { toChildArray } from 'preact';
// import { WorktimeService } from '../worktime/worktime.service';

// interface CalendarItem {
//   id: string;
//   day: string;
//   dayName: string;
//   className: string;
//   isWeekend: boolean;
//   // duration;
//   // startHour;
//   // endHour;
//   // dayFromEndpoint;
// }

// @Component({
//   selector: 'app-worktime',
//   templateUrl: './worktime.component.html',
//   styleUrls: ['./worktime.component.scss']
// })
// export class WorktimeComponent implements OnInit {
//   date = moment().locale('pl');
//   calendar: Array<CalendarItem[]> = [];
//   today;
//   all = true;
//   month = [];

//   constructor(private workdayService: WorktimeService) {}

//   ngOnInit(): void {
//     this.today = moment().format('yyyy-MM-DD');
//     const currentMonth = new Date().getMonth();
//     this.workdayService.getMonthEntry(currentMonth).subscribe(res => {
//       this.month = res;
//       this.calendar = this.createCalendar(this.date);
//     });
//   }

//   mapDataFromArray(value) {
//     return {
//       duration: value.workedTime,
//       startHour: value.startHour,
//       endHour: value.endHour,
//       dayFromEndpoint: value.day
//     };
//   }

//   createCalendar(month: moment.Moment) {
//     const daysInMonth = month.daysInMonth();
//     const startOfMonth = month.startOf('month').format('ddd');
//     const endOfMonth = month.endOf('months').format('ddd');
//     const weekdaysShort = [0, 1, 2, 3, 4, 5, 6].map(dow =>
//       moment()
//         .locale('pl')
//         .weekday(dow)
//         .format('ddd')
//     );

//     const calendar: CalendarItem[] = [];

//     const daysBefore = weekdaysShort.indexOf(startOfMonth);

//     const daysAfter =
//       weekdaysShort.length - 1 - weekdaysShort.indexOf(endOfMonth);

//     const clone = month.startOf('months').clone();
//     console.log(daysBefore);

//     if (daysBefore > 0) {
//       clone.subtract(daysBefore, 'days');
//     }

//     for (let i = 0; i < daysBefore; i++) {
//       calendar.push(this.createCalendarItem(clone, 'previous-month'));
//       clone.add(1, 'days');
//     }

//     for (let i = 0; i < daysInMonth; i++) {
//       calendar.push(this.createCalendarItem(clone, 'in-month'));
//       clone.add(1, 'days');
//     }

//     for (let i = 0; i < daysAfter; i++) {
//       calendar.push(this.createCalendarItem(clone, 'next-month'));
//       clone.add(1, 'days');
//     }

//     return calendar.reduce(
//       (pre: Array<CalendarItem[]>, curr: CalendarItem) => {
//         if (pre[pre.length - 1].length < weekdaysShort.length) {
//           pre[pre.length - 1].push(curr);
//         } else {
//           pre.push([curr]);
//         }
//         return pre;
//       },
//       [[]]
//     );
//   }

//   createCalendarItem(data: moment.Moment, className: string) {
//     const dayName = data.format('ddd');
//     return {
//       id:
//         data.format('YYYY') + '-' + data.format('MM') + '-' + data.format('DD'),
//       day: data.format('D'),
//       dayName,
//       className,
//       isWeekend: dayName === 'ndz' || dayName === 'sob'
//       // duration: value.workedTime,
//       // startHour: value.startHour,
//       // endHour: value.endHour,
//       // dayFromEndpoint: value.day
//     };
//   }

//   public nextmonth() {
//     this.date.add(1, 'months');
//     this.calendar = this.createCalendar(this.date);
//   }

//   public previousmonth() {
//     this.date.subtract(1, 'months');
//     this.calendar = this.createCalendar(this.date);
//   }
// }
