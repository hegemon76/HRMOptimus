import {
  Component,
  OnInit,
  ViewChild,
  ViewContainerRef,
  Input
} from '@angular/core';
import { WorktimeService } from '../../../_services/worktime.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { AccountService } from '../../../_services/account.service';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { EmployeesService } from '../../../_services/employees.service';
import { ProjectsService } from '../../../_services/projects.service';

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
  types = [
    { name: 'Praca zdalna', value: true },
    { name: 'Praca w biurze', value: false }
  ];
  day = {} as Day;
  id;
  user;
  duration = 0;
  durationTime;
  form: FormGroup;
  entriesCount;
  valueDuration;
  valueTiming;
  fullName = localStorage.getItem('fullName');
  formTemplate: FormGroup;
  eId: number = this.route.snapshot.paramMap.get('employeeId')
    ? parseInt(this.route.snapshot.paramMap.get('employeeId'))
    : JSON.parse(localStorage.getItem('user')).employeeId;

  @Input() item: string;

  constructor(
    private workdayService: WorktimeService,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private formBuilder: FormBuilder,
    private datePipe: DatePipe,
    private employeesService: EmployeesService,
    private projectsService: ProjectsService
  ) {
    this.formTemplate = this.formBuilder.group({
      records: this.formBuilder.array([])
    });
  }

  get records(): FormArray {
    return this.formTemplate.controls.records as FormArray;
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      dayName: [''],
      workStart: [''],
      workEnd: [''],
      projectName: [''],
      typeName: ['']
    });

    this.valueDuration = localStorage.getItem('durationOfDay');

    this.valueTiming = localStorage.getItem('timingOfDay');

    this.id = this.route.snapshot.paramMap.get('id');

    if (this.route.snapshot.paramMap.get('employeeId')) {
      this.employeesService
        .getEmployee(this.route.snapshot.paramMap.get('employeeId'))
        .subscribe(res => {
          this.user = res;
        });
    } else {
      this.user = this.accountService.getUser();
    }

    this.workdayService.getWorkday(this.id, this.eId).subscribe(res => {
      res.map(r => {
        r['selected'] = r.projectName;

        if (r.isRemoteWork === true) {
          r['type'] = 'Praca zdalna';
        } else {
          r['type'] = 'Praca w biurze';
        }
      });

      this.workDays = res;

      res.map(r => {
        this.records.push(
          this.formBuilder.group({
            id: r.id,
            day: r.workStart.split('T')[0],
            workStart: [this.datePipe.transform(r.workStart, 'HH:mm')],
            workEnd: [this.datePipe.transform(r.workStop, 'HH:mm')],
            type: r.type,
            projectName: r.projectName,
            projectId: r.projectId,
            name: r.name,
            employeeId: this.user.nameid
          })
        );
      });

      this.entriesCount = this.workDays.length;
    });

    this.projectsService.getEmployeeProjects().subscribe(res => {
      this.projects = res;
    });
  }

  deleteWorkDayEntry(i) {
    const id = this.formTemplate.getRawValue().records[i].id;
    this.workdayService.deleteWorkDayEntries(id).subscribe(() => {
      this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
        this.router.navigate([`worktime/day/${this.id}`]);
      });
    });
  }

  deleteHistory() {
    localStorage.removeItem('durationOfDay');
    localStorage.removeItem('timingOfDay');
  }

  addEntry() {
    let values = this.form.getRawValue();
    let isRemoteWork;

    if (values.typeName === 'Praca zdalna') {
      isRemoteWork = true;
    } else {
      isRemoteWork = false;
    }

    this.workdayService
      .addWorkDayRecord(
        this.form.getRawValue(),
        this.user.nameid,
        this.id,
        isRemoteWork
      )
      .subscribe(() => {
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate([`worktime/day/${this.id}`]);
        });
      });
  }

  updateWorkRecord(i) {
    const recordToEdit = this.formTemplate.getRawValue().records[i];
    recordToEdit.type === 'Praca zdalna'
      ? (recordToEdit['isRemoteWork'] = true)
      : (recordToEdit['isRemoteWork'] = false);
    recordToEdit.workStart = recordToEdit.day + 'T' + recordToEdit.workStart;
    recordToEdit.workEnd = recordToEdit.day + 'T' + recordToEdit.workEnd;

    console.log(recordToEdit.type === 'Praca zdalna');

    console.log(recordToEdit);

    this.workdayService.updateWorkRecord(recordToEdit).subscribe();
  }
}
