import { Appointment } from './appointment';
import { PointOnMap } from './pointOnMap';
import { Time } from '@angular/common';

export class Result
{
     GoodApointments :Appointment[]
     NotGoodRange: Appointment[]
     NoFree: Appointment[]
     Origion: PointOnMap
     Destination: PointOnMap
     ActualStartTime:Time
     ActualEndTime:Time
}