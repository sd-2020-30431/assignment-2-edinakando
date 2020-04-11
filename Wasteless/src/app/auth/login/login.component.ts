import {Component} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    providers: [AuthService]
})

export class LoginComponent{
    loginForm: FormGroup;

    constructor(private formBuilder: FormBuilder,
                private authService: AuthService) { }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            email: ['', [Validators.required, Validators.email]],
            password: ['', Validators.required],
        })
    }
    
    onSubmit(){
        this.authService.login(new User(this.loginForm.get("email").value, this.loginForm.get("password").value));
    }

    logout(){
        this.authService.logout();
    }

    get email(){
        return this.loginForm.get('email');
    }

    get password(){
        return this.loginForm.get('password');
    }
}