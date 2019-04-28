import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';
import { Car } from '../car';

@Component({
    templateUrl: './car-list.component.html'
})
export class CarListComponent implements OnInit {

    cars: Car[];
    constructor(private carService: CarService) { }

    ngOnInit() {
        this.load();
    }
    load() {
        this.carService.getCars().subscribe((data: Car[]) => this.cars = data);
    }
    delete(id: number) {
        this.carService.deleteCar(id).subscribe(data => this.load());
    }
}
