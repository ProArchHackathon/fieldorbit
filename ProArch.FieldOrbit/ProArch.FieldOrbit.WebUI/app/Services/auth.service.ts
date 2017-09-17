import { Injectable } from '@angular/core';


@Injectable()
export class AuthenticateService {
    _loggedIn = false;
    
      get logInStatus(): boolean { return this._loggedIn; }
    
      set logInStatus(loggedIn: boolean) {
        this._loggedIn = loggedIn;
      }
    
      constructor() { }
}
