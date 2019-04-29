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
import { OrderService } from '../services/order.service';
import { UserService } from '../services/user.service';
import { CarService } from '../services/car.service';
var OrderListComponent = /** @class */ (function () {
    function OrderListComponent(orderService, userService, carService) {
        this.orderService = orderService;
        this.userService = userService;
        this.carService = carService;
        this.filter = {};
    }
    OrderListComponent.prototype.ngOnInit = function () {
        this.load();
    };
    OrderListComponent.prototype.load = function () {
        var _this = this;
        this.populateViewOrders();
        this.userService.getUsersWithUniqueFirstnames().subscribe(function (data) { return _this.users = data; });
        this.carService.getCars().subscribe(function (data) { return _this.cars = data; });
    };
    OrderListComponent.prototype.delete = function (id) {
        var _this = this;
        this.orderService.deleteOrder(id).subscribe(function (data) { return _this.load(); });
    };
    OrderListComponent.prototype.populateViewOrders = function () {
        var _this = this;
        this.orderService.getOrders(this.filter)
            .subscribe(function (data) { return _this.viewOrders = data; });
    };
    OrderListComponent.prototype.onFilterChange = function () {
        this.populateViewOrders();
    };
    OrderListComponent.prototype.resetFilter = function () {
        this.filter = {};
        this.onFilterChange();
    };
    OrderListComponent = __decorate([
        Component({
            templateUrl: './order-list.component.html'
        }),
        __metadata("design:paramtypes", [OrderService, UserService, CarService])
    ], OrderListComponent);
    return OrderListComponent;
}());
export { OrderListComponent };
//# sourceMappingURL=order-list.component.js.map