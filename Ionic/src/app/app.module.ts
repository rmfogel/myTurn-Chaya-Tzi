import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';
import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import{ HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { SelectBusinessComponent } from './components/select-business/select-business.component';
import { FormsModule } from '@angular/forms';
import { BusinessDetailsComponent } from './components/business-details/business-details.component';
import { AgmCoreModule } from '@agm/core';
import { AutoCompleteModule } from 'ionic4-auto-complete';
import { BranchListComponent } from './components/branch-list/branch-list.component';

@NgModule({
  declarations: [
    AppComponent,
 
    
    
  ],
  entryComponents: [],
  imports: [
   FormsModule,
    HttpClientModule,
    BrowserModule,
    IonicModule.forRoot(),
     AppRoutingModule,
     AgmCoreModule.forRoot({
      apiKey: 'AIzaSyD7Wui1ikC-x4CMLYBpPz-8Yutf2l3glNo'
    }),
    AutoCompleteModule
    ],

  providers: [
    StatusBar,
    SplashScreen,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy }
  ],
  exports:[
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
