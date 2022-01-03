import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips';
import { map, startWith } from 'rxjs/operators';
import { EmployeeVm } from '../../../../shared/vm/employee.vm';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeesService } from '../../../_services/employees.service';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {
  formData: FormGroup;
  formPassword: FormGroup;
  formRoles: FormGroup;
  allEmployees: EmployeeVm[];
  myControl = new FormControl();
  searchedEmployee: string;
  options: any[] = [];
  filteredOptions: Observable<EmployeeVm[]>;
  employee: EmployeeVm;
  employeeId;
  separatorKeysCodes: number[] = [ENTER, COMMA];
  roleCtrl = new FormControl();
  filteredRoles: Observable<string[]>;
  roles: string[] = [];
  allRoles: string[] = [
    'Administrator',
    'User',
    'ProjectManager',
    'HumanResources'
  ];
  isEmployeeLoaded = false;
  areEmployeesLoaded = false;
  isFormLoaded = false;
  formToDisplay = null;

  @ViewChild('roleInput') roleInput: ElementRef<HTMLInputElement>;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private employeesService: EmployeesService
  ) {
    this.filteredRoles = this.roleCtrl.valueChanges.pipe(
      startWith(null),
      map((role: string | null) =>
        role
          ? this._filter(role)
          : this.allRoles.filter(role => {
              return this.roles.indexOf(role) < 0 ? role : null;
            })
      )
    );
    this.router.routeReuseStrategy.shouldReuseRoute = function() {
      return false;
    };
  }

  ngOnInit(): void {
    this.employeesService.getEmployees().subscribe(res => {
      this.allEmployees = res.items;
      this.fillOptions(this.allEmployees);
      this.areEmployeesLoaded = true;
    });
    this.employeesService
      .getEmployee(this.route.snapshot.paramMap.get('id'))
      .subscribe(res => {
        this.employee = res;
        this.employeeId = this.route.snapshot.paramMap.get('id');
        this.roles = this.employee.roles;
        this.isEmployeeLoaded = true;
        console.log(this.employee);

        this.formData = this.formBuilder.group({
          firstName: [this.employee.firstName, Validators.required],
          lastName: [this.employee.lastName, Validators.required],
          gender: [this.employee.gender, Validators.required],
          birthDate: [this.employee.birthDate, Validators.required],
          email: [this.employee.email, Validators.required],
          phoneNumber: [this.employee.phoneNumber, Validators.required],
          street: [this.employee.address.street, Validators.required],
          buildingNumber: [
            this.employee.address.buildingNumber,
            Validators.required
          ],
          houseNumber: [
            this.employee.address.houseNumber != 'string'
              ? this.employee.address.houseNumber
              : '',
            Validators.required
          ],
          zipCode: [this.employee.address.zipCode, Validators.required],
          city: [this.employee.address.city, Validators.required],
          country: [this.employee.address.country, Validators.required],
          contractName: [
            this.employee.contract.contractName,
            Validators.required
          ],
          contractType: [
            this.employee.contract.contractType,
            Validators.required
          ],
          leaveDays: [this.employee.contract.leaveDays, Validators.required]
        });

        this.formPassword = this.formBuilder.group({
          password: ['', Validators.required],
          passwordNew: ['', Validators.required],
          passwordRepeat: ['', Validators.required]
        });

        this.formRoles = this.formBuilder.group({
          roles: [this.roles]
        });

        console.log(this.roles);
      });
    setTimeout(() => {
      this.filteredOptions = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => (typeof value === 'string' ? value : value.name)),
        map(name => (name ? this.optionsFilter(name) : this.options.slice()))
      );
      this.isFormLoaded = true;
    }, 1000);
  }
  changeUser() {
    this.router.navigate(['/employees/edit/', this.myControl.value.id]);
  }
  displayFn(option: EmployeeVm): string {
    return option ? option.firstName + ' ' + option.lastName : '';
  }
  fillOptions(res) {
    res.map(e => {
      this.options.push({
        firstName: e.firstName,
        lastName: e.lastName,
        id: e.id
      });
    });
  }
  optionsFilter(name: string): EmployeeVm[] {
    const filterValue = name.toLowerCase();
    return this.options.filter(option =>
      option.firstName.toLowerCase().includes(filterValue)
    );
  }
  setFormToDisplay(option) {
    this.formToDisplay = option;
  }

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.roles.push(value);
    }

    event.chipInput!.clear();

    this.roleCtrl.setValue(null);
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.roles.push(event.option.viewValue);
    this.roleInput.nativeElement.value = '';
    this.roleCtrl.setValue(null);
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    const filteredArray = this.allRoles.filter(role => {
      return this.roles.indexOf(role) < 0 ? role : null;
    });
    return filteredArray.filter(role =>
      role.toLowerCase().includes(filterValue)
    );
  }
}
