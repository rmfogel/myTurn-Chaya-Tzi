import { Component, OnInit } from '@angular/core';
import { AreaRange } from 'src/app/shared/models/area-range';
import { TimeRange } from 'src/app/shared/models/time-range';
import { WalkingBy } from 'src/app/shared/models/walking-by';
import { ModalController } from '@ionic/angular';
import { BusinessService } from 'src/app/shared/services/business.services';
import { BusinessDto } from 'src/app/shared/models/business';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { CreateRouteService } from 'src/app/shared/services/create-route.service';
import { Route } from 'src/app/shared/models/route';

import { UserService } from 'src/app/shared/services/user.service';
import { ChoosenBusinessDto } from 'src/app/shared/models/choosen-business';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-create-route',
  templateUrl: './create-route.page.html',
  styleUrls: ['./create-route.page.scss'],
})
export class CreateRoutePage implements OnInit {

  businessList:number[]=[]
  route:Route=new Route();
  walkingBy:WalkingBy=WalkingBy.Car;
  

  constructor(
    public modalController: ModalController,
    private bussinessService:BusinessService,
    private createRouteService:CreateRouteService,
    private userService:UserService,
    private activeRoute:ActivatedRoute
    ) { }

  ngOnInit() {
    this.route.timeRange=new TimeRange();
    this.route.areaRange=new AreaRange();
    this.activeRoute.params.subscribe(
      p=>{
        if(p.route!=null)
        this.route=JSON.parse(p.route)
        console.log(this.route)
      }
    )
  }

  saveDetails(){
   
   
    this.route.UserId=this.userService.currentUser().id;
    if(this.walkingBy==WalkingBy.Car)
    this.route.walkingBy=1;
    else
    this.route.walkingBy=0;
    this.createRouteService.route=this.route;
  console.log("this.calcRouteService.route",this.createRouteService.route)
  }

  // async presentModal() {
  //   const modal = await this.modalController.create({
  //     component: SelectBusinessComponent,
  //     // cssClass: 'my-custom-class'
  //   });
  //   return await modal.present();
  // }
  // loadBusinesses(){
  //   this.bussinessService.getBusinessList()
  //   .subscribe((res)=>{this.businessList=res
  //   })
  // }

   handleDestinationPointChange(destination:Address){
    
    console.log("destination; ",destination);
     this.route.areaRange.destinationPoint=destination.formatted_address;
   
  }

  handlestartingPointChange(starting:Address){
    
    console.log("starting; ",starting);
    this.route.areaRange.startingPoint=starting.formatted_address;
  }


}
