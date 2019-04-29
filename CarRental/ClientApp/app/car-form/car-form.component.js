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
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from '../services/car.service';
import { Car } from '../car';
var CarFormComponent = /** @class */ (function () {
    function CarFormComponent(carService, router, activeRoute) {
        this.carService = carService;
        this.router = router;
        this.car = new Car(); // добавляемый объект
        this.loaded = false;
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }
    CarFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        if (this.id)
            this.carService.getCar(this.id)
                .subscribe(function (data) {
                _this.car = data;
                if (_this.car != null)
                    _this.loaded = true;
            });
    };
    CarFormComponent.prototype.save = function () {
        var _this = this;
        if (this.id) {
            this.carService.updateCar(this.car).subscribe(function (data) { return _this.router.navigateByUrl("/CarList"); });
        }
        else {
            this.carService.createCar(this.car).subscribe(function (data) { return _this.router.navigateByUrl("/CarList"); });
        }
    };
    CarFormComponent = __decorate([
        Component({
            templateUrl: './car-form.component.html'
        }),
        __metadata("design:paramtypes", [CarService, Router, ActivatedRoute])
    ], CarFormComponent);
    return CarFormComponent;
}());
export { CarFormComponent };
//# sourceMappingURL=car-form.component.js.map