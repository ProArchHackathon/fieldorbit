import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    public ApiServer: string = "http://localhost/webapi/";  // when you run with IIS
    // if you run the project with IIS express, please use the address http://localhost:51214/

    public GetApiUrl: string = "api/Home";

    public PostApiUrl: string = "api/Home/detailspost";
    // public ServerWithApiUrl: string = this.ApiServer + this.ApiUrl;
    public ServerWithApiUrlGet: string = this.ApiServer + this.GetApiUrl;

    public ServerWithApiUrlPost: string = this.ApiServer + this.PostApiUrl;
}