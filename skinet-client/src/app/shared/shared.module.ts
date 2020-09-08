import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagerComponent } from './components/pager/pager.component';
import { FormsModule } from '@angular/forms';
import { OrderTotalsComponent } from './order-totals/order-totals.component';



@NgModule({
  declarations: [PagerComponent, PagerComponent, OrderTotalsComponent],
  imports: [
    CommonModule,
    FormsModule,
    PaginationModule.forRoot()
  ],
  exports: [PaginationModule, PagerComponent, OrderTotalsComponent]
})
export class SharedModule { }


