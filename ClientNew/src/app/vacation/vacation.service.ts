import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VacationService {
  getEmployeeVacationsUrl =
    'https://localhost:5001/api/leavesRegister/getByEmployeeId';

  constructor(private http: HttpClient) {}

  getEmployeeVacations(id): Observable<any> {
    return this.http
      .get(this.getEmployeeVacationsUrl, {
        params: {
          employeeId: id
        },
        headers: new HttpHeaders({
          Authorization:
            'Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiJkYjJkNGRmMi02YjZjLTRhNmMtODJiZC1kNTEyYWFkODBkNmUiLCJFbXBsb3llZUlkIjoiMSIsIkZ1bGxOYW1lIjoiSmFrdWIgQmFocnlub3dza2kiLCJuYmYiOjE2MzgxMDk3OTksImV4cCI6MTYzODcxNDU5OSwiaWF0IjoxNjM4MTA5Nzk5fQ.zifVQJl4buZ9vHn2fDykBSC3sc-MqDF_A4AdGBS5wKA8eFf8_vRFFH_v9vx7zD5urUWFo2FCbTKrwo3A7c4YJQ'
        })
      })
      .pipe(map((res: any) => res));
  }
}
