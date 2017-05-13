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
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/map");
require("rxjs/add/operator/toPromise");
var app_constants_1 = require("../../common/app.constants");
var ServiceRequestListComponent = (function () {
    function ServiceRequestListComponent(http, _configuration) {
        var _this = this;
        this.http = http;
        this._configuration = _configuration;
        this.http.get(this._configuration.ApiServer + this._configuration.GetAllServiceRequests, null)
            .toPromise()
            .then(function (response) {
            _this.serviceRequestList = response.json();
        })
            .catch(function (errors) {
        });
    }
    ;
    ServiceRequestListComponent.prototype.extractData = function (res) {
    };
    ;
    ServiceRequestListComponent.prototype.handleError = function (error) {
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
    return ServiceRequestListComponent;
}());
ServiceRequestListComponent = __decorate([
    core_1.Component({
        selector: 'service-list-component',
        templateUrl: 'app/components/servicelist/srlist.component.html',
        providers: [app_constants_1.Configuration]
    }),
    __metadata("design:paramtypes", [http_1.Http, app_constants_1.Configuration])
], ServiceRequestListComponent);
exports.ServiceRequestListComponent = ServiceRequestListComponent;
//# sourceMappingURL=srlist.component.js.map