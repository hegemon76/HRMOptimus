import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserVm } from '../../shared/vm/user.vm';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.baseUrl;
  loginUrl: string = `${this.baseUrl}login`;
  logoutUrl: string = `${this.baseUrl}logut`;
  user: UserVm;

  constructor(private http: HttpClient) {}

  tryLogin(form): Observable<any> {
    return this.http.post(this.loginUrl, form).pipe(
      map((res: any) => {
        try {
          this.user = JSON.parse(atob(res.token.split('.')[1]));
          localStorage.setItem('user', atob(res.token.split('.')[1]));
          localStorage.setItem('token', res.token);
          window.location.reload();
        } catch {
          console.log('nope');
        }
      })
    );
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
