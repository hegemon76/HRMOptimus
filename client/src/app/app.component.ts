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
    this.employeesService.getEmployee(this.user.nameid).subscribe(res => {
      const checkRoles = res.roles.sort((a, b) => {
        return a < b;
      });
      const storageRoles = this.user.role.sort((a, b) => {
        return a < b;
      });
      if (JSON.stringify(storageRoles) !== JSON.stringify(checkRoles)) {
        console.log('ding');

        const updatedUser = this.user;
        updatedUser.role = checkRoles;
        localStorage.setItem('user', JSON.stringify(updatedUser));
        setTimeout(() => {
          window.location.reload();
        }, 1000);
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
