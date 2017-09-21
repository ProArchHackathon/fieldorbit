import { Customer } from "./customer.model";

export interface ServiceRequest {
  ServiceRequestId: number;
  SrNumber?: number;
  RequestedBy?: string;
  ServiceType?: string;
  RequestType?: string;
  CreatedDate?: Date;
  StartDate?: Date;
  EndDate?: Date;
  Customer?: Customer;
  Status?: any;
  Location?: string;
//   Button: string;
//   ErrorMessage: string;
}
  