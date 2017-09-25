import { Component, OnInit, ViewEncapsulation } from "@angular/core";
import { Router } from '@angular/router';

@Component({
    selector: 'app-path-notfound',
    templateUrl: 'pathNotFound.component.html',
    styleUrls: ['pathNotFound.component.scss'],
    encapsulation: ViewEncapsulation.Emulated
})

export class PathNotFoundComponent implements OnInit {
    constructor(private _router: Router) { }

    ngOnInit() { }
}