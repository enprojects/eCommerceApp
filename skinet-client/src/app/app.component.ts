import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, ɵConsole } from '@angular/core';
import { BasketService } from './basket/basket.service';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'skinet';




  constructor(private spinner: NgxSpinnerService, private basketService: BasketService) {

  }

  ngOnInit(): void {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(() => {

        console.log('Initialaize basket');
      });
    }
  }

}








