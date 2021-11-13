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
  url = 'https://localhost:5001/api/login';

  constructor(private http: HttpClient) {}

  checkIfUserExists(user): Observable<any> {
    //   var body = {
    //     email: user.email,
    //     password: user.password
    //   };
    //   console.log(body);
    //   return this.http
    //     .post(this.url, body, {
    //       headers: {
    //         'Content-Type': 'application/json'
    //       }
    //     })
    //     .pipe(map((res: any) => res));
    // }
    var body = {
      title: 'foo',
      body: 'bar',
      userId: 1
    };
    console.log(body);
    return this.http
      .post('https://jsonplaceholder.typicode.com/posts', body, {
        headers: {
          'Content-Type': 'application/json'
        }
      })
      .pipe(map((res: any) => res));
  }
}
