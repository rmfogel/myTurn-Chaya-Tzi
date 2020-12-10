import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Route } from '../models/route';

@Injectable({
  providedIn: 'root'
})
export class CreateRouteService {

    dictRoute:any;
    route:Route=new Route();
    curentlyChosenDisplay=[[],[],[],[],[],[],[],[],[],[],[]]
    index:number=0;
  constructor(private http:HttpClient) { }

  calcRoute(){
   
   console.log("this.route",this.route)
    return  this.http.post(`${environment.BASE_URL}/CalcRoute`,this.route)
      
  }
}
