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
var http_1 = require("@angular/http");
require('rxjs/add/operator/catch');
require('rxjs/add/operator/map');
require('rxjs/add/operator/toPromise');
var app_constants_1 = require('../../common/app.constants');
var material_1 = require('@angular/material');
var dialog_1 = require('../../common/dialog/dialog');
var ServiceRequest = (function () {
    function ServiceRequest(ServiceRequestId) {
        this.ServiceRequestId = ServiceRequestId;
    }
    return ServiceRequest;
}());
exports.ServiceRequest = ServiceRequest;
var WorkRequestComponent = (function () {
    function WorkRequestComponent(http, _configuration, dialog) {
        this.http = http;
        this._configuration = _configuration;
        this.dialog = dialog;
        this.ServiceRequestType = "Electric";
        this.status = "";
        this.sTypes = [
            { value: 'electric-0', viewValue: 'Electric' },
            { value: 'water-1', viewValue: 'Water' },
            { value: 'gas-2', viewValue: 'Gas' }
        ];
        this.workStatus = [
            { value: 'open-0', viewValue: 'Open' },
            { value: 'reopen-1', viewValue: 'Re-Open' },
            { value: 'close-2', viewValue: 'Close' }
        ];
        this.ServiceRequest = {
            ServiceRequestId: 0
        };
    }
    ;
    WorkRequestComponent.prototype.ngOnInit = function () {
    };
    WorkRequestComponent.prototype.onUpdate = function () {
        var _this = this;
        var data = {
            WorkRequestId: this.WorkRequestId,
            ServiceRequest: this.ServiceRequest,
            Description: this.Description,
            StartDate: this.StartDate,
            EndDate: this.EndDate,
            ServiceRequestType: this.ServiceRequestType,
            status: this.status,
        };
        this.result = {};
        console.log(data);
        var params = new http_1.URLSearchParams();
        params.set('serviceRequestId', this.ServiceRequest.ServiceRequestId.toString());
        var requestOptions = new http_1.RequestOptions();
        requestOptions.search = params;
        this.http.get(this._configuration.ApiServer + this._configuration.GetServiceRequestById, requestOptions)
            .toPromise()
            .then(function (response) {
            var res = response.json();
            data.ServiceRequest = res;
            var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
            var opt = new http_1.RequestOptions({ headers: headers });
            _this.http.post(_this._configuration.ApiServer + _this._configuration.AddWorkRequest, JSON.stringify(data), opt)
                .toPromise()
                .then(function (response) {
                _this.openDialog();
            })
                .catch(function (errors) {
            });
        })
            .catch(function (errors) {
        });
    };
    ;
    WorkRequestComponent.prototype.extractData = function (res) {
        var body = res.json();
        return body.data || {};
    };
    ;
    WorkRequestComponent.prototype.openDialog = function () {
        var dialogRef = this.dialog.open(dialog_1.DialogResultDialog);
        dialogRef.afterClosed().subscribe(function (result) {
        });
    };
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
        this.WorkRequestId = "12345";
    };
    WorkRequestComponent = __decorate([
        core_1.Component({
            selector: 'work-request',
            templateUrl: 'app/components/workrequest/workrequest.component.html',
            providers: [app_constants_1.Configuration]
        }), 
        __metadata('design:paramtypes', [http_1.Http, app_constants_1.Configuration, material_1.MdDialog])
    ], WorkRequestComponent);
    return WorkRequestComponent;
}());
exports.WorkRequestComponent = WorkRequestComponent;
//# sourceMappingURL=workrequest.component.js.map