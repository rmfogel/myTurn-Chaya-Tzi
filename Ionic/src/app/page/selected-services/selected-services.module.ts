import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SelectedServicesPageRoutingModule } from './selected-services-routing.module';

import { SelectedServicesPage } from './selected-services.page';
import { SelectBusinessComponent } from 'src/app/components/select-business/select-business.component';
import { BusinessDetailsComponent } from 'src/app/components/business-details/business-details.component';
import { BranchListComponent } from 'src/app/components/branch-list/branch-list.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SelectedServicesPageRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  declarations: [
    SelectedServicesPage,
    SelectBusinessComponent,
    BusinessDetailsComponent,
    BranchListComponent
  ]
})
export class SelectedServicesPageModule {}
