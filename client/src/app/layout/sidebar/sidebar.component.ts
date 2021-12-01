import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
<<<<<<< HEAD:ClientNew/src/app/layout/sidebar/sidebar.component.ts
export class SidebarComponent implements OnInit {
  checked = false;
  darkMode = true;

  constructor() {}
=======
>>>>>>> e71cf1a96e22c3097d2355caa133dd8cb9ac0b5a:ClientNew/src/app/core/sidebar/sidebar.component.ts

export class SidebarComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

<<<<<<< HEAD:ClientNew/src/app/layout/sidebar/sidebar.component.ts
  checkWebsiteMode() {
    if (localStorage.getItem('theme') != null) {
      document.querySelector('html').dataset.theme = localStorage.getItem(
        'theme'
      );
      if (localStorage.getItem('theme') == 'dark') {
        this.checked = true;
      }
    }
=======
  constructor(private breakpointObserver: BreakpointObserver) {}

  darkMode = true;
  isVerifiedUser = false;

  ngOnInit() {
    this.checkIsUser();
>>>>>>> e71cf1a96e22c3097d2355caa133dd8cb9ac0b5a:ClientNew/src/app/core/sidebar/sidebar.component.ts
  }

  checkIsUser() {
    if (
      localStorage.getItem('user') != null &&
      localStorage.getItem('user') != undefined
    ) {
      this.isVerifiedUser = true;
    }
  }

  destroyUser() {
        localStorage.removeItem('user');
        window.location.reload();
      }

}

