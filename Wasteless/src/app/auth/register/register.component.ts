import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user';

@Component({
    selector: 'register',
    templateUrl: './register.component.html',
    providers: [AuthService]
})

export class RegisterComponent {
    registerForm: FormGroup;
    passwordsForm: FormGroup;

    constructor(private formBuilder: FormBuilder,
                private authService: AuthService) { }

    ngOnInit() {
        this.passwordsForm = this.formBuilder.group({
            password: ['', Validators.required],
            confirmPassword: ['', Validators.required]
        }, { validator: this.areEqual });

        this.registerForm = this.formBuilder.group({
            email: ['', [Validators.required, Validators.email]],
            passwords: this.passwordsForm,
        })
    }

    areEqual(formGroup: FormGroup) {
        let password = formGroup.get('password');
        let confirmPassword = formGroup.get('confirmPassword');

        if (confirmPassword.errors == null || 'passwordMismatch' in confirmPassword.errors) {
            if (password.value != confirmPassword.value){               
                password.setErrors({ passwordMismatch: true });
                confirmPassword.setErrors({ passwordMismatch: true });
            }
            else
                confirmPassword.setErrors(null);
        }
    }

    onSubmit() {
        this.authService.register(new User(this.registerForm.get("email").value, this.passwordsForm.get("password").value));
    }

    get email(){
        return this.registerForm.get('email');
    }

    get password(){
        return this.passwordsForm.get('password');
    }

    get confirmPassword(){
        return this.passwordsForm.get('confirmPassword');
    }
}