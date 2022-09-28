import { Component, Inject, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html'
})

export class AdminPageComponent implements OnInit{
  public cars: Car[];
  modalTitle: any;
  activateEditCarCom: boolean = false;
  Car: any;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {}
  
  ngOnInit(): void {
    this.refreshCarList();
  }

  refreshCarList() {
    this.http.get<Car[]>(this.baseUrl + 'car').subscribe(result => {
      this.cars = result;
    }, error => console.error(error));
  }
  EditCar(item: any) {
    this.Car = item;
    this.activateEditCarCom = true;
    this.modalTitle = "Update Car";
    this.refreshCarList();
  }

  deleteClick(item: any) {
    if (confirm('Are you sure??')) {
      this.http.delete(this.baseUrl + 'car/' + `${item}`).subscribe(data => {
        alert(data.toString());
      })
    }
    this.refreshCarList();
  }

  closeClick() {
    this.activateEditCarCom = false;
    this.Car = "";
  }

  saveClick() {
    this.activateEditCarCom = false;
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
}
