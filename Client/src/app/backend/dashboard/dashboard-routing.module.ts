import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { AuthGuardService } from 'src/app/lib/services/guard.service';
import { AppLayoutComponent } from 'src/app/layout/app.layout.component';

@NgModule({
    imports: [RouterModule.forChild([
            { path: '', component: DashboardComponent },
            { path: 'certificate', loadChildren: () => import('../ACertificate/ACertificate.module').then(m => m.ACertificateModule) }
        ])],
    exports: [RouterModule]
})
export class DashboardsRoutingModule { }
