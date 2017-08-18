import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Configuration } from '../../common/app.constants';

@Component({
    selector: 'service-list-component',
    templateUrl: 'srlist.component.html',
    providers:[Configuration]
})

export class ServiceRequestListComponent {
    serviceRequestList: any;
    constructor(private http: Http, private _configuration: Configuration) {
        this.http.get(this._configuration.ApiServer + this._configuration.GetAllServiceRequests, null)
            .toPromise()
            .then((response: Response) => {
                this.serviceRequestList = response.json();
            })
            .catch((errors: any) => {

            });
    };
   
    private extractData(res: Response) {
    };

    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;

        } else {
            errMsg = error.message ? error.message : error.toString();

        }
        console.error(errMsg);
        return Promise.reject(errMsg);

    }
}



