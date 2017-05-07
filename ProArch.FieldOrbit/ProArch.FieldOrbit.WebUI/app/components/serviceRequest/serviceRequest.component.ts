import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions } from '@angular/http';
//import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Configuration } from '../../common/app.constants';


@Component({
    selector: 'service-request',
    templateUrl: 'app/components/serviceRequest/serviceRequest.component.html',
    providers:[Configuration]
})

export class ServiceRequestComponent {

    SrNumber: string;
    RequestedBy: string;
    ServiceType: string;
    RequestType: string;
    CreatedDate: Date;
    StartDate: Date;
    EndDate: Date;
    CustomerId: string;
    Status: any;
    constructor(private http: Http, private _configuration: Configuration) {

    };

    serviceType = [
        { value: '0', viewValue: 'Electricity ' },
        { value: '1', viewValue: 'Gas' },
        { value: '2', viewValue: 'Water' },
    ];

    statusList = [
        { value: 'Open', viewValue: 'Open' },
        { value: 'InProgress', viewValue: 'InProgress' },
        { value: 'Closed', viewValue: 'Closed' },
        { value: 'Hold', viewValue: 'Hold' }
    ];

    requestType = [
        { value: '0', viewValue: 'Connect' },
        { value: '1', viewValue: 'Reconnect' },
        { value: '2', viewValue: 'Disconnect' },
        { value: '3', viewValue: 'Miscellaneous' }
    ];

    onUpdate(): void {
        var data =
         {
             SrNumber: this.SrNumber,
             RequestedBy: this.RequestedBy,
             ServiceType: this.ServiceType,
             RequestType: this.RequestType,
             CreatedDate: this.CreatedDate,
             StartDate: this.StartDate,
             EndDate: this.EndDate,
             CustomerId: this.CustomerId,
             Status: this.Status
         };

        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8' });
        let opt = new RequestOptions({ headers: headers });

        this.http.post(this._configuration.ApiServer + this._configuration.AddServiceRequest, JSON.stringify(data), opt)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);
    };

    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
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


    onLoad() {
        
    }
}
