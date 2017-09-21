import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';
import { Configuration } from '../../common/app.constants';
import { CookieService } from '../app.cookieManager';
import { Router } from '@angular/router';
import { AuthenticateService } from '../../Services/auth.service';
import { User } from '../../Models/user.model';

@Component({
    templateUrl: 'login.component.html',
    styleUrls: ['login.component.scss']
})

export class LoginComponent implements OnInit{
    user: User;
    constructor(private _loginService: LoginService,
                private _authService: AuthenticateService,
                private _cookieService: CookieService,
                private _route: Router) {}

    ngOnInit (){
        this.user = {
            username: '',
            password: ''
        };

        console.log(this._authService.logInStatus);
        if (this._authService.logInStatus === true){
            this._route.navigate(['dashboard']);
        }
    }


    public errorMessage: string;

    OnSubmit = function() {
        this.errorMessage = null;
        // var cookie = this._cookieService.getCookie("filedOrbitAccess");
        this._loginService.ValidateLoginInformation(this.user)
            .toPromise()
            .then((response) => {
                var output = response.json();
                this._authService.logInStatus = true;
                console.log('navigated');
                this._route.navigate(['dashboard']);
            })
            .catch((error: any) => {
                this.errorMessage = error._body;
            });
    };
}
