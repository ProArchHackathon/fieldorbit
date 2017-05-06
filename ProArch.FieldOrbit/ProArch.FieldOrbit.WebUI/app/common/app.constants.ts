import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    public ApiServer: string = "http://localhost/fieldorbitApi/";  

    public GetAllDevicesApiUrl: string = "api/Home";

    public FileUploadApiUrl: string = "api/Home/detailspost";

    public LoginApiUrl:string ="api/LoginOperations/Validate"

}