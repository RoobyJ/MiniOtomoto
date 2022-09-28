import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html'
})

export class DetailsComponent {
  public cars: Car[];
  id: number;
  public image_amount: Array<number>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    http.get<Car[]>(baseUrl + 'car/' + `${id}`).subscribe(result => {
      this.cars = result;
      this.image_amount = Array(result[0].image_amount).fill(1).map((x, i) => i);
    }, error => console.error(error));
    
  }
  
}

interface Car {
  brand: string;
  model: string;
  id_offer: number;
  mileage: string;
  prodyear: number;
  fuel: string;
  power: string;
  image_amount: number;
}
