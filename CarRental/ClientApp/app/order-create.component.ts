﻿import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from './data.service';
import { Order } from './order';

@Component({
    templateUrl: './order-create.component.html'
})
export class OrderCreateComponent {

    order: Order = new Order();    // добавляемый объект
    constructor(private dataService: DataService, private router: Router) { }
    save() {
        this.dataService.createOrder(this.order).subscribe(data => this.router.navigateByUrl("/OrderList"));
    }
}
