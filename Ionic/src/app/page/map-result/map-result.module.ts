import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MapResultPageRoutingModule } from './map-result-routing.module';

import { MapResultPage } from './map-result.page';
import { AgmDirectionModule } from 'agm-direction'
import { AgmCoreModule } from '@agm/core';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MapResultPageRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyD7Wui1ikC-x4CMLYBpPz-8Yutf2l3glNo'
    }),
    AgmDirectionModule
  ],
  declarations: [MapResultPage]
})
export class MapResultPageModule {}
