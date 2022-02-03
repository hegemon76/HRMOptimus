import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { delay } from 'rxjs/operators';
import { MatSidenav } from '@angular/material/sidenav';
import { AccountService } from './_services/account.service';
import { UserVm } from '../shared/vm/user.vm';
import { Router } from '@angular/router';
import { EmployeesService } from './_services/employees.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  user: any;

  constructor(
    private breakpointObserver: BreakpointObserver,
    private accountService: AccountService,
    private employeesService: EmployeesService
  ) {}

  ngAfterViewInit() {
    this.breakpointObserver
      .observe(['(max-width: 800px)'])
      .pipe(delay(1))
      .subscribe(res => {
        if (res.matches) {
          this.sidenav.mode = 'over';
          this.sidenav.close();
        } else {
          this.sidenav.mode = 'side';
          this.sidenav.open();
        }
      });
  }

  ngOnInit() {
    this.user = this.accountService.getUser();
    console.log(typeof this.user.role);

    this.employeesService.getEmployee(this.user.nameid).subscribe(res => {
      console.log(res);

      const checkRoles = res.roles.sort((a, b) => {
        return a < b;
      });
      let storageRoles;
      if (Array.isArray(this.user.role)) {
        storageRoles = this.user.role.sort((a, b) => {
          return a < b;
        });
      } else {
        storageRoles = this.user.role;
      }
      if (storageRoles != checkRoles) {
        this.accountService.logoutUser();
      }
    });

    if (!this.user && window.location.pathname != '/') {
      window.location.pathname = '/';
    }
  }

  toggleSidenav() {
    this.sidenav.toggle();
  }
}
