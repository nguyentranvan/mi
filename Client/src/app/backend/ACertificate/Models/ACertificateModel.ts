import { Guid } from "guid-typescript";
import { BaseMoel } from "src/app/lib/models/base-model";

export class ACertificateModel extends BaseMoel{
    id : string;
    code : string;
    name : string;
    fileId : string;
    description : string;

    public ACertificateModel(){
       this.id = Guid.create().toJSON().value;
    }
}
