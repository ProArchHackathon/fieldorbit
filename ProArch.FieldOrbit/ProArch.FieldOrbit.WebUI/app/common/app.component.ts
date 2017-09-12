import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'msg-app',
  template: `<nav class="tab-background" md-tab-nav-bar>
    <img style="height:40px" src="./Images/login.png" />
  <a md-tab-link *ngFor="let link of navLinks"
     [routerLink]="link.route"
     routerLinkActive #rla="routerLinkActive"
     [active]="rla.isActive"><b>
    {{link.label}}</b>
    </a>
    <a style="float:right;" md-tab-link (click)="logout()"><b>
   Log Out</b>
  </a>
</nav>
<router-outlet></router-outlet>`
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
