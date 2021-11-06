import { Component, OnInit } from '@angular/core';
import { WorkersService } from '../../workers/workers.service';

interface User {
  login: string;
  password: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(private workersService: WorkersService) {}

  ngOnInit(): void {}

  user = {} as User;

  checkIfUserExists(user) {
    this.workersService.checkIfUserExists(user);
  }
}
