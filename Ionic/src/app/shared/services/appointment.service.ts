import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Result } from '../models/result';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http: HttpClient) { }

  deleteAppointment(id): Observable<Result> {
    return this.http.get<Result>(`${environment.BASE_URL}/Appointment/get/${id}`)

  }
}