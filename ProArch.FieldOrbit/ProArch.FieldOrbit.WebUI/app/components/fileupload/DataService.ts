//import { Injectable } from "@angular/core";
//import { Http, RequestOptions, Headers, Response } from "@angular/http";
//import "rxjs/add/operator/map";
//import { Observable, Subject } from "rxjs/Rx";
////import { NoteItem } from "./noteModel";
//import { Configuration } from "../../common/app.constants";
//import 'rxjs/add/operator/toPromise';

//@Injectable()
//export class DataService {

//    constructor(private _http: Http, private _configuration: Configuration) {

//    }

//    public getAllDeviceDetails = () => {
//        return this._http.get(this._configuration.ApiServer + this._configuration.GetAllDevicesApiUrl)
//            .map(data => data.json());
//    };


//    public fileUpload(model) {
//        let headers = new Headers({
//            'Content-Type':
//            'application/json; charset=utf-8'
//        });
//        let options = new RequestOptions({ headers: headers });
//        //delete model["id"];
//        let body = JSON.stringify(model);
//        return this._http.post(this._configuration.ApiServer + this._configuration.FileUploadApiUrl, body,
//            options).toPromise().catch();
//    }

//}