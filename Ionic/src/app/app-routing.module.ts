import { CommonModule } from '@angular/common';
import { NgModule, Component } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { CreateRoutePage } from './page/create-route/create-route.page';
import { AuthService } from './shared/services/auth.service';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./page/start/start.module').then( m => m.StartPageModule)
  },
 
  {
    path: 'home',
    loadChildren: () => import('./page/home/home.module').then( m => m.HomePageModule)
  },
 
 
  
  {
    path: 'register',
    loadChildren: () => import('./page/register/register.module').then( m => m.RegisterPageModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./page/login/login.module').then( m => m.LoginPageModule)
  },

  {
    path: 'create-route', canActivate: [AuthService],
    loadChildren: () => import('./page/create-route/create-route.module').then( m => m.CreateRoutePageModule)
  },
  // {
  //   path: 'create-route',
  //   component:CreateRoutePage,canActivate:[AuthService]
  // },
  // {
  //   path: 'create-route',
  //   component:CreateRoutePage
  //   //,canActivate:[AuthService]
  // },
  
  {
    path: 'map-result/:result',
    loadChildren: () => import('./page/map-result/map-result.module').then( m => m.MapResultPageModule)
  },
  {
    path: 'view-routes',
    loadChildren: () => import('./page/view-routes/view-routes.module').then( m => m.ViewRoutesPageModule)
  },
  {
    path: 'selected-services',
    loadChildren: () => import('./page/selected-services/selected-services.module').then( m => m.SelectedServicesPageModule)
  }
  
];

@NgModule({
  imports: [
    CommonModule ,
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
