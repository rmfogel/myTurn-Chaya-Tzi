import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SelectedServicesPage } from './selected-services.page';
import { SelectBusinessComponent } from 'src/app/components/select-business/select-business.component';

const routes: Routes = [
  {
    path: '',
    component: SelectedServicesPage
  },
  {
    path: 'select-bussines',
    component: SelectBusinessComponent
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SelectedServicesPageRoutingModule {}
