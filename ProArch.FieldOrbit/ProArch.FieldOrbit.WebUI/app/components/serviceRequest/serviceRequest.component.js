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
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
//import { Observable } from 'rxjs/Observable';
require("rxjs/add/operator/catch");
require("rxjs/add/operator/map");
require("rxjs/add/operator/toPromise");
var app_constants_1 = require("../../common/app.constants");
var Customer = (function () {
    function Customer(CustomerId) {
        this.CustomerId = CustomerId;
    }
    return Customer;
}());
exports.Customer = Customer;
var ServiceRequestComponent = (function () {
    function ServiceRequestComponent(http, _configuration) {
        var _this = this;
        this.http = http;
        this._configuration = _configuration;
        this.serviceType = [
            { value: 'Electricity', viewValue: 'Electricity ' },
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
    ServiceRequestComponent.prototype.onUpdate = function () {
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
            .then(this.extractData)
            .catch(this.handleError);
    };
    ;
    ServiceRequestComponent.prototype.extractData = function (res) {
        var body = res.json();
        return body.data || {};
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
    ServiceRequestComponent.prototype.onLoad = function () {
    };
    return ServiceRequestComponent;
}());
ServiceRequestComponent = __decorate([
    core_1.Component({
        selector: 'service-request',
        templateUrl: 'app/components/serviceRequest/serviceRequest.component.html',
        providers: [app_constants_1.Configuration]
    }),
    __metadata("design:paramtypes", [http_1.Http, app_constants_1.Configuration])
], ServiceRequestComponent);
exports.ServiceRequestComponent = ServiceRequestComponent;
//# sourceMappingURL=serviceRequest.component.js.map