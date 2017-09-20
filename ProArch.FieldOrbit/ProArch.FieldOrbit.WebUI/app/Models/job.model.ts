import { ServiceRequest } from "./serviceRequest.model";

export interface Job {
  JobId: number;
  ServiceRequest: ServiceRequest;
  JobDescription: string;
  StartTime: Date;
  EndTime: Date;
  Status: string;
  Priority: string;
  jobCategory: string;
  Comments: string;
  Observations: string;
  result: any;
  showError: boolean;
  showhighError: boolean;
  showdateError: boolean;
//   Button: string;
//   ErrorMessage: string;
//   serviceRequestError: string;
//   showButton: boolean;
  Request: any;
}
  