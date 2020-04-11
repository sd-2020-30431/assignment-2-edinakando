import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'; 
import { environment } from 'src/environments/environment';

import { User } from 'src/app/models/user';

@Injectable()

export class AuthService {
    constructor(private http: HttpClient, private router: Router) { }

    register(user: User) {
        this.http.post(`${environment.apiUrl}/authentication/register`, user)
                .subscribe(res => {
                    this.login(user);
                })
                err => {
                    if (err.status == 400){
                        console.log('User already exists.');
                    }
                    else
                        console.log(err);
                    }
    }

    login(user: User) {
        this.http.post(`${environment.apiUrl}/authentication/login`, user)
            .subscribe((res: any) => 
                {
                    localStorage.setItem(`${environment.token_name}`, res.token);
                    localStorage.setItem(`${environment.user_id}`, res.userId);
                    this.router.navigate(['/'])
                        .then(() => {
                             window.location.reload();
                        });
                },
                err => {
                    if (err.status == 400){
                        console.log('Incorrect username or password.');
                        //TODO: import an alert/toaster
                        //this.alertService.error('Incorrect username or password.', { id: 'alert-1' });
                    }
                    else
                        console.log(err);
                    }
            );
    }

    logout() {
        localStorage.removeItem(`${environment.token_name}`);
        localStorage.removeItem(`${environment.user_id}`);
        location.reload();
    }

    isLoggedIn(){
        var token = localStorage.getItem(`${environment.token_name}`);
        return token != 'undefined' && token != null;
    }

    getUserId(){
        return localStorage.getItem(`${environment.user_id}`);
    }
}