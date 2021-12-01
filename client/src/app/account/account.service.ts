import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

interface User {
  firstName: string;
  lastName: string;
  gender: string;
  employeeId: number;
  id: string;
}

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  loginUrl = 'https://localhost:5001/api/login';
  logoutUrl = 'https://localhost:5001/api/logut';
  user: User;

  constructor(private http: HttpClient) {}

  tryLogin(form): Observable<any> {
    return this.http.post(this.loginUrl, form).pipe(
      map((res: any) => {
        if (res != null) {
          this.createUser(res);
        } else {
          console.log('nope');
        }
      })
    );
  }
  createUser(res) {
    this.user = JSON.parse(atob(res.token.split('.')[1]));
    localStorage.setItem('user', atob(res.token.split('.')[1]));
    localStorage.setItem('token', res.token);
    window.location.reload();
  }
  getUser() {
    return JSON.parse(localStorage.getItem('user'));
  }
  logoutUser() {
    this.user = null;
    localStorage.removeItem('user');
    window.location.reload();
  }
}
