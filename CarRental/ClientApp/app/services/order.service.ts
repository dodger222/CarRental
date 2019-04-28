import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../order';

@Injectable()
export class OrderService {
    
    private orderUrl = "/api/orders";

    constructor(private http: HttpClient) {
    }

    getOrders() {
        return this.http.get(this.orderUrl);
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