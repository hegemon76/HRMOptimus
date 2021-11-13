import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
interface Worker {
  email: string;
  password: string;
}
@Injectable({
  providedIn: 'root'
})
export class WorkersService {
  proxy = 'https://dry-taiga-05632.herokuapp.com/';
  baseUrl = 'https://localhost:5001/';
  url = 'api/login';

  constructor(private http: HttpClient) {}
  checkIfUserExists(user): Observable<any> {
    return this.http
      .post(this.baseUrl + this.url, {
        body: {
          email: user.email,
          password: user.password
        }
      })
      .pipe(map((res: any) => res));
  }
}
