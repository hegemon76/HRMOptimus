import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../../../_services/employees.service';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { map, startWith } from 'rxjs/operators';
import { Router } from '@angular/router';
import { EmployeeVm } from '../../../../shared/vm/employee.vm';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {
  employeeId;
  employeeToChange;
  employee: EmployeeVm;
  allEmployees: EmployeeVm[];
  isEmployeeLoaded = false;
  areEmployeesLoaded = false;

  myControl = new FormControl();
  searchedEmployee: string;
  options: any[] = [];
  filteredOptions: Observable<EmployeeVm[]>;

  constructor(
    private employessService: EmployeesService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = function() {
      return false;
    };
  }

  ngOnInit(): void {
    this.employessService
      .getEmployee(this.route.snapshot.paramMap.get('id'))
      .subscribe(res => {
        this.employeeId = this.route.snapshot.paramMap.get('id');
        this.employee = res;
        this.isEmployeeLoaded = true;
      });

    this.employessService.getEmployees().subscribe(res => {
      this.allEmployees = res.items;
      this.fillOptions(this.allEmployees);
      this.areEmployeesLoaded = true;
    });

    setTimeout(() => {
      this.filteredOptions = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => (typeof value === 'string' ? value : value.name)),
        map(name => (name ? this.optionsFilter(name) : this.options.slice()))
      );
    }, 1000);
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

  displayFn(option: EmployeeVm): string {
    return option ? option.firstName + ' ' + option.lastName : '';
  }

  optionsFilter(name: string): EmployeeVm[] {
    const filterValue = name.toLowerCase();

    return this.options.filter(option =>
      option.firstName.toLowerCase().includes(filterValue)
    );
  }

  changeUser() {
    this.router.navigate(['/employees/edit', this.myControl.value.id]);
  }
}
