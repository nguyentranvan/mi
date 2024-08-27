import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { ResponseResult } from "../models/response-model";
import { BaseService } from "./base-service";

@Injectable()
export class ACertificateService extends BaseService {
    constructor(http: HttpClient) {
        super(http, environment.apiDomain.fileEnpoint + "/FileController");
    }
    
}
