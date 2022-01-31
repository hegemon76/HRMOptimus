import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VacationService {
  baseUrl = environment.baseUrl;
  getEmployeeVacationsUrl = `${this.baseUrl}leavesRegister/getByEmployeeId`;
  addVacationUrl = `${this.baseUrl}leavesRegister/add`;
  updateVacationUrl = `${this.baseUrl}leavesRegister/changeStatus`;
  deleteVacationUrl = `${this.baseUrl}leavesRegister/delete`;

  constructor(private http: HttpClient) {}

  getEmployeeVacations(id): Observable<any> {
    return this.http.get(this.getEmployeeVacationsUrl, {
      params: {
        employeeId: id
      },
      headers: new HttpHeaders({
        Authorization: `Bearer ${localStorage.getItem('token')}`
      })
    });
  }
  addVacation(value: any): Observable<any> {
    return this.http.post(this.addVacationUrl, {
      leaveStart: value.leaveStart,
      leaveEnd: value.leaveEnd,
      employeeId: value.employeeId,
      leaveRegisterType: value.leaveRegisterType
    });
  }
  approveVacation(vacationId, employeeId): Observable<any> {
    return this.http.put(this.updateVacationUrl, {
      recordId: vacationId,
      employeeId: employeeId,
      status: 0
    });
  }
  rejectVacation(vacationId, employeeId): Observable<any> {
    return this.http.put(this.updateVacationUrl, {
      recordId: vacationId,
      employeeId: employeeId,
      status: 1
    });
  }
  deleteVacation(vacationId, employeeId): Observable<any> {
    return this.http.delete(this.deleteVacationUrl, {
      params: {
        id: vacationId,
        employeeId: employeeId
      }
    });
  }
}
