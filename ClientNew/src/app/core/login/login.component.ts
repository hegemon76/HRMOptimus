import { Component, OnInit } from '@angular/core';
<<<<<<< HEAD
import { WorkersService } from '../../workers/workers.service';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

interface User {
  email: string;
  password: string;
}
=======
import {HttpClient} from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
>>>>>>> 3a613ca738840f39440cbf5b487a7c50bcc60a2b

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  url = 'https://localhost:5001/api/login';
  form: FormGroup;
  model: any = {};
  constructor(
    private http: HttpClient,
    private formBuilder: FormBuilder,
    ) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: '',
      password: '',
    });
  }

  login() {
    console.log("12333");

<<<<<<< HEAD
  checkIfUserExists(user) {
    this.workersService.checkIfUserExists(user).subscribe(res => {
      console.log(res);
    });
=======
    this.http.post(this.url,this.form.getRawValue()).subscribe(()=>{
      console.log("123");
    }
    );
>>>>>>> 3a613ca738840f39440cbf5b487a7c50bcc60a2b
  }
}
