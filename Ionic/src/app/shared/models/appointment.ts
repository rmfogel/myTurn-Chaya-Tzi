import { BusinessDto } from './business';
import { ServiceDto } from './service';
import { ShiftDayDetails } from './dayDetails';
import { PointOnMap } from './pointOnMap';

export class Appointment{
         id :number;
         hour :Date;
         userId :number;
         Service :ServiceDto;
         Address :PointOnMap;
         Bussiness: BusinessDto;
         Day: ShiftDayDetails;
         DurationService : number 

 }