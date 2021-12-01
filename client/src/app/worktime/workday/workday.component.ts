import { Component, OnInit, ViewChild, ViewContainerRef, ComponentFactoryResolver, ComponentRef } from '@angular/core';
import { WorktimeService } from '../worktime.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { AccountService } from '../../account/account.service';
import { EntryComponent } from '../entry/entry.component'

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
})

export class WorkdayComponent implements OnInit {

  @ViewChild('parent', { read: ViewContainerRef }) target: ViewContainerRef;
  private componentRef: ComponentRef<any>;

  workDays: [];
  projects: any[];
  day = {} as Day;
  id;
  user;

  entriesCount;

  dayName = "test"
  projectId = 9
  emploeeId = 1
  workStart = "2021-11-29 12:57:08";
  workEnd = "2021-11-29 12:57:08";

  constructor(
    private workdayService: WorktimeService,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private componentFactoryResolver: ComponentFactoryResolver
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.user = this.accountService.getUser();

    this.workdayService.getWorkday(this.id).subscribe(res => {
      this.workDays = res;

      console.log(this.workDays);

      this.entriesCount = this.workDays.length
    })

    this.workdayService.getProjects().subscribe(res => {
      this.projects = res;
    })
  }

  addElement() {
    let childComponent = this.componentFactoryResolver.resolveComponentFactory(EntryComponent);
    this.componentRef = this.target.createComponent(childComponent);
  }

  deleteWorkDayEntry(event) {
    var target = event.target || event.srcElement || event.currentTarget;
    var idAttr = target.attributes.id;
    var value = idAttr.nodeValue;

    this.workdayService.deleteWorkDayEntries(value).subscribe(() => {
      this.router
        .navigateByUrl('', { skipLocationChange: true })
        .then(() => {
          this.router.navigate([`worktime/day/${this.id}`]);
        });
    });
  }

  saveChanges() {

    //warunek który sprawdzi czy dany wpis istnieje jeśli tak wykonane zostanie zapytanie PUT

    this.workdayService.addWorkDayRecord(this.dayName, this.workStart, this.workEnd, this.projectId, this.emploeeId).subscribe(() => {
      this.router
        .navigateByUrl('', { skipLocationChange: true })
        .then(() => {
          this.router.navigate([`worktime/day/${this.id}`]);
        });
    });
  }
}
