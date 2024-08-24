import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BaseService } from "src/app/lib/services/base-service";
import { environment } from "src/environments/environment";
import { ACertificateModel } from "../Models/ACertificateModel";
import { ResponseResult } from "src/app/lib/models/response-model";

@Injectable()
export class ACertificateService extends BaseService {
    constructor(http: HttpClient) {
        super(http, environment.apiDomain.lmsEnpoint + "/ACertificate");
    }
    search(offset: number, limit: number, keyword: string): Promise<ResponseResult> {
        const url = `${this.svUrl}/search?offset=${offset}&limit=${limit}&keyword=${keyword}`;
        return this.http.get<ResponseResult>(url).toPromise();
    }
}
