﻿import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';



@Component({
    selector: 'work-request',
    templateUrl: 'app/components/workrequest/workrequest.component.html'
})

export class WorkRequestComponent {

    WorkOrderId: string;
    ServiceRequestId: string;
    Description: string;
    StartDate: Date;
    EndDate: Date;

    ServiceRequestType: string = "Electric";
    status: string = "";
    result: any;
    constructor(private http: Http) {

    };
    onUpdate(): void {
        var data =
            {
                WorkOrderId: this.WorkOrderId,
                ServiceRequestId: this.ServiceRequestId,
                Description: this.Description,
                StartDate: this.StartDate,
                EndDate: this.EndDate,
                ServiceRequestType: this.ServiceRequestType,
                status: this.status,
            };
        this.result = {};
        console.log(data);

        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8' });
        let opt = new RequestOptions({ headers: headers });


        this.http.post('http://192.168.19.12/webapi/api/home/detailspost', JSON.stringify(data), opt)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);

       // alert(this.result);
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

    selectedValue: string;



    serviceTypes = [
        { value: 'electric-0', viewValue: 'Electric' },
        { value: 'water-1', viewValue: 'Water' },
        { value: 'gas-2', viewValue: 'Gas' }
    ];

    workStatus = [
        { value: 'open-0', viewValue: 'Open' },
        { value: 'reopen-1', viewValue: 'Re-Open' },
        { value: 'close-2', viewValue: 'Close' }
    ];

    onLoad() {
        this.WorkOrderId = "12345";
    }

}



