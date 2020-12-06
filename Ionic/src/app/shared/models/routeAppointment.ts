import { Route } from './route';
import { Appointment } from './appointment';
import { Time } from '@angular/common';
import { PointOnMap } from './pointOnMap';

export class RouteAppointment
{
     RouteId :number
         UserId :number
         Date :Date
         StartTime :Time
       EndTime :Time
       StartPoint :PointOnMap
    EndPoint: PointOnMap
         WalkingBy :number
    Appointments:Appointment[];
        
}