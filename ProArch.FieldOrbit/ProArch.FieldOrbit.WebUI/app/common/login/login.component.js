"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var User = (function () {
    function User(username, password) {
        this.username = username;
        this.password = password;
    }
    return User;
}());
exports.User = User;
var LoginComponent = (function () {
    function LoginComponent() {
        this.login = {
            username: "",
            password: ""
        };
    }
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        templateUrl: 'app/common/login/login.component.html'
    })
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map