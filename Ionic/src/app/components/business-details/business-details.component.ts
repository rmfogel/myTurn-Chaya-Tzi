import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceDto } from 'src/app/shared/models/service';
import { ServiceOfBusinessService } from 'src/app/shared/services/service-of-business.service';
import { AlertController } from '@ionic/angular';
import { CreateRouteService } from 'src/app/shared/services/create-route.service';
import { Result } from 'src/app/shared/models/result';
@Component({
  selector: 'app-business-details',
  templateUrl: './business-details.component.html',
  styleUrls: ['./business-details.component.scss'],
})
export class BusinessDetailsComponent implements OnInit {

  @Input()  businessId:number
 @Input() branchId: number=0;
 

  serviceList:ServiceDto[];
  constructor( private serviseOfBusiness:ServiceOfBusinessService,
    private route:ActivatedRoute,
    private createRouteService:CreateRouteService,
    private alertControler: AlertController,
    private router:Router)
   { }

  ngOnInit() {
      this.loadServices();
  }


  loadServices(){
    this.serviseOfBusiness.getServicesList(this.businessId,this.branchId).subscribe((res:ServiceDto[])=>{this.serviceList=res;console.log(this.serviceList);} );
  }

  async choose(service){
 
    if(this.createRouteService.route.businessList.indexOf(service.id) > -1)
    { 
      this.createRouteService.curentlyChosenDisplay[this.createRouteService.route.businessList.length]= [];

      const alert = await this.alertControler.create({
      header: "",
      message: "!ניתן לבחור שרות פעם אחת בלבד",
      buttons: ["OK"],
      id:"alert"
    });
    await alert.present();
   }
  else{
    debugger;this.createRouteService.route.businessList.push(service.id);
    console.log(this.createRouteService.route)
  }
  console.log(this.createRouteService.route)
    this.createRouteService.curentlyChosenDisplay[this.createRouteService.route.businessList.length-1][2] = service.name;

    this.router.navigate(['selected-services'])
  }

  goToResult()
  {
    this.createRouteService.calcRoute().subscribe((res: Result) => {
      console.log("res", res);
      this.router.navigate(["map-result",JSON.stringify(res)])
    });
  }
 
   


}
