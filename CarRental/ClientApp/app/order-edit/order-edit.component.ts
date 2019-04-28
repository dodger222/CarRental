import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { OrderService } from '../services/order.service';
import { Order } from '../order';

@Component({
    templateUrl: './order-edit.component.html'
})
export class OrderEditComponent implements OnInit {

    id: number;
    order: Order;    // изменяемый объект
    loaded: boolean = false;

    constructor(private orderService: OrderService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.orderService.getOrder(this.id)
                .subscribe((data: Order) => {
                    this.order = data;
                    if (this.order != null) this.loaded = true;
                });
    }

    save() {
        this.orderService.updateOrder(this.order).subscribe(data => this.router.navigateByUrl("/OrderList"));
    }
}