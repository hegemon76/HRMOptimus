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

@Component({
  selector: 'app-employee-add-single-form',
  templateUrl: './employee-add-single-form.component.html',
  styleUrls: ['./employee-add-single-form.component.scss']
})
export class EmployeeAddSingleFormComponent implements OnInit {
  @Output() rm = new EventEmitter();
  form: FormGroup;

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

  @ViewChild('roleInput') roleInput: ElementRef<HTMLInputElement>;

  constructor(private formBuilder: FormBuilder) {
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
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      gender: ['', Validators.required],
      birthDate: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
      street: ['', Validators.required],
      buildingNumber: ['', Validators.required],
      houseNumber: [''],
      zipCode: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      contractName: ['', Validators.required],
      contractType: ['', Validators.required],
      leaveDays: ['', Validators.required],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(
            '^(?=[^A-Z]*[A-Z])(?=[^a-z]*[a-z])(?=\\D*\\d)[A-Za-z\\d!$%@#£€*?&]{8,}$'
          )
        ]
      ],
      roles: [this.roles]
    });
  }

  remove() {
    this.rm.emit();
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

  checkValues() {
    console.log(this.form.getRawValue());
  }
}
