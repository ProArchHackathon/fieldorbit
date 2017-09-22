import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';
import { CookieService } from '../app.cookieManager';
import { Router } from '@angular/router';
import { AuthenticateService } from '../../Services/auth.service';
import { User } from '../../Models/user.model';
import { FormGroup, Validators, FormBuilder} from '@angular/forms';

@Component({
    templateUrl: 'login.component.html',
    styleUrls: ['login.component.scss']
})

export class LoginComponent implements OnInit{
    user: User;
    loginForm: FormGroup;
    errorMessage: string;

    constructor(private _route: Router,
                private fb: FormBuilder,
                private _loginService: LoginService,
                private _cookieService: CookieService,
                private _authService: AuthenticateService) {

         this.loginForm = fb.group({
                   userName: ['',
                                Validators.compose([Validators.required,
                                                    Validators.maxLength(10),
                                                    Validators.minLength(5)])],
                   password: ['',
                                Validators.compose([Validators.required,
                                                    Validators.minLength(6),
                                                    Validators.maxLength(10)])]
              });
        }

    ngOnInit () {
        this.user = {
            userName: '',
            password: ''
        };

        console.log(this._authService.logInStatus);
        if (this._authService.logInStatus === true){
            this._route.navigate(['dashboard']);
        }
    }

    OnSubmit = function() {
        this.errorMessage = null;
        // var cookie = this._cookieService.getCookie("filedOrbitAccess");
        this._loginService
            .ValidateLoginInformation(this.user)
            .toPromise()
            .then((response) => {
                const output = response.json();
                this._authService.logInStatus = true;
                this._route.navigate(['dashboard']);
            })
            .catch((error: any) => {
                this.errorMessage = error._body;
            });
    };
}
