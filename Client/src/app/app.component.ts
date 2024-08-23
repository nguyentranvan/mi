import { Component, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
import { OAuthService } from 'angular-oauth2-oidc';
import { AppConfig, LayoutService } from './layout/service/app.layout.service';
import { authCodeFlowConfig } from './lib/config/OAuthConfig';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

    constructor(
        private primengConfig: PrimeNGConfig, 
        private layoutService: LayoutService,
        private oauthService: OAuthService) { }

    ngOnInit() {
        this.primengConfig.ripple = true;
        const config: AppConfig = {
            ripple: true,                      //toggles ripple on and off
            inputStyle: 'outlined',             //default style for input elements
            menuMode: 'static',                 //layout mode of the menu, valid values are "static" and "overlay"
            colorScheme: 'light',               //color scheme of the template, valid values are "light" and "dark"
            theme: 'bootstrap4-light-purple',         //default component theme for PrimeNG
            scale: 14                           //size of the body font size to scale the whole application
        };
        this.layoutService.config.set(config);
        this.oauthService.configure(authCodeFlowConfig);
        this.oauthService.setupAutomaticSilentRefresh();
    }
}
