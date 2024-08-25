import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VnpkcRoutingModule } from './vnpkc-routing.module';
import { VNPKCHomeComponent } from './vnpkc.component';
import { StyleClassModule } from 'primeng/styleclass';
import { DividerModule } from 'primeng/divider';
import { ChartModule } from 'primeng/chart';
import { PanelModule } from 'primeng/panel';
import { ButtonModule } from 'primeng/button';
import { LibModule } from 'src/app/lib/libModule';
import { ToastModule } from 'primeng/toast';

@NgModule({
    imports: [
        CommonModule,
        LibModule,
        VnpkcRoutingModule,
        DividerModule,
        StyleClassModule,
        ChartModule,
        PanelModule,
        ToastModule,
        ButtonModule
    ],
    declarations: [VNPKCHomeComponent]
})
export class VnpkcModule { }
