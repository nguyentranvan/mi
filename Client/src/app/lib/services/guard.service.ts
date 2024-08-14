import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Injectable } from '@angular/core';
import { appConfig } from '../config/AppConfig';


@Injectable()
export class AuthGuardService  implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean {
    return this.checkAuth();
  }


  private checkAuth(): boolean {
    return true;
    if (this.authService.isAuthenticatedUser()) {
      return true;
    } else {
      this.router.navigate([appConfig.urlLogin]);
      return false;
    }
  }

}