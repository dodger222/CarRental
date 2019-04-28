import { Component, Input, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Order } from './order';
import { User } from './user';
import { Car } from './car';

@Component({
    selector: "order-form",
    templateUrl: './order-form.component.html'
})
export class OrderFormComponent implements OnInit {
    @Input() order: Order;

    users: User[];
    cars: Car[];
    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.load();
    }
    load() {
        this.dataService.getUsers().subscribe((data: User[]) => this.users = data);
        this.dataService.getCars().subscribe((data: Car[]) => this.cars = data);
    }
}
