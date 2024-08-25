import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { OAuthService, OAuthStorage } from 'angular-oauth2-oidc';
import { MessageService } from 'primeng/api';
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
        private translate: TranslateService,
        private messageService: MessageService,
        private authService: OAuthService,
    ) { }


    login() {
        this.isBusy = true;
        this.authService
            .fetchTokenUsingPasswordFlow(this.model.username, encodeURIComponent(this.model.password))
            .then(result => {
                    this.messageService.add({ severity: 'success', 
                                            summary: this.translate.instant("MSG_LOGIN_SUCCESS"),
                                            detail: this.translate.instant("MSG_LOGIN_SUCCESS_DETAIL")});
                    this.redirectURL();
                },
                error => {
                    this.messageService.add({
                        severity: 'error',
                        summary: this.translate.instant("MSG_LOGIN_ERROR"),
                        detail: this.translate.instant("MSG_LOGIN_ERROR_DETAIL")
                    });
                }
            ).catch(() => {
                this.isBusy = false;
                this.messageService.add({
                    severity: 'error',
                    summary: this.translate.instant("MSG_LOGIN_ERROR"),
                    detail: this.translate.instant("MSG_LOGIN_ERROR_DETAIL")
                });
            });
    }
    redirectURL() {
        window.location.replace("/");
    }
}
