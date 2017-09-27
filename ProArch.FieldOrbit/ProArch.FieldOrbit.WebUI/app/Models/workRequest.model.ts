import { Customer } from './customer.model';
import { Employee } from './employee.model';



export interface WorkRequest {
    SrNumber: string;
    CreatedBy: Employee;
    ServiceType: string;
    RequestType: string;
    CreatedDate: Date;
    StartDate: Date;
    EndDate: Date;
    Customer: Customer;
    Status: any;
    Location: string;
    Type?: string;
}
