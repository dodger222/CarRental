var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { OrderService } from '../services/order.service';
import { UserService } from '../services/user.service';
import { CarService } from '../services/car.service';
import { Order } from '../order';
var OrderFormComponent = /** @class */ (function () {
    function OrderFormComponent(userService, carService, orderService, router, activeRoute) {
        this.userService = userService;
        this.carService = carService;
        this.orderService = orderService;
        this.router = router;
        this.order = new Order(); // изменяемый объект
        this.loaded = false;
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }
    OrderFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        if (this.id)
            this.orderService.getOrder(this.id)
                .subscribe(function (data) {
                _this.order = data;
                if (_this.order != null)
                    _this.loaded = true;
            });
        this.load();
    };
    OrderFormComponent.prototype.load = function () {
        var _this = this;
        this.userService.getUsers().subscribe(function (data) { return _this.users = data; });
        this.carService.getCars().subscribe(function (data) { return _this.cars = data; });
    };
    OrderFormComponent.prototype.save = function () {
        var _this = this;
        if (this.id) {
            this.orderService.updateOrder(this.order).subscribe(function (data) { return _this.router.navigateByUrl("/OrderList"); });
        }
        else {
            this.orderService.createOrder(this.order).subscribe(function (data) { return _this.router.navigateByUrl("/OrderList"); });
        }
    };
    OrderFormComponent = __decorate([
        Component({
            templateUrl: './order-form.component.html'
        }),
        __metadata("design:paramtypes", [UserService,
            CarService,
            OrderService,
            Router,
            ActivatedRoute])
    ], OrderFormComponent);
    return OrderFormComponent;
}());
export { OrderFormComponent };
//# sourceMappingURL=order-form.component.js.map