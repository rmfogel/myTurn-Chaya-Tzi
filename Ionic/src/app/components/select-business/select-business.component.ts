import { Component, OnInit,Output,EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { BusinessDto } from 'src/app/shared/models/business';
import { Category } from 'src/app/shared/models/category';
import { ChoosenBusinessDto } from 'src/app/shared/models/choosen-business';
import { ServiceDto } from 'src/app/shared/models/service';
import { BusinessService } from 'src/app/shared/services/business.services';
import { CategoryService } from 'src/app/shared/services/category.service';
import { CreateRouteService } from 'src/app/shared/services/create-route.service';
import { ServiceOfBusinessService } from 'src/app/shared/services/service-of-business.service';





@Component({
  selector: 'app-select-business',
  templateUrl: './select-business.component.html',
  styleUrls: ['./select-business.component.scss'],
})
export class SelectBusinessComponent implements OnInit {

  
  businessList:BusinessDto[]=[]
  allBussinesses: BusinessDto[] = []
  currentModal:any=null
  
  categoryList:Category[]=[];
  allCategories: Category[] = [];

  choosenBusinessId:number;
   
  constructor(private bussinessService:BusinessService,
    private categoryService:CategoryService,
    private serviseOfBusiness :ServiceOfBusinessService,
    private createRouteService:CreateRouteService,
    private router:Router) { }

  ngOnInit() {
    this.loudCategories()}

  loadBusinesses(event){

    let id = event.target.id ;
   
    console.log('category.id',id)
    this.bussinessService.getBusinessList(id)
    .subscribe((res)=>{this.businessList=res;
      this.allBussinesses=res;
    console.log('business',res)})
  }

  loudCategories(){
    this.categoryService.getCategoriesList()
    .subscribe((res)=>{this.categoryList=res;
      this.allCategories=res;
    })
  }

  loudService(id){
    this.choosenBusinessId= id;
    this.router.navigate(['/business-details',this.choosenBusinessId]);
   
    
  }

  filterBussines(event)
  {
    this.businessList=this.allBussinesses.filter(b=>
      b.name.indexOf(event.srcElement.value)>-1
      )
  }

  filterCategories(event) {
    this.categoryList = this.allCategories.filter(b =>
      b.name.indexOf(event.srcElement.value) > -1
    )
  }

  loudBranches(id) {
    this.router.navigate(['/branch-list', id]);
  }



  
 
 
}
