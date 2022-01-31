import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartConfiguration, ChartEvent, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { AccountService } from '../../_services/account.service';
import { WorktimeService } from '../../_services/worktime.service';
import { EmployeesService } from '../../_services/employees.service';
import { VacationService } from '../../_services/vacation.service';
import { ProjectsService } from '../../_services/projects.service';
import { EmployeeVm } from '../../../shared/vm/employee.vm';
import { UserVm } from '../../../shared/vm/user.vm';
import { formatDate } from '@angular/common';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  @ViewChild(BaseChartDirective) chart?: BaseChartDirective;
  isChartEmpty = true;
  isProjectListEmpty = true;

  monthTime: string;
  months: string[] = [
    'Styczeń',
    'Luty',
    'Marzec',
    'Kwiecień',
    'Maj',
    'Czerwiec',
    'Lipiec',
    'Sierpień',
    'Wrzesień',
    'Październik',
    'Listopad',
    'Grudzień'
  ];
  user: UserVm;
  currentMonth: string = this.months[new Date().getMonth()];
  currentYear: number = new Date().getFullYear();
  vacationLimit: number;
  vacationLeft: number;

  barChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: [],
        label: 'Przepracowane godziny w obecnym miesiącu',
        backgroundColor: '#FDC20E',
        borderColor: 'rgba(148,159,177,1)',
        pointBackgroundColor: 'rgba(148,159,177,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        fill: 'origin'
      }
    ],
    labels: []
  };

  barChartOptions: ChartConfiguration['options'] = {
    maintainAspectRatio: false,
    elements: {
      line: {
        tension: 0.5
      }
    },
    scales: {
      y: {
        max: 12,
        grid: {
          borderWidth: 0
        }
      },
      x: {
        grid: {
          lineWidth: 0
        }
      }
    },
    plugins: {
      legend: {
        display: false
      }
    }
  };

  barChartType: ChartType = 'bar';
  employees: EmployeeVm[];
  adminsToDisplay: EmployeeVm[];
  color: ThemePalette = 'primary';
  color2: ThemePalette = 'accent';
  mode: ProgressSpinnerMode = 'determinate';
  value = 100;
  value2;
  projects: any[];

  constructor(
    private accountService: AccountService,
    private worktimeService: WorktimeService,
    private employeesService: EmployeesService,
    private vacationService: VacationService,
    private projectsService: ProjectsService
  ) {}

  ngOnInit(): void {
    this.user = this.accountService.getUser();
    const today = new Date();
    const daysCount = this.daysInMonth(today.getFullYear(), today.getMonth());
    this.setLabels(daysCount);
    this.setData();
    if (this.chart) {
      this.chart.update();
    }
    this.getEmployees();
    this.setLimitAndLeft();
    this.setProjects();
  }

  daysInMonth(month, year) {
    return new Date(year, month, 0).getDate();
  }

  setLabels(daysCount) {
    for (let i = 1; i <= daysCount + 1; i++) {
      this.barChartData.labels = this.barChartData.labels.concat(i);
    }
  }
  setData() {
    const today = new Date();
    const monthStart = formatDate(
      new Date(today.getFullYear(), today.getMonth(), 1),
      'yyyy-MM-dd',
      'en-US'
    );
    const monthEnd = formatDate(
      new Date(today.getFullYear(), today.getMonth() + 1, 0),
      'yyyy-MM-dd',
      'en-US'
    );
    // this.worktimeService.getMonthEntryDefault().subscribe(res => {
    this.worktimeService
      .getMonthEntryTest(this.user.employeeId)
      .subscribe(res => {
        let hours = 0;
        let minutes = 0;
        res.daysWorkRecords.map(h => {
          hours += parseInt(h.workedTime.split(':')[0]);
          minutes += parseInt(h.workedTime.split(':')[1]);
          this.barChartData.datasets[0].data = this.barChartData.datasets[0].data.concat(
            parseFloat(h.workedTime.split(':')[0]) +
              parseFloat(h.workedTime.split(':')[1]) / 60
          );
        });
        hours += Math.floor(minutes / 60);
        minutes = minutes % 60;
        this.monthTime = hours + ':' + minutes + 'h';
      });
    setTimeout(() => {
      if (this.chart) {
        this.chart.update();
      }
      const test = this.barChartData.datasets[0].data.some(d => {
        return d != 0;
      });
      if (test) {
        this.isChartEmpty = false;
      }
    }, 500);
  }
  getEmployees() {
    this.employeesService.getEmployees().subscribe(res => {
      this.employees = res.items.sort(function(a, b) {
        return b.id - a.id;
      });
    });
    this.employeesService.getAdminEmployees().subscribe(res => {
      this.adminsToDisplay = res;
    });
  }
  setLimitAndLeft() {
    this.vacationService
      .getEmployeeVacations(this.user.employeeId)
      .subscribe(res => {
        this.vacationLimit = res.leaveDaysByContract;
        this.vacationLeft = res.leaveDaysLeft;
        this.value2 = (this.vacationLeft / this.vacationLimit) * 100;
      });
  }
  setProjects() {
    this.projectsService.getProjects().subscribe(res => {
      this.projects = res;
      if (this.projects.length > 0) {
        this.isProjectListEmpty = false;
      }
    });
  }
}
