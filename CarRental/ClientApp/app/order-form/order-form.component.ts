import { Component, Input, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { CarService } from '../services/car.service';
import { Order } from '../order';
import { User } from '../user';
import { Car } from '../car';

@Component({
    selector: "order-form",
    templateUrl: './order-form.component.html'
})
export class OrderFormComponent implements OnInit {
    @Input() order: Order;

    users: User[];
    cars: Car[];
    constructor(private userService: UserService, private carService: CarService) { }

    ngOnInit() {
        this.load();
    }
    load() {
        this.userService.getUsers().subscribe((data: User[]) => this.users = data);
        this.carService.getCars().subscribe((data: Car[]) => this.cars = data);
    }
}
