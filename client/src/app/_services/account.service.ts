import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
  updateEmailUrl: string = `${this.baseUrl}changeEmail`;
  confirmEmailUrl: string = `${this.baseUrl}confirmEmail`;
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
  updateEmail(apId, newEmail): Observable<any> {
    console.log(apId);
    console.log(newEmail);

    return this.http.post(this.updateEmailUrl, {
      applicationUserId: apId,
      newEmail: newEmail
    });
  }
  confirmEmail(token): Observable<any> {
    console.log(token);

    return this.http.post(this.confirmEmailUrl, {
      headers: new HttpHeaders({
        Authorization: `Bearer ${localStorage.getItem('token')}`
      }),
      params: {
        token: token
      }
    });
  }
}
