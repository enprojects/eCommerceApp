import { ShopRoutingModule } from './shop-routing.module';
import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { FormsModule } from '@angular/forms';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from '@angular/router';
import { BasketModule } from '../basket/basket.module';



@NgModule({
  declarations: [ShopComponent, ProductItemComponent, ProductDetailsComponent],
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    ShopRoutingModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
