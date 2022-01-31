import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { delay } from 'rxjs/operators';
import { MatSidenav } from '@angular/material/sidenav';
import { AccountService } from './_services/account.service';
import { UserVm } from '../shared/vm/user.vm';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  user: UserVm;

  constructor(
    private breakpointObserver: BreakpointObserver,
    private accountService: AccountService
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
    if (!this.user && window.location.pathname != '/') {
      window.location.pathname = '/';
    }
  }

  toggleSidenav() {
    this.sidenav.toggle();
  }
}
