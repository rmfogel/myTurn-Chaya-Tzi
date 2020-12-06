import { Component, OnInit } from '@angular/core';
import { Result } from 'src/app/shared/models/result';
import { CreateRouteService } from 'src/app/shared/services/create-route.service';
import { PointOnMap } from 'src/app/shared/models/pointOnMap';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-map-result',
  templateUrl: './map-result.page.html',
  styleUrls: ['./map-result.page.scss'],
})
export class MapResultPage implements OnInit {
  reult:Result=new Result();
  lat = 41.85;
  lng = -87.65;

  origin = { lat:0, lng: 0};
  destination = { lat: 0, lng:0 };

  public renderOptions = {
    suppressMarkers: false
  }
  public markerOptions = {
    origin: {
      infoWindow: 'התחלה.',
   //   icon: 'http://i.imgur.com/7teZKif.png',
    },
    waypoints: [
      
       ],
    destination: {
      infoWindow: 'סיום',
     // icon: 'http://i.imgur.com/7teZKif.png',
    },
  };

  
  waypoints = [];
  constructor(private createRouteService:CreateRouteService,
    private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(
      p=>{
        this.reult =JSON.parse(p.result);
      this.createMapLocations();
      this.renderOptions.suppressMarkers=true;
      });
   

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
  
}
