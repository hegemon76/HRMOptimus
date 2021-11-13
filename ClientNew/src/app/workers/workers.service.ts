import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
    var body = {
      email: 'bahrynowski.jakub@gmail.com',
      password: 'Zaq1234!'
    };
    return this.http
      .post(this.baseUrl + this.url, body)
      .pipe(map((res: any) => res));
  }
}
