import { Component, OnInit } from '@angular/core';
import { DataService } from './DataService';
import { Configuration } from './Configuration';
//import { NoteItem } from "./noteModel";
//import { Product } from "./Product";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';


@Component({
    selector: 'file-upload',
    moduleId: module.id,
    // templateUrl: 'app/components/fileupload/fileupload.component.html',
    templateUrl: 'fileupload.component.html',
    providers: [DataService, Configuration],
})
export class FileUploadComponent {
    constructor(private _dataService: DataService) {
    }
    model = {};
    onSubmit() {
        this._dataService
            .postSomething(this.model);
    }

}





