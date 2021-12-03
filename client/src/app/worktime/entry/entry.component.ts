import { Component, OnInit } from '@angular/core';
import { WorktimeService } from '../worktime.service';

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.scss']
})
export class EntryComponent implements OnInit {

  projects: any[];
  workDays: [];

  constructor(
    private workdayService: WorktimeService
  ) { }

  ngOnInit(): void {
    this.workdayService.getProjects().subscribe(res => {
      this.projects = res;
    })

  }
}
