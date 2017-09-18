import { Directive, HostListener, OnInit } from "@angular/core";

@Directive({ selector: '[app-data-clearer]' })

export class DataClearerDirective implements OnInit{
    constructor() { }


    ngOnInit(){
        console.log('hitttt');
    }
    @HostListener('window:unload', ['$event'])
    unloadHandler(event) {
      localStorage.removeItem('_loggedIn');
      localStorage.clear();
    }
}