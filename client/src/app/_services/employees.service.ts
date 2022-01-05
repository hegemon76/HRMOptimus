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
  editEmployeeUrl = `${this.baseUrl}editEmployee`;
  editEmployeeContractUrl = `${this.baseUrl}editContract`;
  setRolesUrl = `${this.baseUrl}setRoles`;

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
  editEmployee(form, id): Observable<any> {
    return this.http.put(this.editEmployeeUrl, {
      employeeId: id,
      firstName: form.firstName,
      lastName: form.lastName,
      birthDate: form.birthDate,
      gender: form.gender,
      zipCode: form.zipCode,
      city: form.city,
      street: form.street,
      buildingNumber: form.buildingNumber,
      houseNumber: form.houseNumber,
      country: form.country,
      phoneNumber: form.phoneNumber
    });
  }
  editEmployeeContract(form, id): Observable<any> {
    return this.http.put(this.editEmployeeContractUrl, {
      contractId: id,
      contractName: form.contractName,
      contractType: form.contractType,
      leaveDays: form.leaveDays
    });
  }
  setRoles(roles, email): Observable<any> {
    console.log(roles + ' ' + email);

    return this.http.post(this.setRolesUrl, {
      email: email,
      userRoles: roles
    });
  }
}
