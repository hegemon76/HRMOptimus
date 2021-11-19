import { Component, ViewEncapsulation, ViewChild} from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay, delay } from 'rxjs/operators';
import { MatSidenav } from '@angular/material/sidenav';
import { AccountService } from './account/account.service';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {

  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

  constructor(private breakpointObserver: BreakpointObserver, private accountService: AccountService) { }

  ngAfterViewInit() {
    this.breakpointObserver
      .observe(['(max-width: 800px)'])
      .pipe(delay(1))
      .subscribe((res) => {
        if (res.matches) {
          this.sidenav.mode = 'over';
          this.sidenav.close();
        } else {
          this.sidenav.mode = 'side';
          this.sidenav.open();
        }
      });
  }

  darkMode = true;
  isVerifiedUser = false;

  user: any;
  logoutWrapperToggled = false;

  ngOnInit() {
    this.checkIsUser();
    this.checkWebsiteMode();
    this.user = this.accountService.getUser();
  }

  checkIsUser() {
    if (
      localStorage.getItem('user') != null &&
      localStorage.getItem('user') != undefined
    ) {
      this.isVerifiedUser = true;
    }
  }

  changeWebsiteMode() {
    if (document.querySelector('html').dataset.theme == 'light') {
      localStorage.setItem('theme', 'dark');
      document.querySelector('html').dataset.theme = localStorage.getItem(
        'theme'
      );
    } else {
      localStorage.setItem('theme', 'light');
      document.querySelector('html').dataset.theme = localStorage.getItem(
        'theme'
      );
    }
  }

  checkWebsiteMode() {
    if (localStorage.getItem('theme') != null) {
      document.querySelector('html').dataset.theme = localStorage.getItem(
        'theme'
      );
    }
  }

  openSubmenu(e) {
    e.target.parentElement.parentElement.classList.toggle('opened');
  }

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
}
