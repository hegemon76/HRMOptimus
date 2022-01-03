import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { VacationService } from '../../_services/vacation.service';
import { formatDate } from '@angular/common';
import { CalendarComponent } from '../shared/calendar/calendar.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { UserVm } from '../../../shared/vm/user.vm';
import { EmployeeVm } from '../../../shared/vm/employee.vm';
import { AccountService } from '../../_services/account.service';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { EmployeesService } from '../../_services/employees.service';
import { map, startWith } from 'rxjs/operators';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';

export interface DialogData {}

@Component({
  selector: 'app-vacation',
  templateUrl: './vacation.component.html',
  styleUrls: ['./vacation.component.scss']
})
export class VacationComponent implements OnInit {
  @ViewChild(CalendarComponent) calendar: CalendarComponent;
  user: UserVm;
  form: FormGroup;
  allEmployees: EmployeeVm[];
  myControl = new FormControl();
  searchedEmployee: string;
  options: any[] = [];
  filteredOptions: Observable<EmployeeVm[]>;
  employee: EmployeeVm;
  employeeId;
  employeeVacationLimit: number;
  employeeVacationLeft: number;
  vacationDaysDeclared: number = 0;
  employeeVacation: any[];
  typeOptions: any[] = [
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
      label: 'Opiekuńczy'
    },
    {
      value: 3,
      label: 'Bezpłatny'
    }
  ];
  color: ThemePalette = 'primary';
  color2: ThemePalette = 'accent';
  mode: ProgressSpinnerMode = 'determinate';
  value = 100;
  value2;
  isEmployeeLoaded = false;
  areEmployeesLoaded = false;

  constructor(
    private formBuilder: FormBuilder,
    private vacationService: VacationService,
    private router: Router,
    private route: ActivatedRoute,
    private accountService: AccountService,
    private employeesService: EmployeesService,
    public dialog: MatDialog
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = function() {
      return false;
    };
  }

  ngOnInit(): void {
    this.employeesService.getEmployees().subscribe(res => {
      this.allEmployees = res.items;
      this.fillOptions(this.allEmployees);
      this.areEmployeesLoaded = true;
    });
    this.employeesService
      .getEmployee(this.route.snapshot.paramMap.get('id'))
      .subscribe(res => {
        this.employee = res;
        this.employeeId = this.route.snapshot.paramMap.get('id');
        this.isEmployeeLoaded = true;
        this.getEmployeeVacation(this.employeeId).then(res =>
          this.fillCalendar()
        );
      });
    this.user = this.accountService.getUser();
    this.form = this.formBuilder.group({
      leaveRegisterType: ['', Validators.required],
      leaveStart: ['', Validators.required],
      leaveEnd: ['', Validators.required],
      employeeId: this.route.snapshot.paramMap.get('id')
    });
    setTimeout(() => {
      this.filteredOptions = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => (typeof value === 'string' ? value : value.name)),
        map(name => (name ? this.optionsFilter(name) : this.options.slice()))
      );
    }, 1000);
  }
  changeUser() {
    this.router.navigate(['/vacation/', this.myControl.value.id]);
  }
  displayFn(option: EmployeeVm): string {
    return option ? option.firstName + ' ' + option.lastName : '';
  }
  fillOptions(res) {
    res.map(e => {
      this.options.push({
        firstName: e.firstName,
        lastName: e.lastName,
        id: e.id
      });
    });
  }
  optionsFilter(name: string): EmployeeVm[] {
    const filterValue = name.toLowerCase();

    return this.options.filter(option =>
      option.firstName.toLowerCase().includes(filterValue)
    );
  }

  changeMonth() {
    this.fillCalendar();
  }

  getEmployeeVacation(id) {
    return new Promise((resolve, reject) => {
      this.vacationService.getEmployeeVacations(id).subscribe(res => {
        this.employeeVacationLimit = res.leaveDaysByContract;
        this.employeeVacationLeft = res.leaveDaysLeft;
        this.employeeVacation = res.leaveRecords;
        this.value2 =
          (this.employeeVacationLeft / this.employeeVacationLimit) * 100;
      });
      resolve('done');
    });
  }

  fillCalendar() {
    var isArraySet = setInterval(() => {
      if (this.employeeVacation != null) {
        clearInterval(isArraySet);
        this.employeeVacation.map(d => {
          var leaveStatus, leaveRegisterType;
          if (d.isApproved == 2) {
            leaveStatus = 'pending';
          } else if (d.isApproved == 1) {
            leaveStatus = 'rejected';
          } else if (d.isApproved == 0) {
            leaveStatus = 'approved';
          }
          if (d.leaveRegisterType === 0) {
            leaveRegisterType = 'sickleave';
          } else if (d.leaveRegisterType === 1) {
            leaveRegisterType = 'casualleave';
          } else if (d.leaveRegisterType === 2) {
            leaveRegisterType = 'caringleave';
          } else if (d.leaveRegisterType === 3) {
            leaveRegisterType = 'unpaidleave';
          }
          let daysArray = [];
          let push = false;
          this.calendar.calendar.map(w => {
            w.map(day => {
              if (day.id == formatDate(d.dateFrom, 'ddMMYYYY', 'en-US')) {
                push = true;
              }
              if (push) {
                if (!day.isWeekend) {
                  this.vacationDaysDeclared++;
                }
                daysArray.push(day);
                this.calendar.setLeaveDay(
                  day.id,
                  leaveStatus,
                  leaveRegisterType
                );
              }
              if (day.id == formatDate(d.dateTo, 'ddMMYYYY', 'en-US')) {
                push = false;
              }
            });
          });
        });
      }
    }, 100);
  }

  addVacation() {
    if (
      this.form.valid &&
      !this.checkIfAlreadyDeclared() &&
      !this.checkIfOverflowed() &&
      !this.checkIfRangeIsCorrect()
    ) {
      console.log('ok');
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
          this.router.navigate(['/vacation', this.employeeId]);
        });
      });
    } else if (this.checkIfAlreadyDeclared()) {
      this.openAlreadyDeclaredDialog();
    } else if (this.checkIfOverflowed()) {
      this.openDatesOverflowedDialog();
    } else if (this.checkIfRangeIsCorrect()) {
      this.openIncorrectRangeDialog();
    }
  }
  checkIfAlreadyDeclared(): boolean {
    const start =
      formatDate(this.form.getRawValue().leaveStart, 'YYYY-MM-dd', 'en-US') +
      'T00:00:00';
    const end =
      formatDate(this.form.getRawValue().leaveEnd, 'YYYY-MM-dd', 'en-US') +
      'T00:00:00';
    let check = false;
    this.employeeVacation.map(v => {
      // if (
      //   (start < v.dateFrom && end <= v.dateTo && end >= v.dateFrom) ||
      //   (start >= v.dateFrom && end <= v.dateTo) ||
      //   (start >= v.dateFrom && end > v.dateTo && start <= v.dateTo) ||
      //   (start <= v.dateFrom && end >= v.dateTo)
      // )
      if (start < v.dateFrom && end <= v.dateTo && end >= v.dateFrom) {
        console.log(1);
        check = true;
      } else if (start >= v.dateFrom && end <= v.dateTo) {
        console.log(2);
        check = true;
      } else if (start >= v.dateFrom && end > v.dateTo && start <= v.dateTo) {
        console.log(3);
        check = true;
      } else if (start <= v.dateFrom && end >= v.dateTo) {
        console.log(4);
        console.log(this.form.getRawValue().leaveStart);
        check = true;
      } else {
        check = false;
      }
    });
    return check;
  }

  checkIfOverflowed(): boolean {
    let incomingDaysCount = 0;
    const start = new Date(this.form.getRawValue().leaveStart);
    const end = new Date(this.form.getRawValue().leaveEnd);
    const endNextDay = new Date(end);
    endNextDay.setDate(end.getDate() + 1);
    let currentDay = start;
    let check = false;
    while (currentDay < endNextDay) {
      if (currentDay.getDay() != 6 && currentDay.getDay() != 0) {
        incomingDaysCount++;
      }
      currentDay.setDate(currentDay.getDate() + 1);
    }
    if (
      this.vacationDaysDeclared + incomingDaysCount >
      this.employeeVacationLimit
    ) {
      check = true;
    }
    return check;
  }
  checkIfRangeIsCorrect() {
    const start = new Date(this.form.getRawValue().leaveStart);
    const end = new Date(this.form.getRawValue().leaveEnd);
    let check = false;
    if (start > end) {
      check = true;
    }
    return check;
  }

  approveVacation(vacationId) {
    this.vacationService
      .approveVacation(vacationId, this.employeeId)
      .subscribe(res => {
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/vacation', this.employeeId]);
        });
      });
  }
  rejectVacation(vacationId) {
    this.vacationService
      .rejectVacation(vacationId, this.employeeId)
      .subscribe(res => {
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/vacation', this.employeeId]);
        });
      });
  }
  deleteVacation(vacationId) {
    this.vacationService
      .deleteVacation(vacationId, this.employeeId)
      .subscribe(res => {
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/vacation', this.employeeId]);
        });
      });
  }
  openAlreadyDeclaredDialog() {
    const dialogRef = this.dialog.open(DateUnavailableDialog);
  }
  openDatesOverflowedDialog() {
    const dialogRef = this.dialog.open(DatesOverflowedDialog);
  }
  openIncorrectRangeDialog() {
    const dialogRef = this.dialog.open(DateRangeIncorrectDialog);
  }
}

@Component({
  selector: 'date-unavailable-dialog',
  templateUrl: 'date-unavailable-dialog.html',
  styleUrls: ['./vacation.component.scss']
})
export class DateUnavailableDialog {
  constructor(
    public dialogRef: MatDialogRef<DateUnavailableDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
}

@Component({
  selector: 'dates-overflowed-dialog',
  templateUrl: 'dates-overflowed-dialog.html',
  styleUrls: ['./vacation.component.scss']
})
export class DatesOverflowedDialog {
  constructor(
    public dialogRef: MatDialogRef<DatesOverflowedDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
}

@Component({
  selector: 'date-range-incorrect-dialog',
  templateUrl: 'date-range-incorrect-dialog.html',
  styleUrls: ['./vacation.component.scss']
})
export class DateRangeIncorrectDialog {
  constructor(
    public dialogRef: MatDialogRef<DateRangeIncorrectDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
}
