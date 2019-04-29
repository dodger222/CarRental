import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';
import { UserService } from '../services/user.service';
import { CarService } from '../services/car.service';
import { ViewOrder } from '../viewOrder';
import { Order } from '../order';
import { User } from '../user';
import { Car } from '../car';

@Component({
    templateUrl: './order-list.component.html'
})
export class OrderListComponent implements OnInit {
    
    viewOrders: ViewOrder[];
    users: User[];
    cars: Car[];
    filter: any = {}
    constructor(private orderService: OrderService, private userService: UserService, private carService: CarService) { }

    ngOnInit() {
        this.load();
    }
    load() {
        this.populateViewOrders();
        this.userService.getUsersWithUniqueFirstnames().subscribe((data: User[]) => this.users = data);
        this.carService.getCars().subscribe((data: Car[]) => this.cars = data);
    }
    delete(id: number) {
        this.orderService.deleteOrder(id).subscribe(data => this.load());
    }

    private populateViewOrders() {
        this.orderService.getOrders(this.filter)
            .subscribe((data: ViewOrder[]) => this.viewOrders = data)
    }

    onFilterChange() {
        this.populateViewOrders();
    }
    resetFilter() {
        this.filter = {};
        this.onFilterChange();
    }
}
