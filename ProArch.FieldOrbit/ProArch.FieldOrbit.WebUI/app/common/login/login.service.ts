import { Injectable } from "@angular/core";
import { Http, RequestOptions, Headers, Response, URLSearchParams  } from "@angular/http";
import "rxjs/add/operator/map";
import { Observable, Subject } from "rxjs/Rx";
import { Configuration } from "../../common/app.constants";
import { User } from './login.component';

@Injectable()
export class LoginService {
    result: any;
    constructor(private _http: Http, private _configuration: Configuration) {

    }


    public ValidateLoginInformation = (login: User) => {
        let params: URLSearchParams = new URLSearchParams();
        params.set('username', login.username);
        params.set('password', login.password);

        let requestOptions = new RequestOptions();
        requestOptions.search = params;
       
        let body = JSON.stringify(login);
        //return this._http.post(this._configuration.ApiServer + this._configuration.LoginApiUrl, body,
        //    options).toPromise().catch();

        return this._http.get(this._configuration.ApiServer + this._configuration.LoginApiUrl, requestOptions);
    };
}