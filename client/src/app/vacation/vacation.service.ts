import { environment } from '../enviroment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VacationService {
  baseUrl = environment.baseUrl;
  getEmployeeVacationsUrl = `${this.baseUrl}leavesRegister/getByEmployeeId`;
  addVacationUrl = `${this.baseUrl}leavesRegister/add`;

  constructor(private http: HttpClient) {}

  getEmployeeVacations(id): Observable<any> {
    return this.http
      .get(this.getEmployeeVacationsUrl, {
        params: {
          employeeId: id
        },
        headers: new HttpHeaders({
          Authorization: `Bearer ${localStorage.getItem('token')}`
        })
      })
      .pipe(map((res: any) => res));
  }
  addVacation(id): Observable<any> {
    return this.http
      .post(this.addVacationUrl, {
        body: {
          leaveStart: '2021-11-22T06:11:32.701Z',
          leaveEnd: '2021-11-25T06:11:32.701Z',
          employeeId: 1,
          leaveRegisterType: 0
        }
      })
      .pipe(map((res: any) => res));
  }
}
