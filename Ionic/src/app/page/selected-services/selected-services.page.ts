import { Component, OnInit } from '@angular/core';
import { CreateRouteService } from 'src/app/shared/services/create-route.service';

@Component({
  selector: 'app-selected-services',
  templateUrl: './selected-services.page.html',
  styleUrls: ['./selected-services.page.scss'],
})
export class SelectedServicesPage implements OnInit {

  constructor(public routeService:CreateRouteService) { }

  ngOnInit() {
    
  }

  removeService(i) {
    this.routeService.route.businessList.splice(i,1)
    this.routeService.curentlyChosenDisplay[i]=[];
  }
}
