import { environment } from "src/environments/environment";

export class PageBaseIndex{
    offset =0;
    limit = 20;
    keyword ="";
    cols: any[] = [];
    rowsPerPageOptions = [5, 10, 20];

    apiUrl = environment.apiDomain.fileEnpoint;
}