import { NgModule } from '@angular/core';
import { HashLocationStrategy, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import { NotfoundComponent } from './demo/components/notfound/notfound.component';
import { ProductService } from './demo/service/product.service';
import { CountryService } from './demo/service/country.service';
import { CustomerService } from './demo/service/customer.service';
import { EventService } from './demo/service/event.service';
import { IconService } from './demo/service/icon.service';
import { NodeService } from './demo/service/node.service';
import { PhotoService } from './demo/service/photo.service';
import { AuthService } from './lib/services/auth.service';
import { AuthGuardService } from './lib/services/guard.service';
import { OAuthModule, OAuthService, OAuthStorage } from 'angular-oauth2-oidc';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
export function createTranslateLoader(http: HttpClient) {
    return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}


@NgModule({
    declarations: [AppComponent, NotfoundComponent],
    imports: [
        AppRoutingModule,
        AppLayoutModule,  
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        OAuthModule.forRoot(),
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: createTranslateLoader,
                deps: [HttpClient]
            }
        })
    ],
    providers: [
        { provide: LocationStrategy, useClass: PathLocationStrategy },
        CountryService, CustomerService, EventService, IconService, NodeService,
        PhotoService, ProductService,
        AuthGuardService,
        AuthService,
        OAuthService,
        {
        provide: OAuthStorage,
        useValue: localStorage,
        }
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
