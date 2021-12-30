import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartConfiguration, ChartEvent, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { WorktimeService } from '../../_services/worktime.service';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  @ViewChild(BaseChartDirective) chart?: BaseChartDirective;

  barChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: [],
        label: 'Przepracowane godziny w obecnym miesiącu',
        backgroundColor: '#ff4081',
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
      x: {},
      y: {
        max: 12,
        beginAtZero: true
      }
    }
  };

  barChartType: ChartType = 'bar';

  constructor(private worktimeService: WorktimeService) {}

  ngOnInit(): void {
    const today = new Date();
    const daysCount = this.daysInMonth(today.getFullYear(), today.getMonth());
    this.setLabels(daysCount);
    this.setData();
  }

  daysInMonth(month, year) {
    return new Date(year, month, 0).getDate();
  }

  setLabels(daysCount) {
    for (let i = 1; i < daysCount + 1; i++) {
      this.barChartData.labels = this.barChartData.labels.concat(i);
    }
  }
  setData() {
    const today = new Date();
    const monthStart = formatDate(
      new Date(today.getFullYear(), today.getMonth(), 1),
      'YYYY-MM-dd',
      'en-US'
    );
    const monthEnd = formatDate(
      new Date(today.getFullYear(), today.getMonth() + 1, 0),
      'YYYY-MM-dd',
      'en-US'
    );
    this.worktimeService
      .getMonthRecords(monthStart, monthEnd)
      .subscribe(res => {
        console.log(res);
        res.map(h => {
          this.barChartData.datasets[0].data = this.barChartData.datasets[0].data.concat(
            h.workedTime
          );
        });
      });
  }
}
