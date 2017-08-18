import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions, URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Configuration } from '../../common/app.constants';
import { MdDialog, MdDialogRef } from '@angular/material';
import { DialogResultDialog } from '../../common/dialog/dialog';
export class WorkRequest {
    constructor(
        public WorkRequestId: number) {

    }
}


@Component({
    selector: 'msg-app',
    templateUrl: 'job.component.html',
    styleUrls: ['job.component.css'],
    providers: [Configuration]
})

export class JobComponent {

    constructor(private http: Http, private _configuration: Configuration, public dialog: MdDialog) {
        this.WorkRequest = {
            WorkRequestId: 0
        }
    }
    message = 'This is Job Component';
    Statuses = [
        { value: 'Open', viewValue: 'Open' },
        { value: 'Close', viewValue: 'Close' },
        { value: 'Unscheduled', viewValue: 'Unscheduled' }
    ];
    Priorities = [
        { value: 'High', viewValue: 'High' },
        { value: 'Medium', viewValue: 'Medium' },
        { value: 'Low', viewValue: 'Low' }
    ];
    Category = [
        { value: 'High', viewValue: 'High' },
        { value: 'Medium', viewValue: 'Medium' },
        { value: 'Low', viewValue: 'Low' }
    ];

    //Properties......
    public JobId: number;
    public WorkRequest: WorkRequest;
    public JobDescription: string;
    public StartTime: Date;
    public EndTime: Date;
    public Status: string;
    public Priority: string;
    public jobCategory: string;
    public Comments: string;
    public Observations: string;
    public result: any;
    public showError: boolean;
    public showhighError: boolean;
    public showdateError: boolean;

    //validating the Date here
    validateDate() {
        if (this.EndTime <= this.StartTime) {
            this.showhighError = true;
        }
        if (this.StartTime == undefined) {
            this.showdateError = true;
        }
    }

    openDialog() {
        let dialogRef = this.dialog.open(DialogResultDialog);
        dialogRef.afterClosed().subscribe(result => {
        });
    }

    onSubmit() {

        var data =
            {
                JobId: this.JobId,
                WorkRequest: this.WorkRequest,
                JobDescription: this.JobDescription,
                StartTime: this.StartTime,
                EndTime: this.EndTime,
                Status: this.Status,
                Priority: this.Priority,
                Comments: this.Comments,
                Observations: this.Observations

            };


        let params: URLSearchParams = new URLSearchParams();
        params.set('workRequestNumber', this.WorkRequest.WorkRequestId.toString());

        let requestOptions = new RequestOptions();
        requestOptions.search = params;

        this.http.get(this._configuration.ApiServer + this._configuration.GetWorkRequestById, requestOptions)
            .toPromise()
            .then((response: Response) => {
                let res = response.json();
                data.WorkRequest = res;
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let opt = new RequestOptions({ headers: headers });

                this.http.post(this._configuration.ApiServer + this._configuration.AddJob, JSON.stringify(data), opt)
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

