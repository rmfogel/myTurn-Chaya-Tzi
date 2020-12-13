import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BusinessService } from 'src/app/shared/services/business.services';
import { UserService } from 'src/app/shared/services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  email: string;
  phoneNumber: string;

  constructor( private router: Router,private UserService:UserService) { }

  ngOnInit() {
    if (localStorage.getItem(environment.key)!=null)
      this.router.navigate(['/view-routes'])
  }

  logIn() {
    this.UserService
      .logIn(this.email, this.phoneNumber).subscribe(
        (res) => {
          console.log('resultLogin', res);
          localStorage.setItem(environment.key, JSON.stringify(res) );
          this.router.navigate(['/create-route']);
        }, (err) => {
          console.log(err);
          this.router.navigate(['/register'])
          this.email="";
          this.phoneNumber="";
        })
  }


}
