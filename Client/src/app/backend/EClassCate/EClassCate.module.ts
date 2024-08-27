import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { EClassCateRoutingModule } from './EClassCate-routing.module';
import { ClassCateComponent } from './ClassCate/ClassCate.component';
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
import { MenubarModule } from 'primeng/menubar';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { EClassCateService } from './Services/ClassCate.service';
import { HttpClientModule } from '@angular/common/http';
import { LibModule } from 'src/app/lib/libModule';
import { TranslateModule } from '@ngx-translate/core';
@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,
        EClassCateRoutingModule,
        LibModule,
        TranslateModule,
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
    declarations: [ClassCateComponent],
    providers: [
        EClassCateService
    ]
})
export class EClassCateModule { }
