"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
//import { Observable } from 'rxjs/Observable';
require('rxjs/add/operator/catch');
require('rxjs/add/operator/map');
require('rxjs/add/operator/toPromise');
var app_constants_1 = require('../../common/app.constants');
var material_1 = require('@angular/material');
var dialog_1 = require('../../common/dialog/dialog');
var Customer = (function () {
    function Customer(CustomerId) {
        this.CustomerId = CustomerId;
    }
    return Customer;
}());
exports.Customer = Customer;
var ServiceRequestComponent = (function () {
    function ServiceRequestComponent(http, _configuration, dialog) {
        var _this = this;
        this.http = http;
        this._configuration = _configuration;
        this.dialog = dialog;
        this.serviceType = [
            { value: 'Electric', viewValue: 'Electric' },
            { value: 'Gas', viewValue: 'Gas' },
            { value: 'Water', viewValue: 'Water' },
        ];
        this.statusList = [
            { value: 'Open', viewValue: 'Open' },
            { value: 'InProgress', viewValue: 'InProgress' },
            { value: 'Closed', viewValue: 'Closed' },
            { value: 'Hold', viewValue: 'Hold' }
        ];
        this.requestType = [
            { value: 'Connect', viewValue: 'Connect' },
            { value: 'Reconnect', viewValue: 'Reconnect' },
            { value: 'Disconnect', viewValue: 'Disconnect' },
            { value: 'Miscellaneous', viewValue: 'Miscellaneous' }
        ];
        this.Customer = {
            CustomerId: 0
        };
        this.http.get(this._configuration.ApiServer + this._configuration.GetAllServiceRequests, null)
            .toPromise()
            .then(function (response) {
            _this.serviceRequestList = response.json();
        })
            .catch(function (errors) {
        });
    }
    ;
    ServiceRequestComponent.prototype.openDialog = function () {
        var dialogRef = this.dialog.open(dialog_1.DialogResultDialog);
        dialogRef.afterClosed().subscribe(function (result) {
        });
    };
    ServiceRequestComponent.prototype.onUpdate = function () {
        var _this = this;
        var data = {
            SrNumber: this.SrNumber,
            RequestedBy: this.RequestedBy,
            ServiceType: this.ServiceType,
            RequestType: this.RequestType,
            CreatedDate: new Date(this.CreatedDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-'),
            StartDate: new Date(this.StartDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-'),
            EndDate: (this.EndDate) ? new Date(this.EndDate).toLocaleDateString('en-GB', {
                day: 'numeric',
                month: 'short',
                year: 'numeric'
            }).split(' ').join('-') : null,
            Customer: this.Customer,
            Status: this.Status,
            Location: this.Location
        };
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var opt = new http_1.RequestOptions({ headers: headers });
        this.http.post(this._configuration.ApiServer + this._configuration.AddServiceRequest, JSON.stringify(data), opt)
            .toPromise()
            .then(function (response) {
            _this.openDialog();
        })
            .catch(this.handleError);
    };
    ;
    ServiceRequestComponent.prototype.handleError = function (error) {
        // In a real world app, we might use a remote logging infrastructure
        var errMsg;
        if (error instanceof http_1.Response) {
            var body = error.json() || '';
            var err = body.error || JSON.stringify(body);
            errMsg = error.status + " - " + (error.statusText || '') + " " + err;
        }
        else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Promise.reject(errMsg);
    };
    ServiceRequestComponent.prototype.onSelectedRow = function (serviceRequest) {
        this.SrNumber = serviceRequest.ServiceRequestId;
        this.RequestedBy = serviceRequest.RequestedBy;
        this.ServiceType = serviceRequest.ServiceType;
        this.RequestType = serviceRequest.RequestType;
        this.Customer.CustomerId = serviceRequest.Customer.CustomerId;
        this.Location = serviceRequest.Location;
        this.CreatedDate = new Date(serviceRequest.CreatedDate);
        this.StartDate = serviceRequest.StartDate;
        this.EndDate = serviceRequest.EndDate;
        this.Status = serviceRequest.Status;
    };
    ServiceRequestComponent.prototype.onLoad = function () {
    };
    ServiceRequestComponent = __decorate([
        core_1.Component({
            selector: 'service-request',
            templateUrl: 'app/components/serviceRequest/serviceRequest.component.html',
            providers: [app_constants_1.Configuration]
        }), 
        __metadata('design:paramtypes', [http_1.Http, app_constants_1.Configuration, material_1.MdDialog])
    ], ServiceRequestComponent);
    return ServiceRequestComponent;
}());
exports.ServiceRequestComponent = ServiceRequestComponent;
//# sourceMappingURL=serviceRequest.component.js.map