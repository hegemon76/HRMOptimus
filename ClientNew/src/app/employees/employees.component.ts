import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class employeesComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  checkUser(login, password) {
    if (login == 'admin' && password == 'admin') {
      return true;
    } else {
      return false;
    }
  }
}
