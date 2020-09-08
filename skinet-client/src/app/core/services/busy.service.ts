import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {

  busyRequetCount = 0;
  constructor(private spinnerServise: NgxSpinnerService) { }
  busy() {
    this.busyRequetCount++;
    this.spinnerServise.show();

  }

  idle() {

    this.busyRequetCount--;
    if (this.busyRequetCount <= 0) {
      this.spinnerServise.hide();
    }
  }

}
