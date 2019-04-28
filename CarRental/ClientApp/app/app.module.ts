import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { NavMenuComponent } from './navmenu/navmenu.component';

import { MainPageComponent } from './home/main-page.component';

import { CarListComponent } from './car-list/car-list.component';
import { CarFormComponent } from './car-form/car-form.component';
import { CarCreateComponent } from './car-create/car-create.component';
import { CarEditComponent } from './car-edit/car-edit.component';

import { UserListComponent } from './user-list/user-list.component';
import { UserFormComponent } from './user-form/user-form.component';
import { UserCreateComponent } from './user-create/user-create.component';
import { UserEditComponent } from './user-edit/user-edit.component';

import { OrderListComponent } from './order-list/order-list.component';
import { OrderFormComponent } from './order-form/order-form.component';
import { OrderCreateComponent } from './order-create/order-create.component';
import { OrderEditComponent } from './order-edit/order-edit.component';

import { NotFoundComponent } from './not-found/not-found.component';

import { CarService } from './services/car.service';
import { UserService } from './services/user.service';
import { OrderService } from './services/order.service';

// определение маршрутов
const appRoutes: Routes = [

    { path: '', component: MainPageComponent },

    { path: 'CarList', component: CarListComponent },
    { path: 'CarCreate', component: CarCreateComponent },
    { path: 'CarEdit/:id', component: CarEditComponent },

    { path: 'UserList', component: UserListComponent },
    { path: 'UserCreate', component: UserCreateComponent },
    { path: 'UserEdit/:id', component: UserEditComponent },

    { path: 'OrderList', component: OrderListComponent },
    { path: 'OrderCreate', component: OrderCreateComponent },
    { path: 'OrderEdit/:id', component: OrderEditComponent },

    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, MainPageComponent, CarListComponent, CarCreateComponent, CarEditComponent,
        CarFormComponent, UserListComponent, UserCreateComponent, UserEditComponent,
        UserFormComponent, OrderListComponent, OrderCreateComponent, OrderEditComponent,
        OrderFormComponent, NotFoundComponent, NavMenuComponent],
    providers: [UserService, CarService, OrderService],
    bootstrap: [AppComponent]
})
export class AppModule { }
