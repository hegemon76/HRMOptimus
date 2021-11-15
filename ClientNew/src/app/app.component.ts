import { Component, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  darkMode = true;
  isVerifiedUser = true;

  ngOnInit() {
    // this.checkIsUser();

    localStorage.removeItem('user');
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
