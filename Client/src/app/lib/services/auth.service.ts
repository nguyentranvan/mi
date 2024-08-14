import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable()
export class AuthService {

  private isAuthenticated = false;

  constructor(private oauthService: OAuthService) { 

    this.isAuthenticated = this.oauthService.hasValidAccessToken();
  }
  isAuthenticatedUser(): boolean {
    return this.isAuthenticated;
  }
}