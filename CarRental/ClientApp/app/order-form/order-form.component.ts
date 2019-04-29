import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { OrderService } from '../services/order.service';
import { UserService } from '../services/user.service';
import { CarService } from '../services/car.service';
import { Order } from '../order';
import { User } from '../user';
import { Car } from '../car';

@Component({
    templateUrl: './order-form.component.html'
})
export class OrderFormComponent implements OnInit {

    users: User[];
    cars: Car[];

    id: number;
    order: Order = new Order();    // изменяемый объект
    loaded: boolean = false;

    constructor(
        private userService: UserService,
        private carService: CarService,
        private orderService: OrderService,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.orderService.getOrder(this.id)
                .subscribe((data: Order) => {
                    this.order = data;
                    if (this.order != null) this.loaded = true;
                });

        this.load();
    }

    load() {
        this.userService.getUsers().subscribe((data: User[]) => this.users = data);
        this.carService.getCars().subscribe((data: Car[]) => this.cars = data);
    }

    save() {
        if (this.id) {
            this.orderService.updateOrder(this.order).subscribe(data => this.router.navigateByUrl("/OrderList"));
        }
        else {
            this.orderService.createOrder(this.order).subscribe(data => this.router.navigateByUrl("/OrderList"));
        }
    }
}