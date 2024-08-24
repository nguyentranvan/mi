import { HttpClient } from "@angular/common/http";

export class BaseService
{
    svUrl: string;
    http: HttpClient;

    constructor(private _http: HttpClient, svUrl: string) {
        this.svUrl = svUrl;
        this.http = _http;
    }
}