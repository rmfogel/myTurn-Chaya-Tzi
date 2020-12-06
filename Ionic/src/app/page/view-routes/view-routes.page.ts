import { Component, OnInit } from '@angular/core';
import { RouteService } from 'src/app/shared/services/route.service';
import { RouteAppointment } from 'src/app/shared/models/routeAppointment';
import { Result } from 'src/app/shared/models/result';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-routes',
  templateUrl: './view-routes.page.html',
  styleUrls: ['./view-routes.page.scss'],
})
export class ViewRoutesPage implements OnInit {
  routes:RouteAppointment[]=[];
  constructor(private routeService:RouteService,
    private router:Router) { }

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
    this.router.navigate(['map-result',JSON.stringify(res)])
  }

}
