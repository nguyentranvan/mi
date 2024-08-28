import { Component, OnInit, OnDestroy } from '@angular/core';
import { MessageService } from 'primeng/api';
import { PageBaseIndex } from 'src/app/lib/pages/base-page-index';
import { EClassCateService } from '../Services/ClassCate.service';
import { EClassCateModel } from '../Models/EClassCateModel';
import { TranslateService } from '@ngx-translate/core';
import { Guid } from "guid-typescript";
@Component({
    templateUrl: './ClassCate.component.html',
})
export class ClassCateComponent extends PageBaseIndex implements OnInit, OnDestroy {

    itemDialog: boolean = false;
    deleteItemDialog: boolean = false;
    deleteItemsDialog: boolean = false;

    items: EClassCateModel[] = [];
    item: EClassCateModel;
    selectedItems: EClassCateModel[] = [];
    lstParents= [];

    submitted: boolean = false;

    //#region page Function
    constructor(
        private translate: TranslateService,
        private itemService : EClassCateService,
        private messageService: MessageService) {
        super();
    }

    ngOnInit() {
        this.cols = [
            { field: 'code', header: 'Mã' },
            { field: 'name', header: 'Tên danh mục' }
        ];
       this.search();
       this.getParentId();
    }

    ngOnDestroy() {

    }
    doPageChange(event: any): void {
        this.offset = event.first;
        this.limit = event.rows;
        this.search();
    }
    //#endregion

    //#region data Function
    search(){
        this.itemService.search(this.offset, this.limit, this.keyword).then(rs => 
            {
                if(rs.status)
                    this.items = rs.data;
            }
    );
    }
    getParentId(){
        this.itemService.searchByParentId(Guid.createEmpty().toJSON().value).then(rs => 
            {
                if(rs.status)
                {
                    var arr = [];
                    rs.data.forEach((item, index) => {
                        arr.push({ name: item.name, value: item.id });
                    });
                    this.lstParents = arr;
                    console.log(this.lstParents);
                }
                    
            }
        );
        
    }
    openNew() {
        this.item = new EClassCateModel();
        this.submitted = false;
        this.itemDialog = true;
    }
    deleteSelectedItems() {
        this.deleteItemsDialog = true;
    }

    editItem(EClassCateModel: EClassCateModel) {
        this.itemService.detail(EClassCateModel.id).then(rs => {
            if(rs.status)
            {
                this.item = rs.data;
                this.itemDialog = true;
            }
        })
    }

    deleteItem(EClassCateModel: EClassCateModel) {
        this.deleteItemDialog = true;
        this.item = EClassCateModel;
    }

    confirmDeleteSelected() {
        this.deleteItemsDialog = false;
        this.itemService.delete(this.item.id).then(rs => {
            if(rs.status)
            {
                this.messageService.add({ severity: 'success', summary: this.translate.instant("MSG_SUCCESS")});
                this.selectedItems = [];
                this.search();
            }
        })
        //this.products = this.products.filter(val => !this.selectedProducts.includes(val));
        
    }

    confirmDelete() {
        this.deleteItemDialog = false;
        this.itemService.delete(this.item.id).then(rs => {
            if(rs.status)
            {
                this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Products Deleted', life: 3000 });
                this.selectedItems = [];
                this.search();
            }
        })
    }

    hideDialog() {
        this.itemDialog = false;
        this.submitted = false;
    }

    saveItem() {
        this.submitted = true;
        //#region  check save
        //#endregion
        if (this.item.parentId) {
            this.item.parentId = this.item.parentId.toString();
        }
        console.log(this.item);
        try {
            this.itemService.save(this.item).then(rs => {
                if(rs.status)
                {
                    this.hideDialog();
                    this.search();
                    this.messageService.add({ severity: 'success', summary: this.translate.instant("MSG_SUCCESS")});
                }else{
                    this.messageService.add({ severity: 'error', summary:  this.translate.instant("MSG_ERROR")});
                }
            });
        } catch (error) {
            this.messageService.add({ severity: 'error', summary: this.translate.instant("MSG_EXCEPTION"), detail: this.translate.instant("MSG_EXCEPTION_HELP"), life: 3000 });
        }
    }
    //#endregion
    //#region common Function
    
    //#endregion
}
