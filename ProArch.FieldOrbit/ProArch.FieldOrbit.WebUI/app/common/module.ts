import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { JobComponent } from '../components/job/job.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '@angular/material';
//import 'hammerjs';
@NgModule({
    imports: [
        BrowserModule,
        FormsModule, BrowserAnimationsModule,MaterialModule.forRoot()
    ],
    declarations: [
        JobComponent
    ],
    exports: [
        MaterialModule
    ],
    bootstrap: [JobComponent]
})
export class AppModule { }