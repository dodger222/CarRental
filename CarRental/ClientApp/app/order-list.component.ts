import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { ViewOrder } from './viewOrder';
import { Order } from './order';
import { User } from './user';

@Component({
    templateUrl: './order-list.component.html'
})
export class OrderListComponent implements OnInit {
    
    viewOrders: ViewOrder[];
    allViewOrder: ViewOrder[];
    users: User[];
    filter: any = {}
    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.load();
    }
    load() {
        this.dataService.getOrders().subscribe((data: ViewOrder[]) => this.viewOrders = this.allViewOrder = data);
        this.dataService.getUsers().subscribe((data: User[]) => this.users = data);
    }
    delete(id: number) {
        this.dataService.deleteOrder(id).subscribe(data => this.load());
    }
    onFilterChange() {
        var viewOrders = this.allViewOrder;

        if (this.filter.userId)
            viewOrders = viewOrders.filter(v => v.userId == this.filter.userId)

        if (this.filter.autoId)
            viewOrders = viewOrders.filter(v => v.carId == this.filter.autoId)

        this.viewOrders = viewOrders;
    }
    resetFilter() {
        this.filter = {};
        this.onFilterChange();
    }
}
