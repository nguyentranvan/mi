import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VnpkcRoutingModule } from './vnpkc-routing.module';
import { VNPKCHomeComponent } from './vnpkc.component';
import { StyleClassModule } from 'primeng/styleclass';
import { DividerModule } from 'primeng/divider';
import { ChartModule } from 'primeng/chart';
import { PanelModule } from 'primeng/panel';
import { ButtonModule } from 'primeng/button';

@NgModule({
    imports: [
        CommonModule,
        VnpkcRoutingModule,
        DividerModule,
        StyleClassModule,
        ChartModule,
        PanelModule,
        ButtonModule
    ],
    declarations: [VNPKCHomeComponent]
})
export class VnpkcModule { }
