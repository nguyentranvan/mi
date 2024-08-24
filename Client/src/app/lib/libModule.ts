import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { FileUploadModule } from 'primeng/fileupload';
import { RippleModule } from 'primeng/ripple';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { RatingModule } from 'primeng/rating';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputNumberModule } from 'primeng/inputnumber';
import { DialogModule } from 'primeng/dialog';
import { MessageService } from 'primeng/api';
import { MenubarModule } from 'primeng/menubar';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { OAuthStorage } from 'angular-oauth2-oidc';
import { AuthorizationIntercepter } from 'src/app/lib/intercepters/authorization-intercepter';
@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,
        TableModule,
        FileUploadModule,
        FormsModule,
        ButtonModule,
        RippleModule,
        ToastModule,
        ToolbarModule,
        RatingModule,
        InputTextModule,
        InputTextareaModule,
        DropdownModule,
        RadioButtonModule,
        InputNumberModule,
        DialogModule,
        MenubarModule,
        BreadcrumbModule
    ],
    declarations: [],
    providers: [
        MessageService,
        {
            provide: OAuthStorage,
            useValue: localStorage
        },
        { provide: HTTP_INTERCEPTORS, useClass: AuthorizationIntercepter, multi: true}
    ]
})
export class LibModule {
    static forRoot() {
        return {
            ngModule: LibModule
        };
    }
 }
