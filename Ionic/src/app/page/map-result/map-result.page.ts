import { Component, OnInit } from '@angular/core';
import { Result } from 'src/app/shared/models/result';
import { CreateRouteService } from 'src/app/shared/services/create-route.service';
import { PointOnMap } from 'src/app/shared/models/pointOnMap';
import { Router, ActivatedRoute } from '@angular/router';
import { AppointmentService } from 'src/app/shared/services/appointment.service';
import { Appointment } from 'src/app/shared/models/appointment';

@Component({
  selector: 'app-map-result',
  templateUrl: './map-result.page.html',
  styleUrls: ['./map-result.page.scss'],
})
export class MapResultPage implements OnInit {
  reult:Result=new Result();
  notRealAppointments:Appointment[]
  lat = 41.85;
  lng = -87.65;

  origin = { lat:0, lng: 0};
  destination = { lat: 0, lng:0 };

  public renderOptions = {
    suppressMarkers: false
  }
  public markerOptions = {
    origin: {
      infoWindow: 'התחלה. שעת יציאה: ',
   //   icon: 'http://i.imgur.com/7teZKif.png',
    },
    waypoints: [
      
       ],
    destination: {
      infoWindow: 'סיום. שעת הגעה' ,
     // icon: 'http://i.imgur.com/7teZKif.png',
    },
  };

  
  waypoints = [];
  constructor(private appointmentService:AppointmentService,
    private route:ActivatedRoute,
    private router:Router) { }

  ngOnInit() {
    this.route.params.subscribe(
      p=>{
        this.reult =JSON.parse(p.result);
        this.notRealAppointments=this.reult.GoodApointments.filter(a=>a.hour==null)
        this.reult.GoodApointments = this.reult.GoodApointments.filter(a => a.hour != null);

      this.createMapLocations();
      this.renderOptions.suppressMarkers=true;
      });
   

  }

  getTimeString(date)
  {
  return new Date(date).toLocaleTimeString();
  }
  funcc()
  {
    debugger
  }
  createMapLocations(){
    this.origin.lat=+this.reult.Origion.Lat;
    this.origin.lng = +this.reult.Origion.Lng;
    this.destination.lat = +this.reult.Destination.Lat;
    this.destination.lng = +this.reult.Destination.Lng;
    this.markerOptions.origin.infoWindow += this.reult.ActualStartTime;
    this.markerOptions.destination.infoWindow += this.reult.ActualEndTime;

    for(let point of this.reult.GoodApointments)
    {
      let s=`${new Date(point.hour).toLocaleTimeString()}
           ${point.Address.formatedAddress}`
      let p: PointOnMap = point.Address;
       this.waypoints = [...this.waypoints, ...[{
        location: { lat: +p.Lat, lng: +p.Lng },
        stopover: false
      }]];
      this.markerOptions.waypoints = [...this.markerOptions.waypoints, ...[{
        infoWindow: `<a routerLink="/view-routes">${s}</a>`
      }]];
    }
  }

  deleteAppointment(id)
  {
    this.appointmentService.deleteAppointment(id).subscribe(res=>{
    this.router.navigate(['map-result',JSON.stringify(res)])})
  }
}
