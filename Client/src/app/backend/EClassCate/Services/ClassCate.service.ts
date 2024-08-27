import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BaseService } from "src/app/lib/services/base-service";
import { environment } from "src/environments/environment";
import { EClassCateModel } from "../Models/EClassCateModel";
import { ResponseResult } from "src/app/lib/models/response-model";
import { Guid } from "guid-typescript";

@Injectable()
export class EClassCateService extends BaseService {
    constructor(http: HttpClient) {
        super(http, environment.apiDomain.lmsEnpoint + "/EClassCate");
    }
    search(offset: number, limit: number, keyword: string): Promise<ResponseResult> {
        const url = `${this.svUrl}?offset=${offset}&limit=${limit}&keyword=${keyword}`;
        return this.http.get<ResponseResult>(url).toPromise();
    }
    searchByParentId(parentid: string): Promise<ResponseResult> {
        const url = `${this.svUrl}?parentId=${parentid}`;
        return this.http.get<ResponseResult>(url).toPromise();
    }
    save(model : any): Promise<ResponseResult> {
        const url = `${this.svUrl}`;
        return this.http.post<ResponseResult>(url, model).toPromise();
    }
    detail(id : any): Promise<ResponseResult> {
        const url = `${this.svUrl}/detail/${id}`;
        return this.http.get<ResponseResult>(url).toPromise();
    }
    delete(id : any): Promise<ResponseResult> {
        const url = `${this.svUrl}/${id}`;
        return this.http.delete<ResponseResult>(url).toPromise();
    }
    
}
