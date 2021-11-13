import { Component, OnInit } from '@angular/core';
import { WorkersService } from '../../workers/workers.service';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

interface User {
  email: string;
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
    this.workersService.checkIfUserExists(user).subscribe(res => {
      console.log(res);
    });
  }
}
