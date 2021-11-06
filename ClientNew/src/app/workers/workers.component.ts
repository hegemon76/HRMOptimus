import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-workers',
  templateUrl: './workers.component.html',
  styleUrls: ['./workers.component.scss']
})
export class WorkersComponent implements OnInit {
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
