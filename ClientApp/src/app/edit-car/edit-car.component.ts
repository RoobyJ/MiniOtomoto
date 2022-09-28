import { Component, OnInit, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html'
})

export class EditCarComponent implements OnInit{
    @Input() Car: any;
    brand: string = "";
    model: string = "";
    id_offer: number = 9999;
    mileage: string = "";
    prodyear: number = 9999;
    fuel: string = "";
    power: string = "";

    constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {}
  
    ngOnInit(): void {
      this.brand = this.Car.brand,
        this.model = this.Car.model,
        this.id_offer = this.Car.id_offer,
        this.mileage = this.Car.mileage,
        this.prodyear = this.Car.prodyear,
        this.fuel = this.Car.fuel,
        this.power = this.Car.power
    }

    updateCar() {
      var val = {
        brand: this.brand,
        model: this.model,
        id_offer: this.id_offer,
        mileage: this.mileage,
        prodyear: this.prodyear,
        fuel: this.fuel,
        power: this.power
      };
      this.http.put(this.baseUrl + 'car/', val).subscribe(res => {
        alert(res.toString());
      })
    }
}
