import { Component } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from "@angular/router";
import { Title } from "@angular/platform-browser";
import { ComponentPageTitle } from "../Services/pageTitle.service";

@Component({
  selector: 'msg-app',
  template: `<router-outlet></router-outlet>`
})

export class AppComponent {
  constructor(private _route: Router,
              private titleService: Title,
              private activatedRoute: ActivatedRoute,
              public _componentPageTitle: ComponentPageTitle) {
    
  }
  ngOnInit() {
    this._route.events
    .filter((event) => event instanceof NavigationEnd)
    .map(() => this.activatedRoute)
    .map((route) => {
      while (route.firstChild) route = route.firstChild;
      return route;
    })
    .filter((route) => route.outlet === 'primary')
    .mergeMap((route) => route.data)
    .subscribe((event) => this._componentPageTitle.title = event['Title']);
  }
  
  navLinks = [{ route: 'servicerequest', label: 'Service Request' },
  { route: 'workrequest', label: 'Work Request' },
  { route: 'job', label: 'Job' }];

  logout = function () {
    this._route.navigate(['login']);
    this.showNavBar = false;
  }
}
