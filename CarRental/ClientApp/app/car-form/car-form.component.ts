import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from '../services/car.service';
import { Car } from '../car';

@Component({
    templateUrl: './car-form.component.html'
})
export class CarFormComponent implements OnInit {

    id: number;
    car: Car = new Car();    // добавляемый объект
    loaded: boolean = false;

    constructor(private carService: CarService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.carService.getCar(this.id)
                .subscribe((data: Car) => {
                    this.car = data;
                    if (this.car != null) this.loaded = true;
                });
    }

    save() {
        if (this.id) {
            this.carService.updateCar(this.car).subscribe(data => this.router.navigateByUrl("/CarList"));
        }
        else {
            this.carService.createCar(this.car).subscribe(data => this.router.navigateByUrl("/CarList"));
        }
    }
}
