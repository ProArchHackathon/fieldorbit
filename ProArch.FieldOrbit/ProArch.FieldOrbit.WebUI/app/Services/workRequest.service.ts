import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../common/app.constants';
import { Observable } from 'rxjs/Observable';
import { WorkRequest } from '../Models/workRequest.model';
import { StaticDataLoaderService } from './staticDataLoader.service';

@Injectable()
export class WorkRequestService {
    constructor(private httpClient: HttpClient,
                private _config: Configuration,
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
    addWorkRequest (workRequest) {
        // Gathering data
       let data = this._staticLoader.modifyData(workRequest, 'WorkRequest');

       return this.httpClient
                  .post(this._config.ApiServer + this._config.AddServiceRequest, data)
                  .map(this.extractData)
                  .do((response) => console.log(response))
                  .catch(this.handleError);
    }

     /**
     * addWorkRequest
     */
    updateWorkRequest(workRequest) {
        // Gathering data
       let data = this._staticLoader.modifyData(workRequest, 'WorkRequest');

       return this.httpClient
                  .post(this._config.ApiServer + this._config.UpdateServiceRequest, data)
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
