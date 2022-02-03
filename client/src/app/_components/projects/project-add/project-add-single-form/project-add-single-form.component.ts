import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  ElementRef,
  ViewChild
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips';
import { map, startWith } from 'rxjs/operators';
import { EmployeesService } from '../../../../_services/employees.service';

@Component({
  selector: 'app-project-add-single-form',
  templateUrl: './project-add-single-form.component.html',
  styleUrls: ['./project-add-single-form.component.scss']
})
export class ProjectAddSingleFormComponent implements OnInit {
  @Output() rm = new EventEmitter();
  form: FormGroup;
  color: string = '#000000';

  separatorKeysCodes: number[] = [ENTER, COMMA];
  employeeCtrl = new FormControl();
  filteredEmployees: Observable<string[]>;
  employees: any[] = [];
  allEmployees: any[] = [];
  employeesIds: any[] = [];

  @ViewChild('employeeInput') employeeInput: ElementRef<HTMLInputElement>;

  constructor(
    private formBuilder: FormBuilder,
    private employeesService: EmployeesService
  ) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      colorLabel: [this.color, Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required],
      dateFrom: ['', Validators.required],
      dateTo: ['', Validators.required],
      hoursBudget: ['', Validators.required],
      employees: [this.employeesIds]
    });

    this.employeesService.getEmployees().subscribe(res => {
      this.allEmployees = res.items;
    });

    setTimeout(() => {
      this.filteredEmployees = this.employeeCtrl.valueChanges.pipe(
        startWith(null),
        map(employee =>
          employee
            ? this._filter(employee)
            : this.allEmployees.filter(employee => {
                return this.employees.indexOf(employee) < 0 ? employee : null;
              })
        )
      );
    }, 1000);
  }

  remove() {
    this.rm.emit();
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    const filteredArray = this.allEmployees.filter(employee => {
      return this.employees.indexOf(employee) < 0 ? employee : null;
    });
    const test = filteredArray.filter(employee =>
      employee.fullName.toLowerCase().includes(filterValue)
    );
    return test;
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
    this.addEmployeesToProject(event.option.viewValue);
    this.employeeInput.nativeElement.value = '';
    this.employeeCtrl.setValue(null);
  }

  addEmployeesToProject(val) {
    this.allEmployees.find(empl => {
      empl.fullName == val
        ? (this.employeesIds = [...this.employeesIds, empl.id])
        : false;
    });
    this.form.controls.employees.setValue(this.employeesIds);
  }
}
