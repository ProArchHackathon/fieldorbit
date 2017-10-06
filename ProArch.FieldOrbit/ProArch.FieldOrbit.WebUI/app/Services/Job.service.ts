import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Configuration } from '../common/app.constants';
import { StaticDataLoaderService } from './staticDataLoader.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class JobService {
    constructor(private httpClient: HttpClient,
                private _config: Configuration,
                private _staticLoader: StaticDataLoaderService) { }

    getJobDetails() {
        return this.httpClient
                   .get(this._config.ApiServer + this._config.GetAllJobs)
                   .map(this.extractData)
                   .map(this._staticLoader.formatJobDate)
                   .do((response) => console.log(response))
                   .catch(this.handleError);
    }

    createJob(jobDetails) {
        return this.httpClient
                   .post(this._config.ApiServer + this._config.AddJob, jobDetails)
                   .map(this.extractData)
                   .do((response) => console.log(response))
                   .catch(this.handleError);
    }

    updateJob(jobDetails) {
        return this.httpClient
                   .put(this._config.ApiServer + this._config.UpdateJob, jobDetails)
                   .map(this.extractData)
                   .do((response) => console.log(response))
                   .catch(this.handleError);
    }

    private extractData(response: Response | any) {
        let body = response;

        return body;
    };

    private handleError(error: HttpErrorResponse) {
        console.log(error);
        return Observable.throw(error || 'server error');
    };
}