import { Component } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'HRM Optima';
  switch = false;

  switchTest() {
    if (this.switch) {
      this.switch = false;
    } else {
      this.switch = true;
    }
    console.log(this.switch);
  }
}
