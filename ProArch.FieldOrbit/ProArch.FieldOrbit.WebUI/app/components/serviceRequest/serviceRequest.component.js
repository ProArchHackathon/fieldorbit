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
var ServiceRequestComponent = (function () {
    function ServiceRequestComponent(http) {
        this.http = http;
        this.serviceType = [
            { value: 'Connect-0', viewValue: 'Connect' },
            { value: 'Reconnect-1', viewValue: 'Reconnect' },
            { value: 'Disconnect-2', viewValue: 'Disconnect' },
            { value: 'Miscellaneous-3', viewValue: 'Miscellaneous' }
        ];
        this.requestType = [
            { value: 'Connect-0', viewValue: 'Connect' },
            { value: 'Reconnect-1', viewValue: 'Reconnect' },
            { value: 'Disconnect-2', viewValue: 'Disconnect' },
            { value: 'Miscellaneous-3', viewValue: 'Miscellaneous' }
        ];
    }
    ;
    ServiceRequestComponent.prototype.onUpdate = function () {
        alert(this.RequestedBy + this.CreateDate + this.CostomerId + this.CompletedDate + this.Fee);
        var data = {
            SrNumber: this.SrNumber,
            RequestedBy: this.RequestedBy,
            ServiceType: this.ServiceType,
            RequestType: this.RequestType,
            CreateDate: this.CreateDate,
            CompletedDate: this.CompletedDate,
            CostomerId: this.CostomerId,
            Fee: this.Fee
        };
        this.result = {};
        var headers = new http_1.Headers({ 'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8' });
        var opt = new http_1.RequestOptions({ headers: headers });
        this.http.post('http://192.168.19.12/webapi/api/home/detailspost', JSON.stringify(data), opt)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);
        alert(this.result);
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
        this.SrNumber = "12345";
    };
    return ServiceRequestComponent;
}());
ServiceRequestComponent = __decorate([
    core_1.Component({
        selector: 'service-request',
        templateUrl: 'app/components/serviceRequest/serviceRequest.component.html'
    }),
    __metadata("design:paramtypes", [http_1.Http])
], ServiceRequestComponent);
exports.ServiceRequestComponent = ServiceRequestComponent;
//# sourceMappingURL=serviceRequest.component.js.map