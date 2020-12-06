import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { RouteAppointment } from '../models/routeAppointment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private router: Router) { }



logIn(email: string, phoneNumber: string): Observable<any> {
  return this
    .http
    .get<any>(`${environment.BASE_URL}/User`, { params: { email, phoneNumber } })
}





logOut() {
  localStorage.removeItem(environment.key);
  this.router.navigate(['/login']);
}

currentUser() {
  if (localStorage.getItem(environment.key))
    return JSON.parse( localStorage.getItem(environment.key));
  return false;
}

register(user:User): Observable<any> {
  return this
    .http
    .post<Observable<any>>(`${environment.BASE_URL}/User`, user);
    
}

}
