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
var app_constants_1 = require("../../common/app.constants");
var material_1 = require("@angular/material");
var dialog_1 = require("../../common/dialog/dialog");
var WorkRequest = (function () {
    function WorkRequest(WorkRequestId) {
        this.WorkRequestId = WorkRequestId;
    }
    return WorkRequest;
}());
exports.WorkRequest = WorkRequest;
var JobComponent = (function () {
    function JobComponent(http, _configuration, dialog) {
        this.http = http;
        this._configuration = _configuration;
        this.dialog = dialog;
        this.message = 'This is Job Component';
        this.Statuses = [
            { value: 'Open', viewValue: 'Open' },
            { value: 'Close', viewValue: 'Close' },
            { value: 'Unscheduled', viewValue: 'Unscheduled' }
        ];
        this.Priorities = [
            { value: 'High', viewValue: 'High' },
            { value: 'Medium', viewValue: 'Medium' },
            { value: 'Low', viewValue: 'Low' }
        ];
        this.Category = [
            { value: 'High', viewValue: 'High' },
            { value: 'Medium', viewValue: 'Medium' },
            { value: 'Low', viewValue: 'Low' }
        ];
        this.WorkRequest = {
            WorkRequestId: 0
        };
    }
    //validating the Date here
    JobComponent.prototype.validateDate = function () {
        if (this.EndTime <= this.StartTime) {
            this.showhighError = true;
        }
        if (this.StartTime == undefined) {
            this.showdateError = true;
        }
    };
    JobComponent.prototype.openDialog = function () {
        var dialogRef = this.dialog.open(dialog_1.DialogResultDialog);
        dialogRef.afterClosed().subscribe(function (result) {
        });
    };
    JobComponent.prototype.onSubmit = function () {
        var _this = this;
        var data = {
            JobId: this.JobId,
            WorkRequest: this.WorkRequest,
            JobDescription: this.JobDescription,
            StartTime: this.StartTime,
            EndTime: this.EndTime,
            Status: this.Status,
            Priority: this.Priority,
            Comments: this.Comments,
            Observations: this.Observations
        };
        var params = new http_1.URLSearchParams();
        params.set('workRequestNumber', this.WorkRequest.WorkRequestId.toString());
        var requestOptions = new http_1.RequestOptions();
        requestOptions.search = params;
        this.http.get(this._configuration.ApiServer + this._configuration.GetWorkRequestById, requestOptions)
            .toPromise()
            .then(function (response) {
            var res = response.json();
            data.WorkRequest = res;
            var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
            var opt = new http_1.RequestOptions({ headers: headers });
            _this.http.post(_this._configuration.ApiServer + _this._configuration.AddJob, JSON.stringify(data), opt)
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
    JobComponent.prototype.extractData = function (res) {
        var body = res.json();
        return body.data || {};
    };
    ;
    JobComponent.prototype.handleError = function (error) {
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
    return JobComponent;
}());
JobComponent = __decorate([
    core_1.Component({
        selector: 'msg-app',
        templateUrl: 'app/components/job/job.component.html',
        styleUrls: ['app/components/job/job.component.css'],
        providers: [app_constants_1.Configuration]
    }),
    __metadata("design:paramtypes", [http_1.Http, app_constants_1.Configuration, material_1.MdDialog])
], JobComponent);
exports.JobComponent = JobComponent;
//# sourceMappingURL=job.component.js.map