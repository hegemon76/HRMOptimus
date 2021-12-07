import { environment } from '../environment';
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
  updateVacationUrl = `${this.baseUrl}leavesRegister/changeStatus`;

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
  addVacation(value): Observable<any> {
    return this.http
      .post(this.addVacationUrl, {
        leaveStart: value.leaveStart,
        leaveEnd: value.leaveEnd,
        employeeId: value.employeeId,
        leaveRegisterType: value.leaveRegisterType
      })
      .pipe(map((res: any) => res));
  }
  approveVacation(vacationId, employeeId): Observable<any> {
    return this.http
      .put(this.updateVacationUrl, {
        recordId: vacationId,
        employeeId: employeeId,
        status: 0
      })
      .pipe(map((res: any) => res));
  }
  rejectVacation(vacationId, employeeId): Observable<any> {
    return this.http
      .put(this.updateVacationUrl, {
        recordId: vacationId,
        employeeId: employeeId,
        status: 1
      })
      .pipe(map((res: any) => res));
  }
}
