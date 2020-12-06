import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CreateRoutePageRoutingModule } from './create-route-routing.module';

import { CreateRoutePage } from './create-route.page';
import {AgmCoreModule} from '@agm/core'
import {GooglePlaceModule} from 'ngx-google-places-autocomplete'
import {NgxLoadingModule, ngxLoadingAnimationTypes} from 'ngx-loading'
import { SelectBusinessComponent } from 'src/app/components/select-business/select-business.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CommonModule ,
    CreateRoutePageRoutingModule,
    GooglePlaceModule,
    NgxLoadingModule.forRoot({
      animationType: ngxLoadingAnimationTypes.threeBounce,
      backdropBackgroundColour: 'rgba(0,0,0,0)', 
      backdropBorderRadius: '0.01px',
      primaryColour: 'green', 
      secondaryColour: 'green', 
      tertiaryColour: 'green'
    }),
    AgmCoreModule.forRoot(  {
      apiKey: 'AIzaSyD7Wui1ikC-x4CMLYBpPz-8Yutf2l3glNo',
     libraries: ["places"]
    })

  ],
  declarations: [
    CreateRoutePage,
    SelectBusinessComponent
    ]
})
export class CreateRoutePageModule {}
