import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '@angular/material';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { LoginComponent } from '../common/login/login.component';
import { AppComponent } from '../common/app.component';
import { DialogResultDialog } from './dialog/dialog';
import 'hammerjs';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DetailsModule } from "../components/details.module";
import { ComponentPageTitle } from "../Services/pageTitle.service";
import { DataClearerDirective } from "../Directive/dataClearer.directive";
import {
  MdAutocompleteModule,
  MdButtonModule,
  MdButtonToggleModule,
  MdCardModule,
  MdCheckboxModule,
  MdChipsModule,
  MdCoreModule,
  MdDatepickerModule,
  MdDialogModule,
  MdExpansionModule,
  MdGridListModule,
  MdIconModule,
  MdInputModule,
  MdListModule,
  MdMenuModule,
  MdNativeDateModule,
  MdPaginatorModule,
  MdProgressBarModule,
  MdProgressSpinnerModule,
  MdRadioModule,
  MdRippleModule,
  MdSelectModule,
  MdSidenavModule,
  MdSliderModule,
  MdSlideToggleModule,
  MdSnackBarModule,
  MdSortModule,
  MdTableModule,
  MdTabsModule,
  MdToolbarModule,
  MdTooltipModule,
} from '@angular/material';
import { CookieService } from "./app.cookieManager";
import { LoginService } from "./login/login.service";
import { Routing } from "../Routing/app.routing";
import { HeaderInterceptor } from "../Services/headerInterceptor.service";
import { JobService } from "../Services/Job.service";
import { Logger } from '../Services/logger.service';
@NgModule({
  imports: [
    MdAutocompleteModule,
    MdButtonModule,
    MdButtonToggleModule,
    MdCardModule,
    MdCheckboxModule,
    MdChipsModule,
    MdCoreModule,
    MdDatepickerModule,
    MdDialogModule,
    MdExpansionModule,
    MdGridListModule,
    MdIconModule,
    MdInputModule,
    MdListModule,
    MdMenuModule,
    MdNativeDateModule,
    MdPaginatorModule,
    MdProgressBarModule,
    MdProgressSpinnerModule,
    MdRadioModule,
    MdRippleModule,
    MdSelectModule,
    MdSidenavModule,
    MdSliderModule,
    MdSlideToggleModule,
    MdSnackBarModule,
    MdSortModule,
    MdTableModule,
    MdTabsModule,
    MdToolbarModule,
    MdTooltipModule,
    BrowserModule,
    MdDialogModule,
    MdDatepickerModule,
    MdNativeDateModule,
    FormsModule,
    HttpModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    DetailsModule,
    Routing,
    ReactiveFormsModule
  ],
  declarations: [AppComponent, LoginComponent, DialogResultDialog, DataClearerDirective],
  exports: [MaterialModule],
  bootstrap: [AppComponent],
  entryComponents: [DialogResultDialog],
  providers: [
    ComponentPageTitle,
    LoginService,
    CookieService,
    HeaderInterceptor,
    JobService,
    Logger
  ]
})
export class AppModule {}