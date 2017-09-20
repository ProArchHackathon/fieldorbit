import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ServiceRequest } from "../Models/serviceRequest.model";
import { Observable } from "rxjs/Observable";
import { Configuration } from "../common/app.constants";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';


@Injectable()
export class ServiceRequestService {
    private _serviceType = [
        { value: 'Electric', viewValue: 'Electric' },
        { value: 'Gas', viewValue: 'Gas' },
        { value: 'Water', viewValue: 'Water' },
    ];

    private _statusList = [
        { value: 'Open', viewValue: 'Open' },
        { value: 'InProgress', viewValue: 'InProgress' },
        { value: 'Closed', viewValue: 'Closed' },
        { value: 'Hold', viewValue: 'Hold' }
    ];

    private _requestType = [
        { value: 'Connect', viewValue: 'Connect' },
        { value: 'Reconnect', viewValue: 'Reconnect' },
        { value: 'Disconnect', viewValue: 'Disconnect' },
        { value: 'Miscellaneous', viewValue: 'Miscellaneous' }
    ];

    constructor(private httpClient: HttpClient,
                private _configuration: Configuration) { }

    public getAllServiceRequestDetails = ():Observable<ServiceRequest[]> => {
        // setting Headers
      const Headers = this.addingHeaders();        

      return this.httpClient
                 .get(this._configuration.ApiServer + this._configuration.GetAllServiceRequests,{ headers:Headers })
                 .map(this.extractData)
                 .map(this.FormatDate)
                 .do((response) => console.log(response))
                 .catch(this.handleError);
    };


    get serviceType():any { return this._serviceType; }
    get statusList():any { return this._statusList; }
    get requestType():any { return this._requestType; }
    
    /**
     * updateServiceRequest
     */
    public updateServiceRequest(serviceRequest) {
        // Gathering data
       const data = this.modifyData(serviceRequest);
       const Headers = this.addingHeaders();

       return this.httpClient
                  .put(this._configuration.ApiServer + this._configuration.UpdateServiceRequest, data, { headers: Headers })
                  .map(this.extractData)
                  .do((response) => console.log(response))
                  .catch(this.handleError);
    }

    /**
     * addServiceRequest
     */
    public addServiceRequest(serviceRequest) {
        // Gathering data
       let data = this.modifyData(serviceRequest);
       const Headers = this.addingHeaders();
        
       return this.httpClient
                  .post(this._configuration.ApiServer + this._configuration.AddServiceRequest, data, { headers: Headers })
                  .map(this.extractData)
                  .do((response) => console.log(response))
                  .catch(this.handleError);
    }

    /**
     * Adding Headers
     */
    private addingHeaders() {
        const headers = new HttpHeaders();
        headers.append('Accept', 'application/json');

        return headers;
    }

    private modifyData(serviceRequest) {
        let data = {
            ServiceRequestId:serviceRequest.SrNumber,
            CreatedBy: { EmployeeId: serviceRequest.RequestedBy },
            ServiceType: serviceRequest.ServiceType,
            RequestType: serviceRequest.RequestType,
            CreatedDate: new Date(serviceRequest.CreatedDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-'),
            StartDate: new Date(serviceRequest.StartDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-'),
            EndDate: (serviceRequest.EndDate) ? new Date(serviceRequest.EndDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-') : null,
            Customer: serviceRequest.Customer,
            Status: serviceRequest.Status,
            Location: serviceRequest.Location,
            Type: 'ServiceRequest'
        };

        return data;
    }

    private FormatDate(serviceRequestList) {
        serviceRequestList.forEach(element => {
            element.StartDate = new Date(element.StartDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-');
            element.CreatedDate = new Date(element.CreatedDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-');
            element.EndDate = new Date(element.EndDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-');
        });

        return serviceRequestList;
    }

    private extractData(response:Response | any) {
        let body = response;
        return body;
    };

    private handleError(error: Response) {
        return Observable.throw(error || 'server error');
    };
}