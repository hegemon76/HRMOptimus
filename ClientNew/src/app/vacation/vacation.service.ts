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
}
