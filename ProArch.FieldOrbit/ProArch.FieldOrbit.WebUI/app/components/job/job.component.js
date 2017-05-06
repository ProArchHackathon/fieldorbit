"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var JobComponent = (function () {
    function JobComponent() {
        this.message = 'This is Job Component';
        this.Status = [
            { value: 'Open', viewValue: 'Open' },
            { value: 'Close', viewValue: 'Close' },
            { value: 'Unscheduled', viewValue: 'Unscheduled' }
        ];
        this.Priority = [
            { value: 'High', viewValue: 'High' },
            { value: 'Medium', viewValue: 'Medium' },
            { value: 'Low', viewValue: 'Low' }
        ];
        this.Category = [
            { value: 'High', viewValue: 'High' },
            { value: 'Medium', viewValue: 'Medium' },
            { value: 'Low', viewValue: 'Low' }
        ];
    }
    return JobComponent;
}());
JobComponent = __decorate([
    core_1.Component({
        selector: 'msg-app',
        templateUrl: 'app/components/job/job.component.html'
    })
], JobComponent);
exports.JobComponent = JobComponent;
//# sourceMappingURL=job.component.js.map