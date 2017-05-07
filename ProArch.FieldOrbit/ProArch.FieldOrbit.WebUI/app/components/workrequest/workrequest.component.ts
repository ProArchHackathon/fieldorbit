import { Component, OnInit } from '@angular/core';
import { Http, RequestOptions, Headers, Response, URLSearchParams } from "@angular/http";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Configuration } from '../../common/app.constants';
import { MdDialog, MdDialogRef } from '@angular/material';
import { DialogResultDialog } from '../../common/dialog/dialog';

export class ServiceRequest {
    constructor(
        public ServiceRequestId: number) {

    }
}

@Component({
    selector: 'work-request',
    templateUrl: 'app/components/workrequest/workrequest.component.html',
    providers: [Configuration]
})

export class WorkRequestComponent implements OnInit {

    WorkRequestId: string;
    ServiceRequest: ServiceRequest;
    Description: string;
    StartDate: Date;
    EndDate: Date;

    ServiceRequestType: string = "Electric";
    status: string = "";
    result: any;
    constructor(private http: Http, private _configuration: Configuration, public dialog: MdDialog) {
        this.ServiceRequest = {
            ServiceRequestId: 0
        }
    };

    ngOnInit() {

    }
    onUpdate(): void {
        var data =
            {
                WorkRequestId: this.WorkRequestId,
                ServiceRequest: this.ServiceRequest,
                Description: this.Description,
                StartDate: this.StartDate,
                EndDate: this.EndDate,
                ServiceRequestType: this.ServiceRequestType,
                status: this.status,
            };
        this.result = {};
        console.log(data);

        let params: URLSearchParams = new URLSearchParams();
        params.set('serviceRequestId', this.ServiceRequest.ServiceRequestId.toString());

        let requestOptions = new RequestOptions();
        requestOptions.search = params;

        this.http.get(this._configuration.ApiServer + this._configuration.GetServiceRequestById, requestOptions)
            .toPromise()
            .then((response: Response) => {
                let res = response.json();
                data.ServiceRequest = res;
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let opt = new RequestOptions({ headers: headers });

                this.http.post(this._configuration.ApiServer + this._configuration.AddWorkRequest, JSON.stringify(data), opt)
                    .toPromise()
                    .then((response: Response) => {
                        this.openDialog();
                    })
                    .catch((errors: any) => {

                    });
            })
            .catch((errors: any) => {

            });
    };
    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    };

    openDialog() {
        let dialogRef = this.dialog.open(DialogResultDialog);
        dialogRef.afterClosed().subscribe(result => {
        });
    }

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



    sTypes = [
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
        this.WorkRequestId = "12345";
    }

}



