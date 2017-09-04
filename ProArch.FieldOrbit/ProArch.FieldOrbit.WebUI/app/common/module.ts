import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '@angular/material';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { JobComponent } from '../components/job/job.component';
import { LoginComponent } from '../common/login/login.component';
import { AppComponent } from '../common/app.component';
//import { FileUploadComponent } from '../components/fileupload/fileupload.component';
//import { FileUploadDetailsComponent } from '../components/fileupload/fileuploaddetails.component';
import { ServiceRequestComponent } from '../components/serviceRequest/serviceRequest.component';
import { WorkRequestComponent } from '../components/workrequest/workrequest.component';
import { SidenavComponent } from './material/sidenav';
import { ServiceRequestListComponent } from '../components/servicelist/srlist.component';
import { DialogResultDialog } from './dialog/dialog';
import { MdDialogModule } from '@angular/material';
import {MdDatepickerModule,MdNativeDateModule } from '@angular/material';

import 'hammerjs';
@NgModule({
    imports: [
        BrowserModule, MdDialogModule,MdDatepickerModule,MdNativeDateModule ,
        FormsModule, HttpModule, BrowserAnimationsModule, MaterialModule,
        RouterModule.forRoot([
            {
                path: 'login',
                component: LoginComponent
            },
            {
                path: 'job',
                component: JobComponent
            },
            {
                path: 'servicerequest',
                component: ServiceRequestComponent
            },
            {
                 path: 'workrequest',
                 component: WorkRequestComponent
            }, 
            {
                path: '',
                redirectTo: '/login',
                pathMatch: 'full'
            }
        ], { useHash: true })
    ],
    declarations: [
        AppComponent, JobComponent, LoginComponent, ServiceRequestListComponent, DialogResultDialog,
        ServiceRequestComponent, WorkRequestComponent, SidenavComponent

    ],
    exports: [
        MaterialModule
    ],
    bootstrap: [AppComponent],
    entryComponents: [DialogResultDialog]
})
export class AppModule { }