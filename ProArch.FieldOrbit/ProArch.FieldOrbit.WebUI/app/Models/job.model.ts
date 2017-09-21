import { ServiceRequest } from './serviceRequest.model';

export interface Job {
  JobId: number;
  ServiceRequest: ServiceRequest;
  JobDescription: string;
  StartTime: Date;
  EndTime: Date;
  Status: string;
  Priority: string;
  Comments: string;
  Observations: string;
}
  