import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions } from '@angular/http';
//import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';



@Component({
    selector: 'service-request',
    templateUrl: 'app/components/serviceRequest/serviceRequest.component.html'
    //styleUrls: ['./input-form-example.css'],
})

export class ServiceRequestComponent {

    SrNumber: string;
    RequestedBy: string;
    ServiceType: string;
    RequestType: string;
    CreateDate: Date;
    CompletedDate: Date;
    CostomerId: string;
    Fee: string;

    result: any;
    Person: any;
    constructor(private http: Http) {

    };

    serviceType = [
        { value: 'Connect-0', viewValue: 'Connect' },
        { value: 'Reconnect-1', viewValue: 'Reconnect' },
        { value: 'Disconnect-2', viewValue: 'Disconnect' },
        { value: 'Miscellaneous-3', viewValue: 'Miscellaneous' }
    ];

    requestType = [
        { value: 'Connect-0', viewValue: 'Connect' },
        { value: 'Reconnect-1', viewValue: 'Reconnect' },
        { value: 'Disconnect-2', viewValue: 'Disconnect' },
        { value: 'Miscellaneous-3', viewValue: 'Miscellaneous' }
    ];

    onUpdate(): void {
        alert(this.RequestedBy + this.CreateDate + this.CostomerId + this.CompletedDate + this.Fee);

        var data =
            {
                SrNumber: this.SrNumber,
                RequestedBy: this.RequestedBy,
                ServiceType: this.ServiceType,
                RequestType: this.RequestType,
                CreateDate: this.CreateDate,
                CompletedDate: this.CompletedDate,
                CostomerId: this.CostomerId,
                Fee: this.Fee

            };
        this.result = {};
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8' });
        let opt = new RequestOptions({ headers: headers });

        this.http.post('http://192.168.19.12/webapi/api/home/detailspost', JSON.stringify(data), opt)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);

        alert(this.result);
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
        this.SrNumber = "12345";
    }
}
