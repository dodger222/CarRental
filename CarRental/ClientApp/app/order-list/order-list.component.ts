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
    orders: Order[];
    users: User[];
    cars: Car[];
    query: any = {}
    constructor(private orderService: OrderService, private userService: UserService, private carService: CarService) { }

    ngOnInit() {
        this.load();
    }
    load() {
        this.populateViewOrders();
        this.userService.getUsersWithUniqueFirstnames().subscribe((data: User[]) => this.users = data);
        this.carService.getCarsWithUniqueMake().subscribe((data: Car[]) => this.cars = data);
        this.carService.getCarsWithUniqueModel().subscribe((data: Car[]) => this.cars = data);
        this.orderService.getOrdersWithUniqueStartDate().subscribe((data: Order[]) => this.orders = data);
        this.orderService.getOrdersWithUniqueFinalDate().subscribe((data: Order[]) => this.orders = data);
    }
    delete(id: number) {
        this.orderService.deleteOrder(id).subscribe(data => this.load());
    }

    private populateViewOrders() {
        this.orderService.getOrders(this.query)
            .subscribe((data: ViewOrder[]) => this.viewOrders = data)
    }

    onFilterChange() {
        this.populateViewOrders();
    }
    resetFilter() {
        this.query = {};
        this.onFilterChange();
    }

    sortBy(columnName: any) {
        if (this.query.sortBy === columnName) {
            this.query.isSortAscending = !this.query.isSortAscending;
        }
        else {
            this.query.sortBy = columnName;
            this.query.isSortAscending = true;
        }
        this.populateViewOrders();
    }
}
