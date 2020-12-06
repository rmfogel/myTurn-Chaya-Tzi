import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BusinessDto } from '../models/business';

@Injectable({
    providedIn: 'root'
  })
  export class BusinessService {
    
    constructor(private http: HttpClient, private router: Router) { }

    getBusinessList(idCategory:number):Observable<any>{
     return this.http.get<Observable<any>>(`${environment.BASE_URL}/Business/${idCategory}`)
     
    }

  getBranchList(idBussines: number): Observable<any> {
    return this.http.get<Observable<any>>(`${environment.BASE_URL}/Branch/${idBussines}`)

  }

    // getBusinessByServiceId(idServise:number):Observable<any>{
    //   return this.http.get<Observable<any>>(`${environment.BASE_URL}/Business/${idServise}`)
      
    //  }
    
   

  }  