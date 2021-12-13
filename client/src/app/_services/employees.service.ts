import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
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
    return this.http.get(this.getEmployeesurl);
  }

  getEmployee(id): Observable<any> {
    return this.http.get(this.getEmployeeUrl, {
      params: {
        employeeId: id
      }
    });
  }

  deleteEmployee(id): Observable<any> {
    return this.http.delete(this.deleteEmployeeUrl, {
      params: {
        employeeId: id
      }
    });
  }

  addEmployee(form): Observable<any> {
    return this.http.post(this.addEmployeeUrl, form);
  }
}
