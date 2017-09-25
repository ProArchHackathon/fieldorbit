﻿import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { MdDialog, MdDialogRef,MdDatepickerModule, MdNativeDateModule} from '@angular/material';

import { DialogResultDialog } from '../../common/dialog/dialog';
import { viewer } from './../../Models/viewer.model';
import { Customer } from '../../Models/customer.model';
import { StaticDataLoaderService } from '../../Services/staticDataLoader.service';
import { WorkRequest } from './../../Models/workRequest.model';
import { WorkRequestService } from '../../Services/workRequest.service';

@Component({
    selector: 'work-request',
    templateUrl: 'workrequest.component.html'
})

export class WorkRequestComponent implements OnInit{
    statusList: viewer[];
    requestType: viewer[];
    serviceType: viewer[];
    minDate = new Date();
    workRequest: WorkRequest;
    workRequestForm: FormGroup;
    Button: string;
    ErrorMessage: string;
    workRequestList: WorkRequest[];
    failedToLoad: Boolean = false;
    constructor(public dialog: MdDialog,
                private _formBuilder: FormBuilder,
                private workRequestService: WorkRequestService,
                private _staticDataLoader: StaticDataLoaderService) {

                    this.workRequestForm = _formBuilder.group({
                        serviceType: ['', Validators.required],
                        status: ['', Validators.required],
                        requestType: ['', Validators.required],
                        requestedBy: ['', Validators.required],
                        customerId: ['', Validators.required],
                        createdDate: [null, Validators.required]
                    });
                };

    ngOnInit() {
        // Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        this.workRequest = {
            SrNumber: null,
            RequestedBy: '',
            ServiceType: '',
            RequestType: '',
            CreatedDate: new Date(),
            StartDate: new Date(),
            EndDate: null,
            Customer : {
                CustomerId: null
            },
            Status: '',
            Location: ''
        };
        this.serviceType = this._staticDataLoader.serviceType;
        this.statusList = this._staticDataLoader.statusList;
        this.requestType = this._staticDataLoader.requestType;
        this.Button = 'Create';
        this.getAllWorkRequests();
    }

    resetDetails() {
        this.workRequestForm.reset();
        this.Button = 'Create';
        this.workRequest.SrNumber = null;
    }

    validateDate() {
        if (!this.workRequest.StartDate) {
            this.ErrorMessage = 'Please Select Start Date';
        }else if (this.workRequest.EndDate && (this.workRequest.EndDate <= this.workRequest.StartDate)) {
            this.ErrorMessage = 'End Date should be greater than Start Date';
        }
    }

    getAllWorkRequests() {
        this.workRequestService
            .getAllWorkRequests()
            .subscribe(response => {
                this.workRequestList = response;
            },
                error => this.failedToLoad = true,
                () => console.log('Get all Items complete'));
    }

    openDialog() {
        let dialogRef = this.dialog.open(DialogResultDialog);
        dialogRef.afterClosed().subscribe(result => {
            this.getAllWorkRequests();
            this.failedToLoad = false;
        });
    }

    createWorkRequest () {
        console.log(this.workRequestService);
        this.workRequestService
            .addWorkRequest(this.workRequest)
            .subscribe(response => { this.openDialog(); },
                       error => this.ErrorMessage = <any>error,
                       () => console.log('Get all Items complete'));
    }

    updateWorkRequest () {
        console.log(this.workRequestService);
        this.workRequestService
            .updateWorkRequest(this.workRequest)
            .subscribe(response => { this.openDialog(); },
                       error => this.ErrorMessage = <any>error,
                       () => console.log('Get all Items complete'));
    }

    onUpdate(button): void {
        if (this.workRequestForm.valid) {
         if (this.Button === 'Create')  {
           this.createWorkRequest();
         } else {
            this.updateWorkRequest();
        }
            this.ErrorMessage = null;
        }else {
            this.ErrorMessage = 'Enter all the required fields';
        }

      };

    onSelectedRow(serviceRequest): void {
        this.workRequest.SrNumber = serviceRequest.ServiceRequestId;
        this.workRequest.RequestedBy = serviceRequest.CreatedBy == null ? 0 : serviceRequest.CreatedBy.EmployeeId;
        this.workRequest.ServiceType = serviceRequest.ServiceType;
        this.workRequest.RequestType = serviceRequest.RequestType;
        this.workRequest.Customer.CustomerId = serviceRequest.Customer.CustomerId;
        this.workRequest.Location = serviceRequest.Location;
        this.workRequest.CreatedDate = new Date(serviceRequest.CreatedDate);
        this.workRequest.StartDate = new Date(serviceRequest.StartDate);
        this.workRequest.EndDate = new Date(serviceRequest.EndDate);
        this.workRequest.Status = serviceRequest.Status;
        this.Button = 'Update';
    }
}
