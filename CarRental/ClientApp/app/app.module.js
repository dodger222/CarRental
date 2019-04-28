var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
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
var appRoutes = [
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
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
            declarations: [AppComponent, MainPageComponent, CarListComponent, CarCreateComponent, CarEditComponent,
                CarFormComponent, UserListComponent, UserCreateComponent, UserEditComponent,
                UserFormComponent, OrderListComponent, OrderCreateComponent, OrderEditComponent,
                OrderFormComponent, NotFoundComponent, NavMenuComponent],
            providers: [DataService],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map