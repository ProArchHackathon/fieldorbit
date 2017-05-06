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
var DataService_1 = require("./DataService");
var Configuration_1 = require("./Configuration");
//import { NoteItem } from "./noteModel";
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var FileUploadDetailsComponent = (function () {
    function FileUploadDetailsComponent(_dataService) {
        this._dataService = _dataService;
    }
    FileUploadDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._dataService
            .getAll()
            .subscribe(function (data) { return _this.myItems = data; }, function (error) { return console.log(error); }, function () { return console.log("getAllItems() complete from init"); });
    };
    return FileUploadDetailsComponent;
}());
FileUploadDetailsComponent = __decorate([
    core_1.Component({
        selector: 'fileupload-details',
        providers: [DataService_1.DataService, Configuration_1.Configuration],
        moduleId: module.id,
        // templateUrl: 'app/components/fileupload/fileupload.component.html',
        templateUrl: 'fileuploaddetails.component.html',
    }),
    __metadata("design:paramtypes", [DataService_1.DataService])
], FileUploadDetailsComponent);
exports.FileUploadDetailsComponent = FileUploadDetailsComponent;
//# sourceMappingURL=fileuploaddetails.component.js.map