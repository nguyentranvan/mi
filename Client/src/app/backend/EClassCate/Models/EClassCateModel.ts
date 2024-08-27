import { Guid } from "guid-typescript";
import { BaseMoel } from "src/app/lib/models/base-model";

export class EClassCateModel extends BaseMoel{
    id : string;
    code : string;
    name : string;
    parentid : string;
    catetype : number;
    ordernum : number;

    public EClassCateModel(){
       this.id = Guid.create().toJSON().value;
    }
}
