"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var Configuration = (function () {
    function Configuration() {
        this.ApiServer = "http://localhost/webapi/"; // when you run with IIS
        // if you run the project with IIS express, please use the address http://localhost:51214/
        this.GetApiUrl = "api/Home";
        this.PostApiUrl = "api/Home/detailspost";
        // public ServerWithApiUrl: string = this.ApiServer + this.ApiUrl;
        this.ServerWithApiUrlGet = this.ApiServer + this.GetApiUrl;
        this.ServerWithApiUrlPost = this.ApiServer + this.PostApiUrl;
    }
    return Configuration;
}());
Configuration = __decorate([
    core_1.Injectable()
], Configuration);
exports.Configuration = Configuration;
//# sourceMappingURL=Configuration.js.map