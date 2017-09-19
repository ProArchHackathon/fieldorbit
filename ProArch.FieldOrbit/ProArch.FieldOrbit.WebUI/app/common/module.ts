import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
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
    RouterModule.forRoot(
      [
        { path: "", redirectTo: "/login", pathMatch: "full" },
        { path: "login", component: LoginComponent, data: { Title: "Login" } }
      ],
      { useHash: true }
    )
  ],
  declarations: [AppComponent, LoginComponent, DialogResultDialog],
  exports: [MaterialModule],
  bootstrap: [AppComponent],
  entryComponents: [DialogResultDialog],
  providers: [ComponentPageTitle, DataClearerDirective]
})
export class AppModule {}