import { DetailsRouting } from './details.routing';
import { JobComponent } from './job/job.component';
import { ServiceRequestComponent } from './serviceRequest/serviceRequest.component';
import { WorkRequestComponent } from './workrequest/workrequest.component';
import { SidenavComponent } from './../common/material/sidenav';
import { DialogResultDialog } from './../common/dialog/dialog';
import { ServiceRequestListComponent } from './servicelist/srlist.component';
import { NavbarComponent } from './../common/navbar/navbar.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MdDialogModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MdDatepickerModule, MdNativeDateModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '@angular/material';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import {HttpClientModule} from '@angular/common/http';
import { DetailsComponent } from './details/details.component';
import { AuthenticateService } from '../Services/auth.service';
import { AuthGuard } from '../Guards/auth.guard';
import { ServiceRequestService } from '../Services/serviceRequest.service';
import { Configuration } from '../common/app.constants';
import { WorkRequestService } from '../Services/workRequest.service';
import { StaticDataLoaderService } from '../Services/staticDataLoader.service';

@NgModule({
  imports: [ 
    DetailsRouting,
    BrowserModule,
    MdDialogModule,
    MdDatepickerModule,
    MdNativeDateModule,
    FormsModule,
    HttpModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    NoopAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  exports: [
    DetailsComponent,
    NavbarComponent,
    ServiceRequestListComponent,
    ServiceRequestComponent,
    WorkRequestComponent,
    SidenavComponent
  ],
  declarations: [
    DetailsComponent,
    NavbarComponent,
    ServiceRequestListComponent,
    ServiceRequestComponent,
    WorkRequestComponent,
    SidenavComponent,
    JobComponent
  ],
  providers: [AuthenticateService, AuthGuard, ServiceRequestService, Configuration, WorkRequestService, StaticDataLoaderService]
})
export class DetailsModule {}
