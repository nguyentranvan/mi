import { Component } from '@angular/core';
import { OAuthService, OAuthStorage } from 'angular-oauth2-oidc';
import { LayoutService } from 'src/app/layout/service/app.layout.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styles: [`
        :host ::ng-deep .pi-eye,
        :host ::ng-deep .pi-eye-slash {
            transform:scale(1.6);
            margin-right: 1rem;
            color: var(--primary-color) !important;
        }
    `]
})
export class LoginComponent {

    valCheck: string[] = ['remember'];
    password!: string;
    isBusy = false;

    model: any = {
        username: "",
        password: "",
        captcha: ""
    };

    constructor(
        public layoutService: LayoutService,
        private authService: OAuthService,
        private authStorage: OAuthStorage,
    ) { }


    login(){
        this.isBusy = true;
        this.authService
            .fetchTokenUsingPasswordFlow(
                this.model.username,
                encodeURIComponent(this.model.password)
            )
            .then(
                result => {
                    this.redirectURL();
                },
                error => {
                }
            ).catch(() => this.isBusy = false);
    }
    redirectURL() {
        window.location.replace("/admin");
    }
}
