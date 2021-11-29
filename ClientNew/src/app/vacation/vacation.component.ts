import { Component, OnInit, ViewChild } from '@angular/core';
import { VacationService } from './vacation.service';
import { formatDate } from '@angular/common';
import { map, filter } from 'rxjs/operators';
import { CalendarComponent } from '../shared/calendar/calendar.component';

@Component({
  selector: 'app-vacation',
  templateUrl: './vacation.component.html',
  styleUrls: ['./vacation.component.scss']
})
export class VacationComponent implements OnInit {
  @ViewChild(CalendarComponent) calendar: CalendarComponent;
  employee: any;
  employeeVacation: any[];

  constructor(private vacationService: VacationService) {}

  ngOnInit(): void {
    this.employee = JSON.parse(localStorage.getItem('user'));
    this.getEmployeeVacation(this.employee.employeeId).then(res =>
      this.fillCalendar()
    );
  }

  getEmployeeVacation(id) {
    return new Promise((resolve, reject) => {
      this.vacationService.getEmployeeVacations(id).subscribe(res => {
        console.log(res);
        this.employeeVacation = res;
      });
      resolve('done');
    });
  }

  fillCalendar() {
    var isArraySet = setInterval(() => {
      if (this.employeeVacation != null) {
        clearInterval(isArraySet);
        this.employeeVacation.map(d => {
          var colorToFill;
          if (d.isApproved == 2) {
            colorToFill = '#fcf4a3';
          } else if (d.isApproved == 0) {
            colorToFill = '#d9ffbf';
          }
          let daysArray = [];
          let push = false;
          this.calendar.calendar.map(w => {
            w.map(day => {
              if (day.id == formatDate(d.dateFrom, 'ddMMYYYY', 'en-US')) {
                push = true;
              }
              if (push) {
                daysArray.push(day);
              }
              if (day.id == formatDate(d.dateTo, 'ddMMYYYY', 'en-US')) {
                push = false;
              }
            });
          });
          daysArray.map(vDay => {
            document.getElementById(
              vDay.id
            ).style.backgroundColor = colorToFill;
            document.getElementById(vDay.id).querySelector('span').style.color =
              '#000000de';
          });
        });
      }
    }, 100);
  }
}
