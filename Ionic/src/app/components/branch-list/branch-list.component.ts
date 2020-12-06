import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Branch } from 'src/app/shared/models/branch';
import { BusinessService } from 'src/app/shared/services/business.services';

@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.scss'],
})
export class BranchListComponent implements OnInit {
  businessId:number;
  branchList:Branch[]=[];
  allBranches:Branch[]=[];
  constructor(private route:ActivatedRoute,private bussinesService:BusinessService,
    private router:Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.businessId = +params['id'];
      this.loadBranches();
    })
  }


  loadBranches() {
    this.bussinesService.getBranchList(this.businessId).subscribe((res: Branch[]) => { this.branchList = res; this.allBranches=res; });
  }
  loudService(branch)
  {
    this.router.navigate(['/business-details', this.businessId,branch.id]);  }
}
