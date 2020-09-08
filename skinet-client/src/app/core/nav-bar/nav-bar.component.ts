import { BasketService } from './../../basket/basket.service';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { pipe, Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { IBasket } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  product: any[];
  basket$: Observable<IBasket>;

  constructor(private basketService: BasketService) {

  }

  ngOnInit(): void {

    this.basket$ = this.basketService.basket$;
  }

}
