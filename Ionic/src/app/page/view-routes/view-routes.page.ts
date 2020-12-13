import { Component, OnInit } from '@angular/core';
import { RouteService } from 'src/app/shared/services/route.service';
import { RouteAppointment } from 'src/app/shared/models/routeAppointment';
import { Result } from 'src/app/shared/models/result';
import { Router } from '@angular/router';
import { Route } from 'src/app/shared/models/route';
import { TimeRange } from 'src/app/shared/models/time-range';
import { AreaRange } from 'src/app/shared/models/area-range';
import { CreateRouteService } from 'src/app/shared/services/create-route.service';

@Component({
  selector: 'app-view-routes',
  templateUrl: './view-routes.page.html',
  styleUrls: ['./view-routes.page.scss'],
})
export class ViewRoutesPage implements OnInit {
  routes:RouteAppointment[]=[];
  constructor(private routeService:RouteService,
    private router:Router,
    private createRouteService:CreateRouteService) { }

  ngOnInit() {
    this.routeService.getUsersRouts().subscribe(res=>this.routes=res)
  }

  openMap(route: RouteAppointment)
  {
    debugger
    let res=new Result();
    res.GoodApointments=route.Appointments;
    res.Origion=route.StartPoint;
    res.Destination=route.EndPoint;
    res.ActualStartTime=route.StartTime;
    res.ActualEndTime=route.EndTime;
    this.router.navigate(['map-result',JSON.stringify(res)])
  }

  updateRoute(r:RouteAppointment)
  {
    let route:Route=new Route();
    route.UserId=r.UserId;
    route.walkingBy = r.WalkingBy;
    route.timeRange=new TimeRange();
    route.timeRange.StartingTime =String(r.StartTime);
    route.timeRange.EndTime = String(r.EndTime);

    route.areaRange = new AreaRange();
    route.areaRange.startingPoint = r.StartPoint.formatedAddress
    route.areaRange.destinationPoint = r.EndPoint.formatedAddress;
    route.timeRange.Day=String(r.Date);
    let i=0;
    for(let ap of r.Appointments)
    {
      this.createRouteService.curentlyChosenDisplay[i]=[ap.Bussiness.name,ap.Address.formatedAddress,ap.Service.name]
    this.createRouteService.route.businessList.push(ap.Service.id)
    }

    this.router.navigate(['create-route',JSON.stringify(route)])
  }

}
