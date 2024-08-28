import { Guid } from "guid-typescript";
import { BaseMoel } from "src/app/lib/models/base-model";

export class EClassCateModel extends BaseMoel{
    id : string;
    code : string;
    name : string;
    parentId : string;
    cateType : number;
    orderNum : number;

    public EClassCateModel(){
       this.id = Guid.create().toJSON().value;
    }
}
