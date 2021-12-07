import { Component, OnInit } from '@angular/core';

interface Day {
  id: string;
  dayName: string;
  isWeekend: boolean;
}

@Component({
  selector: 'app-workday',
  templateUrl: './workday.component.html',
  styleUrls: ['./workday.component.scss']
})
export class WorkdayComponent implements OnInit {
  day = {} as Day;
  constructor() {}
  ngOnInit(): void {
    this.day.id = history.state.id;
    this.day.dayName = history.state.name;
    this.day.isWeekend = history.state.weekend;
  }
}
