import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    public readonly ApiServer: string = "http://localhost/test-fieldorbit-api/";

    public readonly LoginApiUrl: string = "api/LoginOperations/Validate"

    //Service Request Info Api Calls
    public readonly AddServiceRequest: string = "api/ServiceRequest/Post";

    public readonly UpdateServiceRequest: string = "api/ServiceRequest/Put";

    public readonly GetAllServiceRequests: string = "api/ServiceRequest/GetAllServiceRequest";

    public readonly GetServiceRequestById: string = "api/ServiceRequest/Get";

    //Work Request
    public readonly GetWorkRequestById: string = "api/WorkRequest/Get";

    public readonly AddWorkRequest: string = "api/WorkRequest/Post";

    public readonly UpdateWorkRequest: string = "api/WorkRequest/Put";

    //Job
    public readonly GetJobById: string = "api/Job/GetJobById";

    public readonly AddJob: string = "api/Job/Post";

}