import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ClassCateComponent } from './ClassCate/ClassCate.component';

@NgModule({
    imports: [RouterModule.forChild([
         { path: '', component: ClassCateComponent }
    ])],
    exports: [RouterModule]
})
export class EClassCateRoutingModule { }
