import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { NotfoundComponent } from './demo/components/notfound/notfound.component';
import { AppLayoutComponent } from "./layout/app.layout.component";
import { AuthGuardService } from './lib/services/guard.service';

@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: '', canActivate: [AuthGuardService], loadChildren: () => import('./frontend/vnpkc/vnpkc.module').then(m => m.VnpkcModule) },
            { path: 'login', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) },
            { path: 'admin', canActivate: [AuthGuardService], component: AppLayoutComponent, loadChildren: () => import('./backend/dashboard/dashboard.module').then(m => m.DashboardModule) },
            {
                path: 'demo', component: AppLayoutComponent,
                children: [
                    { path: 'uikit', loadChildren: () => import('./demo/components/uikit/uikit.module').then(m => m.UIkitModule) },
                    { path: 'utilities', loadChildren: () => import('./demo/components/utilities/utilities.module').then(m => m.UtilitiesModule) },
                    { path: 'documentation', loadChildren: () => import('./demo/components/documentation/documentation.module').then(m => m.DocumentationModule) },
                    { path: 'blocks', loadChildren: () => import('./demo/components/primeblocks/primeblocks.module').then(m => m.PrimeBlocksModule) },
                    { path: 'pages', loadChildren: () => import('./demo/components/pages/pages.module').then(m => m.PagesModule) }
                ]
            },
            { path: 'notfound', component: NotfoundComponent },
            { path: '**', redirectTo: '/notfound' },
        ], { scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload' })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
