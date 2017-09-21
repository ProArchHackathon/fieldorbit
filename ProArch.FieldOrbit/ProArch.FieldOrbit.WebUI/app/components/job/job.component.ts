import { Component, OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions, URLSearchParams } from '@angular/http';
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
    selector: 'msg-app',
    templateUrl: 'job.component.html',
    styleUrls: ['job.component.scss'],
    providers: [Configuration]
})

export class JobComponent implements OnInit{
    jobList: any;
    Statuses:any;
    Types:any;
    Priorities:any;
    Category:any;
    message = 'This is Job Component';

    constructor(private http: Http, private _configuration: Configuration, public dialog: MdDialog) { }

    ngOnInit() {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        this.ServiceRequest = {
            ServiceRequestId: 0,
        }
        this.Button = 'Create';
        this.getAllJobs();
        this.showButton = false;
    }
    
    //Properties......
    public JobId: number;
    public ServiceRequest: ServiceRequest;
    public JobDescription: string;
    public StartTime: Date = null;
    public EndTime: Date =null;
    public Status: string;
    public Priority: string;
    public jobCategory: string;
    public Comments: string;
    public Observations: string;
    public result: any;
    public showError: boolean;
    public showhighError: boolean;
    public showdateError: boolean;
    public Button: string;
    public ErrorMessage: string;
    public serviceRequestError: string;
    public showButton: boolean;
    public Request:any;

    //validating the Date here

    validateDate() {
        this.ErrorMessage = null;
        this.serviceRequestError = null;
        if (!this.StartTime) {
            this.ErrorMessage = 'Please Select Start Time';
        }
        else if (this.EndTime && (this.EndTime <= this.StartTime)) {
            this.ErrorMessage = 'End Time should be greater than Start Time';
        }
    }

    openDialog() {
        let dialogRef = this.dialog.open(DialogResultDialog);
        dialogRef.afterClosed().subscribe(result => {
            this.getAllJobs();
        });
    }

    getAllJobs() {
        this.http.get(this._configuration.ApiServer + this._configuration.GetAllJobs, null)
            .toPromise()
            .then((response: Response) => {
                this.jobList = response.json();
                this.jobList.forEach(element => {
                    element.StartTime = new Date(element.StartTime).toLocaleDateString('en-GB', {
                        day: 'numeric',
                        month: 'short',
                        year: 'numeric'
                    }).split(' ').join('-');
                    element.EndTime = new Date(element.EndTime).toLocaleDateString('en-GB', {
                        day: 'numeric',
                        month: 'short',
                        year: 'numeric'
                    }).split(' ').join('-');
                });
            })
            .catch((errors: any) => {

            });
    }

    getServiceRequest() {
        this.serviceRequestError = null;
        let params: URLSearchParams = new URLSearchParams();
        params.set('serviceRequestId', this.ServiceRequest.ServiceRequestId.toString());

        let requestOptions = new RequestOptions();
        requestOptions.search = params;
        this.http.get(this._configuration.ApiServer + this._configuration.GetServiceRequestById, requestOptions)
            .toPromise()
            .then((response: Response) => {
                let res = response.json();
                this.Request = res;
                if (this.Request) {
                    this.showButton = true;
                }
                else {
                    this.serviceRequestError = 'No Service Request Found';
                    this.showButton = false;
                }
            })
            .catch((error) => {
                this.serviceRequestError = 'No Service Request Found';
                this.showButton = false;
            });
    }

    onSubmit() {
        this.ErrorMessage = null;
        this.serviceRequestError = null;

        var data =
            {
                JobId: this.JobId,
                ServiceRequest: this.Request,
                JobDescription: this.JobDescription,
                StartTime: this.StartTime,
                EndTime: this.EndTime,
                Status: this.Status,
                Priority: this.Priority,
                Comments: this.Comments,
                Observations: this.Observations,
            };

        data.ServiceRequest = this.Request;
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let opt = new RequestOptions({ headers: headers });

        if (this.Button == 'Create') {
            this.http.post(this._configuration.ApiServer + this._configuration.AddJob, JSON.stringify(data), opt)
                .toPromise()
                .then((response: Response) => {
                    this.openDialog();
                })
                .catch((errors: any) => {

                });
        }
        else {
            this.http.put(this._configuration.ApiServer + this._configuration.UpdateJob, JSON.stringify(data), opt)
                .toPromise()
                .then((response: Response) => {
                    console.log('updated successfully');
                    this.openDialog();
                })
                .catch((errors: any) => {

                });
        }
    };

    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    };

    private onSelectedRow(sr): void {
        this.ServiceRequest.ServiceRequestId = sr.ServiceRequest.ServiceRequestId;
        this.JobId = sr.JobId;
        this.JobDescription = sr.JobDescription;
        this.StartTime = sr.StartTime;
        this.EndTime = sr.EndTime;
        this.Priority = sr.Priority;
        this.Comments = sr.Comments;
        this.Observations = sr.Observations;
        this.Button = 'Update';
        this.Status = sr.Status;

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

}

