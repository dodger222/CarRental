import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { OrderService } from '../services/order.service';
import { Order } from '../order';

@Component({
    templateUrl: './order-create.component.html'
})
export class OrderCreateComponent {

    order: Order = new Order();    // добавляемый объект
    constructor(private orderService: OrderService, private router: Router) { }
    save() {
        this.orderService.createOrder(this.order).subscribe(data => this.router.navigateByUrl("/OrderList"));
    }
}
