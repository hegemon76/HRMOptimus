import { Component, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  darkMode = true;
  isVerifiedUser = false;

  ngOnInit() {
    // this.checkIsUser();
  }

  // checkIsUser() {
  //   console.log(localStorage.getItem('user'));
  //   if (localStorage.getItem('user') != null) {
  //     this.isVerifiedUser = true;
  //   }
  // }
}
