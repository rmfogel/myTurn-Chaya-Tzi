import { Component, OnInit } from '@angular/core';
import { CreateRouteService } from 'src/app/shared/services/create-route.service';
import { Result } from 'src/app/shared/models/result';
import { Router } from '@angular/router';

@Component({
  selector: 'app-selected-services',
  templateUrl: './selected-services.page.html',
  styleUrls: ['./selected-services.page.scss'],
})
export class SelectedServicesPage implements OnInit {

  constructor(public routeService:CreateRouteService,
    private router:Router) { }

  ngOnInit() {
    
  }

  removeService(i) {
    this.routeService.route.businessList.splice(i,1)
    this.routeService.curentlyChosenDisplay[i]=[];
  }

  goToResult() {
    this.routeService.calcRoute().subscribe((res: Result) => {
      console.log("res", res);
      this.router.navigate(["map-result", JSON.stringify(res)])
    });
  }
}
