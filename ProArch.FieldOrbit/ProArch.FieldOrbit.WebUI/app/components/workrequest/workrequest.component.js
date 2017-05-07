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
require("rxjs/add/operator/catch");
require("rxjs/add/operator/map");
require("rxjs/add/operator/toPromise");
var WorkRequestComponent = (function () {
    function WorkRequestComponent(http) {
        this.http = http;
        this.ServiceRequestType = "Electric";
        this.status = "";
        this.serviceTypes = [
            { value: 'electric-0', viewValue: 'Electric' },
            { value: 'water-1', viewValue: 'Water' },
            { value: 'gas-2', viewValue: 'Gas' }
        ];
        this.workStatus = [
            { value: 'open-0', viewValue: 'Open' },
            { value: 'reopen-1', viewValue: 'Re-Open' },
            { value: 'close-2', viewValue: 'Close' }
        ];
    }
    ;
    WorkRequestComponent.prototype.onUpdate = function () {
        var data = {
            WorkOrderId: this.WorkOrderId,
            ServiceRequestId: this.ServiceRequestId,
            Description: this.Description,
            StartDate: this.StartDate,
            EndDate: this.EndDate,
            ServiceRequestType: this.ServiceRequestType,
            status: this.status,
        };
        this.result = {};
        console.log(data);
        var headers = new http_1.Headers({ 'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8' });
        var opt = new http_1.RequestOptions({ headers: headers });
        this.http.post('http://192.168.19.12/webapi/api/home/detailspost', JSON.stringify(data), opt)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);
        // alert(this.result);
    };
    ;
    WorkRequestComponent.prototype.extractData = function (res) {
        var body = res.json();
        return body.data || {};
    };
    ;
    WorkRequestComponent.prototype.handleError = function (error) {
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
    WorkRequestComponent.prototype.onLoad = function () {
        this.WorkOrderId = "12345";
    };
    return WorkRequestComponent;
}());
WorkRequestComponent = __decorate([
    core_1.Component({
        selector: 'work-request',
        templateUrl: 'app/components/workrequest/workrequest.component.html'
    }),
    __metadata("design:paramtypes", [http_1.Http])
], WorkRequestComponent);
exports.WorkRequestComponent = WorkRequestComponent;
//# sourceMappingURL=workrequest.component.js.map