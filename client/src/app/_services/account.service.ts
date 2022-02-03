import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserVm } from '../../shared/vm/user.vm';
import { environment } from '../../environments/environment';
import jwt_decode from 'jwt-decode';
import { stringify } from 'querystring';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.baseUrl;
  loginUrl: string = `${this.baseUrl}login`;
  logoutUrl: string = `${this.baseUrl}logut`;
  updateEmailUrl: string = `${this.baseUrl}changeEmail`;
  confirmEmailUrl: string = `${this.baseUrl}confirmEmail`;
  updatePasswordUrl: string = `${this.baseUrl}resetPassword`;
  confirmPasswordUrl: string = `${this.baseUrl}confirmPasswordReset`;
  user: UserVm;

  constructor(private http: HttpClient) {}

  tryLogin(form): Observable<any> {
    return this.http.post(this.loginUrl, form).pipe(
      map((res: any) => {
        console.log(res);

        if (res.token != '') {
          this.user = JSON.parse(window.atob(res.token.split('.')[1]));
          localStorage.setItem('user', window.atob(res.token.split('.')[1]));
          localStorage.setItem('token', res.token);
          var decodedToken = jwt_decode(res.token);
          var fullName = decodedToken['unique_name'];
          localStorage.setItem('fullName', fullName);
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
    return this.http.post(this.updateEmailUrl, {
      applicationUserId: apId,
      newEmail: newEmail
    });
  }
  confirmEmail(token): Observable<any> {
    return this.http.post(
      this.confirmEmailUrl,
      {},
      {
        params: {
          token: token
        }
      }
    );
  }
  updatePassword(newPassword): Observable<any> {
    return this.http.post(this.updatePasswordUrl, {
      newPassword: newPassword
    });
  }
  confirmPassword(token): Observable<any> {
    return this.http.post(
      this.confirmPasswordUrl,
      {},
      {
        params: {
          token: token
        }
      }
    );
  }
}
