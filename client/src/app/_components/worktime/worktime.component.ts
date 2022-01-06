import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { toChildArray } from 'preact';
import { WorktimeService } from '../worktime/worktime.service';

interface CalendarItem {
  id: string;
  day: string;
  dayName: string;
  className: string;
  isWeekend: boolean;
  duration;
  startHour;
  endHour;
  dayFromEndpoint;
}

@Component({
  selector: 'app-worktime',
  templateUrl: './worktime.component.html',
  styleUrls: ['./worktime.component.scss']
})

export class WorktimeComponent implements OnInit {
  date = moment().locale('pl');
  calendar: Array<CalendarItem[]> = [];
  today;
  all = true;

  constructor(
    private workdayService: WorktimeService,
  ) { }

  month: [];

  ngOnInit(): void {

    this.today = moment().format('yyyy-MM-DD');

    this.workdayService.getMonthEntry().subscribe(res => {
      this.month = res;
      this.month.map(r => {
        calendar.push(this.createCalendarItem(clone, 'in-month', value));
      })
      this.calendar = this.createCalendar(this.date);
    })
  }

  mapDataFromArray(value) {
    //console.log(value.workedTime, value.startHour, value.endHour, value.day)
    return {
      duration: value.workedTime,
      startHour: value.startHour,
      endHour: value.endHour,
      dayFromEndpoint: value.day
    };
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

    const daysAfter = weekdaysShort.length - 1 - weekdaysShort.indexOf(endOfMonth);

    const clone = month.startOf('months').clone();

    if (daysBefore > 0) {
      clone.subtract(daysBefore, 'days');
    }

    // for (let i = 0; i < daysBefore; i++) {
    //   calendar.push(this.createCalendarItem(clone, 'previous-month', value));
    //   clone.add(1, 'days');
    // }

    // for (let i = 0; i < daysInMonth; i++) {
    //   calendar.push(this.createCalendarItem(clone, 'in-month', value));
    //   clone.add(1, 'days');
    // }




    // for (let i = 0; i < daysAfter; i++) {
    //   calendar.push(this.createCalendarItem(clone, 'next-month', value));
    //   clone.add(1, 'days');
    // }

    // for (let i = 0; i < calendar.length; i++) {
    //   calendar[i].duration = this.month[i];
    // }



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

  createCalendarItem(data: moment.Moment, className: string, value) {
    const dayName = data.format('ddd');
    return {
      id: data.format('YYYY') + "-" + data.format('MM') + "-" + data.format('DD'),
      day: data.format('D'),
      dayName,
      className,
      isWeekend: dayName === 'ndz' || dayName === 'sob',
      duration: value.workedTime,
      startHour: value.startHour,
      endHour: value.endHour,
      dayFromEndpoint: value.day
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
