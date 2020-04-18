import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'; 
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

import { GroceryList } from '../models/groceryList';
import { GroceryItem } from '../models/groceryItem';

@Injectable()

export class GroceryService {
    constructor(private http: HttpClient, private router: Router) { }

    saveList(groceryList: GroceryList){
        console.log(groceryList);

        this.http.post(`${environment.apiUrl}/groceries/save`, groceryList)
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

    getGroceries(userId) : Observable<GroceryList[]>{
        return this.http.get<GroceryList[]>(`${environment.apiUrl}/groceries`, {params: {userId: userId}} );
    }

    checkNotifications(userId) : Observable<GroceryItem[]>{
        return this.http.get<GroceryItem[]>(`${environment.apiUrl}/notifications/expiration`, {params: {userId: userId}} );
    }

    editItems(groceryItems: GroceryItem[]){
        this.http.post(`${environment.apiUrl}/groceries/edit`, groceryItems)
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