//import { Component, OnInit } from '@angular/core';
//import { DataService } from './DataService';
//import { Configuration } from '../../common/app.constants';
//import 'rxjs/add/operator/map';
//import 'rxjs/add/operator/catch';
//import { Product } from "./ProductDetails";
//@Component({
//    selector: 'file-upload',
//    moduleId: module.id,
//    // templateUrl: 'app/components/fileupload/fileupload.component.html',
//    templateUrl: 'fileupload.component.html',
//    providers: [DataService, Configuration]
//})
//export class FileUploadComponent {
//    constructor(private _dataService: DataService) {
//    }
//    public ModelType = [
//        { value: '2D', display: '2D' },
//        { value: '3D', display: '3D' }
//    ];
//    public Recommend = [
//        { value: 'Yes', display: 'Yes' },
//        { value: 'No', display: 'NO' }
//    ];
//    model = new Product(0, '', '', '');
//    onSubmit() {
//        this._dataService
//            .fileUpload(this.model);
//    }
//}
//# sourceMappingURL=fileupload.component.js.map