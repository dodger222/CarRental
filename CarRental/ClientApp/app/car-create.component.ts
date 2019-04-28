import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from './data.service';
import { Car } from './car';

@Component({
    templateUrl: './car-create.component.html'
})
export class CarCreateComponent {

    car: Car = new Car();    // добавляемый объект
    constructor(private dataService: DataService, private router: Router) { }
    save() {
        this.dataService.createCar(this.car).subscribe(data => this.router.navigateByUrl("/CarList"));
    }
}
