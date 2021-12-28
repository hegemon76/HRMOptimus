import { Component, OnInit, Inject } from '@angular/core';
import {
  ComponentFactoryResolver,
  ViewChild,
  ViewContainerRef
} from '@angular/core';
import { EmployeeAddSingleFormComponent } from './employee-add-single-form/employee-add-single-form.component';
import { EmployeesService } from '../../../_services/employees.service';
import { formatDate } from '@angular/common';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';
import { Router } from '@angular/router';

export interface DialogData {}

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.scss']
})
export class EmployeeAddComponent implements OnInit {
  @ViewChild('container', { read: ViewContainerRef })
  container: ViewContainerRef;
  addEmployeeRow = EmployeeAddSingleFormComponent;
  components = [];
  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private employeesService: EmployeesService,
    public dialog: MatDialog,
    private router: Router
  ) {}

  ngOnInit(): void {
    var checkContainerLoaded = setInterval(() => {
      if (this.container) {
        clearInterval(checkContainerLoaded);
        this.addComponent();
      }
    }, 100);
  }

  ngAfterContentInit() {}

  addComponent() {
    if (
      this.components.length > 0 &&
      this.components[this.components.length - 1].instance.form.status ==
        'INVALID'
    ) {
      this.openDialog();
    } else {
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(
        EmployeeAddSingleFormComponent
      );
      const component = this.container.createComponent(componentFactory);
      component.instance.rm.subscribe(r => {
        this.removeComponent(component);
      });
      this.components.push(component);
    }
  }
  removeComponent(component) {
    const componentIndex = this.components.indexOf(component);

    if (componentIndex !== -1) {
      this.container.remove(componentIndex);
      this.components.splice(componentIndex, 1);
    }
  }

  addEmployees() {
    this.components.map(c => {
      // console.log(c);
      if (c.instance.form.status == 'VALID') {
        const formData = c.instance.form.getRawValue();
        formData.birthDate =
          formatDate(formData.birthDate, 'YYYY-MM-dd', 'en-US') +
          'T00:00:00.000Z';
        this.employeesService.addEmployee(formData).subscribe(() => {
          this.router.navigate(['/employees']);
        });
      }
    });
  }

  openDialog() {
    const dialogRef = this.dialog.open(FillFormDialog);
  }
}

@Component({
  selector: 'fill-form-dialog',
  templateUrl: 'fill-form-dialog.html',
  styleUrls: ['./employee-add.component.scss']
})
export class FillFormDialog {
  constructor(
    public dialogRef: MatDialogRef<FillFormDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
}
