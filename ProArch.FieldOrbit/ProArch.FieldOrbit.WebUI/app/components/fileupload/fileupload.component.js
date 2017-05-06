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
//import { Product } from "./Product";
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var FileUploadComponent = (function () {
    function FileUploadComponent(_dataService) {
        this._dataService = _dataService;
        this.model = {};
    }
    FileUploadComponent.prototype.onSubmit = function () {
        this._dataService
            .postSomething(this.model);
    };
    return FileUploadComponent;
}());
FileUploadComponent = __decorate([
    core_1.Component({
        selector: 'file-upload',
        moduleId: module.id,
        // templateUrl: 'app/components/fileupload/fileupload.component.html',
        templateUrl: 'fileupload.component.html',
        providers: [DataService_1.DataService, Configuration_1.Configuration],
    }),
    __metadata("design:paramtypes", [DataService_1.DataService])
], FileUploadComponent);
exports.FileUploadComponent = FileUploadComponent;
//# sourceMappingURL=fileupload.component.js.map