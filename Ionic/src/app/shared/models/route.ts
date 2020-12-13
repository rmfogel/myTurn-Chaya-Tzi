import { AreaRange } from './area-range';
import { TimeRange } from './time-range';
import { WalkingBy } from './walking-by';
import { ChoosenBusinessDto } from './choosen-business';

export class Route{
RouteId:number=0;
    UserId:number
    areaRange:AreaRange=new AreaRange();
    timeRange:TimeRange=new TimeRange();
    walkingBy:number
    businessList:number[]=[]
   

}