"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var animations_1 = require("@angular/platform-browser/animations");
var material_1 = require("@angular/material");
var router_1 = require("@angular/router");
var http_1 = require("@angular/http");
var job_component_1 = require("../components/job/job.component");
var login_component_1 = require("../common/login/login.component");
var app_component_1 = require("../common/app.component");
//import { FileUploadComponent } from '../components/fileupload/fileupload.component';
//import { FileUploadDetailsComponent } from '../components/fileupload/fileuploaddetails.component';
var serviceRequest_component_1 = require("../components/serviceRequest/serviceRequest.component");
var workrequest_component_1 = require("../components/workrequest/workrequest.component");
var sidenav_1 = require("./material/sidenav");
var srlist_component_1 = require("../components/servicelist/srlist.component");
//import 'hammerjs';
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule, http_1.HttpModule, animations_1.BrowserAnimationsModule, material_1.MaterialModule.forRoot(),
            router_1.RouterModule.forRoot([
                {
                    path: 'login',
                    component: login_component_1.LoginComponent
                },
                {
                    path: 'job',
                    component: job_component_1.JobComponent
                },
                {
                    path: 'servicerequest',
                    component: serviceRequest_component_1.ServiceRequestComponent
                },
                {
                    path: 'workrequest',
                    component: workrequest_component_1.WorkRequestComponent
                },
                {
                    path: '',
                    redirectTo: '/login',
                    pathMatch: 'full'
                }
            ], { useHash: true })
        ],
        declarations: [
            app_component_1.AppComponent, job_component_1.JobComponent, login_component_1.LoginComponent, srlist_component_1.ServiceRequestListComponent,
            serviceRequest_component_1.ServiceRequestComponent, workrequest_component_1.WorkRequestComponent, sidenav_1.SidenavComponent
        ],
        exports: [
            material_1.MaterialModule
        ],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=module.js.map