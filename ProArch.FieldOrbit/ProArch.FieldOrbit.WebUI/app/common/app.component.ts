import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'msg-app',
  template: `<router-outlet></router-outlet>`
})

export class AppComponent {
  constructor(private _route: Router) {
    
  }
  
  navLinks = [{ route: 'servicerequest', label: 'Service Request' },
  { route: 'workrequest', label: 'Work Request' },
  { route: 'job', label: 'Job' }];

  logout = function () {
    this._route.navigate(['login']);
    this.showNavBar = false;
  }
}
