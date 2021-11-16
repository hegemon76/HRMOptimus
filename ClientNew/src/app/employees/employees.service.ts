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
export class EmployeesService {
  getEmployeesurl = 'https://localhost:5001/api/employees';
  constructor(private http: HttpClient) {}

  getEmployees(): Observable<any> {
    return this.http
      .get(this.getEmployeesurl, {
        headers: {
          'Content-Type': 'applicastion/json'
        }
      })
      .pipe(map((res: any) => res));
  }
}
