import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';

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

    this.http.post(this.url,this.form.getRawValue()).subscribe(()=>{
      console.log("123");
    }
    );
  }
}
