import { WorkRequest } from './../../Models/workRequest.model';
import { Component, OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Configuration } from '../../common/app.constants';
import { MdDialog, MdDialogRef } from '@angular/material';
import { DialogResultDialog } from '../../common/dialog/dialog';
import { MdDatepickerModule, MdNativeDateModule } from '@angular/material';
import { Customer } from "../../Models/customer.model";

@Component({
    selector: 'work-request',
    templateUrl: 'workrequest.component.html'
})

export class WorkRequestComponent implements OnInit{
    statusList:any;
    requestType:any;
    serviceType:any;
    workRequest: WorkRequest
    Button: string;
    ErrorMessage: string;
    serviceRequestList: any;

    constructor(private http: Http,
                public dialog: MdDialog,
                private _configuration: Configuration) {};

    ngOnInit() {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        this.workRequest = {
            SrNumber: null,
            RequestedBy: '',
            ServiceType: '',
            RequestType: '',
            CreatedDate: new Date(),
            StartDate: new Date(),
            EndDate: null,
            Customer : {
                CustomerId:null
            },
            Status: '',
            Location: ''
        }
        this.Button = 'Create';
        this.getAllWorkRequests();
    }

    validateDate() {
        if (!this.workRequest.StartDate) {
            this.ErrorMessage = 'Please Select Start Date';
        }
        else if (this.workRequest.EndDate && (this.workRequest.EndDate <= this.workRequest.StartDate)) {
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

    onUpdate(valid): void {
        this.ErrorMessage = null;
      
            var data =
                {
                    ServiceRequestId: this.workRequest.SrNumber,
                    CreatedBy: { EmployeeId: this.workRequest.RequestedBy },
                    ServiceType: this.workRequest.ServiceType,
                    RequestType: this.workRequest.RequestType,
                    CreatedDate: new Date(this.workRequest.CreatedDate).toLocaleDateString('en-GB', {
                        day: 'numeric',
                        month: 'short',
                        year: 'numeric'
                    }).split(' ').join('-'),
                    StartDate: new Date(this.workRequest.StartDate).toLocaleDateString('en-GB', {
                        day: 'numeric',
                        month: 'short',
                        year: 'numeric'
                    }).split(' ').join('-'),
                    EndDate: (this.workRequest.EndDate) ? new Date(this.workRequest.EndDate).toLocaleDateString('en-GB', {
                        day: 'numeric',
                        month: 'short',
                        year: 'numeric'
                    }).split(' ').join('-') : null,
                    Customer: this.workRequest.Customer,
                    Status: this.workRequest.Status,
                    Location: this.workRequest.Location,
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
        this.workRequest.SrNumber = serviceRequest.ServiceRequestId;
        this.workRequest.RequestedBy = serviceRequest.CreatedBy == null ? 0 : serviceRequest.CreatedBy.EmployeeId;
        this.workRequest.ServiceType = serviceRequest.ServiceType;
        this.workRequest.RequestType = serviceRequest.RequestType;
        this.workRequest.Customer.CustomerId = serviceRequest.Customer.CustomerId;
        this.workRequest.Location = serviceRequest.Location;
        this.workRequest.CreatedDate = serviceRequest.CreatedDate;
        this.workRequest.StartDate = serviceRequest.StartDate;
        this.workRequest.EndDate = serviceRequest.EndDate;
        this.workRequest.Status = serviceRequest.Status;
        this.Button = 'Update';
    }
    onLoad() {

    }
}
