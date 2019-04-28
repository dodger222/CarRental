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
import { DataService } from './data.service';
var OrderListComponent = /** @class */ (function () {
    function OrderListComponent(dataService) {
        this.dataService = dataService;
        this.filter = {};
    }
    OrderListComponent.prototype.ngOnInit = function () {
        this.load();
    };
    OrderListComponent.prototype.load = function () {
        var _this = this;
        this.dataService.getOrders().subscribe(function (data) { return _this.viewOrders = _this.allViewOrder = data; });
        this.dataService.getUsers().subscribe(function (data) { return _this.users = data; });
    };
    OrderListComponent.prototype.delete = function (id) {
        var _this = this;
        this.dataService.deleteOrder(id).subscribe(function (data) { return _this.load(); });
    };
    OrderListComponent.prototype.onFilterChange = function () {
        var _this = this;
        var viewOrders = this.allViewOrder;
        if (this.filter.userId)
            viewOrders = viewOrders.filter(function (v) { return v.userId == _this.filter.userId; });
        if (this.filter.autoId)
            viewOrders = viewOrders.filter(function (v) { return v.carId == _this.filter.autoId; });
        this.viewOrders = viewOrders;
    };
    OrderListComponent.prototype.resetFilter = function () {
        this.filter = {};
        this.onFilterChange();
    };
    OrderListComponent = __decorate([
        Component({
            templateUrl: './order-list.component.html'
        }),
        __metadata("design:paramtypes", [DataService])
    ], OrderListComponent);
    return OrderListComponent;
}());
export { OrderListComponent };
//# sourceMappingURL=order-list.component.js.map