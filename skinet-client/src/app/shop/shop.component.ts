import { map, filter, distinctUntilChanged, debounceTime, tap, switchMap } from 'rxjs/operators';
import { IType } from './../shared/models/productType';
import { IBrand } from './../shared/models/brands';
import { ShopParams } from './../shared/models/ShopParams';

import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { IProduct } from './../shared/models/product';
import { ShopService } from './shop.service';
import { IPagination } from '../shared/models/pagination';
import { Observable, Subject } from 'rxjs';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {


  products: IProduct[];
  brands$: Observable<IBrand[]>;
  productTypes$: Observable<IType[]>;
  searchTerm: '';
  sortIdSelected = '0';
  currentPage: 1;
  totalNumberOfRecord: number;

  shopParams: Partial<ShopParams> = { sortField: 'name', order: 'desc', pageSize: 3, pageIndex: 1 };
  onSearchChange$ = new Subject<string>();


  sortOptions = [
    { id: '0', display: 'Alphabetic', field: 'name', order: 'desc' },
    { id: '1', display: 'Price Low to High', field: 'price', order: 'desc' },
    { id: '2', display: 'Price High to Low', field: 'price', order: 'asc' }
  ];

  constructor(private shopService: ShopService, private cdref: ChangeDetectorRef) { }

  ngOnInit(): void {

    this.getProducts();
    this.getBrands();
    this.getTypes();

    this.onSearchChange$.pipe(
      distinctUntilChanged(),
      debounceTime(500),
      switchMap(term => {
        const sp = this.shopParams as ShopParams;
        sp.search = term;
        return this.shopService.getProducts(sp as ShopParams);

      })
    ).subscribe(response => {
      this.setProductPagePropertirs({ data: response.data, count: response.count });
    });

  }


  getProducts() {
    this.shopService.getProducts(this.shopParams as ShopParams).subscribe(response => {
      this.setProductPagePropertirs({ data: response.data, count: response.count });
    });
  }


  getBrands() {
    this.brands$ = this.shopService.getBrands();
  }

  getTypes() {
    this.productTypes$ = this.shopService.getTypes();
  }

  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageIndex = 1;
    this.getProducts();
  }

  onTypeIdSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageIndex = 1;
    this.getProducts();
  }



  onSortSelected() {

    const sortSelectedObject = this.sortOptions.filter(o => o.id === this.sortIdSelected)[0];
    this.shopParams.sortField = sortSelectedObject.field;
    this.shopParams.order = sortSelectedObject.order;
    this.shopParams.pageIndex = 1;
    this.getProducts();

  }
  onPageChanged(page: number) {

    this.shopParams.pageIndex = page;
    this.getProducts();

  }

  resetDataPage() {
    this.shopParams.search = '';
    this.getProducts();

  }


  private setProductPagePropertirs(obj: { data: IProduct[], count: number }) {

    this.products = obj.data;
    this.totalNumberOfRecord = obj.count;
  }



}



