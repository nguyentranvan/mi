import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { AuthGuardService } from 'src/app/lib/services/guard.service';

@NgModule({
    imports: [RouterModule.forChild([
            { path: '', component: DashboardComponent },
            { path: 'certificate', canActivate: [AuthGuardService], loadChildren: () => import('../ACertificate/ACertificate.module').then(m => m.ACertificateModule) }
        ])],
    exports: [RouterModule]
})
export class DashboardsRoutingModule { }
