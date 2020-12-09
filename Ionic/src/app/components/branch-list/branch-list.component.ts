import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Branch } from 'src/app/shared/models/branch';
import { BusinessService } from 'src/app/shared/services/business.services';
import { CreateRouteService } from 'src/app/shared/services/create-route.service';

@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.scss'],
})
export class BranchListComponent implements OnInit {
  @Input('businessId') businessId:number;
  @Input('selectBranch') selectBranch:boolean=false;
  branchList:Branch[]=[];
  allBranches:Branch[]=[];
  selectedBranch:number=0;
  constructor(private route:ActivatedRoute,private bussinesService:BusinessService,
    private router:Router,
    private createRouteService:CreateRouteService) { }

  ngOnInit() {
   // this.route.params.subscribe(params => {
     // this.businessId = +params['id'];
     if(this.selectBranch)
      this.loadBranches();
   // })
  }


  loadBranches() {
    this.bussinesService.getBranchList(this.businessId).subscribe((res: Branch[]) => { this.branchList = res; this.allBranches=res; });
  }
  loudService(branch)
  {
    this.createRouteService.curentlyChosenDisplay[this.createRouteService.route.businessList.length][1] = branch.adress;

      this.selectedBranch=branch.id;
  }

  filterBranches(event) {
    this.branchList = this.allBranches.filter(b =>
      b.adress.indexOf(event.srcElement.value) > -1
    )
  }
}
