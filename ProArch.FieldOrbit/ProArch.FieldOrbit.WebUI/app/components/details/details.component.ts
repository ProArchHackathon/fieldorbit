import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-details',
    templateUrl: 'details.component.html'
})

export class DetailsComponent implements OnInit {
    constructor(private router: Router) { }

    ngOnInit() {
        //this.router.navigate(['dashboard/']);
     }
}