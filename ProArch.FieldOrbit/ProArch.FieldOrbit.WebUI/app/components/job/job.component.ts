import { Job } from '../../Models/job.model';
import { Component, OnInit } from '@angular/core';
import { JobService } from '../../Services/Job.service';
import { MdDialog, MdDialogRef } from '@angular/material';
import { DialogResultDialog } from '../../common/dialog/dialog';
import { ServiceRequestService } from '../../Services/serviceRequest.service';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { StaticDataLoaderService } from '../../Services/staticDataLoader.service';
import { FormBuilder } from '@angular/forms';


@Component({
    selector: 'msg-app',
    templateUrl: 'job.component.html',
    styleUrls: ['job.component.scss'],
})

export class JobComponent implements OnInit{
    jobList: Job[];
    job: Job;
    Statuses: any;
    Types: any;
    Priorities: any;
    Category: any;
    result: any;
    showError: boolean;
    showhighError: boolean;
    showdateError: boolean;
    Button: string;
    ErrorMessage: string;
    serviceRequestError: string;
    showButton: boolean;
    failedToLoad: Boolean = false;
    message = 'This is Job Component';

    constructor(public dialog: MdDialog,
                private fb: FormBuilder,
                private serviceRequestService: ServiceRequestService,
                private jobService: JobService,
                private _staticDataLoader: StaticDataLoaderService) { }

    ngOnInit() {
        //  Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        this.job = {
            JobId: null,
            ServiceRequest : {
                ServiceRequestId: 0
            },
            JobDescription: '',
            StartTime: null,
            EndTime: null,
            Status: '',
            Priority: '',
            Comments: '',
            Observations: ''
        };
        this.Types = this._staticDataLoader.Types;
        this.Statuses = this._staticDataLoader.Statuses;
        this.Category = this._staticDataLoader.Category;
        this.Priorities = this._staticDataLoader.Priorities;
        this.Button = 'Create';
        this.getAllJobs();
        this.showButton = false;
    }

    // validating the Date here
    validateDate() {
        this.ErrorMessage = null;
        this.serviceRequestError = null;
        if (!this.job.StartTime) {
            this.ErrorMessage = 'Please Select Start Time';
        }else if (this.job.EndTime && (this.job.EndTime <= this.job.StartTime)) {
            this.ErrorMessage = 'End Time should be greater than Start Time';
        }
    }

    openDialog() {
        let dialogRef = this.dialog.open(DialogResultDialog);
        dialogRef.afterClosed().subscribe(result => {
            this.getAllJobs();
            this.failedToLoad = false;
        });
    }

    getAllJobs() {
        this.jobService
        .getJobDetails()
        .subscribe(response => {
            this.jobList = response;
        },
            error => this.failedToLoad = true,
            () => console.log('Get all Items complete'));
    }

    getServiceRequest() {
        this.serviceRequestError = null;

        this.serviceRequestService
            .getServiceRequestDetails(this.job.ServiceRequest.ServiceRequestId.toString())
            .subscribe(response => {
                this.job.ServiceRequest = response;
                this.showButton = true;
            },
                error => {
                    console.log(error);
                    this.ErrorMessage = <any>error;
                    this.showButton = false;
                },
                () => console.log('Get all Items complete'));
    };

    onSubmit() {
        this.ErrorMessage = null;
        this.serviceRequestError = null;
        if (this.Button === 'Create') {
            this.jobService
                .createJob(this.job)
                .subscribe(response => {
                    this.openDialog();
                },
                    error => this.ErrorMessage = <any>error,
                    () => console.log('Job Creation complete'));
        }else {
            this.jobService
                .updateJob(this.job)
                .subscribe(response => {
                    this.openDialog();
                },
                    error => this.ErrorMessage = <any>error,
                    () => console.log('Job Update complete'));
        }
    };

    onSelectedRow(sr): void {
        this.job = sr;
        this.Button = 'Update';
        console.log(this.job, 'job');
    }
}

