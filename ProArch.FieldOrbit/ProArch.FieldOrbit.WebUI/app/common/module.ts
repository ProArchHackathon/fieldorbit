import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { JobComponent } from '../components/job/job.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule
    ],
    declarations: [
        JobComponent
    ],
    bootstrap: [JobComponent]
})
export class AppModule { }