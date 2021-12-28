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
  selector: 'app-project-add-single-form',
  templateUrl: './project-add-single-form.component.html',
  styleUrls: ['./project-add-single-form.component.scss']
})
export class ProjectAddSingleFormComponent implements OnInit {
  @Output() rm = new EventEmitter();
  form: FormGroup;
  color: string = '#000000';

  // separatorKeysCodes: number[] = [ENTER, COMMA];
  // roleCtrl = new FormControl();
  // filteredRoles: Observable<string[]>;
  // roles: string[] = [];
  // allRoles: string[] = [
  //   'Administrator',
  //   'User',
  //   'ProjectManager',
  //   'HumanResources'
  // ];

  // @ViewChild('roleInput') roleInput: ElementRef<HTMLInputElement>;

  constructor(private formBuilder: FormBuilder) {
    // this.filteredRoles = this.roleCtrl.valueChanges.pipe(
    //   startWith(null),
    //   map((role: string | null) =>
    //     role ? this._filter(role) : this.allRoles.slice()
    //   )
    // );
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      colorLabel: [this.color, Validators.required],
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

  // add(event: MatChipInputEvent): void {
  //   const value = (event.value || '').trim();

  //   // Add our role
  //   if (value) {
  //     this.roles.push(value);
  //   }

  //   // Clear the input value
  //   event.chipInput!.clear();

  //   this.roleCtrl.setValue(null);
  // }

  // remove2(role: string): void {
  //   const index = this.roles.indexOf(role);

  //   if (index >= 0) {
  //     this.roles.splice(index, 1);
  //   }
  // }

  // selected(event: MatAutocompleteSelectedEvent): void {
  //   this.roles.push(event.option.viewValue);
  //   this.roleInput.nativeElement.value = '';
  //   this.roleCtrl.setValue(null);
  // }

  // private _filter(value: string): string[] {
  //   const filterValue = value.toLowerCase();

  //   return this.allRoles.filter(role =>
  //     role.toLowerCase().includes(filterValue)
  //   );
  // }
}
