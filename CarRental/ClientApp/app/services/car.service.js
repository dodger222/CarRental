var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var CarService = /** @class */ (function () {
    function CarService(http) {
        this.http = http;
        this.carUrl = "/api/cars";
    }
    CarService.prototype.getCars = function () {
        return this.http.get(this.carUrl);
    };
    CarService.prototype.getCar = function (id) {
        return this.http.get(this.carUrl + '/' + id);
    };
    CarService.prototype.createCar = function (car) {
        return this.http.post(this.carUrl, car);
    };
    CarService.prototype.updateCar = function (car) {
        return this.http.put(this.carUrl + '/' + car.id, car);
    };
    CarService.prototype.deleteCar = function (id) {
        return this.http.delete(this.carUrl + '/' + id);
    };
    CarService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], CarService);
    return CarService;
}());
export { CarService };
//# sourceMappingURL=car.service.js.map