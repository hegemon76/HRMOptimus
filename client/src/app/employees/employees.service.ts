import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  baseUrl = environment.baseUrl;
  getEmployeesurl = `${this.baseUrl}employees?PageNumber=1&PageSize=1000&SortBy=FullName&SortDirection=1`;
  getEmployeeUrl = `${this.baseUrl}employee/details`;
  deleteEmployeeUrl = `${this.baseUrl}employee/delete`;
  addEmployeeUrl = `${this.baseUrl}register`;
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

  getEmployee(id): Observable<any> {
    return this.http
      .get(this.getEmployeeUrl, {
        headers: {
          'Content-Type': 'applicastion/json'
        },
        params: {
          employeeId: id
        }
      })
      .pipe(map((res: any) => res));
  }

  deleteEmployee(id): Observable<any> {
    return this.http
      .delete(this.deleteEmployeeUrl, {
        params: {
          employeeId: id
        }
      })
      .pipe(map((res: any) => res));
  }

  addEmployee(form): Observable<any> {
    return this.http
      .post(this.addEmployeeUrl, form)
      .pipe(map((res: any) => res));
  }
}
