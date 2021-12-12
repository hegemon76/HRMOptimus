import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-project-add-single-form',
  templateUrl: './project-add-single-form.component.html',
  styleUrls: ['./project-add-single-form.component.scss']
})
export class ProjectAddSingleFormComponent implements OnInit {
  @Output() rm = new EventEmitter();
  form: FormGroup;
  color: string = '#000000';
  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      colorLabel: ['', Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required],
      dateFrom: ['', Validators.required],
      dateTo: ['', Validators.required],
      hoursBudget: ['', Validators.required]
    });
  }

  remove() {
    this.rm.emit();
  }
}
