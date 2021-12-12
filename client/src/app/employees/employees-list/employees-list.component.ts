import { Component, OnInit, Inject } from '@angular/core';
import { EmployeesService } from '../../_services/employees.service';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EmployeeVm } from '../../../shared/vm/employee.vm';

export interface DialogData {
  fullName: string;
}

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.scss']
})
export class EmployeesListComponent implements OnInit {
  employees: EmployeeVm[];
  searchedEmployee: string;

  constructor(
    private employeesService: EmployeesService,
    private router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.employeesService.getEmployees().subscribe(res => {
      this.employees = res.items;
    });
  }

  openDialog(fN, id) {
    const dialogRef = this.dialog.open(DeleteEmployeeDialog, {
      data: { fullName: fN }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == true) {
        this.employeesService.deleteEmployee(id).subscribe(() => {
          this.router
            .navigateByUrl('', { skipLocationChange: true })
            .then(() => {
              this.router.navigate(['/employees']);
            });
        });
      }
    });
  }
}

@Component({
  selector: 'delete-employee-dialog',
  templateUrl: 'delete-employee-dialog.html',
  styleUrls: ['./employees-list.component.scss']
})
export class DeleteEmployeeDialog {
  constructor(
    public dialogRef: MatDialogRef<DeleteEmployeeDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
}
