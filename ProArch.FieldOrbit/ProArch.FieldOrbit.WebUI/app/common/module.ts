import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { JobComponent } from '../components/job/job.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '@angular/material';
import { RouterModule } from '@angular/router';
import { LoginComponent } from '../common/login/login.component';
import { HttpModule } from '@angular/http';

//import 'hammerjs';
@NgModule({
    imports: [
        BrowserModule,
        FormsModule, HttpModule, BrowserAnimationsModule, MaterialModule.forRoot(),
        RouterModule.forRoot([
            {
                path: 'login',
                component: LoginComponent
            }, {
                path: '',
                redirectTo: '/login',
                pathMatch: 'full'
            }
        ], { useHash: true })
    ],
    declarations: [
        JobComponent, LoginComponent

    ],
    exports: [
        MaterialModule
    ],
    bootstrap: [JobComponent]
})
export class AppModule { }