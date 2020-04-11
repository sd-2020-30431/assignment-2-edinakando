import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';

import { GroceryList } from 'src/app/models/groceryList';
import { GroceryService } from '../services/grocery.service';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'view-grocery-list',
    templateUrl: './view-grocery-list.component.html',
    providers: [AuthService, GroceryService]
})

export class ViewGroceryListComponent {
    groceryLists: GroceryList[];
    consumptionForm: FormGroup;

    constructor(private formBuilder: FormBuilder,
                private groceryService: GroceryService,
                private authService: AuthService,
                private router: Router) { }
   
    ngOnInit() {
        this.groceryService.getGroceries(this.authService.getUserId())
            .subscribe(res => {
                this.setGroceryView(res);
            })

        this.consumptionForm = this.formBuilder.group({
            dates: this.formBuilder.array([])
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

    get consumptionDates() : FormArray {
        return this.consumptionForm.get("dates") as FormArray;
    }

    onSubmit(){
    }
}