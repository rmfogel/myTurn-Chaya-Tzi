import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ViewRoutesPageRoutingModule } from './view-routes-routing.module';

import { ViewRoutesPage } from './view-routes.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ViewRoutesPageRoutingModule
  ],
  declarations: [ViewRoutesPage]
})
export class ViewRoutesPageModule {}
