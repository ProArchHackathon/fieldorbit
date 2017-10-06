import { MdDialog, MdDialogRef } from '@angular/material';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { DialogResultDialog } from '../../common/dialog/dialog';
import { ServiceRequest } from '../../Models/serviceRequest.model';
import { ServiceRequestService } from '../../Services/serviceRequest.service';
import { StaticDataLoaderService } from './../../Services/staticDataLoader.service';


@Component({
    selector: 'service-request',
    templateUrl: 'serviceRequest.component.html',
    encapsulation: ViewEncapsulation.None
})

export class ServiceRequestComponent implements OnInit{
    Button: string;
    statusList: any;
    requestType: any;
    serviceType: any;
    minDate = new Date();
    ErrorMessage: string;
    failedToLoad: Boolean = false;
    serviceRequestList: ServiceRequest[];
    serviceRequest: ServiceRequest;
    public serviceRequestForm: FormGroup;

    constructor(public dialog: MdDialog,
                private formBuilder: FormBuilder,
                private serviceRequestService: ServiceRequestService,
                private staticDataLoaderService: StaticDataLoaderService) {

                    this.serviceRequestForm = formBuilder.group({

                        requestedBy: ['', Validators.compose([Validators.required,
                                          Validators.pattern('^[0-9]*$'),
                                          Validators.minLength(4),
                                          Validators.maxLength(6)])],
                        customerId: ['',  Validators.compose([Validators.required,
                                          Validators.pattern('^[0-9]*$'),
                                          Validators.maxLength(4)])],
                        serviceType: ['', Validators.required],
                        status: ['', Validators.required],
                        requestType: ['', Validators.required],
                        createdDate: [{ value: new Date(), disabled: true }, Validators.required],
                        startDate: [new Date()],
                        endDate: [null]
                    });
    };

    ngOnInit() {
        this.serviceRequest = {
            ServiceRequestId: null,
            SrNumber: null,
            ServiceType: '',
            CreatedBy: {
                EmployeeId: 0
            },
            RequestType: '',
            Customer: {
                CustomerId: 0 
            },
            CreatedDate: new Date(),
            StartDate: new Date(),
            EndDate: null,
            Status: null,
            Location: '',
            Type: 'ServiceRequest'
        };

        this.Button = 'Create';
        this.getAllServiceRequests();
        this.serviceType = this.staticDataLoaderService.serviceType;
        this.statusList = this.staticDataLoaderService.statusList;
        this.requestType = this.staticDataLoaderService.requestType;
    }

    clearDateDetails() {
        this.serviceRequest.EndDate = null;
    }


    resetDetails() {
        this.serviceRequestForm.reset();
        this.Button = 'Create';
        this.serviceRequest.SrNumber = null;
        this.serviceRequest.Location = null;
        this.ErrorMessage = null;
    }

    getAllServiceRequests() {
        this.serviceRequestService
            .getAllServiceRequestDetails()
            .subscribe(response => {
                this.serviceRequestList = response;
            },
                error => this.failedToLoad = true,
                () => console.log('Get all Items complete'));
    }

    validateDate() {
        this.ErrorMessage = null;
        if (!this.serviceRequest.StartDate) {
            this.ErrorMessage = 'Please Select Start Date';
        }else if (this.serviceRequest.EndDate && (this.serviceRequest.EndDate <= this.serviceRequest.StartDate)) {
            this.ErrorMessage = 'End Date should be greater than Start Date';
        }
    }

    openDialog() {
        let dialogRef = this.dialog.open(DialogResultDialog);
        dialogRef.afterClosed()
                 .subscribe(result => {
            this.getAllServiceRequests();
            this.failedToLoad = false;
        });
    }

    createServiceRequest() {
        this.serviceRequestService
            .addServiceRequest(this.serviceRequest)
            .subscribe(response => { this.openDialog(); },
                       error => this.ErrorMessage = <any>error,
                       () => console.log('Get all Items complete'));
    }

    updateServiceRequest() {
        this.serviceRequestService
            .updateServiceRequest(this.serviceRequest)
            .subscribe(response => { this.openDialog(); },
                       error => this.ErrorMessage = <any>error,
                       () => console.log('Get all Items complete'));
    }

    onUpdate(): void {

      if (this.serviceRequestForm.valid) {
        this.ErrorMessage = null;
        if (this.Button === 'Create')  {
            this.createServiceRequest();
          } else {
            this.updateServiceRequest();
          }
      } else {
          this.ErrorMessage = 'Provide input to all the fields';
      }
    };

    onSelectedRow(serviceRequest: ServiceRequest): void {
        console.log(serviceRequest);
        this.serviceRequest = serviceRequest;
        if (this.serviceRequest.Customer.Address.length === 0){
            this.serviceRequest.Customer.Address = null;
        }
        this.serviceRequest.Type = 'ServiceRequest';
        this.Button = 'Update';
    }
}
