import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { Configuration } from "../../common/app.constants";
import { CookieService } from '../app.cookieManager';
import { Router } from '@angular/router';

export class User {
    constructor(
        public username: string,
        public password: string) { }
}

@Component({
    templateUrl: 'login.component.html',
    providers: [LoginService, Configuration, CookieService]
})
export class LoginComponent {
    constructor(private _loginService: LoginService, private _cookieService: CookieService, private _route : Router) {

    }

    public login: User = {
        username: "",
        password: ""
    };

    OnSubmit() {
        //var cookie = this._cookieService.getCookie("filedOrbitAccess");
        this._loginService.ValidateLoginInformation(this.login)
            .map((response) => {
                var output = response.json();
                this._route.navigate(['servicerequest']);
                //this._cookieService.setCookie("filedOrbitAccess", output.AccessToken, 1);
            })
            .subscribe(function(errors) {
                var error = errors;
            });
    }
}
