import { v4 as uuid } from 'uuid';


export interface IBasket {
  id: string;
  items: IBasketItem[];
}

export interface IBasketItem {
  id: number;
  productName: string;
  price: number;
  quantity: number;
  pictureUrl?: any;
  brand?: any;
  type?: any;
}

export class Basket implements IBasket {

  id = uuid();
  items: IBasketItem[] = [];
}

export interface IBasketTotals {
  shipping: number;
  subtotal: number;
  total: number;
}

