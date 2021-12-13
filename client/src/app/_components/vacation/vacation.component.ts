import { Component, OnInit, ViewChild } from '@angular/core';
import { VacationService } from '../../_services/vacation.service';
import { formatDate } from '@angular/common';
import { CalendarComponent } from '../shared/calendar/calendar.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { UserVm } from '../../../shared/vm/user.vm';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-vacation',
  templateUrl: './vacation.component.html',
  styleUrls: ['./vacation.component.scss']
})
export class VacationComponent implements OnInit {
  @ViewChild(CalendarComponent) calendar: CalendarComponent;
  user: UserVm;
  form: FormGroup;
  employee: any;
  employeeVacationLimit: number;
  employeeVacationLeft: number;
  employeeVacation: any[];
  options: any[] = [
    {
      value: 0,
      label: 'Chorobowy'
    },
    {
      value: 1,
      label: 'Na żądanie'
    },
    {
      value: 2,
      label: 'Macieżyński'
    },
    {
      value: 3,
      label: 'Tecieżyński'
    },
    {
      value: 4,
      label: 'Bezpłatny'
    }
  ];
  color: ThemePalette = 'primary';
  color2: ThemePalette = 'accent';
  mode: ProgressSpinnerMode = 'determinate';
  value = 100;
  value2 = (27 / 40) * 100;

  constructor(
    private formBuilder: FormBuilder,
    private vacationService: VacationService,
    private router: Router,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.user = this.accountService.getUser();
    this.employee = JSON.parse(localStorage.getItem('user'));
    this.form = this.formBuilder.group({
      leaveRegisterType: ['', Validators.required],
      leaveStart: ['', Validators.required],
      leaveEnd: ['', Validators.required],
      employeeId: this.employee.employeeId
    });
    this.getEmployeeVacation(this.employee.employeeId).then(res =>
      this.fillCalendar()
    );
  }

  getEmployeeVacation(id) {
    return new Promise((resolve, reject) => {
      this.vacationService.getEmployeeVacations(id).subscribe(res => {
        this.employeeVacationLimit = res.leaveDaysByContract;
        this.employeeVacationLeft = res.leaveDaysLeft;
        this.employeeVacation = res.leaveRecords;
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
          } else if (d.isApproved == 1) {
            colorToFill = '#d38891';
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

  addVacation() {
    if (this.form.valid) {
      var vacationFormatted = {
        leaveRegisterType: this.form.getRawValue().leaveRegisterType,
        leaveStart:
          formatDate(
            this.form.getRawValue().leaveStart,
            'YYYY-MM-dd',
            'en-US'
          ) + 'T00:00:00.000Z',
        leaveEnd:
          formatDate(this.form.getRawValue().leaveEnd, 'YYYY-MM-dd', 'en-US') +
          'T23:59:59.404Z',
        employeeId: this.form.getRawValue().employeeId
      };
      this.vacationService.addVacation(vacationFormatted).subscribe(res => {
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/vacation']);
        });
      });
    }
  }
  approveVacation(vacationId, employeeId) {
    this.vacationService
      .approveVacation(vacationId, employeeId)
      .subscribe(res => {
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/vacation']);
        });
      });
  }
  rejectVacation(vacationId, employeeId) {
    this.vacationService
      .rejectVacation(vacationId, employeeId)
      .subscribe(res => {
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/vacation']);
        });
      });
  }
}
