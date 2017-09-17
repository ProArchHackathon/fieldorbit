import { Injectable } from '@angular/core';
import {Router} from '@angular/router';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { AuthenticateService } from "../Services/auth.service";

@Injectable()
export class AuthGuard implements CanActivate {
    constructor( private authService: AuthenticateService,private router : Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.authService.logInStatus) {
            return true;
       }else {
        this.router.navigate(['/login'], {});
            return false;
        }
     }      
}