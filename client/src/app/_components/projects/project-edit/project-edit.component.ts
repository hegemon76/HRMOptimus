import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl
} from '@angular/forms';
import { Observable } from 'rxjs';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { ProjectsService } from '../../../_services/projects.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-project-edit',
  templateUrl: './project-edit.component.html',
  styleUrls: ['./project-edit.component.scss']
})
export class ProjectEditComponent implements OnInit {
  form: FormGroup;
  color: string = '#000000';
  project: any;
  employees: string[] = [];
  filteredEmployees: Observable<string[]>;
  allEmployees: string[] = [];
  employeeCtrl = new FormControl();
  isFormLoaded = false;
  @ViewChild('employeeInput') employeeInput: ElementRef<HTMLInputElement>;
  separatorKeysCodes: number[] = [ENTER, COMMA];

  constructor(
    private formBuilder: FormBuilder,
    private projectsService: ProjectsService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.projectsService
      .getProjectDetails(this.route.snapshot.paramMap.get('id'))
      .subscribe(res => {
        this.project = res;
        this.form = this.formBuilder.group({
          colorLabel: [this.project.colorLabel, Validators.required],
          name: [this.project.name, Validators.required],
          description: [this.project.description, Validators.required],
          dateFrom: [this.project.dateFrom, Validators.required],
          dateTo: [this.project.dateTo, Validators.required],
          hoursBudget: [this.project.hoursBudget, Validators.required]
          // projectMembers: [this.employees]
        });
        this.isFormLoaded = true;
      });
  }

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.employees.push(value);
    }

    event.chipInput!.clear();

    this.employeeCtrl.setValue(null);
  }

  remove2(employee: string): void {
    const index = this.employees.indexOf(employee);

    if (index >= 0) {
      this.employees.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.employees.push(event.option.viewValue);
    this.employeeInput.nativeElement.value = '';
    this.employeeCtrl.setValue(null);
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    const filteredArray = this.allEmployees.filter(employee => {
      return this.employees.indexOf(employee) < 0 ? employee : null;
    });
    return filteredArray.filter(employee =>
      employee.toLowerCase().includes(filterValue)
    );
  }

  updateProject() {
    this.projectsService
      .updateProject(
        this.form.getRawValue(),
        this.route.snapshot.paramMap.get('id')
      )
      .subscribe(res => {
        this.router.navigate(['/projects']);
      });
  }
}
