import { Injectable } from "@angular/core";
import { Http, RequestOptions, Headers, Response, URLSearchParams  } from "@angular/http";
import "rxjs/add/operator/map";
import { Observable, Subject } from "rxjs/Rx";
import { Configuration } from "../../common/app.constants";
import { User } from "../../Models/user.model";

@Injectable()
export class LoginService {
    result: any;
    constructor(private _http: Http, private _configuration: Configuration) {}


    ValidateLoginInformation = (user: User) => {
        let params: URLSearchParams = new URLSearchParams();
        params.set('username', user.username);
        params.set('password', user.password);

        let requestOptions = new RequestOptions();
        requestOptions.search = params;
       
        let body = JSON.stringify(user);
        //return this._http.post(this._configuration.ApiServer + this._configuration.LoginApiUrl, body,
        //    options).toPromise().catch();

        return this._http.get(this._configuration.ApiServer + this._configuration.LoginApiUrl, requestOptions);
    };
}