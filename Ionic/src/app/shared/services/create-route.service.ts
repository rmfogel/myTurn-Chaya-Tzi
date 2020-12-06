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
  constructor(private http:HttpClient) { }

  calcRoute(){
    if (localStorage.getItem('r') == null || JSON.parse(localStorage.getItem('r')).businessList.length == 0)
    localStorage.setItem('r',JSON.stringify(this.route));
    else this.route = JSON.parse(localStorage.getItem('r'))
   console.log("this.route",this.route)
    return  this.http.post(`${environment.BASE_URL}/CalcRoute`,this.route)
      
  }
}
