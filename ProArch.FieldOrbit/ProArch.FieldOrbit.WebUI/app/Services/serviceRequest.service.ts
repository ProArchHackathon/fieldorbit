import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { LoaderService } from './loader.service';
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
                private _config: Configuration,
                private loaderService: LoaderService,
                private _staticLoader: StaticDataLoaderService) { }


    public getAllServiceRequestDetails = (): Observable<ServiceRequest[]> => {
        this.showLoader();

      return this.httpClient
                 .get(this._config.ApiServer + this._config.GetAllServiceRequests)
                 .map(this.extractData)
                 .map(this._staticLoader.FormatDate)
                 .do((response) => console.log(response))
                 .catch(this.handleError)
                 .finally(() => this.onEnd() );
    };

    /**
     * Get's service request by id
     * @return ServiceRequest
     */

    public getServiceRequestDetails = (serviceReqId): Observable<ServiceRequest> => {
      const params = new HttpParams().set('serviceRequestId', serviceReqId);
      this.showLoader();

      return this.httpClient
                 .get(this._config.ApiServer + this._config.GetServiceRequestById, { params: params})
                 .map(this.extractData)
                 .do((response) => console.log(response))
                 .catch(this.handleError)
                 .finally(() => this.onEnd() );
    };

    /**
     * updateServiceRequest
     */
    public updateServiceRequest(serviceRequest) {
        this.showLoader();

       return this.httpClient
                  .put(this._config.ApiServer + this._config.UpdateServiceRequest, serviceRequest)
                  .map(this.extractData)
                  .do((response) => console.log(response))
                  .catch(this.handleError)
                  .finally(() => this.onEnd() );
    }

    /**
     * addServiceRequest
     */
    public addServiceRequest(serviceRequest) {
       this.showLoader();

       return this.httpClient
                  .post(this._config.ApiServer + this._config.AddServiceRequest, serviceRequest)
                  .map(this.extractData)
                  .do((response) => console.log(response))
                  .catch(this.handleError)
                  .finally(() => this.onEnd() );
    }

    private extractData(response: Response | any) {
        let body = response;

        return body;
    };

    private handleError(error: Response) {
        return Observable.throw(error || 'server error');
    };

    private showLoader(): void {
        console.log('loader loaded');
        this.loaderService.show();
    }

    private hideLoader(): void {
        this.loaderService.hide();
    }

    private onEnd(): void {
        this.hideLoader();
    }
}
