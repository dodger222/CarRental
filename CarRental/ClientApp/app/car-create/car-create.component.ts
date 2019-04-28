import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CarService } from '../services/car.service';
import { Car } from '../car';

@Component({
    templateUrl: './car-create.component.html'
})
export class CarCreateComponent {
    isShowErrorMessage: boolean = false;
    errorMessage = 'Wrong lines: \n';

    car: Car = new Car();    // добавляемый объект
    constructor(private carService: CarService, private router: Router) { }
    save() {
        if (!this.car.model) {
            this.isShowErrorMessage = true;
            this.errorMessage += 'model\n'
        } else {
            this.carService.createCar(this.car).subscribe(data => this.router.navigateByUrl("/CarList"));
        }
    }
}
