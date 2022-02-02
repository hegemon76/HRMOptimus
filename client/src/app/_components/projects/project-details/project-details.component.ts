import { Component, OnInit } from '@angular/core';
import { ProjectsService } from '../../../_services/projects.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { map, startWith } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.scss']
})
export class ProjectDetailsComponent implements OnInit {
  isProjectLoaded: boolean = false;
  project: any;
  allProjects: any[];
  areProjectsLoaded = false;

  myControl = new FormControl();
  searchedProject: string;
  options: any[] = [];
  filteredOptions: Observable<any[]>;

  constructor(
    private projectsService: ProjectsService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = function() {
      return false;
    };
  }

  ngOnInit(): void {
    this.getProjectDetails();

    this.projectsService.getProjects().subscribe(res => {
      this.allProjects = res;
      this.fillOptions(this.allProjects);
      this.areProjectsLoaded = true;
    });

    setTimeout(() => {
      this.filteredOptions = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => (typeof value === 'string' ? value : value.name)),
        map(name => (name ? this.optionsFilter(name) : this.options.slice()))
      );
    }, 1000);
  }

  getProjectDetails() {
    this.projectsService
      .getProjectDetails(this.route.snapshot.paramMap.get('id'))
      .subscribe(res => {
        this.project = res;
        console.log(this.project);

        this.isProjectLoaded = true;
      });
  }

  fillOptions(res) {
    res.map(e => {
      this.options.push({
        name: e.name,
        id: e.id
      });
    });
  }

  displayFn(option: any): string {
    return option ? option.name : '';
  }

  optionsFilter(name: string): any[] {
    const filterValue = name.toLowerCase();

    return this.options.filter(option =>
      option.name.toLowerCase().includes(filterValue)
    );
  }

  changeProject() {
    this.router.navigate(['/projects/details', this.myControl.value.id]);
  }
}
