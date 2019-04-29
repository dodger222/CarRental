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
    allViewOrder: ViewOrder[];
    users: User[];
    cars: Car[];
    filter: any = {}
    constructor(private orderService: OrderService, private userService: UserService, private carService: CarService) { }

    ngOnInit() {
        this.load();
    }
    load() {
        this.orderService.getOrders().subscribe((data: ViewOrder[]) => this.viewOrders = this.allViewOrder = data);
        this.userService.getUsers().subscribe((data: User[]) => this.users = data);
        this.carService.getCars().subscribe((data: Car[]) => this.cars = data);
    }
    delete(id: number) {
        this.orderService.deleteOrder(id).subscribe(data => this.load());
    }
    onFilterChange() {
        var viewOrders = this.allViewOrder;

        if (this.filter.userId)
            viewOrders = viewOrders.filter(v => v.userId == this.filter.userId)

        if (this.filter.carId)
            viewOrders = viewOrders.filter(v => v.carId == this.filter.carId)

        this.viewOrders = viewOrders;
    }
    resetFilter() {
        this.filter = {};
        this.onFilterChange();
    }
}
