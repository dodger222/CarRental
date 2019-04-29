import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Car } from '../car';

@Injectable()
export class CarService {
    
    private carUrl = "/api/cars";

    constructor(private http: HttpClient) {
    }

    getCars() {
        return this.http.get(this.carUrl);
    }

    getCarsWithUniqueMake() {
        return this.http.get(this.carUrl + '/' + encodeURIComponent('UniqueMake'));
    }

    getCarsWithUniqueModel() {
        return this.http.get(this.carUrl + '/' + encodeURIComponent('UniqueModel'));
    }

    getCar(id: number) {
        return this.http.get(this.carUrl + '/' + id);
    }

    createCar(car: Car) {
        return this.http.post(this.carUrl, car);
    }

    updateCar(car: Car) {
        return this.http.put(this.carUrl + '/' + car.id, car);
    }

    deleteCar(id: number) {
        return this.http.delete(this.carUrl + '/' + id);
    }
}