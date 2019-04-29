import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../order';

@Injectable()
export class OrderService {
    
    private orderUrl = "/api/orders";

    constructor(private http: HttpClient) {
    }

    getOrders(filter: any) {
        return this.http.get(this.orderUrl + '?' + this.toQueryString(filter));
    }

    getOrdersWithUniqueStartDate() {
        return this.http.get(this.orderUrl + '/' + encodeURIComponent('UniqueStartDate'));
    }
    getOrdersWithUniqueFinalDate() {
        return this.http.get(this.orderUrl + '/' + encodeURIComponent('UniqueFinalDate'));
    }

    toQueryString(obj: any) {
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined)
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
        }

        return parts.join('&');
    }

    getOrder(id: number) {
        return this.http.get(this.orderUrl + '/' + id);
    }

    createOrder(order: Order) {
        return this.http.post(this.orderUrl, order);
    }

    updateOrder(order: Order) {
        return this.http.put(this.orderUrl + '/' + order.id, order);
    }

    deleteOrder(id: number) {
        return this.http.delete(this.orderUrl + '/' + id);
    }
}