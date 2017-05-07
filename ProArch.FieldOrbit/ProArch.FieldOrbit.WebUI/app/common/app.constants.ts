import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    public ApiServer: string = "http://192.168.21.161/dev-fieldorbit-api/";

    public LoginApiUrl: string = "api/LoginOperations/Validate"

    //Service Request Info Api Calls
    public AddServiceRequest: string = "api/ServiceRequest/Post";

    public UpdateServiceRequest: string = "api/ServiceRequest/Put";

    public GetAllServiceRequests: string = "api/Device/GetAllServiceRequest";

    public GetServiceRequestById: string = "api/ServiceRequest/Get";

}