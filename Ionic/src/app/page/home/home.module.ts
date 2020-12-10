import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { HomePage } from './home.page';
import { HomePageRoutingModule } from './home-routing.module';
import {AgmCoreModule} from '@agm/core'
import {GooglePlaceModule} from 'ngx-google-places-autocomplete'
import {NgxLoadingModule, ngxLoadingAnimationTypes} from 'ngx-loading'


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
  
    IonicModule,
    HomePageRoutingModule,
    
   
  ],
  declarations: [
    HomePage,
    
    ]
})
export class HomePageModule {}
