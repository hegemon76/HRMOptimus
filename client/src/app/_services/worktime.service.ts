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

  getAdminMonth = 'https://localhost:5001/api/workrecord/monthAdmin';

  getMonth = 'https://localhost:5001/api/workrecord/month';

  updateWorkRecordUrl = 'https://localhost:5001/api/workrecord/update';

  dayDuration: string;

  dayTiming: string;

  constructor(private http: HttpClient) {}

  getWorkday(id, employeeId): Observable<any> {
    return this.http
      .get(this.getWorkdayEntries, {
        headers: {
          'Content-Type': 'application/json'
        },
        params: {
          dayWork: id,
          employeeId: employeeId
        }
      })
      .pipe(map((res: any) => res));
  }

  setDayDuration(val) {
    this.dayDuration = val;
  }

  getDayDuration() {
    return this.dayDuration;
  }

  setDayTiming(val) {
    this.dayTiming = val;
  }

  getDayTiming() {
    return this.dayTiming;
  }

  getProjects(): Observable<any> {
    return this.http
      .get(this.getProjectsEntries, {
        headers: {
          'Content-Type': 'application/json'
        }
      })
      .pipe(map((res: any) => res));
  }

  getMonthEntry(month, id): Observable<any> {
    return this.http
      .get(this.getAdminMonth, {
        headers: {
          'Content-Type': 'application/json'
        },
        params: {
          monthFromCurrent: month,
          employeeId: id
        }
      })
      .pipe(map((res: any) => res));
  }

  getEmployeeMonthEntry(month): Observable<any> {
    return this.http
      .get(this.getMonth, {
        headers: {
          'Content-Type': 'application/json'
        },
        params: {
          monthFromCurrent: month
        }
      })
      .pipe(map((res: any) => res));
  }

  getMonthEntryDefault(): Observable<any> {
    return this.http
      .get(this.getMonth, {
        headers: {
          'Content-Type': 'application/json'
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

  addWorkDayRecord(values, emploeeId, value, isRemote): Observable<any> {
    return this.http
      .post(
        this.addWorkEntry,
        {
          name: values.dayName,
          workStart: value + ' ' + values.workStart,
          workEnd: value + ' ' + values.workEnd,
          isRemoteWork: isRemote,
          projectId: values.projectName.id,
          employeeId: emploeeId
        },
        {
          headers: { 'Content-Type': 'application/json' }
        }
      )
      .pipe(map((res: any) => res));
  }

  updateWorkRecord(formData): Observable<any> {
    return this.http
      .put(this.updateWorkRecordUrl, {
        id: formData.id,
        name: formData.name,
        workStart: formData.workStart,
        workEnd: formData.workEnd,
        isRemoteWork: formData.isRemoteWork,
        projectId: parseInt(formData.projectId),
        employeeId: parseInt(formData.employeeId)
      })
      .pipe(map((res: any) => res));
  }
}
