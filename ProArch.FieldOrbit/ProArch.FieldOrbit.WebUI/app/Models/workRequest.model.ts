import { Customer } from "./customer.model";



export interface WorkRequest {
    SrNumber: string;
    RequestedBy: string;
    ServiceType: string;
    RequestType: string;
    CreatedDate: Date;
    StartDate: Date;
    EndDate: Date;
    Customer: Customer;
    Status: any;
    Location: string;
    // Button: string;
    // ErrorMessage: string;
  }
  