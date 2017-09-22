import { viewer } from './../Models/viewer.model';
import { Injectable } from '@angular/core';

@Injectable()
export class StaticDataLoaderService {

    private readonly _serviceType: viewer[] = [
        { value: 'Electric', viewValue: 'Electric' },
        { value: 'Gas', viewValue: 'Gas' },
        { value: 'Water', viewValue: 'Water' },
    ];

    private readonly _statusList: viewer[]  = [
        { value: 'Open', viewValue: 'Open' },
        { value: 'InProgress', viewValue: 'InProgress' },
        { value: 'Closed', viewValue: 'Closed' },
        { value: 'Hold', viewValue: 'Hold' }
    ];

    private readonly _requestType: viewer[]  = [
        { value: 'Connect', viewValue: 'Connect' },
        { value: 'Reconnect', viewValue: 'Reconnect' },
        { value: 'Disconnect', viewValue: 'Disconnect' },
        { value: 'Miscellaneous', viewValue: 'Miscellaneous' }
    ];

    private readonly _statuses: viewer[]  = [
        { value: 'Open', viewValue: 'Open' },
        { value: 'Close', viewValue: 'Close' },
        { value: 'Unscheduled', viewValue: 'Unscheduled' }
    ];

    private readonly _types: viewer[]  = [
        { value: 'WorkRequest', viewValue: 'Work Request' },
        { value: 'ServiceRequest', viewValue: 'Service Request' }
    ];

    private readonly _priorities: viewer[]  = [
        { value: 'High', viewValue: 'High' },
        { value: 'Medium', viewValue: 'Medium' },
        { value: 'Low', viewValue: 'Low' }
    ];

    private readonly _category: viewer[] = [
        { value: 'High', viewValue: 'High' },
        { value: 'Medium', viewValue: 'Medium' },
        { value: 'Low', viewValue: 'Low' }
    ];

    constructor() { }

    get Statuses(): viewer[] { return this._statuses; }
    get Types(): viewer[] { return this._types; }
    get Priorities(): viewer[] { return this._priorities; }
    get Category(): viewer[] { return this._category; }
    get serviceType(): viewer[] { return this._serviceType; }
    get statusList(): viewer[] { return this._statusList; }
    get requestType(): viewer[] { return this._requestType; }

    FormatDate (dataList) {
        dataList.forEach(element => {
            element.StartDate = new Date(element.StartDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-');
            element.CreatedDate = new Date(element.CreatedDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-');
            element.EndDate = new Date(element.EndDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-');
        });

        return dataList;
    }


    formatJobDate(dataList) {
        dataList.forEach(element => {
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

        return dataList;
    }

    modifyData(Request, type) {

        let data = {
            ServiceRequestId: Request.SrNumber,
            CreatedBy: { EmployeeId: Request.RequestedBy },
            ServiceType: Request.ServiceType,
            RequestType: Request.RequestType,
            CreatedDate: new Date(Request.CreatedDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-'),
            StartDate: new Date(Request.StartDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-'),
            EndDate: (Request.EndDate) ? new Date(Request.EndDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-') : null,
            Customer: Request.Customer,
            Status: Request.Status,
            Location: Request.Location,
            Type: type
        };

        return data;
    }

}