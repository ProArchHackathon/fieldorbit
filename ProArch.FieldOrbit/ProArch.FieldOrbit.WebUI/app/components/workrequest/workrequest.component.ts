import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions } from '@angular/http';
//import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Configuration } from '../../common/app.constants';
import { MdDialog, MdDialogRef } from '@angular/material';
import { DialogResultDialog } from '../../common/dialog/dialog';
import { MdDatepickerModule, MdNativeDateModule } from '@angular/material';

export class Customer {
    constructor(
        public CustomerId: number) {

    }
}
@Component({
    selector: 'work-request',
    templateUrl: 'workrequest.component.html',
    providers: [Configuration]
})

export class WorkRequestComponent {

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
    Button: string;
    ErrorMessage: string;

    serviceRequestList: any;
    constructor(private http: Http,
                public dialog: MdDialog,
                private _configuration: Configuration) {
        this.Customer = {
            CustomerId: 0
        }
        this.Button = 'Create';
        this.CreatedDate = new Date();
        this.StartDate = new Date();
        this.getAllWorkRequests();
    };

    validateDate() {
        if (!this.StartDate) {
            this.ErrorMessage = 'Please Select Start Date';
        }
        else if (this.EndDate && (this.EndDate <= this.StartDate)) {
            this.ErrorMessage = 'End Date should be greater than Start Date';
        }
    }

    getAllWorkRequests() {
        this.http.get(this._configuration.ApiServer + this._configuration.GetAllWorkRequests, null)
            .toPromise()
            .then((response: Response) => {
                this.serviceRequestList = response.json();
                this.serviceRequestList.forEach(element => {
                    element.StartDate = new Date(element.StartDate).toLocaleDateString('en-GB', {
                        day: 'numeric',
                        month: 'short',
                        year: 'numeric'
                    }).split(' ').join('-');
                    element.CreatedDate = new Date(element.CreatedDate).toLocaleDateString('en-GB', {
                        day: 'numeric',
                        month: 'short',
                        year: 'numeric'
                    }).split(' ').join('-');
                    element.EndDate = new Date(element.EndDate).toLocaleDateString('en-GB', {
                        day: 'numeric',
                        month: 'short',
                        year: 'numeric'
                    }).split(' ').join('-');
                });
            })
            .catch((errors: any) => {

            });
    }

    openDialog() {
        let dialogRef = this.dialog.open(DialogResultDialog);
        dialogRef.afterClosed().subscribe(result => {
            this.getAllWorkRequests();
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

    onUpdate(valid): void {
        this.ErrorMessage = null;
      
            var data =
                {
                    ServiceRequestId: this.SrNumber,
                    CreatedBy: { EmployeeId: this.RequestedBy },
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
                    EndDate: (this.EndDate) ? new Date(this.EndDate).toLocaleDateString('en-GB', {
                        day: 'numeric',
                        month: 'short',
                        year: 'numeric'
                    }).split(' ').join('-') : null,
                    Customer: this.Customer,
                    Status: this.Status,
                    Location: this.Location,
                    Type: 'WorkRequest'
                };

            let headers = new Headers({ 'Content-Type': 'application/json' });
            let opt = new RequestOptions({ headers: headers });
            if (this.Button == 'Create') {
                this.http.post(this._configuration.ApiServer + this._configuration.AddServiceRequest, JSON.stringify(data), opt)
                    .toPromise()
                    .then((response: Response) => {
                        this.openDialog();
                    })
                    .catch(this.handleError);
            }
            else {
                this.http.put(this._configuration.ApiServer + this._configuration.UpdateServiceRequest, JSON.stringify(data), opt)
                    .toPromise()
                    .then((response: Response) => {
                        this.openDialog();
                    })
                    .catch(this.handleError);
            }
       
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

    private onSelectedRow(serviceRequest): void {
        this.SrNumber = serviceRequest.ServiceRequestId;
        this.RequestedBy = serviceRequest.CreatedBy == null ? 0 : serviceRequest.CreatedBy.EmployeeId;
        this.ServiceType = serviceRequest.ServiceType;
        this.RequestType = serviceRequest.RequestType;
        this.Customer.CustomerId = serviceRequest.Customer.CustomerId;
        this.Location = serviceRequest.Location;
        this.CreatedDate = serviceRequest.CreatedDate;
        this.StartDate = serviceRequest.StartDate;
        this.EndDate = serviceRequest.EndDate;
        this.Status = serviceRequest.Status;
        this.Button = 'Update';
    }
    onLoad() {

    }
}
