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

import { UserListComponent } from './user-list/user-list.component';
import { UserFormComponent } from './user-form/user-form.component';

import { OrderListComponent } from './order-list/order-list.component';
import { OrderFormComponent } from './order-form/order-form.component';

import { NotFoundComponent } from './not-found/not-found.component';

import { CarService } from './services/car.service';
import { UserService } from './services/user.service';
import { OrderService } from './services/order.service';

// определение маршрутов
const appRoutes: Routes = [

    { path: '', component: MainPageComponent },

    { path: 'CarList', component: CarListComponent },
    { path: 'CarCreate', component: CarFormComponent },
    { path: 'CarEdit/:id', component: CarFormComponent },

    { path: 'UserList', component: UserListComponent },
    { path: 'UserCreate', component: UserFormComponent },
    { path: 'UserEdit/:id', component: UserFormComponent },

    { path: 'OrderList', component: OrderListComponent },
    { path: 'OrderCreate', component: OrderFormComponent },
    { path: 'OrderEdit/:id', component: OrderFormComponent },

    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, MainPageComponent,
        CarListComponent, CarFormComponent,
        UserListComponent, UserFormComponent,
        OrderListComponent, OrderFormComponent,
        NotFoundComponent, NavMenuComponent],
    providers: [UserService, CarService, OrderService],
    bootstrap: [AppComponent]
})
export class AppModule { }
