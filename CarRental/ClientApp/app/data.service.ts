import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';
import { Car } from './car';
import { Order } from './order';

@Injectable()
export class DataService {

    private userUrl = "/api/users";
    private carUrl = "/api/cars";
    private orderUrl = "/api/orders";

    constructor(private http: HttpClient) {
    }

    // методы для работы с пользователем
    getUsers() {
        return this.http.get(this.userUrl);
    }

    getUser(id: number) {
        return this.http.get(this.userUrl + '/' + id);
    }

    createUser(user: User) {
        return this.http.post(this.userUrl, user);
    }

    updateUser(user: User) {
        return this.http.put(this.userUrl + '/' + user.id, user);
    }

    deleteUser(id: number) {
        return this.http.delete(this.userUrl + '/' + id);
    }

    // методы для работы с автомобилями
    getCars() {
        return this.http.get(this.carUrl);
    }

    getCar(id: number) {
        return this.http.get(this.carUrl + '/' + id);
    }

    createCar(car: Car) {
        return this.http.post(this.carUrl, car);
    }

    updateCar(car: Car) {
        return this.http.put(this.carUrl + '/' + car.id, car);
    }

    deleteCar(id: number) {
        return this.http.delete(this.carUrl + '/' + id);
    }

    // методы для работы с заказами
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