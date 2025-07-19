import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from './api-response';

export interface EmployeeModel {
  id: number;
  firstName: string;
  lastName:string;
  email:string;
  position: string;
}

@Injectable({
  providedIn: 'root'
})


export class EmployeeService {
   private apiUrl = 'http://localhost:5242/api/employee';

   constructor(private http: HttpClient) {}
    
  public getAll(): Observable<ApiResponse<EmployeeModel[]>> {
    return this.http.get<ApiResponse<EmployeeModel[]>>(this.apiUrl);
  }
  public getById(id: number): Observable<ApiResponse<EmployeeModel>> {
    return this.http.get<ApiResponse<EmployeeModel>>(`${this.apiUrl}/${id}`);
  }
  public create(emp: EmployeeModel): Observable<ApiResponse<EmployeeModel>> {
    return this.http.post<ApiResponse<EmployeeModel>>(this.apiUrl, emp);
  }
 public update(emp: EmployeeModel): Observable<ApiResponse<EmployeeModel>> {
    return this.http.put<ApiResponse<EmployeeModel>>(`${this.apiUrl}/${emp.id}`, emp);
  }
  public delete(id: number): Observable<ApiResponse<EmployeeModel>> {
    return this.http.delete<ApiResponse<EmployeeModel>>(`${this.apiUrl}/${id}`);
  }
}
