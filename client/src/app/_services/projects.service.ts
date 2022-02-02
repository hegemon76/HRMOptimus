import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {
  baseUrl = environment.baseUrl;
  getProjectsUrl = `${this.baseUrl}projects`;
  getProjectDetailsUrl = `${this.baseUrl}project/details`;
  addProjectUrl = `${this.baseUrl}project/add`;
  updateProjectUrl = `${this.baseUrl}project/update`;
  deleteProjectUrl = `${this.baseUrl}project/delete`;
  addEmployeesToProjectUrl = `${this.baseUrl}project/addEmployee`;
  removeEmployeeFromProjectUrl = `${this.baseUrl}project/removeEmployeeFromProject`;

  constructor(private http: HttpClient) {}

  getProjects(): Observable<any> {
    return this.http.get(this.getProjectsUrl);
  }
  getProjectDetails(id): Observable<any> {
    return this.http.get(this.getProjectDetailsUrl, {
      params: {
        projectId: id
      }
    });
  }
  updateProject(data, id): Observable<any> {
    return this.http.put(this.updateProjectUrl, {
      id: id,
      colorLabel: data.colorLabel,
      name: data.name,
      description: data.description,
      dateFrom: data.dateFrom,
      dateTo: data.dateTo,
      hoursBudget: data.hoursBudget,
      deadline: '2022-01-06T17:28:00.539Z'
    });
  }
  addProject(form): Observable<any> {
    console.log(form);

    return this.http.post(this.addProjectUrl, {
      name: form.name,
      description: form.description,
      hoursBudget: form.hoursBudget,
      colorLabel: form.colorLabel,
      dateFrom: form.dateFrom,
      deadline: form.deadline,
      dateTo: form.dateTo
    });
  }
  addEmployeesToProject(id, employeeId): Observable<any> {
    return this.http.post(
      this.addEmployeesToProjectUrl,
      {},
      {
        params: {
          projectId: id,
          employeeId: employeeId
        }
      }
    );
  }
  removeEmployeeFromProject(id, employeeId): Observable<any> {
    return this.http.delete(this.removeEmployeeFromProjectUrl, {
      params: {
        projectId: id,
        employeeId: employeeId
      }
    });
  }
  removeProject(id): Observable<any> {
    return this.http.delete(this.deleteProjectUrl, {
      params: {
        projectId: id
      }
    });
  }
}
