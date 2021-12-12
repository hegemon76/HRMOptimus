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
  addProjectUrl = `${this.baseUrl}project/add`;
  deleteProjectUrl = `${this.baseUrl}project/delete`;

  constructor(private http: HttpClient) {}

  getProjects(): Observable<any> {
    return this.http.get(this.getProjectsUrl);
  }
  addProject(form): Observable<any> {
    return this.http.post(this.addProjectUrl, form);
  }
  removeProject(id): Observable<any> {
    return this.http.delete(this.deleteProjectUrl, {
      params: {
        projectId: id
      }
    });
  }
}
