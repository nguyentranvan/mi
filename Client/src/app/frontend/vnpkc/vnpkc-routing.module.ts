import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { VNPKCHomeComponent } from './vnpkc.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', component: VNPKCHomeComponent }
    ])],
    exports: [RouterModule]
})
export class VnpkcRoutingModule { }
