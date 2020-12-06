import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertController } from '@ionic/angular';
import { User } from 'src/app/shared/models/user';
import { UserService } from 'src/app/shared/services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {
   user:User = {"id":0,"email":"","firstName":"","lastName":"","phoneNumber":""}

 
  
  constructor(private userService: UserService, private route: Router,
    private alertControler: AlertController) {

  }

  ngOnInit() {
  }

  register() {
    console.log(this.user);
    
    this.userService.register(this.user)
      .subscribe((res) => {
        localStorage.setItem(environment.key, JSON.stringify(res));
        this.route.navigate(['/home']);
      }, (err) => {
        console.log(err);
      })
  }

  async btnSave() {
    if (this.user.firstName == "" || this.user.lastName == "" || this.user.email == ""|| this.user.phoneNumber == "") {
      const alert = await this.alertControler.create({
        header: "!רגע",
        message: "השארת שדות ריקים ",
        buttons: ["OK"],
        id:"alert"
      });
      await alert.present();
    }
    else 
      this.register();
    

  }

}
