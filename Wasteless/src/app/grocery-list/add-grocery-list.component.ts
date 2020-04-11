import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';

import { GroceryList } from 'src/app/models/groceryList';
import { GroceryService } from '../services/grocery.service';

@Component({
    selector: 'add-grocery-list',
    templateUrl: './add-grocery-list.component.html',
    providers: [GroceryService]
})

export class AddGroceryListComponent {
    listDetailsForm: FormGroup;
    itemsForm: FormGroup;
    isCountSubmitted: Boolean = false;
    groceryList = new GroceryList();

    constructor(private formBuilder: FormBuilder,
                private groceryService: GroceryService) { }

    ngOnInit() {
        this.listDetailsForm = this.formBuilder.group({
            listName: ['', Validators.required],
            itemsCount: ['', Validators.required],
        });

        this.itemsForm = this.formBuilder.group({
            items: this.formBuilder.array([])
        });
    }

    newItem(): FormGroup{
        return this.formBuilder.group({
            name: ['', Validators.required],
            quantity: ['', Validators.required],
            calories: ['', Validators.required],
            purchaseDate: ['', Validators.required],
            expirationDate: ['', Validators.required],
            consumptionDate: null
        })
    }

    addItems(){
        this.items.push(this.newItem());
    }

    onSubmit() {
        this.groceryList.items = this.itemsForm.get("items").value;
        this.groceryService.saveList(this.groceryList);
    }

    createList() {
        this.isCountSubmitted = true;
        this.groceryList.name = this.listDetailsForm.get("listName").value;
        
        for (let i = 0; i < this.listDetailsForm.get("itemsCount").value; i++) {
           this.addItems();
        }
    }

    get listName() {
        return this.listDetailsForm.get('listName');
    }

    get itemsCountInput() {
        return this.listDetailsForm.get('itemsCount');
    }

    get items() : FormArray {
        return this.itemsForm.get("items") as FormArray;
    }

    name(i){
        return this.items.controls[i].get("name");
    }

    quantity(i){
        return this.items.controls[i].get("quantity");
    }

    calories(i){
        return this.items.controls[i].get("calories");
    }
}