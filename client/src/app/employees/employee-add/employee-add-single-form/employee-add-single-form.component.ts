import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-employee-add-single-form',
  templateUrl: './employee-add-single-form.component.html',
  styleUrls: ['./employee-add-single-form.component.scss']
})
export class EmployeeAddSingleFormComponent implements OnInit {
  @Output() rm = new EventEmitter();
  form: FormGroup;
  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      gender: ['', Validators.required],
      birthDate: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      street: ['', Validators.required],
      buildingNumber: ['', Validators.required],
      houseNumber: ['', Validators.required],
      zipCode: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      contractName: ['', Validators.required],
      contractType: ['', Validators.required],
      leaveDays: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  remove() {
    this.rm.emit();
  }
}
