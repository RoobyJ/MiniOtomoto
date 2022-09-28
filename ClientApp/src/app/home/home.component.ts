import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'home',
  templateUrl: './home.component.html'
})

export class HomeComponent {
  public cars: Car[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Car[]>(baseUrl + 'car').subscribe(result => {
      this.cars = result;
    }, error => console.error(error));
  }
}

interface Car {

  brand: string;
  model: string;
  id_offer: number;
  mileage: string;
}
