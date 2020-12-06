import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ServiceDto } from '../models/service';


@Injectable({
  providedIn: 'root'
})
export class ServiceOfBusinessService {


  constructor(private http:HttpClient) { }

  getServicesList(businessId: number,branchId:number){
    if(branchId==NaN)
    branchId=0;
    return this.http.get(`${environment.BASE_URL}/ServiceOfBusiness?id=${businessId}&branchId=${branchId}`)
     
    
   }

}
