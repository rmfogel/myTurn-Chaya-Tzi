import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreateRoutePage } from './create-route.page';

const routes: Routes = [
  {
    path: '',
    component: CreateRoutePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreateRoutePageRoutingModule {}
