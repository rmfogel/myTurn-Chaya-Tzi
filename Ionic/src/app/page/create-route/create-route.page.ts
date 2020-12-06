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


@Component({
  selector: 'app-create-route',
  templateUrl: './create-route.page.html',
  styleUrls: ['./create-route.page.scss'],
})
export class CreateRoutePage implements OnInit {

  areaRange:AreaRange=new AreaRange();
  timeRange:TimeRange=new TimeRange();
  walkingBy:WalkingBy=WalkingBy.Car
  businessList:number[]=[]
  route:Route=new Route();

  constructor(
    public modalController: ModalController,
    private bussinessService:BusinessService,
    private createRouteService:CreateRouteService,
    private userService:UserService,
    ) { }

  ngOnInit() {}

  saveDetails(){
    console.log('this.areaRange.destinationPoint',this.areaRange.destinationPoint)
    console.log('this.areaRange.startingPoint',this.areaRange.startingPoint)
    console.log('this.timeRange.day',this.timeRange.Day)
    console.log('this.timeRange.endTime',this.timeRange.EndTime)
    console.log('this.timeRange.startTime',this.timeRange.StartingTime)
    console.log('this.walkingBy',this.walkingBy)
   
    this.route.UserId=this.userService.currentUser().id;
    this.route.areaRange=this.areaRange;
    this.route.timeRange=this.timeRange;
    if(this.walkingBy=WalkingBy.Car)
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
    this.areaRange.destinationPoint=destination.formatted_address;
   
  }

  handlestartingPointChange(starting:Address){
    
    console.log("starting; ",starting);
   this.areaRange.startingPoint=starting.formatted_address;
  }


}
