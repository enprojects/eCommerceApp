import { IBasketTotals } from './../shared/models/basket';
import { IProduct } from './../shared/models/product';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { IBasket, IBasketItem, Basket } from '../shared/models/basket';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUrl = environment.base_url;
  private basketSource = new BehaviorSubject<IBasket>(null);
  private basketTotalsource = new BehaviorSubject<IBasketTotals>(null);

  basket$ = this.basketSource.asObservable();
  basketTotal$ = this.basketTotalsource.asObservable();

  constructor(private httpClient: HttpClient) { }

  getBasket(id: string) {
    return this.httpClient.get(`${this.baseUrl + 'Basket/'}${id}`)
      .pipe(map((basket: IBasket) => {
        this.basketSource.next(basket);
        this.calculateTotalas();
      }));
  }
  setBasket(basket: IBasket) {
    this.httpClient.post(this.baseUrl + 'Basket', basket).subscribe((response: IBasket) => {
      this.calculateTotalas();
      this.basketSource.next(basket);
    });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: IProduct, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdate(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }
  addOrUpdate(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {


    const basketItem = items.find(p => p.id === itemToAdd.id);
    if (!!basketItem) {
      basketItem.quantity += quantity;
    } else {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    }
    return items;

  }

  createBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private calculateTotalas() {
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket.items.reduce((acc, product) => {
      return (product.price * product.quantity) + acc;
    }, 0);
    const total = subtotal + shipping;

    this.basketTotalsource.next({
      shipping,
      total,
      subtotal
    });
  }


  private mapProductItemToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity,
      brand: item.productBrand,
      type: item.productType
    };
  }
}
