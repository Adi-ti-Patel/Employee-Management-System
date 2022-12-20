import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  readonly APIUrl = "https://localhost:7253/api";

  constructor(private http : HttpClient) { }

  getDepartmentList() : Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Department');
  }

  getActiveDepartmentList() : Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Department/active');
  }

  deleteDepartment(id : number){
    return this.http.delete<boolean>(this.APIUrl+`/Department/${id}`);
  }
}
