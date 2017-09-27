import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { MdDialog, MdDialogRef, MdDatepickerModule, MdNativeDateModule} from '@angular/material';

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
                        requestedBy: [null, Validators.compose([Validators.required,
                                          Validators.pattern('^[0-9]*$'),
                                          Validators.minLength(4),
                                          Validators.maxLength(6)])],
                        customerId: [null, Validators.compose([Validators.required,
                                         Validators.pattern('^[0-9]*$'),
                                         Validators.minLength(4),
                                         Validators.maxLength(6)])],
                        createdDate: [{ value: new Date(), disabled: true }, Validators.required],
                        startDate: [null],
                        endDate: [null]
                    });
                };

    ngOnInit() {
        /**
         *  Called after the constructor,
         *  initializing input properties,
         *  and the first call to ngOnChanges.
         */
        this.workRequest = {
            SrNumber: null,
            CreatedBy: {
                EmployeeId: ''
            },
            ServiceType: '',
            RequestType: '',
            CreatedDate: new Date(),
            StartDate: new Date(),
            EndDate: null,
            Customer : {
                CustomerId: null
            },
            Status: '',
            Location: '',
            Type: 'WorkRequest'
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
        this.ErrorMessage = null;
        this.workRequest.CreatedDate = new Date();
        console.log(this.workRequest);
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
        this.workRequestService
            .addWorkRequest(this.workRequest)
            .subscribe(response => { this.openDialog(); },
                       error => this.ErrorMessage = <any>error,
                       () => console.log('Get all Items complete'));
    }

    updateWorkRequest () {
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

    onSelectedRow(workRequest: WorkRequest): void {
        this.workRequest = workRequest;
        this.Button = 'Update';
    }
}
