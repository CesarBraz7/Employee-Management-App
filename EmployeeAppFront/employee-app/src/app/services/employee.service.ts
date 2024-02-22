import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { Employee } from '../models/employee';
import { Response } from '../models/response';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = `${environment.apiUrl}/Employee`

  constructor( private http: HttpClient ) { }

  GetEmployee() : Observable<Response<Employee[]>> {
    return this.http.get<Response<Employee[]>>(this.apiUrl);
  }

  GetEmployeeById(id : number) : Observable<Response<Employee>>{
    return this.http.get<Response<Employee>>(`${this.apiUrl}/${id}`);
  }

  CreateEmployee(employee : Employee) : Observable<Response<Employee[]>> {
    return this.http.post<Response<Employee[]>>(`${this.apiUrl}`, employee);
  }

  UpdateEmployee(employee : Employee) : Observable<Response<Employee[]>> {
    return this.http.put<Response<Employee[]>>(`${this.apiUrl}`, employee);
  }

  InactiveEmployee(id : number) : Observable<Response<Employee[]>>{
    return this.http.put<Response<Employee[]>>(`${this.apiUrl}/inactiveEmployee/?id=${id}`, id);
  }

  ActiveEmployee(id : number) : Observable<Response<Employee[]>>{
    return this.http.put<Response<Employee[]>>(`${this.apiUrl}/activeEmployee/?id=${id}`, id);
  }

  DeleteEmployee(id : number) : Observable<Response<Employee[]>>{
    return this.http.delete<Response<Employee[]>>(`${this.apiUrl}/${id}`);
  }

}