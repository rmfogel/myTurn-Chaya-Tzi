import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MapResultPage } from './map-result.page';

const routes: Routes = [
  {
    path: '',
    component: MapResultPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MapResultPageRoutingModule {}
