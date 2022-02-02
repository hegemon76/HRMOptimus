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
import { EmployeesService } from '../../../_services/employees.service';
import { map, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-project-edit',
  templateUrl: './project-edit.component.html',
  styleUrls: ['./project-edit.component.scss']
})
export class ProjectEditComponent implements OnInit {
  form: FormGroup;
  color: string = '#000000';
  project: any;
  filteredEmployees: Observable<string[]>;

  employees: any[] = [];
  allEmployees: any[] = [];
  employeesIds: any[] = [];
  newEmployeesIds: any[] = [];

  addedEmployeesIds = [];
  removedEmployeesIds = [];

  employeeCtrl = new FormControl();
  isFormLoaded = false;
  @ViewChild('employeeInput') employeeInput: ElementRef<HTMLInputElement>;
  separatorKeysCodes: number[] = [ENTER, COMMA];

  constructor(
    private formBuilder: FormBuilder,
    private projectsService: ProjectsService,
    private router: Router,
    private route: ActivatedRoute,
    private employeesService: EmployeesService
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = function() {
      return false;
    };
  }

  ngOnInit(): void {
    this.employeesService.getEmployees().subscribe(res => {
      this.allEmployees = res.items;
    });
    this.projectsService
      .getProjectDetails(this.route.snapshot.paramMap.get('id'))
      .subscribe(res => {
        this.project = res;

        this.project.projectMembers.map(m => {
          this.employees = [...this.employees, m.fullName];
          this.employeesIds = [...this.employeesIds, m.id];
          this.newEmployeesIds = [...this.newEmployeesIds, m.id];
        });

        this.form = this.formBuilder.group({
          colorLabel: [this.project.colorLabel, Validators.required],
          name: [this.project.name, Validators.required],
          description: [this.project.description, Validators.required],
          dateFrom: [this.project.dateFrom, Validators.required],
          dateTo: [this.project.dateTo, Validators.required],
          hoursBudget: [this.project.hoursBudget, Validators.required],
          employees: [this.employeesIds]
        });
        this.isFormLoaded = true;
      });

    setTimeout(() => {
      this.filteredEmployees = this.employeeCtrl.valueChanges.pipe(
        startWith(null),
        map(employee =>
          employee
            ? this._filter(employee)
            : this.allEmployees.filter(employee => {
                return this.employees.indexOf(employee.fullName) < 0
                  ? employee
                  : null;
              })
        )
      );
    }, 1000);
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
      this.newEmployeesIds.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.employees.push(event.option.viewValue);
    this.addEmployeesToProject(event.option.viewValue);
    this.employeeInput.nativeElement.value = '';
    this.employeeCtrl.setValue(null);
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    const filteredArray = this.allEmployees.filter(employee => {
      return this.employees.indexOf(employee.fullName) < 0 ? employee : null;
    });
    const test = filteredArray.filter(employee =>
      employee.fullName.toLowerCase().includes(filterValue)
    );
    return test;
  }

  updateProject() {
    this.projectsService
      .updateProject(
        this.form.getRawValue(),
        this.route.snapshot.paramMap.get('id')
      )
      .subscribe(res => {
        const idsToAdd = this.newEmployeesIds.filter(e => {
          return this.employeesIds.indexOf(e) < 0;
        });

        const idsToRemove = this.employeesIds.filter(e => {
          return this.newEmployeesIds.indexOf(e) < 0;
        });

        idsToAdd.map(e => {
          this.projectsService
            .addEmployeesToProject(this.route.snapshot.paramMap.get('id'), e)
            .subscribe();
        });
        idsToRemove.map(e => {
          this.projectsService
            .removeEmployeeFromProject(
              this.route.snapshot.paramMap.get('id'),
              e
            )
            .subscribe();
        });
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate([
            '/projects/edit',
            this.route.snapshot.paramMap.get('id')
          ]);
        });
      });
  }

  addEmployeesToProject(val) {
    this.allEmployees.find(empl => {
      if (empl.fullName == val) {
        this.newEmployeesIds.push(empl.id);
      }
    });
    this.form.controls.employees.setValue(this.employeesIds);
  }

  test() {
    console.log(this.employeesIds);
    console.log(this.newEmployeesIds);
  }
}
