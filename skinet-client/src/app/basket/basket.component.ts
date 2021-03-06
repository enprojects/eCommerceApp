import { Observable } from 'rxjs';
import { BasketService } from './basket.service';
import { Component, OnInit } from '@angular/core';
import { IBasket } from '../shared/models/basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  constructor(private basketService: BasketService) { }
  basket$: Observable<IBasket>;
  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }

}
