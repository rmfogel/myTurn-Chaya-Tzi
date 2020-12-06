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

  businessId:number
  branchId: number=0;

  serviceList:ServiceDto[];
  constructor( private serviseOfBusiness:ServiceOfBusinessService,
    private route:ActivatedRoute,
    private createRouteService:CreateRouteService,
    private alertControler: AlertController,
    private router:Router)
   { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.businessId = +params['id']; 
      if (params['branchId']!=null)
      this.branchId = +params['branchId'];
    
      this.loadServices();
  })}


  loadServices(){
    this.serviseOfBusiness.getServicesList(this.businessId,this.branchId).subscribe((res:ServiceDto[])=>{this.serviceList=res;console.log(this.serviceList);} );
  }

  async choose(serviceId:number){
 
    if(this.createRouteService.route.businessList.indexOf(serviceId) > -1)
    { const alert = await this.alertControler.create({
      header: "",
      message: "!ניתן לבחור שרות אחד בלבד",
      buttons: ["OK"],
      id:"alert"
    });
    await alert.present();
   }
  else{
    debugger;this.createRouteService.route.businessList.push(serviceId);
    console.log(this.createRouteService.route)
  }
  console.log(this.createRouteService.route)

  }

  goToResult()
  {
    this.createRouteService.calcRoute().subscribe((res: Result) => {
      console.log("res", res);
      this.router.navigate(["map-result",JSON.stringify(res)])
    });
  }
 
   


}
