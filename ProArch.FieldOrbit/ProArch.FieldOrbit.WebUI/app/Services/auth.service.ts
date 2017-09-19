import { Injectable } from '@angular/core';


@Injectable()
export class AuthenticateService {
    
      get logInStatus(): boolean {
        const status = JSON.parse(localStorage.getItem('_loggedIn'));
         return status;
      }
    
      set logInStatus(loggedIn: boolean) {
        localStorage.setItem('_loggedIn', `${loggedIn}`);
        console.log(localStorage.getItem(''))
      }
    
      constructor() { }
}
