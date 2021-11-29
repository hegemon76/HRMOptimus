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
  getEmployeesurl =
    'https://localhost:5001/api/employees?PageNumber=1&PageSize=1000&SortBy=FullName&SortDirection=1';
  getEmployeeUrl = 'https://localhost:5001/api/employee/details';
  deleteEmployeeUrl = 'https://localhost:5001/api/employee/delete';
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
}
