import { Component } from '@angular/core';

@Component({
    selector: 'msg-app',
    templateUrl: 'app/components/job/job.component.html'
})

export class JobComponent {

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

    onSubmit() {
        alert(this.JobID + this.jobDesc + this.fromDate + this.toDate + this.estTime + this.selectedCountry + this.jobStatus + this.jobPriority + this.comments + this.observations);
    }
}
