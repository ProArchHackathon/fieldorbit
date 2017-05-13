"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var AppComponent = (function () {
    function AppComponent() {
        this.navLinks = [{ route: 'servicerequest', label: 'Service Request' },
            { route: 'workrequest', label: 'Work Request' },
            { route: 'job', label: 'Job' }];
    }
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'msg-app',
        template: "<nav class=\"tab-background\" md-tab-nav-bar>\n  <a md-tab-link *ngFor=\"let link of navLinks\"\n     [routerLink]=\"link.route\"\n     routerLinkActive #rla=\"routerLinkActive\"\n     [active]=\"rla.isActive\">\n    {{link.label}}\n  </a>\n</nav>\n<router-outlet></router-outlet>"
    })
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map