import { Component, OnInit } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Job } from '../../Models/job.model';
import { JobService } from '../../Services/Job.service';
import { DialogResultDialog } from '../../common/dialog/dialog';
import { ServiceRequestService } from '../../Services/serviceRequest.service';
import { StaticDataLoaderService } from '../../Services/staticDataLoader.service';
import { Logger } from '../../Services/logger.service';



@Component({
    selector: 'msg-app',
    templateUrl: 'job.component.html',
    styleUrls: ['job.component.scss'],
})

export class JobComponent implements OnInit {
    jobList: Job[];
    job: Job;
    minDate = new Date();
    Statuses: any;
    Types: any;
    Priorities: any;
    Category: any;
    Button: string;
    ErrorMessage: string;
    serviceRequestError: string;
    showButton: boolean;
    jobDetailsForm: FormGroup;
    failedToLoad: Boolean = false;

    constructor(public dialog: MdDialog,
                private fb: FormBuilder,
                private serviceRequestService: ServiceRequestService,
                private jobService: JobService,
                private logger: Logger,
                private _staticDataLoader: StaticDataLoaderService) {

                    this.jobDetailsForm = fb.group({
                      serviceRequestId: ['', Validators.compose([Validators.required,
                                                                 Validators.pattern('^[0-9]*$'),
                                                                 Validators.maxLength(3)])],
                      status: ['', Validators.required],
                      priority: ['', Validators.required],
                      startDate: [null, Validators.required],
                      endDate: [null, Validators.required],
                      jobDescription: ['', Validators.required],
                      comments: [null],
                      observations: [null]

        },{});
    }

    ngOnInit() {
        /**
         *  Called after the constructor,
         *  initializing input properties,
         *  and the first call to ngOnChanges.
         */
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
        this.jobDetailsForm.valueChanges.subscribe(value => this.ErrorMessage = null);
        this.Types = this._staticDataLoader.Types;
        this.Statuses = this._staticDataLoader.Statuses;
        this.Category = this._staticDataLoader.Category;
        this.Priorities = this._staticDataLoader.Priorities;
        this.Button = 'Create';
        this.getAllJobs();
        this.showButton = false;
    }

    resetDetails () {
        this.jobDetailsForm.reset();
        this.ErrorMessage = null;
        this.showButton = false;
        this.job.JobId = null;
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
                if (response === null) {
                    this.ErrorMessage = ' No service request id found';
                } else {
                    this.ErrorMessage = null;
                    this.showButton = true;
                    this.Button = 'Create';
                    this.job.ServiceRequest = response;
                }
            },
                error => {
                    this.ErrorMessage = <any>error;
                    this.showButton = false;
                },
                () => this.logger.log('Get all Items complete'));
    };

    private createJob(): void {
        this.jobService
        .createJob(this.job)
        .subscribe(response => {
            this.openDialog();
            this.resetDetails();
        },
            error => this.ErrorMessage = <any>error,
            () => this.logger.log('Get all Items complete'));
    }

    private updateJob(): void {
        this.jobService
            .updateJob(this.job)
            .subscribe(response => {
                this.openDialog();
                this.resetDetails();
            },
            error => this.ErrorMessage = <any>error,
            () => this.logger.log('Get all Items complete'));
    }

    onSubmit() {
        if (this.jobDetailsForm.valid){
            if (this.Button === 'Create') {
                this.createJob();
            }else {
                this.updateJob();
            }
            this.ErrorMessage = null;
            this.serviceRequestError = null;
        }else {
            this.ErrorMessage = 'Provide input to all the fields';
        }
    };

    onSelectedRow(job: Job): void {
        this.job = job;
        this.Button = 'Update';
        this.showButton = true;
    }
}

