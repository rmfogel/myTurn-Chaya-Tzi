import { BusinessDto } from './business';
import { ServiceDto } from './service';


export class ChoosenBusinessDto{

    constructor(bu:BusinessDto){this.business=bu; this.serviceChoosen=new ServiceDto();}

    business:BusinessDto

    serviceChoosen:ServiceDto
}