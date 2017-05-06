import { Component } from '@angular/core';

export class User {
    constructor(
        public username: string,
        public password: string) { }
}

@Component({
    templateUrl: 'app/common/login/login.component.html'
})
export class LoginComponent {
    login: User = {
        username: "",
        password: ""
    };

    OnSubmit(login) {

    }
}
