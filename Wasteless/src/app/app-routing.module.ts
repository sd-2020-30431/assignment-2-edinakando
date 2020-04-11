import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { AddGroceryListComponent } from './grocery-list/add-grocery-list.component';
import { ViewGroceryListComponent } from './grocery-list/view-grocery-list.component';
import { ReportsComponent } from './reports/reports.component';
import { CharitiesComponent } from './grocery-list/charities-view.component';


const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "register", component: RegisterComponent},
  {path: "addgroceries", component: AddGroceryListComponent},
  {path: "groceries", component: ViewGroceryListComponent},
  {path: "reports", component: ReportsComponent},
  {path: "donate/:id", component: CharitiesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
