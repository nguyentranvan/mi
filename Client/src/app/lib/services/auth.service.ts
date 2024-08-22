import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { UserModel } from '../models/UserModel';
import { jwtDecode } from 'jwt-decode';

@Injectable()
export class AuthService {

  private isAuthenticated = false;

  constructor(private oauthService: OAuthService) { 

    this.isAuthenticated = this.oauthService.hasValidAccessToken();
  }
  isAuthenticatedUser(): boolean {
    return this.isAuthenticated;
  }

  getCurrentUser(): UserModel {
    const result = new UserModel();
    if (this.oauthService.hasValidAccessToken()) {
        const access_token = this.oauthService.getAccessToken();
        if (access_token) {
            const user = <any>jwtDecode(access_token);
            result.displayname = user.displayname;
            result.email = user.email;
            result.userid = user.userid;
            result.username = user.username;
        }
    }
    return result;
}
}