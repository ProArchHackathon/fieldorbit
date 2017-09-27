import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Configuration } from '../common/app.constants';
import { ServiceRequest } from '../Models/serviceRequest.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { StaticDataLoaderService } from './staticDataLoader.service';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';



@Injectable()
export class ServiceRequestService {

    constructor(private httpClient: HttpClient,
                private _configuration: Configuration,
                private _staticLoader: StaticDataLoaderService) { }


    public getAllServiceRequestDetails = (): Observable<ServiceRequest[]> => {

      return this.httpClient
                 .get(this._configuration.ApiServer + this._configuration.GetAllServiceRequests)
                 .map(this.extractData)
                 .map(this._staticLoader.FormatDate)
                 .do((response) => console.log(response))
                 .catch(this.handleError);
    };

    /**
     * Get's service request by id
     * @return ServiceRequest
     */

    public getServiceRequestDetails = (serviceReqId): Observable<ServiceRequest> => {
      const params = new HttpParams().set('serviceRequestId', serviceReqId);

      return this.httpClient
                 .get(this._configuration.ApiServer + this._configuration.GetServiceRequestById, { params: params})
                 .map(this.extractData)
                 .do((response) => console.log(response))
                 .catch(this.handleError);
    };

    /**
     * updateServiceRequest
     */
    public updateServiceRequest(serviceRequest) {

       return this.httpClient
                  .put(this._configuration.ApiServer + this._configuration.UpdateServiceRequest, serviceRequest)
                  .map(this.extractData)
                  .do((response) => console.log(response))
                  .catch(this.handleError);
    }

    /**
     * addServiceRequest
     */
    public addServiceRequest(serviceRequest) {

       return this.httpClient
                  .post(this._configuration.ApiServer + this._configuration.AddServiceRequest, serviceRequest)
                  .map(this.extractData)
                  .do((response) => console.log(response))
                  .catch(this.handleError);
    }

    private extractData(response: Response | any) {
        let body = response;

        return body;
    };

    private handleError(error: Response) {
        return Observable.throw(error || 'server error');
    };
}