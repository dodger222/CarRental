var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { DataService } from './data.service';
import { Order } from './order';
var OrderFormComponent = /** @class */ (function () {
    function OrderFormComponent(dataService) {
        this.dataService = dataService;
    }
    OrderFormComponent.prototype.ngOnInit = function () {
        this.load();
    };
    OrderFormComponent.prototype.load = function () {
        var _this = this;
        this.dataService.getUsers().subscribe(function (data) { return _this.users = data; });
        this.dataService.getCars().subscribe(function (data) { return _this.cars = data; });
    };
    __decorate([
        Input(),
        __metadata("design:type", Order)
    ], OrderFormComponent.prototype, "order", void 0);
    OrderFormComponent = __decorate([
        Component({
            selector: "order-form",
            templateUrl: './order-form.component.html'
        }),
        __metadata("design:paramtypes", [DataService])
    ], OrderFormComponent);
    return OrderFormComponent;
}());
export { OrderFormComponent };
//# sourceMappingURL=order-form.component.js.map