import { Component, OnInit } from '@angular/core';
import { DataService } from "./DataService";
import { Configuration } from "../../common/app.constants";
//import { NoteItem } from "./noteModel";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'fileupload-details',
    providers: [DataService, Configuration],
    moduleId: module.id,
    // templateUrl: 'app/components/fileupload/fileupload.component.html',
    templateUrl: 'fileuploaddetails.component.html',
})

export class FileUploadDetailsComponent implements OnInit {
    public myItems: {};

    constructor(private _dataService: DataService) {
    }

    ngOnInit() {
        this._dataService
            .getAllDeviceDetails()
            .subscribe((data: {}) => this.myItems = data,
            error => console.log(error),
            () => console.log("getAllItems() complete from init"));
    }
}
