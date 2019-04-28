import { Component, Input } from '@angular/core';
import { Car } from '../car';

@Component({
    selector: "car-form",
    templateUrl: './car-form.component.html'
})
export class CarFormComponent {
    @Input() car: Car;
}
