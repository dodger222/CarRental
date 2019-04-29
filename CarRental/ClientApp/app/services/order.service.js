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
var OrderService = /** @class */ (function () {
    function OrderService(http) {
        this.http = http;
        this.orderUrl = "/api/orders";
    }
    OrderService.prototype.getOrders = function (filter) {
        return this.http.get(this.orderUrl + '?' + this.toQueryString(filter));
    };
    OrderService.prototype.getOrdersWithUniqueStartDate = function () {
        return this.http.get(this.orderUrl + '/' + encodeURIComponent('UniqueStartDate'));
    };
    OrderService.prototype.getOrdersWithUniqueFinalDate = function () {
        return this.http.get(this.orderUrl + '/' + encodeURIComponent('UniqueFinalDate'));
    };
    OrderService.prototype.toQueryString = function (obj) {
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined)
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
        }
        return parts.join('&');
    };
    OrderService.prototype.getOrder = function (id) {
        return this.http.get(this.orderUrl + '/' + id);
    };
    OrderService.prototype.createOrder = function (order) {
        return this.http.post(this.orderUrl, order);
    };
    OrderService.prototype.updateOrder = function (order) {
        return this.http.put(this.orderUrl + '/' + order.id, order);
    };
    OrderService.prototype.deleteOrder = function (id) {
        return this.http.delete(this.orderUrl + '/' + id);
    };
    OrderService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], OrderService);
    return OrderService;
}());
export { OrderService };
//# sourceMappingURL=order.service.js.map