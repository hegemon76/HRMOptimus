import {
  Component,
  OnInit,
  ElementRef,
  ViewChild,
  Inject
} from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ValidatorFn
} from '@angular/forms';
import { Observable } from 'rxjs';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips';
import { map, startWith } from 'rxjs/operators';
import { EmployeeVm } from '../../../../shared/vm/employee.vm';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeesService } from '../../../_services/employees.service';
import { AccountService } from '../../../_services/account.service';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';
import { AbstractControl } from '@angular/forms';

export interface DialogData {}

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {
  formData: FormGroup;
  formContract: FormGroup;
  formEmail: FormGroup;
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
  editedEmployeeEqualsUser = false;
  user;
  emails: string[] = [];
  isEmailTaken: boolean;
  emailPlaceholder: string;

  @ViewChild('roleInput') roleInput: ElementRef<HTMLInputElement>;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private employeesService: EmployeesService,
    private accountService: AccountService,
    public dialog: MatDialog
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
      res.items.map(r => {
        this.emails.push(r.email);
      });
    });
    this.user = this.accountService.getUser();

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
        if (this.employeeId == this.user.employeeId) {
          this.editedEmployeeEqualsUser = true;
        }

        this.formData = this.formBuilder.group({
          firstName: [this.employee.firstName, Validators.required],
          lastName: [this.employee.lastName, Validators.required],
          gender: [this.employee.gender, Validators.required],
          birthDate: [this.employee.birthDate, Validators.required],
          phoneNumber: [this.employee.phoneNumber, Validators.required],
          street: [this.employee.address.street, Validators.required],
          buildingNumber: [
            this.employee.address.buildingNumber,
            Validators.required
          ],
          houseNumber: [
            this.employee.address.houseNumber != 'string'
              ? this.employee.address.houseNumber
              : ''
          ],
          zipCode: [this.employee.address.zipCode, Validators.required],
          city: [this.employee.address.city, Validators.required],
          country: [this.employee.address.country, Validators.required]
        });

        this.formContract = this.formBuilder.group({
          contractId: this.employee.contract.id,
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

        this.formEmail = this.formBuilder.group({
          email: [this.employee.email, [Validators.required, Validators.email]],
          emailNew: [
            '',
            [Validators.required, Validators.email, this.emailTaken()]
          ],
          emailRepeat: [
            '',
            [
              Validators.required,
              Validators.email,
              this.emailTaken(),
              this.emailMatch()
            ]
          ]
        });

        this.formPassword = this.formBuilder.group({
          password: ['', Validators.required],
          passwordNew: [
            '',
            [
              Validators.required,
              Validators.minLength(8),
              Validators.pattern(
                '^(?=[^A-Z]*[A-Z])(?=[^a-z]*[a-z])(?=\\D*\\d)[A-Za-z\\d!$%@#£€*?&]{8,}$'
              )
            ]
          ],
          passwordRepeat: [
            '',
            [
              Validators.required,
              Validators.minLength(8),
              Validators.pattern(
                '^(?=[^A-Z]*[A-Z])(?=[^a-z]*[a-z])(?=\\D*\\d)[A-Za-z\\d!$%@#£€*?&]{8,}$'
              )
            ]
          ]
        });

        this.formRoles = this.formBuilder.group({
          roles: [this.roles]
        });
      });
    setTimeout(() => {
      this.filteredOptions = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => (typeof value === 'string' ? value : value.name)),
        map(name => (name ? this.optionsFilter(name) : this.options.slice()))
      );
      this.isFormLoaded = true;
      this.formEmail.valueChanges.subscribe(() => {
        this.emailPlaceholder = this.formEmail.controls.emailNew.value;
      });
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

  remove2(role: string): void {
    const index = this.roles.indexOf(role);

    if (index >= 0) {
      this.roles.splice(index, 1);
    }
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

  editEmployee() {
    this.employeesService
      .editEmployee(this.formData.getRawValue(), this.employeeId)
      .subscribe();
  }
  editEmployeeContract() {
    if (
      this.formContract.getRawValue().leaveDays >=
      this.employee.contract.leaveDays - this.employee.leaveDaysLeft
    ) {
      this.employeesService
        .editEmployeeContract(
          this.formContract.getRawValue(),
          this.employee.contract.id
        )
        .subscribe();
    } else {
      console.log(
        'Wartość urlopów nie może być mniejsza niż ilość dni zaakceptowanych urlopów'
      );
    }
  }
  setRoles() {
    this.employeesService.setRoles(this.roles, this.employee.email).subscribe();
  }
  openDialog() {
    const dialogRef = this.dialog.open(FormValidDialog);

    dialogRef.afterClosed().subscribe(result => {
      this.editEmployee();
      this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
        this.router.navigate(['/employees/edit/', this.employeeId]);
      });
    });
  }
  emailTaken(): ValidatorFn {
    return (control: AbstractControl) => {
      return this.emails.includes(control.value) ? { emailTaken: true } : null;
    };
  }
  emailMatch(): ValidatorFn {
    return (control: AbstractControl) => {
      return this.emailPlaceholder != control.value
        ? { emailMatch: true }
        : null;
    };
  }

  updateEmail() {
    if (
      this.formEmail.controls.emailNew.value ===
      this.formEmail.controls.emailRepeat.value
    ) {
      this.accountService
        .updateEmail(this.user.userId, this.formEmail.controls.emailNew.value)
        .subscribe(res => {
          console.log(res);
        });
    }
  }
}

@Component({
  selector: 'form-valid-dialog',
  templateUrl: 'form-valid-dialog.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class FormValidDialog {
  constructor(
    public dialogRef: MatDialogRef<FormValidDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
}
