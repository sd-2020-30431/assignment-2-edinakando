import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

import { GroceryItem } from 'src/app/models/groceryItem';

@Injectable()

export class ReportsService {
    constructor(private http: HttpClient) { }

    getWeekly(userId): Observable<GroceryItem[]>{
        return this.http.get<GroceryItem[]>(`${environment.apiUrl}/reports`, {params: {type: '0', userId: userId}} );
    }   
    
    getMonthly(userId): Observable<GroceryItem[]>{
        return this.http.get<GroceryItem[]>(`${environment.apiUrl}/reports`, {params: {type: '1', userId: userId}} );
    }
}