import { AuthenticateService } from './../../Services/auth.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-navbar',
    templateUrl: 'navbar.component.html',
    styleUrls:['navbar.component.scss']
})

export class NavbarComponent implements OnInit {
    constructor(private _route: Router, private _authService:AuthenticateService) { }

    ngOnInit() { }

    navLinks = [{ route: 'servicerequest', label: 'Service Request' },
    { route: 'workrequest', label: 'Work Request' },
    { route: 'job', label: 'Job' }];
  
    logout = function () {
      this._authService.logInStatus = false;
      console.log(this._authService.logInStatus);
      this._route.navigate(['login']);
      this.showNavBar = false;
    }
}