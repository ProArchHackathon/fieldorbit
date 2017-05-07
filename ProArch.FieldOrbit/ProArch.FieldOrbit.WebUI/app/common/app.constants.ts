import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    public ApiServer: string = "http://localhost/fieldorbitapi/";

    public LoginApiUrl: string = "api/LoginOperations/Validate"

    //Service Request Info Api Calls
    public AddServiceRequest: string = "api/ServiceRequest/Post";

    public UpdateServiceRequest: string = "api/ServiceRequest/Put";

    public GetAllServiceRequests: string = "api/ServiceRequest/GetAllServiceRequest";

    public GetServiceRequestById: string = "api/ServiceRequest/Get";

    //Work Request
    public GetWorkRequestById: string = "api/WorkRequest/Get";

    public AddWorkRequest: string = "api/WorkRequest/Post";

    public UpdateWorkRequest: string = "api/WorkRequest/Put";

    //Job
    public GetJobById: string = "api/Job/GetJobById";

    public AddJob: string = "api/Job/Post";

}