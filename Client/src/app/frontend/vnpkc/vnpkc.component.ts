import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { UserModel } from 'src/app/lib/models/UserModel';
import { AuthService } from 'src/app/lib/services/auth.service';

@Component({
    selector: 'app-vnpkc',
    styleUrls: ['./vnpkc.component.scss'],
    templateUrl: './vnpkc.component.html'
})
export class VNPKCHomeComponent implements OnInit {

    currentUser: UserModel;
    isLogin = false;
    constructor(
        public layoutService: LayoutService,
        public router: Router,
        private authService: AuthService) { }

    ngOnInit(): void {
        this.isLogin = this.authService.isAuthenticatedUser();
        if (this.isLogin)
            this.currentUser = this.authService.getCurrentUser();
    }

    logout(){
        this.authService.logout();
    }
}
