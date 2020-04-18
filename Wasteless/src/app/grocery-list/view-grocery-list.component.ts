import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';

import { GroceryList } from 'src/app/models/groceryList';
import { GroceryService } from '../services/grocery.service';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

import { Subscription, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { GroceryItem } from '../models/groceryItem';

@Component({
    selector: 'view-grocery-list',
    templateUrl: './view-grocery-list.component.html',
    providers: [AuthService, GroceryService]
})

export class ViewGroceryListComponent {
    groceryLists: GroceryList[];
    consumptionForm: FormGroup;
    notifications: GroceryItem[];

    constructor(private formBuilder: FormBuilder,
                private groceryService: GroceryService,
                private authService: AuthService,
                private router: Router) { }
                subscription: Subscription;
                statusText: string;
            
    ngOnInit() {
        this.groceryService.getGroceries(this.authService.getUserId())
            .subscribe(res => {
                this.setGroceryView(res);
            })

        this.consumptionForm = this.formBuilder.group({
            dates: this.formBuilder.array([])
        });

        this.subscription = timer(0, 10000).pipe(
            switchMap(() => this.groceryService.checkNotifications(this.authService.getUserId())))
                .subscribe(result => {
                    this.setNotifications(result);
                });
    }

    newItem(value): FormGroup{
        return this.formBuilder.group({
            consumptionDate: value
        })
    }

    setGroceryView(res){
        this.groceryLists = res;

        for(let list of this.groceryLists)
            for(let item of list.items){
                this.consumptionDates.push(this.newItem(item.consumptionDate));
            }
    }

    setNotifications(res){
        this.notifications = res;
    }

    get consumptionDates() : FormArray {
        return this.consumptionForm.get("dates") as FormArray;
    }

    onSubmit(){
        var groceryItems: GroceryItem[];
        for(let list of this.groceryLists)
            for(let item of list.items){
                groceryItems.push(item);
            }
        this.groceryService.editItems(groceryItems);
    }
    
    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}