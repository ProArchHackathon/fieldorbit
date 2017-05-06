import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseOptions } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'msg-app',
    templateUrl: 'app/components/job/job.component.html'
})

export class JobComponent {
    constructor(private http: Http) { }
    message = 'This is Job Component';
    Status = [
        { value: 'Open', viewValue: 'Open' },
        { value: 'Close', viewValue: 'Close' },
        { value: 'Unscheduled', viewValue: 'Unscheduled' }
    ];
    Priority = [
        { value: 'High', viewValue: 'High' },
        { value: 'Medium', viewValue: 'Medium' },
        { value: 'Low', viewValue: 'Low' }
    ];
    Category = [
        { value: 'High', viewValue: 'High' },
        { value: 'Medium', viewValue: 'Medium' },
        { value: 'Low', viewValue: 'Low' }
    ];
    JobID: number;
    jobDesc: string;
    fromDate: Date;
    toDate: Date;
    estTime: string;
    selectedCountry: string;
    jobStatus: string;
    jobPriority: string;
    jobCategory: string;
    comments: string;
    observations: string;
    result: any;

    onSubmit() {
        alert(this.JobID + this.jobDesc + this.fromDate + this.toDate + this.estTime + this.selectedCountry + this.jobStatus + this.jobPriority + this.comments + this.observations);


        var data =
            {
                JobID: this.JobID,
                jobDesc: this.jobDesc,
                fromDate: this.fromDate,
                toDate: this.toDate,
                estTime: this.estTime,
                selectedCountry: this.selectedCountry,
                jobStatus: this.jobStatus,
                jobPriority: this.jobPriority,
                comments: this.comments,
                observations: this.observations
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





}
