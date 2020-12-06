import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private route: Router) { }

  canActivate(canActive: ActivatedRouteSnapshot, router: RouterStateSnapshot) {
    let user=this.user();
    if (user!=null)
      return true;
    this.route.navigate(['/login']);
    return false;
  }

  user() {

    let user=localStorage.getItem(`${environment.key}`);
      return user;
  }
}
