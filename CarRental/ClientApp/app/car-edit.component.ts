import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { Car } from './car';

@Component({
    templateUrl: './car-edit.component.html'
})
export class CarEditComponent implements OnInit {

    id: number;
    car: Car;    // изменяемый объект
    loaded: boolean = false;

    constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getCar(this.id)
                .subscribe((data: Car) => {
                    this.car = data;
                    if (this.car != null) this.loaded = true;
                });
    }

    save() {
        this.dataService.updateCar(this.car).subscribe(data => this.router.navigateByUrl("/"));
    }
}