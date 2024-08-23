import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CertificateComponent } from './Certificate/Certificate.component';

@NgModule({
    imports: [RouterModule.forChild([
         { path: '', component: CertificateComponent }
    ])],
    exports: [RouterModule]
})
export class ACertificateRoutingModule { }
