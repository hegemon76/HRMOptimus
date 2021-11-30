import { Component, OnInit } from '@angular/core';
import { WorktimeService } from '../worktime.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { AccountService } from '../../account/account.service';
import { TestBed } from '@angular/core/testing';

interface Day {
  id: string;
  dayName: string;
  isWeekend: boolean;
  workStart: Date;
  workEnd: Date;
}

@Component({
  selector: 'app-workday',
  templateUrl: './workday.component.html',
  styleUrls: ['./workday.component.scss']
})

export class WorkdayComponent implements OnInit {

  workDays: [];
  projects: any[];
  day = {} as Day;
  id;
  user;
  dayName = "dupa"
  projectId = 9
  emploeeId = 1
  workStart = "2021-11-29 12:57:08";
  workEnd = "2021-11-29 12:57:08";

  constructor(private workdayService: WorktimeService, private route: ActivatedRoute, private router: Router, private accountService: AccountService) { }

  ngOnInit(): void {
    this.day.workEnd = history.state.workEnd;
    this.day.workStart = history.state.workStart;
    this.id = this.route.snapshot.paramMap.get('id');
    this.user = this.accountService.getUser();

    this.workdayService.getWorkday(this.id).subscribe(res => {
      this.workDays = res;
    })

    this.workdayService.getProjects().subscribe(res => {
      this.projects = res;
    })

    console.log(this.workStart, this.workEnd, this.emploeeId, this.projectId, this.dayName);
  }

  deleteWorkDayEntry() {
    // this.workdayService.deleteWorkDayEntries(/*this.id*/3).subscribe(() => {
    //   this.router.navigate([`day/${this.id}`]);
    // });
    this.router
      .navigateByUrl('', { skipLocationChange: true })
      .then(() => {
        this.router.navigate([`worktime/day/${this.id}`]);
      });
  }

  addWorkDayEntry() {
    this.workdayService.addWorkDayRecord().subscribe(() => {
      console.log("cipa");
    });
  }
}
