"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var Configuration = (function () {
    function Configuration() {
        this.ApiServer = "http://localhost/test-fieldorbit-api";
        this.LoginApiUrl = "api/LoginOperations/Validate";
        //Service Request Info Api Calls
        this.AddServiceRequest = "api/ServiceRequest/Post";
        this.UpdateServiceRequest = "api/ServiceRequest/Put";
        this.GetAllServiceRequests = "api/ServiceRequest/GetAllServiceRequest";
        this.GetServiceRequestById = "api/ServiceRequest/Get";
        //Work Request
        this.GetWorkRequestById = "api/WorkRequest/Get";
        this.AddWorkRequest = "api/WorkRequest/Post";
        this.UpdateWorkRequest = "api/WorkRequest/Put";
        //Job
        this.GetJobById = "api/Job/GetJobById";
        this.AddJob = "api/Job/Post";
    }
    return Configuration;
}());
Configuration = __decorate([
    core_1.Injectable()
], Configuration);
exports.Configuration = Configuration;
//# sourceMappingURL=app.constants.js.map