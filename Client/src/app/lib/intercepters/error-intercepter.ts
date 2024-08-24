import { Injectable } from "@angular/core";

import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpResponse,
} from "@angular/common/http";

import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/do";
import { HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";
import { OAuthStorage } from "angular-oauth2-oidc";
import { environment } from "../../../environments/environment";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private _router: Router, private _authStorage: OAuthStorage) {}
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        return next.handle(req).do(
            (event: HttpEvent<any>) => {},
            (err: any) => {
                if (err instanceof HttpErrorResponse) {
                    if (!req.url.includes("notification")) {
                    }
                     if (err.status == 401) {
                         if (this._authStorage.getItem("access_token")) {
                             this._authStorage.removeItem("access_token");
                         }
                         var currentUrl = window.location.href;
                         window.location.href = `${environment.clientDomain.loginUrl}?action=signout&continue=${currentUrl}`;
                    }
                }
            }
        );
    }
}
