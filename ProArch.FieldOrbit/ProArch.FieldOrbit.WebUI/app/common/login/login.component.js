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
var login_service_1 = require("./login.service");
var app_constants_1 = require("../../common/app.constants");
var app_cookieManager_1 = require("../app.cookieManager");
var router_1 = require("@angular/router");
var User = (function () {
    function User(username, password) {
        this.username = username;
        this.password = password;
    }
    return User;
}());
exports.User = User;
var LoginComponent = (function () {
    function LoginComponent(_loginService, _cookieService, _route) {
        this._loginService = _loginService;
        this._cookieService = _cookieService;
        this._route = _route;
        this.login = {
            username: "",
            password: ""
        };
    }
    LoginComponent.prototype.OnSubmit = function () {
        var _this = this;
        //var cookie = this._cookieService.getCookie("filedOrbitAccess");
        this._loginService.ValidateLoginInformation(this.login)
            .map(function (response) {
            var output = response.json();
            _this._route.navigate(['fileupload']);
            //this._cookieService.setCookie("filedOrbitAccess", output.AccessToken, 1);
        })
            .subscribe(function (errors) {
            var error = errors;
        });
    };
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        templateUrl: 'app/common/login/login.component.html',
        providers: [login_service_1.LoginService, app_constants_1.Configuration, app_cookieManager_1.CookieService]
    }),
    __metadata("design:paramtypes", [login_service_1.LoginService, app_cookieManager_1.CookieService, router_1.Router])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map