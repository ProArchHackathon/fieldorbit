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
    constructor(private _loginService: LoginService, private _cookieService: CookieService, private _route: Router) {

    }

    public login: User = {
        username: "",
        password: ""
    };
    public errorMessage: string;

    OnSubmit =function() {
        this.errorMessage = null;
        //var cookie = this._cookieService.getCookie("filedOrbitAccess");
        this._loginService.ValidateLoginInformation(this.login)
            .toPromise()
            .then((response) => {
                var output = response.json();
                this._route.navigate(['servicerequest']);
            })
            .catch((error: any) => {
                this.errorMessage = error._body;
            });
    }
}
