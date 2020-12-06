import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { RouteAppointment } from '../models/routeAppointment';

@Injectable({
  providedIn: 'root'
})
export class RouteService {

  constructor(private http: HttpClient, private router: Router) { }


getUsersRouts(): Observable <RouteAppointment[]>
  {
  let userId = JSON.parse(localStorage.getItem('currentUser')).id;
    return this
      .http
      .get<any>(`${environment.BASE_URL}/Route`, { params: { userId } })
  }

}

