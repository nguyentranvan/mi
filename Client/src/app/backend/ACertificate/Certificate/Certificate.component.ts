import { Component, OnInit, OnDestroy } from '@angular/core';
import { MessageService } from 'primeng/api';
import { PageBaseIndex } from 'src/app/lib/pages/base-page-index';
import { ACertificateService } from '../Services/ACertificate.service';
import { ACertificateModel } from '../Models/ACertificateModel';
import { TranslateService } from '@ngx-translate/core';

@Component({
    templateUrl: './Certificate.component.html',
})
export class CertificateComponent extends PageBaseIndex implements OnInit, OnDestroy {

    itemDialog: boolean = false;
    deleteItemDialog: boolean = false;
    deleteItemsDialog: boolean = false;

    items: ACertificateModel[] = [];
    item: ACertificateModel;
    selectedItems: ACertificateModel[] = [];

    submitted: boolean = false;

    uploadedFiles: any[] = [];
    //#region page Function
    constructor(
        private translate: TranslateService,
        private itemService : ACertificateService,
        private messageService: MessageService) {
        super();
    }

    ngOnInit() {
        this.cols = [
            { field: 'code', header: 'Mã' },
            { field: 'name', header: 'Tên chứng chỉ' }
        ];
        this.apiUrl +="?contentType=pdf&objectName=certificate"
       this.search();
    }

    ngOnDestroy() {

    }
    doPageChange(event: any): void {
        this.offset = event.first;
        this.limit = event.rows;
        this.search();
    }
    onUpload(event:any) {
        this.uploadedFiles=[];
        for(let file of event.files) {
            this.item.fileId = file.name;
            this.uploadedFiles.push(file);
        }
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
    openNew() {
        this.item = new ACertificateModel();
        this.submitted = false;
        this.itemDialog = true;
    }
    deleteSelectedItems() {
        this.deleteItemsDialog = true;
    }

    editItem(aCertificateModel: ACertificateModel) {
        this.itemService.detail(aCertificateModel.id).then(rs => {
            if(rs.status)
            {
                this.item = rs.data;
                this.uploadedFiles=[];
                if(this.item.fileId) 
                    this.uploadedFiles.push(this.item.fileId);
                this.itemDialog = true;
            }
        })
    }

    deleteItem(aCertificateModel: ACertificateModel) {
        this.deleteItemDialog = true;
        this.item = aCertificateModel;
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
