import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'; 
import { environment } from 'src/environments/environment';
import { Charity } from 'src/app/models/charity';
import { Donation } from 'src/app/models/donation';
import { Observable } from 'rxjs';

@Injectable()

export class CharitiesService {
    constructor(private http: HttpClient, private router: Router) { }

    getAll() : Observable<Charity[]>{
        return this.http.get<Charity[]>(`${environment.apiUrl}/charities`);
    }

    donate(donation){
        console.log(donation);
        this.http.post(`${environment.apiUrl}/charities/donate`, donation)
                .subscribe(res => {
                    console.log(res);
                })
                err => {
                    if (err.status == 400){
                        console.log('Something occured.');
                    }
                    else
                        console.log(err);
                    }
    }
}