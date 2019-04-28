import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { NavMenuComponent } from './navmenu.component';

import { MainPageComponent } from './main-page.component';

import { CarListComponent } from './car-list.component';
import { CarFormComponent } from './car-form.component';
import { CarCreateComponent } from './car-create.component';
import { CarEditComponent } from './car-edit.component';

import { UserListComponent } from './user-list.component';
import { UserFormComponent } from './user-form.component';
import { UserCreateComponent } from './user-create.component';
import { UserEditComponent } from './user-edit.component';

import { OrderListComponent } from './order-list.component';
import { OrderFormComponent } from './order-form.component';
import { OrderCreateComponent } from './order-create.component';
import { OrderEditComponent } from './order-edit.component';

import { NotFoundComponent } from './not-found.component';

import { DataService } from './data.service';

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
    providers: [DataService], // регистрация сервисов
    bootstrap: [AppComponent]
})
export class AppModule { }
