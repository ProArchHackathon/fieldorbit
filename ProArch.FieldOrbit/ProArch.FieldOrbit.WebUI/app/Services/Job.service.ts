import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Configuration } from '../common/app.constants';
import { StaticDataLoaderService } from './staticDataLoader.service';
import { Observable } from 'rxjs/Observable';
import { LoaderService } from './loader.service';

@Injectable()
export class JobService {
    constructor(private httpClient: HttpClient,
                private _config: Configuration,
                private loaderService: LoaderService,
                private _staticLoader: StaticDataLoaderService) { }

    getJobDetails() {
        this.showLoader();

        return this.httpClient
                   .get(this._config.ApiServer + this._config.GetAllJobs)
                   .map(this.extractData)
                   .map(this._staticLoader.formatJobDate)
                   .delay(3000)
                   .do((response) => console.log(response))
                   .catch(this.handleError)
                   .finally(() => this.onEnd() );
    }

    createJob(jobDetails) {
        this.showLoader();

        return this.httpClient
                   .post(this._config.ApiServer + this._config.AddJob, jobDetails)
                   .map(this.extractData)
                   .do((response) => console.log(response))
                   .catch(this.handleError)
                   .finally(() => this.onEnd() );
    }

    updateJob(jobDetails) {
        this.showLoader();

        return this.httpClient
                   .put(this._config.ApiServer + this._config.UpdateJob, jobDetails)
                   .map(this.extractData)
                   .do((response) => console.log(response))
                   .catch(this.handleError)
                   .finally(() => this.onEnd() );
    }

    private extractData(response: Response | any) {
        let body = response;

        return body;
    };

    private handleError(error: HttpErrorResponse) {
        console.log(error);
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
