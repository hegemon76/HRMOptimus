import {
  Component,
  OnInit,
  ViewChild,
  ViewContainerRef,
  ComponentFactoryResolver,
  ComponentRef
} from '@angular/core';
import { WorktimeService } from '../worktime.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { AccountService } from '../../../_services/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  private componentRef: ComponentRef<any>;

  workDays: [];
  projects: any[];
  month: [];
  day = {} as Day;
  id;
  user;
  duration = 0;
  durationTime;
  form: FormGroup;
  saveChanges = false;
  entriesCount;

  constructor(
    private workdayService: WorktimeService,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private componentFactoryResolver: ComponentFactoryResolver,
    private formBuilder: FormBuilder,
    private datePipe: DatePipe
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      dayName: [''],
      workStart: [''],
      workEnd: [''],
      projectName: ['']
    });

    this.id = this.route.snapshot.paramMap.get('id');

    this.user = this.accountService.getUser();

    this.workdayService.getWorkday(this.id).subscribe(res => {
      res.map(r => {
        r['selected'] = r.projectName;
      });

      res.map(a => {
        this.duration +=
          parseInt(a.duration.split(':')[0]) * 3600 +
          parseInt(a.duration.split(':')[1]) * 60 +
          parseInt(a.duration.split(':')[2]);
      });

      this.workDays = res;

      this.durationTime = new Date(this.duration * 1000);

      this.entriesCount = this.workDays.length;
    });

    this.workdayService.getProjects().subscribe(res => {
      this.projects = res;
    });

    this.workdayService.getMonthEntry(this.id, this.id).subscribe(res => {
      this.month = res;




      this.datePipe.transform("test", 'YYYY-MM-DD')




      const index = this.month.findIndex(day => day === this.id)

      console.log(index);
    })
  }

  checkForChanges() {
    this.saveChanges = true;
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
