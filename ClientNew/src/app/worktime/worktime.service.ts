import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class WorktimeService {

  getWorkdayEntries = 'https://localhost:5001/api/workrecord/day';

  getProjectsEntries = 'https://localhost:5001/api/projects';

  deleteWorkDay = 'https://localhost:5001/api/workrecord/delete';

  addWorkEntry = 'https://localhost:5001/api/workrecord/add';

  constructor(private http: HttpClient) { }

  getWorkday(id): Observable<any> {
    return this.http
      .get(this.getWorkdayEntries, {
        headers: {
          'Content-Type': 'application/json'
        },
        params: {
          dayWork: id
        }
      })
      .pipe(map((res: any) => res));
  }

  getProjects(): Observable<any> {
    return this.http
      .get(this.getProjectsEntries, {
        headers: {
          'Content-Type': 'application/json'
        },
        params: {
          dayWork: "2021-11-29"
        }
      })
      .pipe(map((res: any) => res));
  }

  deleteWorkDayEntries(id): Observable<any> {
    return this.http
      .delete(this.deleteWorkDay, {
        params: {
          workRecordId: id
        }
      })
      .pipe(map((res: any) => res));
  }

  addWorkDayRecord(): Observable<any> {
    return this.http.post(this.addWorkEntry, {
      name: "pipa", workStart: "2021-11-12T21:30", workEnd: "2021-11-12T23:45", projectId: 9, employeeId: 1
      //   workStart: "2021-11-12T21:30",},
      // body: {
      //   name: "pipa",
      //   workStart: "2021-11-12T21:30",
      //   workEnd: "2021-11-12T23:45",
      //   projectId: 9,
      //   employeeId: 1
      // },
      // headers: {
      //   'Content-Type': 'application/json'
      // }
    }, { headers: { 'Content-Type': 'application/json' } })
      .pipe(map((res: any) => res));
  }
}
