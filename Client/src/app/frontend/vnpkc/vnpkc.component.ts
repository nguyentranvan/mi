import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LayoutService } from 'src/app/layout/service/app.layout.service';

@Component({
    selector: 'app-vnpkc',
    styleUrls: ['./vnpkc.component.scss'],
    templateUrl: './vnpkc.component.html'
})
export class VNPKCHomeComponent {

    constructor(public layoutService: LayoutService, public router: Router) { }
    
}
