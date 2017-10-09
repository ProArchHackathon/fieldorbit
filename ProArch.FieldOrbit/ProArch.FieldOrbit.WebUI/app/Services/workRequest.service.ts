import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Configuration } from '../common/app.constants';
import { Observable } from 'rxjs/Observable';
import { WorkRequest } from '../Models/workRequest.model';
import { StaticDataLoaderService } from './staticDataLoader.service';
import { Logger } from './logger.service';

@Injectable()
export class WorkRequestService {
    constructor(private httpClient: HttpClient,
                private _config: Configuration,
                private logger: Logger,
                private _staticLoader: StaticDataLoaderService) { }

    getAllWorkRequests = (): Observable<WorkRequest[]> => {
        return this.httpClient
                   .get(this._config.ApiServer + this._config.GetAllWorkRequests)
                   .map(this.extractData)
                   .map(this._staticLoader.FormatDate)
                   .do((response) => console.log(response))
                   .catch(this.handleError);
    }

     /**
     * addWorkRequest
     */
    addWorkRequest (workRequest: WorkRequest) {

       return this.httpClient
                  .post(this._config.ApiServer + this._config.AddServiceRequest, workRequest)
                  .map(this.extractData)
                  .do((response) => console.log(response))
                  .catch(this.handleError);
    }

     /**
     * addWorkRequest
     */
    updateWorkRequest(workRequest: WorkRequest) {

       return this.httpClient
                  .put(this._config.ApiServer + this._config.UpdateServiceRequest, workRequest)
                  .map(this.extractData)
                  .do((response) => console.log(response))
                  .catch(this.handleError);
    }


    private extractData(response: Response | any) {
        let body = response;
        return body;
    };

    private handleError(error: HttpErrorResponse) {
        this.logger.error(error.message);
        return Observable.throw(error || 'server error');
    };
}
