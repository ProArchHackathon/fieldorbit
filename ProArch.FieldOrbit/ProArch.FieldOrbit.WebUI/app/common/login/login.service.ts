import { Injectable } from '@angular/core';
import { Http, RequestOptions, URLSearchParams } from '@angular/http';
import { Configuration } from '../../common/app.constants';
import { User } from '../../Models/user.model';
import { LoaderService } from '../../Services/loader.service';

@Injectable()
export class LoginService {
  result: any;
  constructor(
    private _http: Http,
    private _config: Configuration,
    private loaderService: LoaderService
  ) {}

  ValidateLoginInformation = (user: User) => {
    let params: URLSearchParams = new URLSearchParams();
    params.set('username', user.userName);
    params.set('password', user.password);

    let requestOptions = new RequestOptions();
    requestOptions.search = params;

    let body = JSON.stringify(user);

    return this._http.get(this._config.ApiServer + this._config.LoginApiUrl, requestOptions);
  };

  private showLoader(): void {
    this.loaderService.show();
  }

  private hideLoader(): void {
    this.loaderService.hide();
  }
}
