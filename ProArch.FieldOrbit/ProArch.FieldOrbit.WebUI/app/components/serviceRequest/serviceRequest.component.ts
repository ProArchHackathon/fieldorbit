﻿import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions } from '@angular/http';
//import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Configuration } from '../../common/app.constants';
import { MdDialog, MdDialogRef } from '@angular/material';
import { DialogResultDialog } from '../../common/dialog/dialog';
export class Customer {
    constructor(
        public CustomerId: number) {

    }
}
@Component({
    selector: 'service-request',
    templateUrl: 'serviceRequest.component.html',
    providers: [Configuration]
})

export class ServiceRequestComponent {

    SrNumber: string;
    RequestedBy: string;
    ServiceType: string;
    RequestType: string;
    CreatedDate: Date;
    StartDate: Date;
    EndDate: Date;
    Customer: Customer;
    Status: any;
    Location: string;


    serviceRequestList: any;
    constructor(private http: Http, private _configuration: Configuration, public dialog: MdDialog) {
        this.Customer = {
            CustomerId: 0
        }
        this.http.get(this._configuration.ApiServer + this._configuration.GetAllServiceRequests, null)
            .toPromise()
            .then((response: Response) => {
                this.serviceRequestList = response.json();
            })
            .catch((errors: any) => {

            });
    };

    openDialog() {
        let dialogRef = this.dialog.open(DialogResultDialog);
        dialogRef.afterClosed().subscribe(result => {
        });
    }

    serviceType = [
        { value: 'Electric', viewValue: 'Electric' },
        { value: 'Gas', viewValue: 'Gas' },
        { value: 'Water', viewValue: 'Water' },
    ];

    statusList = [
        { value: 'Open', viewValue: 'Open' },
        { value: 'InProgress', viewValue: 'InProgress' },
        { value: 'Closed', viewValue: 'Closed' },
        { value: 'Hold', viewValue: 'Hold' }
    ];

    requestType = [
        { value: 'Connect', viewValue: 'Connect' },
        { value: 'Reconnect', viewValue: 'Reconnect' },
        { value: 'Disconnect', viewValue: 'Disconnect' },
        { value: 'Miscellaneous', viewValue: 'Miscellaneous' }
    ];

    onUpdate(): void {
        var data =
            {
                SrNumber: this.SrNumber,
                RequestedBy: this.RequestedBy,
                ServiceType: this.ServiceType,
                RequestType: this.RequestType,
                CreatedDate: new Date(this.CreatedDate).toLocaleDateString('en-GB', {
                    day: 'numeric',
                    month: 'short',
                    year: 'numeric'
                }).split(' ').join('-'),
                StartDate: new Date(this.StartDate).toLocaleDateString('en-GB', {
                    day: 'numeric',
                    month: 'short',
                    year: 'numeric'
                }).split(' ').join('-'),
                EndDate: (this.EndDate)? new Date(this.EndDate).toLocaleDateString('en-GB', {
                    day: 'numeric',
                    month: 'short',
                    year: 'numeric'
                }).split(' ').join('-'):null,
                Customer: this.Customer,
                Status: this.Status,
                Location:this.Location
            };

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let opt = new RequestOptions({ headers: headers });
        this.http.post(this._configuration.ApiServer + this._configuration.AddServiceRequest, JSON.stringify(data), opt)
            .toPromise()
            .then((response: Response) => {
                this.openDialog();
            })
            .catch(this.handleError);
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

    private onSelectedRow(serviceRequest): void
    {
        this.SrNumber = serviceRequest.ServiceRequestId;
        this.RequestedBy = serviceRequest.RequestedBy;
        this.ServiceType = serviceRequest.ServiceType;
        this.RequestType = serviceRequest.RequestType;
        this.Customer.CustomerId = serviceRequest.Customer.CustomerId;
        this.Location = serviceRequest.Location;
        this.CreatedDate = new Date(serviceRequest.CreatedDate);
        this.StartDate = serviceRequest.StartDate;
        this.EndDate = serviceRequest.EndDate;
        this.Status = serviceRequest.Status;

    }
    onLoad() {

    }
}
