import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';
import { OAuthStorage } from 'angular-oauth2-oidc';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable()
export class AuthorizationIntercepter implements HttpInterceptor {
    constructor(private _authStorage: OAuthStorage) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        if (this._authStorage.getItem("access_token")) {
            const authenticationToken = this._authStorage.getItem("access_token") || "";
            const authorizationToken  = this._authStorage.getItem("access_token") || "";
            const headers             = req.headers.set('Authorization', `Bearer ${authenticationToken}`).set('X-Authorize', authorizationToken);

            req = req.clone({ headers });
        }
        return next.handle(req);
    }
}
