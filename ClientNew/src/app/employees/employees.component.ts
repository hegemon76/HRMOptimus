import { Component, OnInit, Inject } from '@angular/core';
import { EmployeesService } from './employees.service';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';

export interface DialogData {
  fullName: string;
}

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  employees: any[];
  searchedEmployee: string;

  constructor(
    private employeesService: EmployeesService,
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
        this.employeesService.deleteEmployee(id).subscribe();
      }
    });
  }
}

@Component({
  selector: 'delete-employee-dialog',
  templateUrl: 'delete-employee-dialog.html'
})
export class DeleteEmployeeDialog {
  constructor(
    public dialogRef: MatDialogRef<DeleteEmployeeDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
}
