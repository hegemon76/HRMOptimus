import {
  Component,
  OnInit,
  ViewChild,
  ViewContainerRef,
  ComponentFactoryResolver,
  ComponentRef,
  Input
} from '@angular/core';
import { WorktimeService } from '../../../_services/worktime.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { AccountService } from '../../../_services/account.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DatePipe } from '@angular/common';

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
  styleUrls: ['./workday.component.scss'],
  providers: [DatePipe]
})

export class WorkdayComponent implements OnInit {
  @ViewChild('parent', { read: ViewContainerRef }) target: ViewContainerRef;

  workDays: [];
  projects: any[];
  month: [];
  day = {} as Day;
  id;
  user;
  duration = 0;
  durationTime;
  form: FormGroup;
  entriesCount;
  valueDuration;
  valueTiming;

  @Input() item: string;

  constructor(
    private workdayService: WorktimeService,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      dayName: [''],
      workStart: [''],
      workEnd: [''],
      projectName: ['']
    });

    this.valueDuration = localStorage.getItem('durationOfDay');

    this.valueTiming = localStorage.getItem('timingOfDay');

    this.id = this.route.snapshot.paramMap.get('id');

    this.user = this.accountService.getUser();

    this.workdayService.getWorkday(this.id).subscribe(res => {
      res.map(r => {
        r['selected'] = r.projectName;
      });

      this.workDays = res;

      this.entriesCount = this.workDays.length;
    });

    this.workdayService.getProjects().subscribe(res => {
      this.projects = res;
    });
  }

  deleteWorkDayEntry(id) {
    this.workdayService.deleteWorkDayEntries(id).subscribe(() => {
      this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
        this.router.navigate([`worktime/day/${this.id}`]);
      });
    });
  }

  addEntry() {
    this.workdayService
      .addWorkDayRecord(this.form.getRawValue(), this.user.employeeId, this.id)
      .subscribe(() => {
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate([`worktime/day/${this.id}`]);
        });
      });
  }
}
