import { HttpClient } from '@angular/common/http';
import { compileDeclareInjectableFromMetadata } from '@angular/compiler';
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

  getMonth = 'https://localhost:5001/api/workrecord/month';

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
      })
      .pipe(map((res: any) => res));
  }

  getMonthEntry(dateFrom, dateTo): Observable<any> {
    return this.http
      .get(this.getMonth, {
        headers: {
          'Content-Type': 'application/json'
        },
        params: {
          dateFrom: dateFrom,
          dateTo: dateTo
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

  addWorkDayRecord(values, emploeeId, value): Observable<any> {
    return this.http.post(this.addWorkEntry, {
      name: values.dayName,
      workStart: value + ' ' + values.workStart,
      workEnd: value + ' ' + values.workEnd,
      projectId: values.projectName.id,
      employeeId: emploeeId
    },
      {
        headers: { 'Content-Type': 'application/json' }
      })
      .pipe(map((res: any) => res));
  }
}
