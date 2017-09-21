import { Component, OnInit } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';
import { DialogResultDialog } from '../../common/dialog/dialog';
import { MdDatepickerModule, MdNativeDateModule } from '@angular/material';
import { Customer } from '../../Models/customer.model';
import { StaticDataLoaderService } from '../../Services/staticDataLoader.service';
import { WorkRequest } from './../../Models/workRequest.model';
import { WorkRequestService } from '../../Services/workRequest.service';

@Component({
    selector: 'work-request',
    templateUrl: 'workrequest.component.html'
})

export class WorkRequestComponent implements OnInit{
    statusList: any;
    requestType: any;
    serviceType: any;
    workRequest: WorkRequest;
    Button: string;
    ErrorMessage: string;
    workRequestList: any;

    constructor(public dialog: MdDialog,
                private workRequestService: WorkRequestService,
                private _staticDataLoader: StaticDataLoaderService) {};

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
                error => this.ErrorMessage = <any>error,
                () => console.log('Get all Items complete'));
    }

    openDialog() {
        let dialogRef = this.dialog.open(DialogResultDialog);
        dialogRef.afterClosed().subscribe(result => {
            this.getAllWorkRequests();
        });
    }

    createWorkRequest (){
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

    onUpdate(valid): void {
        this.ErrorMessage = null;
        if (this.Button === 'Create')  {
          this.createWorkRequest();
        } else {
          this.updateWorkRequest();
        }
      };

    private onSelectedRow(serviceRequest): void {
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
    onLoad() {

    }
}
