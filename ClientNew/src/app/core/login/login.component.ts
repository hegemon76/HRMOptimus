import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  user = {
    login: 'admin',
    password: 'admin'
  };

  checkIfUserExists(user) {
    console.log(user.login + '' + user.password);
    if (user.login == 'admin' && user.password == 'admin') {
      console.log('ok');
      localStorage.setItem('user', 'admin');
    } else {
      console.log('nie');
    }
    console.log(localStorage.getItem('user'));
  }
}
