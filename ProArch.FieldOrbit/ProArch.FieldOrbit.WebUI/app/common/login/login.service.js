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
require("rxjs/add/operator/map");
var app_constants_1 = require("../../common/app.constants");
var LoginService = (function () {
    function LoginService(_http, _configuration) {
        var _this = this;
        this._http = _http;
        this._configuration = _configuration;
        this.ValidateLoginInformation = function (login) {
            var params = new http_1.URLSearchParams();
            params.set('username', login.username);
            params.set('password', login.password);
            var requestOptions = new http_1.RequestOptions();
            requestOptions.search = params;
            var body = JSON.stringify(login);
            //return this._http.post(this._configuration.ApiServer + this._configuration.LoginApiUrl, body,
            //    options).toPromise().catch();
            return _this._http.get(_this._configuration.ApiServer + _this._configuration.LoginApiUrl, requestOptions);
        };
    }
    LoginService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http, app_constants_1.Configuration])
    ], LoginService);
    return LoginService;
}());
exports.LoginService = LoginService;
//# sourceMappingURL=login.service.js.map