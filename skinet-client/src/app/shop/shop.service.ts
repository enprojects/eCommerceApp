import { map } from 'rxjs/operators';
import { IType } from './../shared/models/productType';

import { IBrand } from './../shared/models/brands';
import { IProduct } from './../shared/models/product';
import { IPagination } from './../shared/models/pagination';


import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../src/environments/environment';
import { ShopParams } from '../shared/models/ShopParams';



@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private httpClient: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();


    Object.keys(shopParams).forEach(key => {
      if (shopParams[key]) {
        params = params.append(key, shopParams[key]);
      }
    });

    return this.httpClient.get<IPagination<IProduct>>(`${environment.url_product}`, { observe: 'response', params })
      .pipe(map(response => response.body));
  }
  getBrands() {
    return this.httpClient.get<IBrand[]>(`${environment.url_product}/brands`)
      .pipe(map(response => [{ name: 'All', id: null }].concat(response)));
  }


  getTypes() {
    return this.httpClient.get<IType[]>(`${environment.url_product}/types`)
      .pipe(map(response => [{ name: 'All', id: null }].concat(response)));
  }

  getProduct(id: number) {
    return this.httpClient.get<IProduct>(`${environment.url_product}/${id}`);
  }

}
