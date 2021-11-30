import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { delay } from 'rxjs/operators';
import { MatSidenav } from '@angular/material/sidenav';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
<<<<<<< HEAD
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

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

  isVerifiedUser = false;
  user: any;
  logoutWrapperToggled = false;

  ngOnInit() {
    this.checkIsUser();
    this.user = this.accountService.getUser();
=======
  darkMode = true;
  isVerifiedUser = true;

  ngOnInit() {
    // this.checkIsUser();

    localStorage.removeItem('user');
>>>>>>> e71cf1a96e22c3097d2355caa133dd8cb9ac0b5a
  }

  checkIsUser() {
    if (
      localStorage.getItem('user') != null &&
      localStorage.getItem('user') != undefined
    ) {
      this.isVerifiedUser = true;
    }
  }
}
